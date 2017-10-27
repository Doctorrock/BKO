using BKO.Domain.Enums;
using BKO.Domain.Models;
using Xunit;

namespace BKOXUnitTest
{
    public class AuctionManagerTest
    {
        [Fact]
        public void Bidding_FourPassAtStart()
        {
            var auctionManager = new AuctionManager();

            auctionManager.SetPass(PlayerPosition.East);
            auctionManager.SetPass(PlayerPosition.West);
            auctionManager.SetPass(PlayerPosition.North);
            auctionManager.SetPass(PlayerPosition.South);

            Assert.True(auctionManager.AuctionFinished);
        }

        [Fact]
        public void Bidding_NormalThenThreePass_SpadesWin()
        {
            var auctionManager = new AuctionManager();

            auctionManager.SetBidding(PlayerPosition.East,1,CardColor.Clubs);
            auctionManager.SetBidding(PlayerPosition.North,2,CardColor.Clubs);
            auctionManager.SetBidding(PlayerPosition.West,2,CardColor.Spades);
            auctionManager.SetPass(PlayerPosition.East);
            auctionManager.SetPass(PlayerPosition.West);
            auctionManager.SetPass(PlayerPosition.North);
            var bidding = new Bidding
                {Bid = 2, Color = CardColor.Spades, Player = PlayerPosition.West};

            Assert.True(auctionManager.AuctionFinished);
            Assert.Equal(bidding.BiddingValue,auctionManager.PlayingBidding.BiddingValue);
            Assert.Equal(bidding.Color,auctionManager.PlayingBidding.Color);
            Assert.Equal(bidding.Player,auctionManager.PlayingBidding.Player);
            Assert.Equal(bidding.Bid,auctionManager.PlayingBidding.Bid);
        }
    }
}
