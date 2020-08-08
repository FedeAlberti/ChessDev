using ChessGameApi.Helpers;
using ChessGameApi.Models;

namespace ChessGameAPI.Models.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(colorPlayer color, int x, int y) : base(color, x, y)
        {
            this.PieceType = PiecesTypeEnum.Pawn;
        }

        /// <summary>
        /// Get all possible moves.
        /// </summary>
        public override void GetAllMoves(Game game)
        {
            CheckPossibleMove();
            // white side pawn
            if (Color == colorPlayer.White)
            {
                if (Y == 1)
                {
                    if ( game.tryMove(this,X,Y+1, false, true))
                        game.tryMove(this, X, Y + 2, false, true);
                }
                if (Y < 7)
                {
                    game.tryMove(this, X, Y + 1,false,true);
                    //diagonal eat
                    if (X < 7)
                    {
                        game.tryMove(this, X + 1, Y + 1,true);
                    }
                    if (X > 0)
                    {
                        game.tryMove(this, X - 1, Y + 1,true);
                    }
                }
            }
            else
            { // black side
                if (Y == 6)
                {
                    if (game.tryMove(this, X, Y - 1,false,true))
                        game.tryMove(this, X, Y - 2, false, true);
                }
                if (Y > 0)
                {
                    game.tryMove(this, X, Y - 1,false, true );
                    //diagonal eat
                    if (X < 7)
                    {
                        game.tryMove(this, X + 1, Y - 1, true);
                    }
                    if (X > 0)
                    {
                        game.tryMove(this, X - 1, Y - 1, true);
                    }
                }
            }
        }
    }
}
