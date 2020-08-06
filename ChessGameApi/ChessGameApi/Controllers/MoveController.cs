using AutoMapper;
using ChessGameApi.Domain;
using ChessGameApi.DTOs;
using ChessGameApi.Models;
using ChessGameAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ChessGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveController : ControllerBase
    {
        private readonly IMoveRepository _moveRepo;
        private readonly IGameRepository _gameRepo;
        private readonly IMapper _mapper;

        public MoveController(IMoveRepository moveRepo,
                              IGameRepository gameRepo,
                              IMapper mapper)
        {
            _moveRepo = moveRepo;
            _gameRepo = gameRepo;
            _mapper = mapper;
        }

        [HttpPost("PossibleMoves")]
        public IActionResult PossibleMoves(PieceDto pic)
        {
            var resp = _moveRepo.PossibleMove(_gameRepo.GetGame(), pic.id);

            return Ok(resp);

        }

        [HttpPost("MovePiece")]
        public IActionResult MovePiece(PieceToMoveDto picToMove)
        {
            var resp = _moveRepo.MovePiece(_gameRepo.GetGame(), picToMove.piece.id, picToMove.X,picToMove.Y);
            var gameDto = _mapper.Map<GameDto>(resp);
            return Ok(gameDto);

        }

        [HttpGet("test")]
        public IActionResult test()
        {

            return Ok("hola");

        }

    }
}
