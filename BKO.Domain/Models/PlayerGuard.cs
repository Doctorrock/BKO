using BKO.Domain.Enums;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class PlayerGuard : IPlayerGuard
    {
        private PlayerPosition startingPlayer;

        public bool NewRound => this.startingPlayer == CurrentPlayer;
        public PlayerPosition CurrentPlayer { private set; get; }

        public void SetStartingPlayer(PlayerPosition player)
        {
            CurrentPlayer = player;
            this.startingPlayer = player;
        }

        public void FinishMove()
        {
            CurrentPlayer = (PlayerPosition) (((int) CurrentPlayer + 1) % 4);
        }
    }
}