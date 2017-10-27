
using System.Collections.Generic;
using BKO.Enums;
using BKO.Exceptions;
using BKO.Interfaces;

namespace BKO.Models
{
    public class GameManager
    {
        private readonly IBoard _board;
        private readonly IShuffler _shuffler;
        private const int OnHand = 13;

        private readonly Dictionary<PlayerPosition,IPlayer> _players;
        private Dictionary<PlayerPosition, Hand> _hands;

        public bool TableFull => _players.Count == 4;

        public GameManager(IBoard board, IShuffler shuffler)
        {
            _board = board;
            _shuffler = shuffler;
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
            _hands = hands;
            return hands;
        }

        public void SitPlayer(IPlayer player, PlayerPosition position)
        {
            if (_players.ContainsValue(player))
            {
                throw new PlayerAlreadySatException();
            }

            if (!_players.TryAdd(position, player))
            {
              throw  new PlaceAlreadyTakenException();
            }
        }

    }
}
