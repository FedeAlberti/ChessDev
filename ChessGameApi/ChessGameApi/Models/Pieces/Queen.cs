﻿using ChessGameApi.Helpers;
using ChessGameApi.Models;

namespace ChessGameAPI.Models.Pieces
{
    public class Queen : Piece
    {
        public Queen(Game game, colorPlayer color, int x, int y) : base(game, color, x, y)
        {
        }

        /// <summary>
        /// Get all possible moves.
        /// </summary>
        public override void GetAllMoves()
        {
            
        }
    }
}
