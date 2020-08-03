using ChessGameApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ChessGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveController : ControllerBase
    {
        private readonly IMoveRepository _moveRepo;
        private readonly IGameRepository _gameRepo;

        public MoveController(IMoveRepository moveRepo,
                              IGameRepository gameRepo)
        {
            _moveRepo = moveRepo;
            _gameRepo = gameRepo;
        }

        [HttpPost("PossibleMoves")]
        public IActionResult PossibleMoves()
        {
            int pieceId = 1;
            var resp = _moveRepo.PossibleMove(_gameRepo.getGame(), pieceId);
            return Ok(resp);

        }

        [HttpPost("MovePiece")]
        public IActionResult MovePiece()
        {
            int pieceId = 0;
            var resp = _moveRepo.MovePiece(_gameRepo.getGame(), pieceId,0,2);
            return Ok(resp);

        }

    }
}
