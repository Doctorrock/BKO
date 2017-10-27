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

            trick.TrickCards.Add(PlayerPosition.East, new Card(CardColor.Clubs, CardNumber.Ace));
            trick.TrickCards.Add(PlayerPosition.West, new Card(CardColor.Clubs, CardNumber.Eight));
            trick.TrickCards.Add(PlayerPosition.South, new Card(CardColor.Clubs, CardNumber.Five));
            trick.TrickCards.Add(PlayerPosition.North, new Card(CardColor.Clubs, CardNumber.Jack));

            Assert.True(trick.AllCardsIn);
        }
    }
}
