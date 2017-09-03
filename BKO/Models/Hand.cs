using System.Collections.Generic;
using System.Linq;
using BKO.Interfaces;

namespace BKO.Models
{
    public class Hand : IHand
    {
        public IEnumerable<Card> Cards => cards;
        private List<Card> cards;
        private List<Card> usedCards;
        private Board board;

        public Hand(IEnumerable<Card> cards)
        {
            this.cards = cards.ToList();
            this.usedCards = new List<Card>();
        }




    }
}
