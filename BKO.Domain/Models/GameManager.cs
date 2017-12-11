using System.Collections.Generic;
using System.Linq;
using BKO.Domain.Enums;
using BKO.Domain.Exceptions;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class GameManager
    {
        private readonly Dictionary<PlayerPosition, Hand> hands;
        private readonly IPlayerGuard playerGuard;
        private readonly List<Trick> tricks;
        private readonly CardColor trump;
        private int curentTrickNumber;

        public GameManager(IPlayerGuard guard)
        {
            this.playerGuard = guard;
        }

        public GameManager(Dictionary<PlayerPosition, Hand> hands, CardColor trump)
        {
            this.hands = hands;
            this.trump = trump;

            this.tricks = new List<Trick>();

            for (var i = 0; i < 12; i++)
            {
                this.tricks.Add(new Trick());
            }
            CurentTrick = this.tricks.First();
            this.curentTrickNumber = 0;
        }

        public Trick CurentTrick { private set; get; }

        public void AddCardToTrick(PlayerPosition position, Card card)
        {
            // TODO needs to be tested, something strange here
            if (this.playerGuard.CurrentPlayer != position)
            {
                throw new WrongPlayerException();
            }

            if (!this.hands[position].Cards.Contains(card))
            {
                throw new CardNotInHandException();
            }

            CurentTrick.TrickCards.Add(position, card);
            this.hands[position].Cards.Remove(card);
            this.playerGuard.FinishMove();

            if (CurentTrick.AllCardsIn)
            {
                CurentTrick.Winner = CalculateWinner(CurentTrick);
                this.playerGuard.SetStartingPlayer(CurentTrick.Winner);
                this.curentTrickNumber++;
                CurentTrick = this.tricks[this.curentTrickNumber];
            }
        }

        public PlayerPosition CalculateWinner(ITrick trick)
        {
            var winner = PlayerPosition.West;
            var winnersPoints = 0;
            var trumpValue = 100;
            foreach (var player in trick.TrickCards)
            {
                var playersPoints = (int) player.Value.Color + (int) player.Value.Number;
                if (player.Value.Color == this.trump)
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
            return this.trump == card.Color || this.hands[position].Cards.All(x => x.Color != this.trump);
        }
    }
}