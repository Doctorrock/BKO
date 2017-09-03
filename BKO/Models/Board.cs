using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BKO.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace BKO.Models
{
    public class Board : IBoard
    {
        private Player east;
        private Player west;
        private Player north;
        private Player south;
        private IShuffler _shuffler;
        private Trick trick;

        private Dictionary<TablePosition, Player> players;
        public Board(IShuffler shuffler)
        {
            _shuffler = shuffler;
            players = new Dictionary<TablePosition, Player>();
        }

        public IList<Hand> CreateHands()
        {
            var cards = _shuffler.ShuffleCards().ToList();

            var hands = new List<Hand>();
            const int onHand = 13;
            const int handCount = 4;

            for (var i = 0; i < handCount; ++i)
            {
                hands.Add(new Hand(cards.GetRange(i * onHand, onHand)));
            }

            return hands;
        }

        public bool TrySitPlayer(Player player, TablePosition position)
        {
            if (players.ContainsKey(position))
            {
                return false;
            }

            players.Add(position,player);
            return true;
        }

    }

    public enum TablePosition
    {
        East,
        West,
        North,
        South
    }
}
