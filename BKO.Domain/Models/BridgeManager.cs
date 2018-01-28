using System;
using System.Collections.Generic;
using BKO.Domain.Enums;
using BKO.Domain.Exceptions;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class BridgeManager
    {
        private const int OnHand = 13;
        private readonly IAuctionManager _auctionManager;

        private readonly Dictionary<PlayerPosition, IPlayer> _players;
        private readonly IShuffler _shuffler;

        public bool TableFull => _players.Count == 4;

        public BridgeManager(IShuffler shuffler, IAuctionManager auctionManager)
        {
            _shuffler = shuffler;
            _auctionManager = auctionManager;
            _players = new Dictionary<PlayerPosition, IPlayer>();
        }

        public Dictionary<PlayerPosition, Hand> CreateHands()
        {
            IList<Card> cards = _shuffler.ShuffleCards();
            var hands = new Dictionary<PlayerPosition, Hand>();
            var currentPosition = 0;
            var cardsToHand = new List<Card>();

            foreach (Card card in cards)
            {
                cardsToHand.Add(card);
                if (cardsToHand.Count == OnHand)
                {
                    hands.Add((PlayerPosition) currentPosition, new Hand(cardsToHand));
                    cardsToHand.Clear();
                    currentPosition++;
                }
            }

            return hands;
        }

        public void SitPlayer(IPlayer player, PlayerPosition position)
        {
            if (_players.ContainsValue(player))
            {
                throw new PlayerAlreadySatException();
            }

            if (_players.ContainsKey(position))
            {
                throw new PlaceAlreadyTakenException();
            }

            _players.Add(position, player);
        }

        public void CreateGame()
        {

            throw new NotImplementedException();
        }
    }
}