using ChessGameAPI.Dtos;
using System.Collections.Generic;

namespace ChessGameApi.DTOs
{
    public class PossibleMoveDto
    {
        public List<PieceToMoveDto> moveDto { get; set; }

    }

    public class PieceToMoveDto
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PieceDto piece { get; set; }
    }
}
