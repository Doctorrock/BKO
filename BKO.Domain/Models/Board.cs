using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Board : IBoard
    {
        private readonly IShuffler shuffler;

        private Board()
        {
        }

        public Board(IShuffler shuffler)
        {
            this.shuffler = shuffler;
        }
    }
}