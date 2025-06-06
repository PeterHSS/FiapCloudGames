﻿using FIAPCloudGames.Application.DTOs.Games;
using FIAPCloudGames.Domain.Abstractions.Repositories;
using FIAPCloudGames.Domain.Entities;
using Serilog;

namespace FIAPCloudGames.Application.UseCases.Games;

public sealed class GetGameByIdUseCase
{
    private readonly IGameRepository _gameRepository;

    public GetGameByIdUseCase(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<GameResponse> HandleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Log.Information("Retrieving game with ID {GameId}", id);

        Game? game = await _gameRepository.GetByIdAsync(id, cancellationToken);

        if (game is null)
        {
            Log.Warning("Game with ID {GameId} not found", id);

            throw new KeyNotFoundException($"Game with ID {id} not found.");
        }

        GameResponse gameResponse = GameResponse.Create(game);

        Log.Information("Game with ID {GameId} retrieved successfully", id);

        return gameResponse;
    }
}

