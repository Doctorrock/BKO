using BKO.Domain.Enums;

namespace BKO.Domain.Interfaces
{
    public interface IPlayerGuard
    {
        void SetStartingPlayer(PlayerPosition player);
        bool IsCurentPlayer(PlayerPosition player);
        void FinishMove();
    }
}