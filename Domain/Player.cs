using System;

namespace Domain
{
    public class Player
    {
        private RollDiceGame currentGame;
        public bool IsInGame => currentGame != null;

        public void Joins(RollDiceGame game)
        {
            if (IsInGame)
            {
                throw new InvalidOperationException();
            }
            currentGame = game;
            currentGame.IncrementPlayersCount();
        }

        public void LeaveGame()
        {
            if (!IsInGame)
            {
                throw new InvalidOperationException();
            }
            currentGame.DecrementPlayersCount();
            currentGame = null;
        }
    }
}