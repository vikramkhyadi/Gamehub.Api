using Gamehub.Domain.Models;

namespace Gamehub.Infrastructure.Repositories;

public interface IGameRepository
{

    Task<GameEntity> AddNewGameAsync(GameEntity gameEntity);
    Task<List<GameEntity>> GetAllGamesAsync();
    Task<GameEntity> GetGameByIdAsync(int id);
    Task<GameEntity> UpdateGameAsync(GameEntity gameEntity);
    Task<bool> DeleteGameByIdAsync(int id);
    Task<List<GameEntity>> GetGamesOnPageNumber(int pageNumber, int pageSize);

}
