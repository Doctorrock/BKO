using System.Collections.Generic;
using BKO.Domain.Models;

namespace BKO.Domain.Interfaces
{
    public interface IShuffler
    {
        IList<Card> ShuffleCards();
    }
}
