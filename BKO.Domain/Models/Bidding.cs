using BKO.Domain.Enums;

namespace BKO.Domain.Models
{
    public class Bidding
    {
        public PlayerPosition Player { get; set; }

        public CardColor Color { get; set; }

        public int Bid { get; set; }

        public int BiddingValue => (int)Color + Bid;
    }
}