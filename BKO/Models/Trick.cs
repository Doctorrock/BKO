using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace BKO.Models
{
    public class Trick
    {
        public Card South { get; private set; }
        public Card West { get; private set; }
        public Card North { get; private set; }
        public Card East { get; private set; }

        public bool SouthOnDeck { get; private set; } = false;
        public bool WestOnDeck { get; private set; } = false;
        public bool NorthOnDeck { get; private set; } = false;
        public bool EastOnDeck { get; private set; } = false;

        public Player Winner { get; set; }
        public CardColor WistedColor { get; set; }

        public void PlaceCard(Card card, Player player)
        {

            switch (player.Place)
            {
                case Place.East:
                    East = card;
                    EastOnDeck = true;
                    break;
                case Place.West:
                    West = card;
                    WestOnDeck = true;
                    break;
                case Place.North:
                    North = card;
                    break;
                case Place.South:
                    South = card;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
