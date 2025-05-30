﻿using FIAPCloudGames.Api.Authorization;
using FIAPCloudGames.Application.DTOs.Promotions;
using FIAPCloudGames.Application.UseCases.Promotions;
using FluentValidation;

namespace FIAPCloudGames.Api.Endpoints.Promotions;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("promotions/{id:guid}",
            async (Guid id, UpdatePromotionRequest request, UpdatePromotionUseCase useCase, IValidator<UpdatePromotionRequest> validator, CancellationToken cancellationToken) =>
            {
                validator.ValidateAndThrow(request);

                await useCase.HandleAsync(id, request, cancellationToken);

                return Results.NoContent();
            })
            .WithTags(Tags.Promotions)
            .RequireAuthorization(AuthorizationPolicies.AdministratorOnly);
    }
}