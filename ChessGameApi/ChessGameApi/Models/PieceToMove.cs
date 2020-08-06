namespace ChessGameApi.Models
{
    public class PieceToMove
    {
        public PieceToMove(int x,int y, Piece Piece)
        {
            X = x;
            Y = y;
            piece = Piece;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public Piece piece { get; set; }
    }
}
