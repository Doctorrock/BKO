using System;
using System.Collections.Generic;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Shuffler : IShuffler
    {
        public IList<Card> ShuffleCards()
        {
            var allCardsAmount = 52;
            var cards = new List<Card>();
            var rand = new Random();
            var deck = CreateDeck();
            while (cards.Count != allCardsAmount)
            {
                var index = rand.Next(deck.Count);
                cards.Add(deck[index]);
                deck.RemoveAt(index);
            }

            return cards;
        }

        private static List<Card> CreateDeck()
        {
            var deck = new List<Card>();
            for (var number = 2; number < 15; ++number)
            {
                for (var color = 0; color < 4; ++color)
                {
                    deck.Add(new Card((CardColor) color, (CardNumber) number));
                }
            }
            return deck;
        }
    }
}