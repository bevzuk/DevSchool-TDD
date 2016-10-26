using System;

namespace Domain
{
    public class Player
    {
        private RollDiceGame currentGame;
        public bool IsInGame
        {
            get { return currentGame != null; }
        }

        public void Join(RollDiceGame game)
        {
            if (IsInGame)
            {
                throw new InvalidOperationException();
            }
            currentGame = game;
            currentGame.AddPlayer(this);
        }

        public void LeaveGame()
        {
            if (!IsInGame)
            {
                throw new InvalidOperationException();
            }
            currentGame.RemovePlayer(this);
            currentGame = null;
        }
    }
}