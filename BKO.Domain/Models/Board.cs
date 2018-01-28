using System.Collections.Generic;
using BKO.Domain.Enums;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Board : IBoard
    {

        private Dictionary<PlayerPosition, IHand> _hands;
        private List<ITrick> _ticks;

        private Board()
        {
            _hands = new Dictionary<PlayerPosition, IHand>(4);
            _ticks = new List<ITrick>(13);
        }

      
    }
}