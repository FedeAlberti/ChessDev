using ChessGameApi.Helpers;
using ChessGameAPI.Models.Pieces;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameApi.Models
{
    public class Game
    {
        public const int BoardSize = 8;
        protected List<Piece> _pieces;

        public Game()
        {
            InitGame();
        }

        public List<Piece> Pieces
        {
            get
            {
                if (_pieces == null)
                    return _pieces = new List<Piece>();
                else
                    return _pieces;
            }
            set { _pieces = value; }
        }

        internal bool tryMove(Piece pieceToMove, int endX, int endY, bool isPawnCapture = false, bool donteat = false)
        {
            bool SameColor = false;
            bool pieceNotNull = false;

            if (pieceToMove == null)
                return false;

            Piece pieceAtEndLocation = GetPieceForXY(endX, endY);

            if (pieceAtEndLocation != null)
            {
                SameColor = pieceAtEndLocation.Color == pieceToMove.Color;
                pieceNotNull = true;
            }

            if (SameColor)
                return false;

            if (pieceNotNull &&
                !SameColor)
            {
                if (!donteat)
                {
                    //eat piece
                    pieceToMove.possibleMoves[(endX, endY)] = pieceAtEndLocation;
                }
                return false;
            }

            if (isPawnCapture)
                return false;

            // add possible move
            pieceToMove.possibleMoves[(endX, endY)] = null;
            return true;
        }

        public Piece GetPieceForXY(int x, int y)
        {
            return Pieces.FirstOrDefault(pic => pic.X == x && pic.Y == y);
        }

        public Piece GetPieceByID(int pieceID)
        {
            return Pieces.FirstOrDefault(x => x.Id == pieceID);
        }

        private void InitGame()
        {
            //i is the x
            for (int i = 0; i < Game.BoardSize; i++)
            {

                Pieces.Add(new Pawn(colorPlayer.White, i, 1));
                Pieces.Add(new Pawn(colorPlayer.Black, i, 6));

                switch (i)
                {
                    case 0:
                    case 7:
                        {//rooks
                            Pieces.Add(new Rook(colorPlayer.White, i, 0));
                            Pieces.Add(new Rook(colorPlayer.Black, i, 7));
                            continue;
                        }
                    case 1:
                    case 6:
                        {//knights
                            Pieces.Add(new Knight(colorPlayer.White, i, 0));
                            Pieces.Add(new Knight(colorPlayer.Black, i, 7));
                            continue;
                        }
                    case 2:
                    case 5:
                        {//bishops
                            Pieces.Add(new Bishop(colorPlayer.White, i, 0));
                            Pieces.Add(new Bishop(colorPlayer.Black, i, 7));
                            continue;
                        }
                    case 3:
                        {//queens
                            Pieces.Add(new Queen(colorPlayer.White, i, 0));
                            Pieces.Add(new Queen(colorPlayer.Black, i, 7));
                            continue;
                        }
                    case 4:
                        {//kings
                            Pieces.Add(new King(colorPlayer.White, i, 0));
                            Pieces.Add(new King(colorPlayer.Black, i, 7));
                            continue;
                        }
                }
            }

            int idsum = 0;
            foreach (var piece in Pieces)
            {
                piece.Id = idsum;
                idsum++;
            }

        }

    }
}
