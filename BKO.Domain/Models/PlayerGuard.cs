using System;
using BKO.Domain.Enums;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class PlayerGuard : IPlayerGuard
    {
        private PlayerPosition currentPlayer;
        private PlayerPosition startingPlayer;

        public bool NewRound => this.startingPlayer == this.currentPlayer;

        public void SetStartingPlayer(PlayerPosition player)
        {
            this.currentPlayer = player;
            this.startingPlayer = player;
        }

        public void FinishMove()
        {
            this.currentPlayer = (PlayerPosition) (((int) this.currentPlayer + 1) % 4);
        }

        public bool IsCurentPlayer(PlayerPosition player)
        {
            return player == this.currentPlayer;
        }
    }
}