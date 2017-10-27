using System;
using System.Collections.Generic;
using System.Text;
using BKO.Domain.Enums;
using BKO.Domain.Models;
using Xunit;

namespace BKOXUnitTest
{
     public class PlayerGuardTest
    {
        [Fact]
        public void PlayerGuard_RotationTest()
        {
            var playerGuard = new PlayerGuard();

            playerGuard.SetStartingPlayer(PlayerPosition.North);
            playerGuard.FinishMove();
            Assert.Equal(PlayerPosition.East,playerGuard.CurrentPlayer);
            playerGuard.FinishMove();
            Assert.Equal(PlayerPosition.South, playerGuard.CurrentPlayer);
            playerGuard.FinishMove();
            Assert.Equal(PlayerPosition.West, playerGuard.CurrentPlayer);
            playerGuard.FinishMove();
            Assert.Equal(PlayerPosition.North, playerGuard.CurrentPlayer);
        }

        [Fact]
        public void PlayerGuard_RotationTest_Full()
        {
            var playerGuard = new PlayerGuard();

            playerGuard.SetStartingPlayer(PlayerPosition.East);
            playerGuard.FinishMove();
            playerGuard.FinishMove();
            playerGuard.FinishMove();
            playerGuard.FinishMove();
            Assert.True(playerGuard.NewRound);
        }
    }
}
