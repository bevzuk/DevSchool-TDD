namespace Domain
{
    public class RollDiceGame
    {
        private int playersCount;

        public void IncrementPlayersCount()
        {
            if (playersCount == 6)
            {
                throw new TooManyPlayersException();
            }
            playersCount++;
        }

        public void DecrementPlayersCount()
        {
            playersCount--;
        }
    }
}