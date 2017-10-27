using System;
using System.Collections.Generic;
using System.Text;
using BKO.Domain.Enums;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class PlayerGuard : IPlayerGuard
    {
        public PlayerPosition CurrentPlayer { private set; get; }
        private PlayerPosition _startingPlayer;

        public bool NewRound => _startingPlayer == CurrentPlayer;
     
        public void SetStartingPlayer(PlayerPosition player)
        {
            CurrentPlayer = player;
            _startingPlayer = player;
        }

        public void FinishMove()
        {
            CurrentPlayer = (PlayerPosition)(((int)CurrentPlayer + 1)%4);
        }
    }
}
