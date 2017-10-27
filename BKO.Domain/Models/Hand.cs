using System.Collections.Generic;
using System.Linq;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Hand : IHand
    {
        public IList<Card> Cards => _cards;
        private List<Card> _cards;
        private List<Card> _usedCards;

        public Hand(IEnumerable<Card> cards)
        {
            _cards = cards.ToList();
            _usedCards = new List<Card>();
        }




    }
}
