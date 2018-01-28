using System.Collections.Generic;
using BKO.Domain.Enums;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Trick : ITrick
    {
        public Dictionary<PlayerPosition, Card> TrickCards { get; }
        public PlayerPosition StartingPosition { get; }
        
        public bool Finished => TrickCards.Count == 4;
        public PlayerPosition Winner => Finished ? _winner : PlayerPosition.Null;
        private PlayerPosition _winner;
        public Trick(PlayerPosition starting)
        {
            TrickCards = new Dictionary<PlayerPosition, Card>(4);
            StartingPosition = starting;
        }
    }
}