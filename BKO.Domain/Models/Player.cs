using BKO.Domain.Interfaces;

namespace BKO.Domain.Models
{
    public class Player : IPlayer
    {
        private Board _board;


        public Player(Hand hand, Board board, Place place)
        {
            _board = board;
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