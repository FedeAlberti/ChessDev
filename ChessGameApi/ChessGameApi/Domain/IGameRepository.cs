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
        Game GetGame();
        Piece GetPieceByXY(int x, int y);

    }
}