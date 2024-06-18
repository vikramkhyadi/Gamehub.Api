using Gamehub.Domain.Models;
using Gamehub.Infrastructure.Repositories;

namespace Gamehub.Application;

public class GamesService : IGamesService
{
    private readonly IGameRepository _gameRepository;
    public GamesService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    public Task<List<GameEntity>> GetAllGamesAsync(CancellationToken cancellationToken)
    {
        return _gameRepository.GetAllGamesAsync();
    }

    public Task<GameEntity> AddNewGameAsync(GameEntity gameEntity, CancellationToken cancellationToken)
    {
        return _gameRepository.AddNewGameAsync(gameEntity);
    }

    public Task<GameEntity> GetGameByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _gameRepository.GetGameByIdAsync(id);
    }

    public Task<GameEntity> UpdateGameAsync(GameEntity gameEntity, CancellationToken cancellationToken)
    {
        return _gameRepository.UpdateGameAsync(gameEntity);
    }

    public Task<bool> DeleteGameByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _gameRepository.DeleteGameByIdAsync(id);
    }


    public Task<List<GameEntity>> GetGamesOnPageNumber(CancellationToken cancellationToken, int pageNumber, int pageSize)
    {
        return _gameRepository.GetGamesOnPageNumber(pageNumber, pageSize);
    }
}
