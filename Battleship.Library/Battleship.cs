using Battleship.Library.Model;

namespace Battleship.Library
{
    public class Battleship
    {
        private const int MAX_POSITION = 10;
        private readonly HashSet<Coordinate> attackHits = [];

        public Battleship(BattleshipConfig config)
        {
            Positions = new List<Coordinate>();

            for (int i = 0; i < config.NumberOfShip; i++)
            {
                int row = ComputeRow(config, i);
                int col = ComputeColumn(config, i);

                if (row >= MAX_POSITION || col >= MAX_POSITION)
                {
                    throw new ArgumentOutOfRangeException("Battleship is out of board bounds.");
                }

                Positions.Add(new Coordinate(row, col));
            }
        }

        public List<Coordinate> Positions { get; }

        public bool Occupies(Coordinate pos) => Positions.Contains(pos);
        public bool IsHit(Coordinate pos)
        {
            if (!Occupies(pos))
            {
                return false;
                
            }

            attackHits.Add(pos);
            return true;
        }

        public bool IsSunk() => Positions.All(p => attackHits.Contains(p));

        private int ComputeColumn(BattleshipConfig config, int i)
        {
            return config.Orientation == Orientation.Horizontal ? config.Coordinate.Column + i : config.Coordinate.Column;
        }

        private int ComputeRow(BattleshipConfig config, int i)
        {
            return config.Orientation == Orientation.Vertical ? config.Coordinate.Row + i : config.Coordinate.Row;
        }
    }
}