using BKO.Domain.Enums;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class AuctionManager : IAuctionManager
    {
        private int _bidsAmount;
        private Bidding _currentBiding;
        private int _passAmount;

        public CardColor Trump { get; }
        public bool AuctionFinished => ResolveAuction();
        public Bidding PlayingBidding => AuctionFinished ? _currentBiding : null;


        public void SetPass(PlayerPosition position)
        {
            _passAmount++;
            _bidsAmount++;
        }

        public void SetBidding(PlayerPosition position, int bid, CardColor color)
        {
            var newBidding = new Bidding {Bid = bid, Color = color, Player = position};
            if (_currentBiding == null)
            {
                _currentBiding = newBidding;
                _bidsAmount++;
                _passAmount = 0;
                return;
            }

            if (newBidding.BiddingValue > _currentBiding.BiddingValue)
            {
                _currentBiding = newBidding;
            }
            else
            {
                throw new BiddingException();
            }

            _bidsAmount++;
            _passAmount = 0;
        }

        private bool ResolveAuction()
        {
            if (_bidsAmount == 4)
            {
                return _passAmount == 4;
            }

            return _passAmount == 3;
        }
    }
}