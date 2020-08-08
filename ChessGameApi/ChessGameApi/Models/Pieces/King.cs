using ChessGameApi.Helpers;
using ChessGameApi.Models;

namespace ChessGameAPI.Models.Pieces
{
    public class King : Piece
    {
        public King(colorPlayer color, int x, int y) : base(color, x, y)
        {
            this.PieceType = PiecesTypeEnum.King;
        }

        /// <summary>
        /// Get all possible moves.
        /// </summary>
        public override void GetAllMoves(Game game)
        {
            CheckPossibleMove();

            bool canMoveLeft = X > 0;
            bool canMoveRight = X < 7;
            bool canMoveUp = Y < 7;
            bool canMoveDown = Y > 0;

            if (canMoveRight)
            {
                game.tryMove(this, X + 1, Y);
                if (canMoveUp)
                {
                    game.tryMove(this, X + 1, Y + 1);
                }
                if (canMoveDown)
                {
                    game.tryMove(this, X + 1, Y - 1);
                }
            }
            
            if (canMoveLeft)
            {
                game.tryMove(this, X - 1, Y);
                if (canMoveUp)
                {
                    game.tryMove(this, X - 1, Y + 1);
                }
                if (canMoveDown)
                {
                    game.tryMove(this, X - 1, Y - 1);
                }
            }

            if (canMoveUp)
            {
                game.tryMove(this, X, Y + 1);
            }

            if (canMoveDown)
            {
                game.tryMove(this, X, Y - 1);
            }

        }
    }
}
