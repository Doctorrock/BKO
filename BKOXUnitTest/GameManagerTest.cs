using System;
using System.Collections.Generic;
using System.Text;
using BKO.Domain.Models;
using BKO.Domain.Enums;
using BKO.Domain.Interfaces;
using Moq;
using Xunit;

namespace BKOXUnitTest
{
     public class GameManagerTest
    {

        [Fact]
        public void CanPlayerAddCard_PlayerHasCard_True()
        {
            var clubs = new List<Card>
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
            var hands = new Dictionary<PlayerPosition, Hand>();
            hands.Add(PlayerPosition.East, new Hand(clubs));
            var gameManager = new GameManager(hands,CardColor.Clubs);

            Assert.True(gameManager.CanPlayerAddCard(PlayerPosition.East,new Card(CardColor.Clubs,CardNumber.Ace)));
        }

        [Fact]
        public void CanPlayerAddCard_NoTrumpColor_True()
        {
            var clubs = new List<Card>
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
            var hands = new Dictionary<PlayerPosition, Hand>();
            hands.Add(PlayerPosition.East, new Hand(clubs));
            var gameManager = new GameManager(hands, CardColor.Diamonds);

            Assert.True(gameManager.CanPlayerAddCard(PlayerPosition.East, new Card(CardColor.Clubs, CardNumber.Ace)));
        }

        [Fact]
        public void CanPlayerAddCard_NotTrump_False()
        {
            var clubs = new List<Card>
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
                new Card(CardColor.Diamonds, CardNumber.Two),
            };

            var hands = new Dictionary<PlayerPosition, Hand>();
            hands.Add(PlayerPosition.East, new Hand(clubs));
            var gameManager = new GameManager(hands, CardColor.Diamonds);

            Assert.False(gameManager.CanPlayerAddCard(PlayerPosition.East, new Card(CardColor.Clubs, CardNumber.Ace)));
        }

        [Fact]
        public void CalculateWinner_NoTrump()
        {
            var hands = new Dictionary<PlayerPosition, Hand>();
            var gameManager = new GameManager(hands, CardColor.NoTrump);
            var trickCards = new Dictionary<PlayerPosition, Card>()
            {
                {PlayerPosition.East, new Card(CardColor.Clubs, CardNumber.Ace)},
                {PlayerPosition.North, new Card(CardColor.Diamonds, CardNumber.Ace)},
                {PlayerPosition.South, new Card(CardColor.Spades, CardNumber.Ace)},
                {PlayerPosition.West, new Card(CardColor.Hearts, CardNumber.Ace)},
            };
            var trickMock = new Mock<ITrick>();
            trickMock.SetupGet(x => x.TrickCards).Returns(trickCards);


            var winner = gameManager.CalculateWinner(trickMock.Object);
            var expectedWinner = PlayerPosition.South;
            Assert.Equal(expectedWinner, winner);
        }

        [Fact]
        public void CalculateWinner_ClubsTrump()
        {
            var hands = new Dictionary<PlayerPosition, Hand>();
            var gameManager = new GameManager(hands, CardColor.Clubs);
            var trickCards = new Dictionary<PlayerPosition, Card>()
            {
                {PlayerPosition.East, new Card(CardColor.Clubs, CardNumber.Ace)},
                {PlayerPosition.North, new Card(CardColor.Clubs, CardNumber.Two)},
                {PlayerPosition.South, new Card(CardColor.Spades, CardNumber.Ace)},
                {PlayerPosition.West, new Card(CardColor.Hearts, CardNumber.Ace)},
            };
            var trickMock = new Mock<ITrick>();
            trickMock.SetupGet(x => x.TrickCards).Returns(trickCards);


            var winner = gameManager.CalculateWinner(trickMock.Object);
            var expectedWinner = PlayerPosition.East;
            Assert.Equal(expectedWinner, winner);
        }
    }
}
