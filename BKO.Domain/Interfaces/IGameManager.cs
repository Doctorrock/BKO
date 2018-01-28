using System.Collections.Generic;
using BKO.Domain.Enums;
using BKO.Domain.Models;

namespace BKO.Domain.Interfaces
{
    public interface IGameManager
    {
        Trick CurentTrick { get; }
        PlayerPosition PrevoiusTrickWinner { set; get; }
        void SetGame(Dictionary<PlayerPosition, Hand> hands, CardColor trump);
        void AddCardToTrick(PlayerPosition position, Card card);
        PlayerPosition CalculateWinner(ITrick trick);
        bool CanPlayerAddCard(PlayerPosition position, Card card);
    }
}