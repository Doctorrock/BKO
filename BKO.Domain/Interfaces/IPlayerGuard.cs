using System;
using System.Collections.Generic;
using System.Text;
using BKO.Domain.Enums;

namespace BKO.Domain.Interfaces
{
    public interface IPlayerGuard
    {
        PlayerPosition CurrentPlayer { get; }
        void SetStartingPlayer(PlayerPosition player);

        void FinishMove();

    }
}
