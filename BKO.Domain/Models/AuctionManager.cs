using System;
using System.Collections.Generic;
using System.Text;
using BKO.Domain.Enums;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class AuctionManager : IAuctionManager
    {
        private int _passAmount = 0;
        private int _bidsAmount = 0;
        private Bidding _currentBiding;

        public CardColor Trump { private set; get; }
        public bool AuctionFinished => resolveAuction();
        public Bidding PlayingBidding => AuctionFinished ? _currentBiding : null;


        public void SetPass(PlayerPosition position)
        {
            _passAmount++;
            _bidsAmount++;

        }

        public void SetBidding(PlayerPosition position, int bid, CardColor color)
        {
            var newBidding = new Bidding { Bid = bid, Color = color, Player = position };
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

        private bool resolveAuction()
        {
            if (_bidsAmount == 4)
            {
                return _passAmount == 4;
            }
            return _passAmount == 3;
        }


    }
}
