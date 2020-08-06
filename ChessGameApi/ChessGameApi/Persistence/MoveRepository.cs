using ChessGameApi.Models;
using System;
using System.Collections.Generic;

namespace ChessGameApi.Domain
{
    public class MoveRepository : IMoveRepository
    {
        public Game MovePiece(Game game, int pieceId, int endX,int endY)
        {
            var moves = GetPotentialMoves(game, pieceId);
            if (moves.ContainsKey((endX, endY)))
            {

                moves.TryGetValue((endX, endY), out Piece pieceToEat);
                if (pieceToEat != null)
                {
                    game.Pieces.Remove(pieceToEat);
                }

                var pieceToMove = game.GetPieceByID(pieceId);
                pieceToMove.X = endX;
                pieceToMove.Y = endY;
            }
            else
                throw new Exception();

            return game;
        }

        public List<PieceToMove> PossibleMove(Game game, int pieceID)
        {
            var resplist = new List<PieceToMove>();
            var potMov = GetPotentialMoves(game, pieceID);
            foreach (var item in potMov)
            {
                resplist.Add(new PieceToMove(item.Key.Item1, item.Key.Item2, item.Value));
            }
            return resplist;

        }

        private IDictionary<(int, int), Piece> GetPotentialMoves(Game game, int pieceID)
        {
            var piece = game.GetPieceByID(pieceID);
            piece.GetAllMoves(game);
            return piece.possibleMoves;
        }

    }
}
