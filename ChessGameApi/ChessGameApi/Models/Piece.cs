using ChessGameApi.Helpers;
using System;
using System.Collections.Generic;

namespace ChessGameApi.Models
{
    public abstract class Piece
    {
        public int Id { get; set; }

        /// <summary>
        /// Value (x)
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Value (y)
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Color piece
        /// </summary>
        public colorPlayer Color { get; set; }

        public PiecesTypeEnum PieceType { get; set; }

        public IDictionary<(int, int), Piece> possibleMoves;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="color">Color Player</param>
        /// <param name="x">X value of piece</param>
        /// <param name="y">Y value of the piece</param>
        public Piece(colorPlayer color, int x, int y)
        {
            Color = color;
            X = x;
            Y = y;
        }

        /// <summary>
        /// Possibles moves to the pieces.
        /// </summary>
        public virtual void GetAllMoves(Game game)
        {
            throw new NotImplementedException("GetAllMoves is not imeplemented.");
        }

        internal void CheckPossibleMove()
        {
            if (possibleMoves == null)
            {
                possibleMoves = new Dictionary<(int, int), Piece>();
            }
            else
            {
                possibleMoves.Clear();
            }
        }

        internal void UpLeftMove(Game game)
        {
            int tempX = X;
            int tempY = Y;
            bool keepGoing = true;
            while (tempX > 0 && tempY < 7 && keepGoing)
            {
                tempX--;
                tempY++;
                keepGoing = game.tryMove(Id, tempX, tempY);
            }
        }

        internal void DownRightMove(Game game)
        {
            int tempX = X;
            int tempY = Y;
            bool keepGoing = true;
            while (tempX < 7 && tempY > 0 && keepGoing)
            {
                tempX++;
                tempY--;
                keepGoing = game.tryMove(Id, tempX, tempY);
            }
        }

        internal void DownLeftMove(Game game)
        {
            int tempX = X;
            int tempY = Y;
            bool keepGoing = true;
            while (tempX > 0 && tempY > 0 && keepGoing)
            {
                tempX--;
                tempY--;
                keepGoing = game.tryMove(Id, tempX, tempY);
            }
        }

        internal void UpRightMove(Game game)
        {
            int tempX = X;
            int tempY = Y;
            bool keepGoing = true;
            while (tempX < 7 && tempY < 7 && keepGoing)
            {
                tempX++;
                tempY++;
                keepGoing = game.tryMove(Id, tempX, tempY);
            }
        }

        internal void RightMove(Game game)
        {
            int tempX = X;
            bool keepGoing = true;
            while (tempX < 7 && keepGoing)
            {
                tempX++;
                keepGoing = game.tryMove(Id, tempX, Y);
            }
        }
        internal void LeftMove(Game game)
        {
            int tempX = X;
            bool keepGoing = true;
            while (tempX > 0 && keepGoing)
            {
                tempX--;
                keepGoing = game.tryMove(Id, tempX, Y);
            }
        }
        
        internal void UpMove(Game game)
        {
            int tempY = Y;
            bool keepGoing = true;
            while (tempY < 7 && keepGoing)
            {
                tempY++;
                keepGoing = game.tryMove(Id, X, tempY);
            }
        }
        
        internal void DownMove(Game game)
        {
            int tempY = Y;
            bool keepGoing = true;
            while (tempY > 0 && keepGoing)
            {
                tempY--;
                keepGoing = game.tryMove(Id, X, tempY);
            }
        }

    }

}
