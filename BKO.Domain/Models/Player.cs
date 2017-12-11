using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Player : IPlayer
    {
        private Board board;


        public Player(Hand hand, Board board, Place place)
        {
            this.board = board;
            Hand = hand;
            Place = place;
        }

        public Place Place { get; }
        public Hand Hand { get; }
    }

    public enum Place
    {
        North,
        East,
        South,
        West
    }
}