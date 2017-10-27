using System.Collections.Generic;
using BKO.Domain.Enums;

namespace BKO.Domain.Models
{
    public class Trick
    {
        private Dictionary<PlayerPosition, Card> _trick;

        public bool AllCardsIn => _trick.Count == 4;

        public Trick()
        {
            _trick = new Dictionary<PlayerPosition, Card>();
        }

        public void AddCard(PlayerPosition positon, Card card)
        {
            _trick.Add(positon, card);
        }


    }
}
