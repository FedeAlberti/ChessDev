using ChessGameApi.Models;
using System.Collections.Generic;

namespace ChessGameApi.Domain
{
    public interface IMoveRepository
    {
        public Game MovePiece(Game game, int pieceId, int endX, int endY);

        public List<PieceToMove> PossibleMove(Game game, int pieceID);
    }
}
