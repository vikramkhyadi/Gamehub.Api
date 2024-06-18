using Gamehub.Domain.Models;
using Gamehub.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Gamehub.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly ApplicationDBContext _dbContext;
    public GameRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext ??
            throw new ArgumentNullException(nameof(_dbContext));
    }

    public async Task<GameEntity> AddNewGameAsync(GameEntity gameEntity)
    {
        _dbContext.Games.Add(gameEntity);
        await _dbContext.SaveChangesAsync();
        return gameEntity;
    }

    public Task<List<GameEntity>> GetAllGamesAsync()
    {
        return _dbContext.Games.ToListAsync();
    }

    public async Task<GameEntity> GetGameByIdAsync(int id)
    {
        return await _dbContext.Games.FirstOrDefaultAsync(v => v.ID == id);
    }

    public async Task<GameEntity> UpdateGameAsync(GameEntity gameEntity)
    {
        _dbContext.Entry(gameEntity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return gameEntity;
    }

    public async Task<bool> DeleteGameByIdAsync(int id)
    {
        bool result = false;
        var gameToBeDeleted = await _dbContext.Games.FirstOrDefaultAsync(v => v.ID == id);
        if (gameToBeDeleted != null)
        {
            _dbContext.Remove(gameToBeDeleted);
            _dbContext.SaveChanges();
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }

    public async Task<List<GameEntity>> GetGamesOnPageNumber(int pageNumber, int pageSize)
    {
        var skipCount = (pageNumber - 1) * pageSize;
        var result =await _dbContext.Games.Skip(skipCount).Take(pageSize).ToListAsync();
        return result;
    }
}
