using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BKO.Enums;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace BKO.Models
{
    public class Trick
    {
        private Dictionary<PlayerPosition, Card> _trick;

        public bool AllCardsIn => _trick.Count == 4;

        public Trick()
        {
            _trick = new Dictionary<PlayerPosition, Card>();
        }

        public void AddCard(PlayerPosition positon, Card card)
        {
            _trick.TryAdd(positon, card);
        }


    }
}
