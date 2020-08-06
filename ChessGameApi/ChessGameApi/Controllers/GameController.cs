using AutoMapper;
using ChessGameApi.Domain;
using ChessGameAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ChessGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepo;
        private readonly IMapper _mapper;

        public GameController(IGameRepository gameRepo,
                              IMapper mapper)
        {
            _gameRepo = gameRepo;
            _mapper = mapper;
        }

        [HttpPost("NewGame")]
        public IActionResult NewGame()
        {
            var gameDto = _mapper.Map<GameDto>(_gameRepo.NewGame());
            return Ok(gameDto);
        }

    }
}
