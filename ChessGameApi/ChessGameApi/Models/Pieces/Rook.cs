using ChessGameApi.Helpers;
using ChessGameApi.Models;
using System.Collections.Generic;

namespace ChessGameAPI.Models.Pieces
{
    public class Rook : Piece
    {

        public Rook(colorPlayer color, int x, int y) : base(color, x, y)
        {
            this.PieceType = PiecesTypeEnum.Rook ;
        }

        /// <summary>
        /// Get all possible moves.
        /// </summary>
        public override void GetAllMoves(Game game)
        {
            CheckPossibleMove();

            RightMove(game);

            LeftMove(game);

            UpMove(game);

            DownMove(game);

        }
    }
}
