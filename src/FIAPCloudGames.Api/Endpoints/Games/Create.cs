﻿using FIAPCloudGames.Api.Authorization;
using FIAPCloudGames.Application.DTOs.Games;
using FIAPCloudGames.Application.UseCases.Games;
using FluentValidation;

namespace FIAPCloudGames.Api.Endpoints.Games;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("games",
            async (CreateGameRequest request, CreateGameUseCase useCase, IValidator<CreateGameRequest> validator, CancellationToken cancellationToken) =>
            {
                validator.ValidateAndThrow(request);

                await useCase.HandleAsync(request, cancellationToken);

                return Results.Created();
            })
            .WithTags(Tags.Games)
            .RequireAuthorization(AuthorizationPolicies.AdministratorOnly);
    }
}
