using Battleship.Library;
using Battleship.Library.Model;

namespace Battleship.Tests
{
    [TestClass]
    public class BattleshipBoardTest
    {
        [TestMethod]
        public void AddBattleship_WithinBounds_Succeeds()
        {
            // Arrange
            var board = new BattleshipBoard();
            var config = new BattleshipConfig
            {
                NumberOfShip = 3,
                Orientation = Orientation.Horizontal,
                Coordinate = new Coordinate(0, 0),
            };

            // Act
            var result = board.AddBattleship(config);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddBattleship_Overlapping_Throws()
        {
            var board = new BattleshipBoard();
            board.AddBattleship(new BattleshipConfig
            {
                NumberOfShip = 3,
                Orientation = Orientation.Horizontal,
                Coordinate = new Coordinate(0, 0),
            });

            var result = board.AddBattleship(new BattleshipConfig
            {
                NumberOfShip = 3,
                Orientation = Orientation.Vertical,
                Coordinate = new Coordinate(0, 1),
            });

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AttackBattleship_HitsAndSinkShip()
        {
            // Arrange
            var board = new BattleshipBoard();

            
            board.AddBattleship(new BattleshipConfig
            {
                NumberOfShip = 2,
                Orientation = Orientation.Horizontal,
                Coordinate = new Coordinate(0, 0),
            });

            // Act
            var attack1 = board.Attack(new Coordinate(0, 0));
            var attack2 = board.Attack(new Coordinate(0, 1));
            var lost = board.HasLost();

            // Assert
            Assert.AreEqual(AttackResult.Hit, attack1);
            Assert.AreEqual(AttackResult.Hit, attack2);
            Assert.IsTrue(lost);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Attack_SamePositionTwice_Throws()
        {
            var board = new BattleshipBoard();
            board.AddBattleship(new BattleshipConfig
            {
                NumberOfShip = 2,
                Orientation = Orientation.Horizontal,
                Coordinate = new Coordinate(0, 0),
            });
            board.Attack(new Coordinate(0, 0));
            board.Attack(new Coordinate(0, 0));
        }
    }
}