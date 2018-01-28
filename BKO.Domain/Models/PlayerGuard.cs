using BKO.Domain.Enums;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class PlayerGuard : IPlayerGuard
    {
        private PlayerPosition _currentPlayer;
        private PlayerPosition _startingPlayer;

        public bool NewRound => _startingPlayer == _currentPlayer;

        public void SetStartingPlayer(PlayerPosition player)
        {
            _currentPlayer = player;
            _startingPlayer = player;
        }

        public void FinishMove()
        {
            _currentPlayer = (PlayerPosition) (((int) _currentPlayer + 1) % 4);
        }

        public bool IsCurrentPlayer(PlayerPosition player)
        {
            return player == _currentPlayer;
        }
    }
}