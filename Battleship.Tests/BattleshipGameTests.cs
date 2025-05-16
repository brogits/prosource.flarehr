
using Battleship.Library;
using Battleship.Library.Model;

namespace Battleship.Tests
{
    [TestClass]
    public class BattleshipGameTests
    {
        [TestMethod]
        public void BattleshipGame_Player2WinsTest()
        {
            // Prepare
            var game = new BattleshipGame();
            var player1 = game.ComputePlayerBoard(true);
            var player2 = game.ComputePlayerBoard(false);

            player1.AddBattleship(new BattleshipConfig
            {
                NumberOfShip = 1,
                Orientation = Orientation.Horizontal,
                Coordinate = new Coordinate(1, 2),
            });

            player2.AddBattleship(new BattleshipConfig
            {
                NumberOfShip = 1,
                Orientation = Orientation.Horizontal,
                Coordinate = new Coordinate(2, 3),
            });

            
            // Act
            var player1AttackResult = game.Attack(new Coordinate(3, 5));
            var player2AttackResult = game.Attack(new Coordinate(1, 2));

            // Assert
            Assert.AreEqual(AttackResult.Miss, player1AttackResult);
            Assert.AreEqual(AttackResult.Hit, player2AttackResult);
            Assert.IsTrue(game.GameOver());
            Assert.AreEqual(2, game.Winner());
        }
    }
}
