using System.Collections.Generic;
using BKO.Domain.Enums;
using BKO.Domain.Exceptions;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class BridgeManager
    {
        private readonly IShuffler _shuffler;
        private readonly IAuctionManager _auctionManager;
        private GameManager _gameManager;
        private const int OnHand = 13;

        private readonly Dictionary<PlayerPosition,IPlayer> _players;

        public bool TableFull => _players.Count == 4;

        public BridgeManager(IShuffler shuffler, IAuctionManager auctionManager)
        {
            _shuffler = shuffler;
            _auctionManager = auctionManager;
            _players = new Dictionary<PlayerPosition, IPlayer>();
        }

        public Dictionary<PlayerPosition, Hand> CreateHands()
        {
            var cards = _shuffler.ShuffleCards();
            var hands = new Dictionary<PlayerPosition, Hand>();
            var curentPostion = 0;
            var cardsToHand = new List<Card>();

            foreach (var card in cards)
            {
                cardsToHand.Add(card);
                if (cardsToHand.Count == OnHand)
                {
                    hands.Add((PlayerPosition) curentPostion, new Hand(cardsToHand));
                    cardsToHand.Clear();
                    curentPostion++;
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
              throw  new PlaceAlreadyTakenException();
            }

            _players.Add(position, player);
        }

        public void CreateGame()
        {
            _gameManager = new GameManager(CreateHands(),_auctionManager.Trump);
        }

    }
}
