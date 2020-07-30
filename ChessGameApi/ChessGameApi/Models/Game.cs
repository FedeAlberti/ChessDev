using System.Collections.Generic;

namespace ChessGameApi.Models
{
    public class Game
    {
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
        /// Gets Pieces Dictionary
        /// </summary>
        /// <returns>Positions (x,y) for pieces.</returns>
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
