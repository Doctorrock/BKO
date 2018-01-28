using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BKO.Domain.Enums;
using BKO.Domain.Exceptions;
using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class GameManager : IGameManager
    {
        private readonly IPlayerGuard playerGuard;
        private int curentTrickNumber;
        private Dictionary<PlayerPosition, Hand> hands;
        private List<Trick> tricks;
        private CardColor trump;

        public GameManager(IPlayerGuard guard)
        {
            this.playerGuard = guard;
        }

        public Trick CurrentTrick { private set; get; }

        public PlayerPosition PreviousTrickWinner { set; get; }

        public void SetGame(Dictionary<PlayerPosition, Hand> hands, CardColor trump)
        {
            this.hands = hands;
            this.trump = trump;

            this.tricks = new List<Trick>();

            for (var i = 0; i < 12; i++)
            {
                this.tricks.Add(new Trick(PlayerPosition.North));
            }
            CurrentTrick = this.tricks.First();
            this.curentTrickNumber = 0;
        }

        public void AddCardToTrick(PlayerPosition position, Card card)
        {
            if (!this.playerGuard.IsCurentPlayer(position))
            {
                throw new WrongPlayerException();
            }

            if (!this.hands[position].Cards.Contains(card))
            {
                throw new CardNotInHandException();
            }

            if (!CanPlayerAddCard(position, card))
            {
                throw new CardNotInHandException();
            }

            if (this.trump == CardColor.NoTrump)
            {
                this.trump = card.Color;
            }

            CurrentTrick.TrickCards.Add(position, card);
            this.hands[position].Cards.Remove(card);
            this.playerGuard.FinishMove();

            if (CurrentTrick.Finished)
            {
                PreviousTrickWinner = CalculateWinner(CurrentTrick);
                this.playerGuard.SetStartingPlayer(CurrentTrick.Winner);
                this.curentTrickNumber++;
                CurrentTrick = this.tricks[this.curentTrickNumber];
            }
        }

        public PlayerPosition CalculateWinner(ITrick trick)
        {
            var winner = PlayerPosition.West;
            var winnersPoints = 0;
            var trumpValue = 100;
            foreach (var player in trick.TrickCards)
            {
                var playersPoints = (int) player.Value.Number;
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

        // TODO this should be removed
        public bool CanPlayerAddCard(PlayerPosition position, Card card)
        {
            return this.trump == card.Color || this.hands[position].Cards.All(x => x.Color != this.trump);
        }
    }
}