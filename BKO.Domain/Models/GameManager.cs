using System.Collections.Generic;
using System.Linq;
using BKO.Domain.Enums;
using BKO.Domain.Exceptions;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class GameManager : IGameManager
    {
        private readonly IPlayerGuard _playerGuard;
        private int _currentTrickNumber;
        private Dictionary<PlayerPosition, Hand> _hands;
        private List<Trick> _tricks;
        private CardColor _trump;

        public GameManager(IPlayerGuard guard)
        {
            _playerGuard = guard;
        }

        public Trick CurrentTrick { private set; get; }

        public PlayerPosition PreviousTrickWinner { set; get; }

        public void SetGame(Dictionary<PlayerPosition, Hand> hands, CardColor trump)
        {
            _hands = hands;
            _trump = trump;

            _tricks = new List<Trick>();

            for (var i = 0; i < 12; i++)
            {
                _tricks.Add(new Trick(PlayerPosition.North));
            }

            CurrentTrick = _tricks.First();
            _currentTrickNumber = 0;
        }

        public void AddCardToTrick(PlayerPosition position, Card card)
        {
            if (!_playerGuard.IsCurrentPlayer(position))
            {
                throw new WrongPlayerException();
            }

            if (!_hands[position].Cards.Contains(card))
            {
                throw new CardNotInHandException();
            }

            if (!CanPlayerAddCard(position, card))
            {
                throw new CardNotInHandException();
            }

            if (_trump == CardColor.NoTrump)
            {
                _trump = card.Color;
            }

            CurrentTrick.TrickCards.Add(position, card);
            _hands[position].Cards.Remove(card);
            _playerGuard.FinishMove();

            if (CurrentTrick.Finished)
            {
                PreviousTrickWinner = CalculateWinner(CurrentTrick);
                _playerGuard.SetStartingPlayer(CurrentTrick.Winner);
                _currentTrickNumber++;
                CurrentTrick = _tricks[_currentTrickNumber];
            }
        }

        public PlayerPosition CalculateWinner(ITrick trick)
        {
            var winner = PlayerPosition.West;
            var winnersPoints = 0;
            var trumpValue = 100;
            foreach (KeyValuePair<PlayerPosition, Card> player in trick.TrickCards)
            {
                var playersPoints = (int) player.Value.Number;
                if (player.Value.Color == _trump)
                {
                    playersPoints += trumpValue;
                }

                if (playersPoints > winnersPoints)
                {
                    winner = player.Key;
                    winnersPoints = playersPoints;
                }
            }

            return winner;
        }

        // TODO this should be removed
        public bool CanPlayerAddCard(PlayerPosition position, Card card)
        {
            return _trump == card.Color || _hands[position].Cards.All(x => x.Color != _trump);
        }
    }
}