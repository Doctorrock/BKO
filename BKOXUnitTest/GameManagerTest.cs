using System.Collections.Generic;
using BKO.Domain.Enums;
using BKO.Domain.Interfaces;
using BKO.Domain.Models;
using BKO.Domain.Exceptions;
using Moq;
using Xunit;

namespace BKOXUnitTest
{
    public class GameManagerTest
    {
        [Fact]
        public void CalculateWinner_ClubsTrump()
        {
            var hands = new Dictionary<PlayerPosition, Hand>();
            var playerGuardMock = new Mock<IPlayerGuard>();
            playerGuardMock.Setup(x => x.IsCurentPlayer(It.IsAny<PlayerPosition>())).Returns(true);
            var gameManager = new GameManager(playerGuardMock.Object);
            gameManager.SetGame(hands, CardColor.Clubs);
            var trickCards = new Dictionary<PlayerPosition, Card>
            {
                {PlayerPosition.East, new Card(CardColor.Clubs, CardNumber.Ace)},
                {PlayerPosition.North, new Card(CardColor.Clubs, CardNumber.Two)},
                {PlayerPosition.South, new Card(CardColor.Spades, CardNumber.Ace)},
                {PlayerPosition.West, new Card(CardColor.Hearts, CardNumber.Ace)}
            };
            var trickMock = new Mock<ITrick>();
            trickMock.SetupGet(x => x.TrickCards).Returns(trickCards);


            var winner = gameManager.CalculateWinner(trickMock.Object);
            var expectedWinner = PlayerPosition.East;
            Assert.Equal(expectedWinner, winner);
        }

        [Fact]
        public void CalculateWinner_NoTrump()
        {
            var hands = new Dictionary<PlayerPosition, Hand>();
            var playerGuardMock = new Mock<IPlayerGuard>();
            playerGuardMock.Setup(x => x.IsCurentPlayer(It.IsAny<PlayerPosition>())).Returns(true);
            var gameManager = new GameManager(playerGuardMock.Object);
            gameManager.SetGame(hands, CardColor.NoTrump);
            var trickCards = new Dictionary<PlayerPosition, Card>
            {
                {PlayerPosition.South, new Card(CardColor.Spades, CardNumber.Ace)},
                {PlayerPosition.East, new Card(CardColor.Clubs, CardNumber.Ace)},
                {PlayerPosition.North, new Card(CardColor.Diamonds, CardNumber.Ace)},
                {PlayerPosition.West, new Card(CardColor.Hearts, CardNumber.Ace)}
            };
            var trickMock = new Mock<ITrick>();
            trickMock.SetupGet(x => x.TrickCards).Returns(trickCards);


            var winner = gameManager.CalculateWinner(trickMock.Object);
            var expectedWinner = PlayerPosition.South;
            Assert.Equal(expectedWinner, winner);
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
                new Card(CardColor.Clubs, CardNumber.Two)
            };
            var hands = new Dictionary<PlayerPosition, Hand>
            {
                {PlayerPosition.East, new Hand(clubs)}
            };
            var playerGuardMock = new Mock<IPlayerGuard>();
            playerGuardMock.Setup(x => x.IsCurentPlayer(It.IsAny<PlayerPosition>())).Returns(true);
            var gameManager = new GameManager(playerGuardMock.Object);
            gameManager.SetGame(hands, CardColor.Diamonds);

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
                new Card(CardColor.Diamonds, CardNumber.Two)
            };

            var hands = new Dictionary<PlayerPosition, Hand>
            {
                {PlayerPosition.East, new Hand(clubs)}
            };
            var playerGuardMock = new Mock<IPlayerGuard>();
            playerGuardMock.Setup(x => x.IsCurentPlayer(It.IsAny<PlayerPosition>())).Returns(true);
            var gameManager = new GameManager(playerGuardMock.Object);
            gameManager.SetGame(hands, CardColor.Diamonds);

            Assert.False(gameManager.CanPlayerAddCard(PlayerPosition.East, new Card(CardColor.Clubs, CardNumber.Ace)));
        }

        [Fact]
        public void CanPlayerAddCard_PlayerHasCard_True()
        {
            var clubs = new List<Card>
            {
                new Card(CardColor.Clubs, CardNumber.Ace)
            };
            var hands = new Dictionary<PlayerPosition, Hand>
            {
                {PlayerPosition.East, new Hand(clubs)}
            };
            var playerGuardMock = new Mock<IPlayerGuard>();
            playerGuardMock.Setup(x => x.IsCurentPlayer(It.IsAny<PlayerPosition>())).Returns(true);
            var gameManager = new GameManager(playerGuardMock.Object);
            gameManager.SetGame(hands, CardColor.Clubs);

            Assert.True(gameManager.CanPlayerAddCard(PlayerPosition.East, new Card(CardColor.Clubs, CardNumber.Ace))); 
        }

        [Fact]
        public void FourPlayersAddCards_NoException()
        {
            var clubs = new List<Card>
            {
                new Card(CardColor.Clubs, CardNumber.Ace)
            };
            var diamonds = new List<Card>
            {
                new Card(CardColor.Diamonds, CardNumber.Ace)
            };
            var hearts = new List<Card>
            {
                new Card(CardColor.Hearts, CardNumber.Ace)
            };
            var spades = new List<Card>
            {
                new Card(CardColor.Spades, CardNumber.Ace)
            };
            var hands = new Dictionary<PlayerPosition, Hand>
            {
                {PlayerPosition.East, new Hand(clubs)},
                {PlayerPosition.North, new Hand(hearts)},
                {PlayerPosition.West, new Hand(diamonds)},
                {PlayerPosition.South, new Hand(spades)}
            };

            var playerGuardMock = new Mock<IPlayerGuard>();
            playerGuardMock.Setup(x => x.IsCurentPlayer(It.IsAny<PlayerPosition>())).Returns(true);
            var gameManager = new GameManager(playerGuardMock.Object);
            gameManager.SetGame(hands, CardColor.Clubs);

            gameManager.AddCardToTrick(PlayerPosition.East, new Card(CardColor.Clubs, CardNumber.Ace));
            gameManager.AddCardToTrick(PlayerPosition.North, new Card(CardColor.Hearts, CardNumber.Ace));
            gameManager.AddCardToTrick(PlayerPosition.West, new Card(CardColor.Diamonds, CardNumber.Ace));
            gameManager.AddCardToTrick(PlayerPosition.South, new Card(CardColor.Spades, CardNumber.Ace));

            Assert.Equal(PlayerPosition.East, gameManager.PrevoiusTrickWinner);
        }

        [Fact]
        public void FourPlayersAddCards_WrongCardException()
        {
            var clubs = new List<Card>
            {
                new Card(CardColor.Clubs, CardNumber.Ace)
            };
            var diamonds = new List<Card>
            {
                new Card(CardColor.Diamonds, CardNumber.Ace)
            };
            var hearts = new List<Card>
            {
                new Card(CardColor.Hearts, CardNumber.Ace)
            };
            var spades = new List<Card>
            {
                new Card(CardColor.Spades, CardNumber.Ace)
            };
            var hands = new Dictionary<PlayerPosition, Hand>
            {
                {PlayerPosition.East, new Hand(clubs)},
                {PlayerPosition.North, new Hand(hearts)},
                {PlayerPosition.West, new Hand(diamonds)},
                {PlayerPosition.South, new Hand(spades)}
            };

            var playerGuardMock = new Mock<IPlayerGuard>();
            playerGuardMock.Setup(x => x.IsCurentPlayer(It.IsAny<PlayerPosition>())).Returns(true);
            var gameManager = new GameManager(playerGuardMock.Object);
            gameManager.SetGame(hands, CardColor.Clubs);

            gameManager.AddCardToTrick(PlayerPosition.East, new Card(CardColor.Clubs, CardNumber.Ace));
            gameManager.AddCardToTrick(PlayerPosition.North, new Card(CardColor.Hearts, CardNumber.Ace));
            gameManager.AddCardToTrick(PlayerPosition.West, new Card(CardColor.Diamonds, CardNumber.Ace));
            Assert.Throws<CardNotInHandException>(() => gameManager.AddCardToTrick(PlayerPosition.South, new Card(CardColor.Diamonds, CardNumber.Ace)));
        }
    }
}