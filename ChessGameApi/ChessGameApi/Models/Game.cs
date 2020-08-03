using ChessGameApi.Helpers;
using ChessGameAPI.Models.Pieces;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameApi.Models
{
    public class Game
    {
        public const int BoardSize = 8;
        protected IDictionary<(int, int), Piece> pieceDict;
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

        internal bool tryMove(int pieceID, int endX, int endY, bool isPawnCapture = false)
        {
            Piece pieceToMove = GetPieceByID(pieceID);
            
            if (pieceToMove == null)
            {
                return false;
            }

            Piece pieceAtEndLocation = GetPieceForXY(endX, endY);

            if (pieceAtEndLocation!= null && 
                pieceAtEndLocation.Color != pieceToMove.Color &&
                !isPawnCapture)
            {
                //eat piece
                pieceToMove.possibleMoves[(endX, endY)] = pieceAtEndLocation;     
                return false;
            }

            if (pieceAtEndLocation != null && pieceAtEndLocation.Color == pieceToMove.Color)
                return false;


            if (isPawnCapture)
                return false;

            // add possible move
            pieceToMove.possibleMoves[(endX, endY)] = null;
            return true;
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

        public Piece GetPieceByID(int pieceID)
        {
            IDictionary<(int, int), Piece> pieces = GetPieces();
            if (pieces != null)
            {
                Piece outPiece = pieces.Values.FirstOrDefault(x => x.Id == pieceID);
                if (outPiece != null)
                {
                    return outPiece;
                };
            }
            return null;
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
