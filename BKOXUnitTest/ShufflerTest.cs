using System;
using System.Linq;
using BKO.Domain.Models;
using Xunit;
namespace BKOXUnitTest
{
    public class ShufflerTest
    {
        [Fact]
        public void SimpeShuffleTest()
        {
            const int allCardsAmount = 52;
            var shuffler = new Shuffler();

            var shuffledCards = shuffler.ShuffleCards();

            Assert.Equal(allCardsAmount,shuffledCards.Count );
        }

        [Fact]
        public void NoRepeatsTest()
        {
            var shuffler = new Shuffler();
            var shuffledCards = shuffler.ShuffleCards();

            var gruped = shuffledCards.GroupBy(x => x.Number.ToString() + x.Color.ToString());

            Assert.False(gruped.Any(x => x.Count() > 1));
        }


    }
}
