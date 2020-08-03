using ChessGameApi.Helpers;
using ChessGameApi.Models;
using System.Collections.Generic;

namespace ChessGameAPI.Models.Pieces
{
    public class Queen : Piece
    {
        public Queen(colorPlayer color, int x, int y) : base(color, x, y)
        {
            this.PieceType = PiecesTypeEnum.Queen;
        }

        /// <summary>
        /// Get all possible moves.
        /// </summary>
        public override void GetAllMoves(Game game)
        {
            CheckPossibleMove();

            UpRightMove(game);

            UpLeftMove(game);

            DownRightMove(game);

            DownLeftMove(game);

            RightMove(game);

            LeftMove(game);

            UpMove(game);

            DownMove(game);

        }
    }
}
