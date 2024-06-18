using Gamehub.Domain.Models;

namespace Gamehub.Application;

public interface IGamesService
{
    Task<GameEntity> AddNewGameAsync(GameEntity gameEntity, CancellationToken cancellationToken);
    Task<List<GameEntity>> GetAllGamesAsync(CancellationToken cancellationToken);
    Task<GameEntity> GetGameByIdAsync(int id, CancellationToken cancellationToken);
    Task<GameEntity> UpdateGameAsync(GameEntity gameEntity, CancellationToken cancellationToken);
    Task<bool> DeleteGameByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<GameEntity>> GetGamesOnPageNumber(CancellationToken cancellationToken, int pageNumber, int pageSize);
}
