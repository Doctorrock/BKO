using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Player : IPlayer
    {
        public Place Place { get; private set; }
        public Hand Hand { get; private set; }
        private Board board;
        

        public Player(Hand hand, Board board, Place place)
        {
            this.board = board;
            this.Hand = hand;
            this.Place = place;
        }


    }

    public enum Place
    {
        North,
        East,
        South,
        West
    }
}
