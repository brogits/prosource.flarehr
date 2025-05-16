using Battleship.Library.Model;

namespace Battleship.Library
{
    public class BattleshipGame
    {
        private readonly BattleshipBoard boardOne;
        private readonly BattleshipBoard boardTwo;
        private bool playerOneTurn;

        public BattleshipGame()
        {
            boardOne = new BattleshipBoard();
            boardTwo = new BattleshipBoard();
            playerOneTurn = true;
        }

        public AttackResult Attack(Coordinate pos)
        {
            var opponentBoard = playerOneTurn ? boardTwo : boardOne;
            var result = opponentBoard.Attack(pos);

            playerOneTurn = !playerOneTurn;

            return result;
        }

        public BattleshipBoard ComputePlayerBoard(bool playerOne)
        {
            return playerOne == true ? boardOne : boardTwo;
        }

        public bool GameOver()
        {
            return boardOne.HasLost() || boardTwo.HasLost();
        }

        public int? Winner()
        {
            if (!GameOver()) return null;
            return boardOne.HasLost() ? 2 : 1;
        }
    }
}