using ChessGameApi.Domain;
using ChessGameApi.Models;
using System.Collections.Generic;

namespace ChessGameApi.Persistence
{
    public class GameRepository : IGameRepository
    {
        private Game _game;

        public Game game
        {
            get
            {
                if (_game == null)
                    return _game = new Game();
                else
                    return _game;
            }
            set { _game = value; }
        }

        public Game NewGame()
        {
            game = new Game();
            return game;
        }
        public Game getGame()
        {
            return game;
        }
        public IDictionary<(int, int), Piece> GetPiece()
        {
            return game.GetPieces();
        }

        public Piece GetPieceByXY(int x, int y)
        {
            return game.GetPieceForXY(x, y);
        }

    }
}

