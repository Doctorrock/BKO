using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BKO.Models;

namespace BKO.Interfaces
{
    public interface IShuffler
    {
        IList<Card> ShuffleCards();
    }
}
