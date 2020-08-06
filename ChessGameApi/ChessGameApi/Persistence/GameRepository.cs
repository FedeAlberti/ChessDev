using ChessGameApi.Domain;
using ChessGameApi.Models;

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
        public Game GetGame()
        {
            return game;
        }

        public Piece GetPieceByXY(int x, int y)
        {
            return game.GetPieceForXY(x, y);
        }

    }
}

