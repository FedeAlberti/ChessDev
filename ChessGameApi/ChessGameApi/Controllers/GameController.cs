using ChessGameApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ChessGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepo;

        public GameController(IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }

        [HttpPost("NewGame")]
        public IActionResult NewGame()
        {

            var game = _gameRepo.NewGame();
            return Ok(game);

        }

    }
}
