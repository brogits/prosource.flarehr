using Battleship.Library.Model;

namespace Battleship.Library
{
    public class BattleshipBoard
    {
        private readonly List<Battleship> battleships;
        private readonly HashSet<Coordinate> attackedCoordinates;

        public BattleshipBoard()
        {
            battleships = [];
            attackedCoordinates = [];
        }

        public bool AddBattleship(BattleshipConfig config)
        {
            var battleShip = new Battleship(new BattleshipConfig
            {
                Coordinate = config.Coordinate,
                Orientation = config.Orientation,
                NumberOfShip = config.NumberOfShip,
            });

            foreach (var ship in battleships)
            {
                if (ship.Positions.Any(p => battleShip.Positions.Contains(p)))
                {
                    return false;
                }
                    
            }

            battleships.Add(battleShip);
            return true;
        }

        public AttackResult Attack(Coordinate pos)
        {
            if (attackedCoordinates.Contains(pos))
                throw new InvalidOperationException("Position already attacked.");

            attackedCoordinates.Add(pos);

            foreach (var ship in battleships)
            {
                if (ship.IsHit(pos))
                    return AttackResult.Hit;
            }

            return AttackResult.Miss;
        }

        public bool HasLost() => battleships.All(ship => ship.IsSunk());
    }
}