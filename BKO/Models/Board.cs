using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BKO.Enums;
using BKO.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace BKO.Models
{
    public class Board : IBoard
    {
        private Board()
        { }
        private readonly IShuffler _shuffler;

        public Board(IShuffler shuffler)
        {
            _shuffler = shuffler;
        }

        

    }
}
