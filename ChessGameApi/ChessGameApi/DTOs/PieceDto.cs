using ChessGameApi.Helpers;
using System.Collections.Generic;

namespace ChessGameAPI.Dtos
{
    /// <summary>
    /// dto for piece info
    /// </summary>
    public class PieceDto
    {
        public int id { get; set; }

        public int x { get; set; }

        public int y { get; set; }

        public string color { get; set; }

        public string pieceType { get; set; }

        public IDictionary<string, PieceDto> possibleMoves { get; set; }

    }
}