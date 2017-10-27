using System.Collections.Generic;
using System.Collections.ObjectModel;
using BKO.Domain.Enums;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Trick : ITrick
    {

        public Dictionary<PlayerPosition, Card> TrickCards { get; }

        public bool AllCardsIn => TrickCards.Count == 4;

        public PlayerPosition Winner { get; set; }

        public Trick()
        {
            TrickCards = new Dictionary<PlayerPosition, Card>();
        }
    }
}
