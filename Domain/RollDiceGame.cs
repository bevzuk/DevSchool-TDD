using System;

namespace Domain {
    public class RollDiceGame {
        private readonly Random dice = new Random();
        public Player Player { get; set; }

        public void Play() {
            var winningScore = dice.Next(1, 7);
            if (Player.CurrentBet.Score == winningScore) {
                Player.Win(Player.CurrentBet.Chips * 6);
            }
            else {
                Player.Lose();
            }
        }
    }
}