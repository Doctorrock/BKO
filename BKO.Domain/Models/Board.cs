using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
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
