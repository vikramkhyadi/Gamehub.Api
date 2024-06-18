using FluentAssertions;
using Gamehub.Api.Controllers.V1;
using Gamehub.Application;
using Gamehub.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
namespace Gameshub.Api.Tests.Controller;

public abstract class GamesControllerTests
{
    private readonly IGamesService _gamesService = Substitute.For<IGamesService>();
    private readonly GamesController _sut;
    public GamesControllerTests()
    {
        _sut = new GamesController(_gamesService);
    }

    public sealed class When_Calling_GetGameById : GamesControllerTests
    {
        [Fact]
        public async Task When_Called_GetGameById_It_Should_Return_Ok_with_result()
        {
            // Arrange
            GameEntity gameEntity = new GameEntity
            {
                Description = "Test",
                Genre = "Test",
                ID = 1,
                Price = 10,
                ReleaseDate = DateTime.Now,
                StockQuantity = 100,
                Title = "Test",
            };
            int gameId = 1;

            _gamesService.GetGameByIdAsync(Arg.Any<int>(), CancellationToken.None).ReturnsForAnyArgs(gameEntity);

            var result = await _sut.GetGameById(gameId, CancellationToken.None);

            await _gamesService.Received(1).GetGameByIdAsync(gameId, CancellationToken.None);
            result.Should().BeOfType<OkObjectResult>();    // Asserting using FluentAssertation
            ((OkObjectResult)result).StatusCode.Should().Be(200);
            ((OkObjectResult)result).Value.Should().BeOfType<GameEntity>();
        }


        [Fact]
        public async Task When_Called_GetGameById_It_Should_Return_ReturnsStatusCode400()
        {
            // Arrange
            int gameId = 0;

            var result = await _sut.GetGameById(gameId, CancellationToken.None);
            result.Should().BeOfType<BadRequestResult>();    // Asserting using FluentAssertation
            ((BadRequestResult)result).StatusCode.Should().Be(400);
        }
    }

    public sealed class When_Calling_GetAllGames : GamesControllerTests
    {


        [Fact]
        public async Task It_Should_Return_Ok()
        {
            //Arrange
            List<GameEntity> lstGame = new List<GameEntity>();
            lstGame.Add(new GameEntity
            {
                Description = "Test",
                Genre = "Test",
                ID = 1,
                Price = 10,
                ReleaseDate = DateTime.Now,
                StockQuantity = 100,
                Title = "Test",
            });

            _gamesService.GetAllGamesAsync(CancellationToken.None).ReturnsForAnyArgs(lstGame);

            var result = await _sut.GetAllGames(CancellationToken.None);
            await _gamesService.Received(1).GetAllGamesAsync(CancellationToken.None);
            result.Should().BeOfType<OkObjectResult>();    // Asserting using FluentAssertation
            ((OkObjectResult)result).StatusCode.Should().Be(200);
        }

    }
}
