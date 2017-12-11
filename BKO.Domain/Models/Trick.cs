using System.Collections.Generic;
using BKO.Domain.Enums;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Trick : ITrick
    {
        public Trick()
        {
            TrickCards = new Dictionary<PlayerPosition, Card>();
        }

        public bool AllCardsIn => TrickCards.Count == 4;

        public Dictionary<PlayerPosition, Card> TrickCards { get; }

        public PlayerPosition Winner { get; set; }
    }
}