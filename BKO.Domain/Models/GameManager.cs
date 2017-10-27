using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BKO.Domain.Enums;
using BKO.Domain.Interfaces;
using BKO.Domain.Exceptions;

namespace BKO.Domain.Models
{
    public class GameManager
    {
        private Dictionary<PlayerPosition, Hand> _hands;
        private List<Trick> _tricks;
        public Trick CurentTrick { private set; get; }
        private int _curentTrickNumber;
        private CardColor _trump;

        public GameManager(Dictionary<PlayerPosition, Hand> hands, CardColor trump)
        {
            _hands = hands;
            _trump = trump;

            _tricks = new List<Trick>();

            for (int i = 0; i < 12; i++)
            {
                _tricks.Add(new Trick());
            }
            CurentTrick = _tricks.First();
            _curentTrickNumber = 0;
        }

        public bool AddCardToTrick(PlayerPosition position, Card card)
        {
            if (_hands[position].Cards.Contains(card))
            {
                CurentTrick.TrickCards.Add(position, card);
                _hands[position].Cards.Remove(card);
            }
            else
            {
                throw new CardNotInHandException();
            }

            if (CurentTrick.AllCardsIn)
            {
                CalculateWinner(CurentTrick);
                _curentTrickNumber++;
                CurentTrick = _tricks[_curentTrickNumber];
                return true;
            }

            return false;
        }

        public PlayerPosition CalculateWinner(ITrick trick)
        {
            var winner = PlayerPosition.West;
            var winnersPoints = 0;
            var trumpValue = 100;
            foreach (var player in trick.TrickCards)
            {
                var playersPoints = (int)player.Value.Color + (int)player.Value.Number;
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

        public bool CanPlayerAddCard(PlayerPosition position, Card card)
        {
            return _trump == card.Color || (_hands[position].Cards.All(x => x.Color != _trump));
        }

    }
}
