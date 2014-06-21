#region Usings

using System;
using Domain;
using NUnit.Framework;

#endregion

namespace Tests {
    [TestFixture]
    public class WhenPlayerPlaysRollDiceGame {
        [Test]
        public void PlayerCanBuyChips() {
            var player = new Player();

            player.BuyChips(100);

            Assert.AreEqual(100, player.Chips);
        }

        [Test]
        public void PlayerCanBuyMoreChips() {
            var player = new Player();

            player.BuyChips(100);
            player.BuyChips(50);

            Assert.AreEqual(100 + 50, player.Chips);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void PlayerCanNotBuyNegativeChips() {
            var player = new Player();

            player.BuyChips(-100);
        }

        [Test]
        public void PlayerCanMakeBet() {
            var player = new Player();

            player.BuyChips(100);
            player.Bet(100, 1);

            Assert.AreEqual(100, player.CurrentBet.Chips);
            Assert.AreEqual(1, player.CurrentBet.Score);
        }

        [Test]
        public void AndMakedBetHisChipsReduce() {
            var player = new Player();

            player.BuyChips(100);
            player.Bet(25, 1);

            Assert.AreEqual(100 - 25, player.Chips);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void PlayerCanNotBetMoreThanHeHasChips() {
            var player = new Player();

            player.BuyChips(100);

            player.Bet(101, 1);
        }

        [Test]
        public void PlayerCanLose() {
            var player = new Player();
            player.BuyChips(100);
            player.Bet(25, 1);

            player.Lose();

            Assert.AreEqual(100 - 25, player.Chips);
        }

        [Test]
        public void PlayerCanWin() {
            var player = new Player();
            player.BuyChips(100);
            player.Bet(25, 1);

            player.Win(200);

            Assert.AreEqual(100 - 25 + 200, player.Chips);
        }

        [Test]
        public void PlayerCanJoinGame() {
            var game = new RollDiceGame();
            var player = new Player();

            player.Join(game);

            Assert.AreEqual(player, game.Player);
        }

        [Test]
        public void PlayerCanPlayAndLose() {
            var game = new RollDiceGame();
            var player = new Player();
            player.BuyChips(100);
            player.Join(game);
            player.Bet(100, 1);

            game.Play();

            Assert.AreEqual(0, player.Chips);
        }


        [Test]
        public void PlayerCanPlayAndWin() {
            var game = new RollDiceGame();
            var player = new Player();
            player.BuyChips(100);
            player.Join(game);
            player.Bet(100, 1);

            game.Play();

            Assert.AreEqual(100 - 100 + 100 * 6, player.Chips);
        }
    }
}