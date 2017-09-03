using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BKO.Interfaces;
using BKO.Models;
using Moq;
using Xunit;

namespace BKOXUnitTest
{
    public class BoardTest
    {
        [Fact]
        public void SitPlayers()
        {
            var shufflerMock = new Mock<IShuffler>();
            Board board = new Board(shufflerMock.Object);

            //TODO finish this.
        }
        [Fact]
        public void CreateHands()
        {
            var shufflerMock = new Mock<IShuffler>();


            List<Card> clubs;
            List<Card> diamonds;
            List<Card> hearts;
            List<Card> spades;
            var deck = PrepareDeck(out clubs, out diamonds, out hearts, out spades);
            shufflerMock.Setup(x => x.ShuffleCards()).Returns(deck);

            Board board = new Board(shufflerMock.Object);
            var east = new Hand(clubs,board);
            var west = new Hand(diamonds,board);
            var south = new Hand(hearts, board);
            var north = new Hand(spades, board);

            var hands = new List<Hand>();
            hands.Add(east);
            hands.Add(west);
            hands.Add(south);
            hands.Add(north);

            var handsCreated = board.CreateHands();
            Assert.Equal(4,handsCreated.Count);
            Assert.Equal(13,handsCreated[0].Cards.Count());
            Assert.Equal(13,handsCreated[1].Cards.Count());
            Assert.Equal(13,handsCreated[2].Cards.Count());
            Assert.Equal(13,handsCreated[3].Cards.Count());



        }

        private static List<Card> PrepareDeck(out List<Card> clubs, out List<Card> diamonds, out List<Card> hearts, out List<Card> spades)
        {
            clubs = new List<Card>
            {
                new Card(CardColor.Clubs, CardNumber.Ace),
                new Card(CardColor.Clubs, CardNumber.King),
                new Card(CardColor.Clubs, CardNumber.Queen),
                new Card(CardColor.Clubs, CardNumber.Jack),
                new Card(CardColor.Clubs, CardNumber.Ten),
                new Card(CardColor.Clubs, CardNumber.Nine),
                new Card(CardColor.Clubs, CardNumber.Eight),
                new Card(CardColor.Clubs, CardNumber.Seven),
                new Card(CardColor.Clubs, CardNumber.Six),
                new Card(CardColor.Clubs, CardNumber.Five),
                new Card(CardColor.Clubs, CardNumber.Four),
                new Card(CardColor.Clubs, CardNumber.Three),
                new Card(CardColor.Clubs, CardNumber.Two),
            };

            diamonds = new List<Card>
            {
                new Card(CardColor.Diamonds, CardNumber.Ace),
                new Card(CardColor.Diamonds, CardNumber.King),
                new Card(CardColor.Diamonds, CardNumber.Queen),
                new Card(CardColor.Diamonds, CardNumber.Jack),
                new Card(CardColor.Diamonds, CardNumber.Ten),
                new Card(CardColor.Diamonds, CardNumber.Nine),
                new Card(CardColor.Diamonds, CardNumber.Eight),
                new Card(CardColor.Diamonds, CardNumber.Seven),
                new Card(CardColor.Diamonds, CardNumber.Six),
                new Card(CardColor.Diamonds, CardNumber.Five),
                new Card(CardColor.Diamonds, CardNumber.Four),
                new Card(CardColor.Diamonds, CardNumber.Three),
                new Card(CardColor.Diamonds, CardNumber.Two),
            };

            hearts = new List<Card>
            {
                new Card(CardColor.Hearts, CardNumber.Ace),
                new Card(CardColor.Hearts, CardNumber.King),
                new Card(CardColor.Hearts, CardNumber.Queen),
                new Card(CardColor.Hearts, CardNumber.Jack),
                new Card(CardColor.Hearts, CardNumber.Ten),
                new Card(CardColor.Hearts, CardNumber.Nine),
                new Card(CardColor.Hearts, CardNumber.Eight),
                new Card(CardColor.Hearts, CardNumber.Seven),
                new Card(CardColor.Hearts, CardNumber.Six),
                new Card(CardColor.Hearts, CardNumber.Five),
                new Card(CardColor.Hearts, CardNumber.Four),
                new Card(CardColor.Hearts, CardNumber.Three),
                new Card(CardColor.Hearts, CardNumber.Two),
            };

            spades = new List<Card>
            {
                new Card(CardColor.Spades, CardNumber.Ace),
                new Card(CardColor.Spades, CardNumber.King),
                new Card(CardColor.Spades, CardNumber.Queen),
                new Card(CardColor.Spades, CardNumber.Jack),
                new Card(CardColor.Spades, CardNumber.Ten),
                new Card(CardColor.Spades, CardNumber.Nine),
                new Card(CardColor.Spades, CardNumber.Eight),
                new Card(CardColor.Spades, CardNumber.Seven),
                new Card(CardColor.Spades, CardNumber.Six),
                new Card(CardColor.Spades, CardNumber.Five),
                new Card(CardColor.Spades, CardNumber.Four),
                new Card(CardColor.Spades, CardNumber.Three),
                new Card(CardColor.Spades, CardNumber.Two),
            };


            var deck = new List<Card>();
            deck.AddRange(clubs);
            deck.AddRange(diamonds);
            deck.AddRange(hearts);
            deck.AddRange(spades);
            return deck;
        }
    }
}
