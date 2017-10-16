using System.Collections.Generic;
using System.Linq;
using BKO.Interfaces;

namespace BKO.Models
{
    public class Hand 
    {
        public IEnumerable<Card> Cards => _cards;
        private List<Card> _cards;
        private List<Card> _usedCards;

        public Hand(IEnumerable<Card> cards)
        {
            _cards = cards.ToList();
            _usedCards = new List<Card>();
        }




    }
}
