using ChessGameApi.Helpers;
using System;
using System.Collections.Generic;

namespace ChessGameApi.Models
{
    public abstract class Piece
    {
        /// <summary>
        /// Value (x) (A-H)
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Value (y) (1-8)
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Color piece
        /// </summary>
        public colorPlayer Color { get; set; }

        /// <summary>
        /// Game data
        /// </summary>
        public Game Game { get; set; }


        public IDictionary<(int, int), Piece> possibleMoves;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game">Game data</param>
        /// <param name="color">Color Player</param>
        /// <param name="x">X value of piece</param>
        /// <param name="y">Y value of the piece</param>
        public Piece(Game game, colorPlayer color, int x, int y)
        {
            Game = game;
            Color = color;
            X = x;
            Y = y;
        }

        /// <summary>
        /// Possibles moves to the pieces.
        /// </summary>
        public virtual void GetAllMoves()
        {
            throw new NotImplementedException("GetAllMoves is not imeplemented.");
        }

    }

}
