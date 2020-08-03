using ChessGameApi.Helpers;
using ChessGameApi.Models;
using System.Collections.Generic;

namespace ChessGameAPI.Models.Pieces
{
    public class Knight : Piece
    {
        public Knight(colorPlayer color, int x, int y) : base(color, x, y)
        {
            this.PieceType = PiecesTypeEnum.Knight;
        }

        /// <summary>
        /// Get all possible moves.
        /// </summary>
        public override void GetAllMoves(Game game)
        {
            CheckPossibleMove();

            int[] xOptions = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] yOptions = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int i = 0; i < 8; i++)
            {
                if (X + xOptions[i] >= 0 && X + xOptions[i] <= 7
                    && Y + yOptions[i] >= 0 && Y + yOptions[i] <= 7)
                {
                    game.tryMove(Id, X + xOptions[i], Y + yOptions[i]);
                }
            }
        }
    }
}
