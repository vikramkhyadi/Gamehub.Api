using Gamehub.Application;
using Gamehub.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gamehub.Api.Controllers.V1;

/// <summary>
/// Endpoints for fictional games 
/// </summary>

/// <param name="gamesService"></param>
//[Route("v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGamesService _gamesService;
    public GamesController(IGamesService gamesService)
    {
        _gamesService = gamesService;
    }

    /// <summary>
    ///  Gets all fictional games
    /// </summary>
    /// <returns></returns>
    // GET: api/<GamesController>
    [HttpGet(Constants.RouteNames.GetAllGames)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(OperationId = Constants.RouteNames.GetAllGames, Summary = "This operation gets all the available games.")]
    public async Task<IActionResult> GetAllGames(CancellationToken cancellationToken)
    {
        return Ok(await _gamesService.GetAllGamesAsync(cancellationToken));
    }


    /// <summary>
    ///  Gets fictional games by page index
    /// </summary>
    /// <returns></returns>
    // GET: api/<GamesController>
    [HttpGet(Constants.RouteNames.GetGamesByPageIndex)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(OperationId = Constants.RouteNames.GetGamesByPageIndex, Summary = "This operation gets the games by page number.")]
    public async Task<IActionResult> GetGamesByPageNumber(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 5)
    {
        return Ok(await _gamesService.GetGamesOnPageNumber(cancellationToken, pageNumber, pageSize));
    }


    /// <summary>
    /// Gets fictional game by its Id
    /// </summary>
    /// <param name="gameId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    // GET api/<GamesController>/title
    [HttpGet(Constants.RouteNames.GetGameById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(OperationId = Constants.RouteNames.GetGameById, Summary = "This operation gets the game details by game Id.")]

    public async Task<IActionResult> GetGameById(int gameId, CancellationToken cancellationToken)
    {
        if (gameId <= 0)
            return BadRequest();
        return Ok(await _gamesService.GetGameByIdAsync(gameId, cancellationToken));
    }

    /// <summary>
    /// Add new fictional game
    /// </summary>
    /// <param name="gameEntity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    // POST api/<GamesController>
    [HttpPost(Constants.RouteNames.AddNewGame)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(OperationId = Constants.RouteNames.AddNewGame, Summary = "This operation adds new game.")]

    public async Task<IActionResult> AddNewGame([FromBody] GameEntity gameEntity, CancellationToken cancellationToken)
    {
        var inserted = await _gamesService.AddNewGameAsync(gameEntity, cancellationToken);
        return Ok("Added Successfully");
    }

    /// <summary>
    /// Update fictional game by its Id
    /// </summary>
    /// <param name="gameEntity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    // PUT api/<GamesController>/gemeEntity
    [HttpPut(Constants.RouteNames.Updategame)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(OperationId = Constants.RouteNames.AddNewGame, Summary = "This operation update the existing game details.")]

    public async Task<IActionResult> UpdateGame([FromBody] GameEntity gameEntity, CancellationToken cancellationToken)
    {
        await _gamesService.UpdateGameAsync(gameEntity, cancellationToken);
        return Ok("Updated Successfully");
    }


    /// <summary>
    /// Delete fictional game by its Id
    /// </summary>
    /// <param name="gameId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    // DELETE api/<GamesController>/title
    [HttpDelete(Constants.RouteNames.DeleteGameById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(OperationId = Constants.RouteNames.DeleteGameById, Summary = "This operation deletes the game by its Id.")]

    public async Task<IActionResult> DeleteGameById(int gameId, CancellationToken cancellationToken)
    {
        if (gameId <= 0)
            return BadRequest();
        var result = await _gamesService.DeleteGameByIdAsync(gameId, cancellationToken);
        return Ok("Deleted Successfully");
    }

}
