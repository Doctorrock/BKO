using System.Collections.Generic;
using System.Linq;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Hand : IHand
    {
        private readonly List<Card> cards;
        private List<Card> usedCards;

        public Hand(IEnumerable<Card> cards)
        {
            this.cards = cards.ToList();
            this.usedCards = new List<Card>();
        }

        public IList<Card> Cards => this.cards;
    }
}