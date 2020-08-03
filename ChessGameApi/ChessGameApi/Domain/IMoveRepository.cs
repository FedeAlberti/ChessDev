using ChessGameApi.Models;
using System.Collections.Generic;

namespace ChessGameApi.Domain
{
    public interface IMoveRepository
    {
        public Game MovePiece(Game game, int pieceId, int endX, int endY);

        public IDictionary<(int, int), Piece> PossibleMove(Game game, int pieceID);
    }
}
