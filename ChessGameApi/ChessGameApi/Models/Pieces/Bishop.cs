using ChessGameApi.Helpers;
using ChessGameApi.Models;

namespace ChessGameAPI.Models.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(colorPlayer color, int x, int y) : base( color, x, y)
        {
            PieceType = PiecesTypeEnum.Bishop;
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
        }


    }
}
