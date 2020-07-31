using ChessGameApi.Helpers;
using ChessGameApi.Models;
using System.Collections.Generic;

namespace ChessGameAPI.Models.Pieces
{
    public class Pawn : Piece
    {
        public bool IsCapturing;

        public Pawn(Game game, colorPlayer color, int x, int y) : base(game, color, x, y)
        {
        }

        /// <summary>
        /// Get all possible moves.
        /// </summary>
        public override void GetAllMoves()
        {
            if (possibleMoves == null)
            {
                possibleMoves = new Dictionary<(int, int), Piece>();
            }
            else
            {
                possibleMoves.Clear();
            }
            // white side pawn
            if (Color == colorPlayer.White)
            {
                if (Y == 1)
                {
                    Game.tryMove(X, Y, X, Y + 2);
                }
                if (Y < 7)
                {
                    Game.tryMove(X, Y, X, Y + 1);
                    //diagonal eat
                    if (X < 7)
                    {
                        Game.tryMove(X, Y, X + 1, Y + 1);
                    }
                    if (X > 0)
                    {
                        Game.tryMove(X, Y, X - 1, Y + 1);
                    }
                }
            }
            else
            { // black side
                if (Y == 6)
                {
                    Game.tryMove(X, Y, X, Y - 2);
                }
                if (Y > 0)
                {
                    Game.tryMove(X, Y, X, Y - 1);
                    //diagonal eat
                    if (X < 7)
                    {
                        Game.tryMove(X, Y, X + 1, Y - 1);
                    }
                    if (X > 0)
                    {
                        Game.tryMove(X, Y, X - 1, Y - 1);
                    }
                }
            }
        }
    }
}
