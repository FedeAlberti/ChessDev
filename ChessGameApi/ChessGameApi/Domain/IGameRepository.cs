using ChessGameApi.Models;
using System.Collections.Generic;

namespace ChessGameApi.Domain
{
    /// <summary>
    /// Game Repository Interface
    /// </summary>
    public interface IGameRepository
    {
        Game NewGame();
        Game getGame();
        Piece GetPieceByXY(int x, int y);
        IDictionary<(int, int), Piece> GetPiece();

    }
}