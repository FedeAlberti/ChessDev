using System;
using System.Collections.Generic;

namespace ChessGameAPI.Dtos
{
    /// <summary>
    /// dto for game info
    /// </summary>
    public class GameDto
    {
        /// <summary>
        /// IEnumerable collection of dtos for pieces.
        /// </summary>
        /// <value>IEnumerable of PieceDto objects</value>
        public IEnumerable<PieceDto> Pieces { get; set; }



    }
}