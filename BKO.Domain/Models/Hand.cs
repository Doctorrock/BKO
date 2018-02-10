using System.Collections.Generic;
using System.Linq;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Hand : IHand
    {
        private readonly List<Card> _cards;
        private List<Card> _usedCards;

        public IList<Card> Cards => _cards;

        public Hand()
        {

        }

        public Hand(IEnumerable<Card> cards)
        {
            _cards = cards.ToList();
            _usedCards = new List<Card>();
        }
    }
}