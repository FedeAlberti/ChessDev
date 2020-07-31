using ChessGameApi.Helpers;
using ChessGameAPI.Models.Pieces;
using System.Collections.Generic;

namespace ChessGameApi.Models
{
    public class Game
    {
        public const int BoardSize = 8;
        protected IDictionary<(int, int), Piece> pieceDict;
        protected List<Piece> _pieces;

        public List<Piece> Pieces
        {
            get
            {
                return _pieces;
            }
        }

        /// <summary>
        /// Set new game
        /// </summary>
        public void Initialize()
        {
            pieceDict = new Dictionary<(int, int), Piece>();
            _pieces = new List<Piece>(32);

            //i is the x
            for (int i = 0; i < BoardSize; i++)
            {

                _pieces.Add(new Pawn(this, colorPlayer.White, i, 1));
                _pieces.Add(new Pawn(this, colorPlayer.Black, i, 6));
                
                switch (i)
                {
                    case 0:
                    case 7:
                        {//rooks
                            _pieces.Add(new Rook(this, colorPlayer.White, i, 0));
                            _pieces.Add(new Rook(this, colorPlayer.Black, i, 7));
                            continue;
                        }
                    case 1:
                    case 6:
                        {//knights
                            _pieces.Add(new Knight(this, colorPlayer.White, i, 0));
                            _pieces.Add(new Knight(this, colorPlayer.Black, i, 7));
                            continue;
                        }
                    case 2:
                    case 5:
                        {//bishops
                            _pieces.Add(new Bishop(this, colorPlayer.White, i, 0));
                            _pieces.Add(new Bishop(this, colorPlayer.Black, i, 7));
                            continue;
                        }
                    case 3:
                        {//queens
                            _pieces.Add(new Queen(this, colorPlayer.White, i, 0));
                            _pieces.Add(new Queen(this, colorPlayer.Black, i, 7));
                            continue;
                        }
                    case 4:
                        {//kings
                            _pieces.Add(new King(this, colorPlayer.White, i, 0));
                            _pieces.Add(new King(this, colorPlayer.Black, i, 7));
                            continue;
                        }
                }
            }
        }

        public Piece GetPieceForXY(int x, int y)
        {
            IDictionary<(int, int), Piece> pieces = GetPieces();
            if (pieces != null)
            {
                Piece outPiece;
                if (pieces.TryGetValue((x, y), out outPiece))
                {
                    return outPiece;
                };
            }
            return null;
        }
        internal bool tryMove(int StartX, int StartY, int endX, int endY, bool isPawnCapture = false)
        {
            Piece pieceToMove = GetPieceForXY(StartX, StartY);
            if (pieceToMove == null)
            {
                return false;
            }

            Piece pieceAtEndLocation = GetPieceForXY(endX, endY);

            if (pieceAtEndLocation!= null && 
                pieceAtEndLocation.Color != pieceToMove.Color)
            {
                //eat piece
                pieceToMove.possibleMoves[(endX, endY)] = pieceAtEndLocation;     
                return false;
            }

            // add possible move
            pieceToMove.possibleMoves[(endX, endY)] = null;
            return true;
        }

        public IDictionary<(int, int), Piece> GetPieces()
        {
            if (pieceDict == null && _pieces != null)
            {
                pieceDict = new Dictionary<(int, int), Piece>();
                foreach (Piece piece in _pieces)
                {
                    pieceDict.Add((piece.X, piece.Y), piece);
                }
            }
            return pieceDict;
        }
    }
}
