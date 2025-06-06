﻿using System.Text;
using FIAPCloudGames.Api.Authorization;
using FIAPCloudGames.Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FIAPCloudGames.Api.Extensions;

public static class JwtExtensions
{
    public static IServiceCollection AddJwtAuthenticationAndAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!)),
                    ClockSkew = TimeSpan.Zero
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(AuthorizationPolicies.AdministratorOnly, policy => policy.RequireRole(RoleEnum.Administrator.ToString()));
        });

        return services;
    }

    public static WebApplication UseJwtAuthenticationAndAuthorization(this WebApplication app)
    {
        app.UseAuthentication();

        app.UseAuthorization();

        return app;
    }
}
