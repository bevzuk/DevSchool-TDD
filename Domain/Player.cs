using System;

namespace Domain
{
    public class Player
    {
        public bool IsInGame { get; private set; }

        public void Joins(RollDiceGame game)
        {
            IsInGame = true;
        }

        public void LeaveGame()
        {
            if (!IsInGame)
            {
                throw new InvalidOperationException();
            }
            IsInGame = false;
        }
    }
}