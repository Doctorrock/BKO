using System.Collections.Generic;
using BKO.Domain.Enums;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Board : IBoard
    {

        public string Id { get; set; }

        public Dictionary<PlayerPosition, IHand> Hands { get; }

        public List<ITrick> Tricks { get; }

        public int CurrentTrick { get; }

        public Board(PlayerPosition starter)
        {
            Hands = new Dictionary<PlayerPosition, IHand>(4);
            Tricks = new List<ITrick>(13);
            CurrentTrick = 0;
            Tricks.Add(new Trick(starter));
        }

      
    }
}