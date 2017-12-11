using System.Collections.Generic;
using BKO.Domain.Enums;
using BKO.Domain.Exceptions;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class BridgeManager
    {
        private const int OnHand = 13;
        private readonly IAuctionManager auctionManager;

        private readonly Dictionary<PlayerPosition, IPlayer> players;
        private readonly IShuffler shuffler;
        private GameManager gameManager;

        public BridgeManager(IShuffler shuffler, IAuctionManager auctionManager)
        {
            this.shuffler = shuffler;
            this.auctionManager = auctionManager;
            this.players = new Dictionary<PlayerPosition, IPlayer>();
        }

        public bool TableFull => this.players.Count == 4;

        public Dictionary<PlayerPosition, Hand> CreateHands()
        {
            var cards = this.shuffler.ShuffleCards();
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
            if (this.players.ContainsValue(player))
            {
                throw new PlayerAlreadySatException();
            }

            if (this.players.ContainsKey(position))
            {
                throw new PlaceAlreadyTakenException();
            }

            this.players.Add(position, player);
        }

        public void CreateGame()
        {
            //this.gameManager = new GameManager(CreateHands(), this.auctionManager.Trump);
        }
    }
}