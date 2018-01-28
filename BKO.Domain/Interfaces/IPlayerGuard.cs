using BKO.Domain.Enums;

namespace BKO.Domain.Interfaces
{
    public interface IPlayerGuard
    {
        void SetStartingPlayer(PlayerPosition player);
        bool IsCurrentPlayer(PlayerPosition player);
        void FinishMove();
    }
}