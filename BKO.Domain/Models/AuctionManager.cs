using BKO.Domain.Enums;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class AuctionManager : IAuctionManager
    {
        private int bidsAmount;
        private Bidding currentBiding;
        private int passAmount;

        public CardColor Trump { private set; get; }
        public bool AuctionFinished => ResolveAuction();
        public Bidding PlayingBidding => AuctionFinished ? this.currentBiding : null;


        public void SetPass(PlayerPosition position)
        {
            this.passAmount++;
            this.bidsAmount++;
        }

        public void SetBidding(PlayerPosition position, int bid, CardColor color)
        {
            var newBidding = new Bidding {Bid = bid, Color = color, Player = position};
            if (this.currentBiding == null)
            {
                this.currentBiding = newBidding;
                this.bidsAmount++;
                this.passAmount = 0;
                return;
            }

            if (newBidding.BiddingValue > this.currentBiding.BiddingValue)
            {
                this.currentBiding = newBidding;
            }
            else
            {
                throw new BiddingException();
            }
            this.bidsAmount++;
            this.passAmount = 0;
        }

        private bool ResolveAuction()
        {
            if (this.bidsAmount == 4)
            {
                return this.passAmount == 4;
            }
            return this.passAmount == 3;
        }
    }
}