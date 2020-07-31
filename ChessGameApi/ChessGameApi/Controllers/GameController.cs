using ChessGameApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChessGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpPost]
        public IActionResult NewGame()
        {

            Game newGame = new Game();
            newGame.Initialize();

            return Ok(newGame);
        }


    }
}
