using System;
using System.Collections.Generic;
using BKO.Domain.Enums;
using BKO.Domain.Models;

namespace BKO.Domain.Interfaces
{
    public interface ITrick
    {
        Dictionary<PlayerPosition, Card> TrickCards { get; }
        PlayerPosition Winner { get; set; }
    }
}