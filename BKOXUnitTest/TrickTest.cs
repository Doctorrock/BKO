using System;
using System.Linq;
using BKO.Domain.Enums;
using BKO.Domain.Models;
using Xunit;

namespace BKOXUnitTest
{
    public class TrickTest
    {
        [Fact]
        public void FourCardsAdd()
        {
            var trick = new Trick();

            trick.AddCard(PlayerPosition.East, new Card(CardColor.Clubs, CardNumber.Ace));
            trick.AddCard(PlayerPosition.West, new Card(CardColor.Clubs, CardNumber.Eight));
            trick.AddCard(PlayerPosition.South, new Card(CardColor.Clubs, CardNumber.Five));
            trick.AddCard(PlayerPosition.North, new Card(CardColor.Clubs, CardNumber.Jack));

            Assert.True(trick.AllCardsIn);
        }
    }
}
