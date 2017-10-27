using BKO.Domain.Models;

namespace BKO.Domain.Interfaces
{
    public interface IAuctionManager
    {
        CardColor Trump { get; }

        bool AuctionFinished { get; }

        Bidding PlayingBidding { get; }
    }
}