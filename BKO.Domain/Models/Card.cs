
namespace BKO.Domain.Models
{
    public struct Card
    {
        public CardColor Color;
        public CardNumber Number;

        public Card(CardColor color, CardNumber number)
        {
            Color = color;
            Number = number;
        }
    }

    public enum CardColor
    {
        Clubs = 0,
        Diamonds = 20,
        Hearts = 40,
        Spades = 60,
        NoTrump
    }

    public enum CardNumber
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14

    }
}
