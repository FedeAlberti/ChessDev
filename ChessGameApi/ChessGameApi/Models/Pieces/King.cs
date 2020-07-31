using ChessGameApi.Helpers;
using ChessGameApi.Models;
using System.Collections.Generic;

namespace ChessGameAPI.Models.Pieces
{
    public class King : Piece
    {
        public King(Game game, colorPlayer color, int x, int y) : base(game, color, x, y)
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
            possibleMoves.Clear();
            bool canMoveRight = X > 0;
            bool canMoveLeft = X < 7;
            bool canMoveUp = Y < 7;
            bool canMoveDown = Y > 0;

            if (canMoveRight)
            {
                Game.tryMove(X, Y, X + 1, Y);
                if (canMoveUp)
                {
                    Game.tryMove(X, Y, X + 1, Y + 1);
                }
                if (canMoveDown)
                {
                    Game.tryMove(X, Y, X + 1, Y - 1);
                }
            }
            if (canMoveLeft)
            {
                Game.tryMove(X, Y, X - 1, Y);
                if (canMoveUp)
                {
                    Game.tryMove(X, Y, X - 1, Y + 1);
                }
                if (canMoveDown)
                {
                    Game.tryMove(X, Y, X - 1, Y - 1);
                }
            }
            if (canMoveUp)
            {
                Game.tryMove(X, Y, X, Y + 1);
            }
            if (canMoveDown)
            {
                Game.tryMove(X, Y, X, Y - 1);
            }

        }
    }
}
