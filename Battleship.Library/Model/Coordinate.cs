namespace Battleship.Library.Model
{
    public struct Coordinate
    {
        private const int MAX_POSITION = 10;
        private const int MIN_POSITION = 0;

        public Coordinate(int row, int col)
        {
            if (InValidCoordinate(row,col))
            {
                throw new ArgumentOutOfRangeException("Invalid battleship coordinates.");
            }

            Row = row;
            Column = col;
        }

        public int Row { get; }
        public int Column { get; }

        public override int GetHashCode() => HashCode.Combine(Row, Column);
        public override bool Equals(object obj)
        {
            return obj is Coordinate pos && Row == pos.Row && Column == pos.Column;
        }
        private bool InValidCoordinate(int row, int col)
        {
            return (row < MIN_POSITION || row >= MAX_POSITION || col < MIN_POSITION || col >= MAX_POSITION);
        }
    }
}