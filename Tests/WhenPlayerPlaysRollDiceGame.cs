#region Usings

using System;
using System.Linq;
using System.Text;
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
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerCanNotBuyNegativeChips() {
            var player = new Player();

            player.BuyChips(-100);
        }
 
        [Test]
        public void PlayerCanMakeBet() {
            var player = new Player();

            player.BuyChips(100);
            player.Bet(chips: 100, score: 1);

            Assert.AreEqual(100, player.Bets.Single().Chips);
            Assert.AreEqual(1, player.Bets.Single().Score);
        }

        [Test]
        public void AndMakedBetHisChipsReduce() {
            var player = new Player();

            player.BuyChips(100);
            player.Bet(chips: 25, score: 1);

            Assert.AreEqual(100 - 25, player.Chips);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerCanNotBetMoreThanHeHasChips() {
            var player = new Player();

            player.BuyChips(100);

            player.Bet(chips: 101, score: 1);
        }

        [Test]
        public void PlayerCanMakeAnotherBet() {
            var player = new Player();

            player.BuyChips(100);
            player.Bet(chips: 25, score: 1);
            player.Bet(chips: 30, score: 1);

            Assert.AreEqual(100 - 25 - 30, player.Chips);
        }

        [Test]
        public void PlayerHasAnotherBet() {
            var player = new Player();

            player.BuyChips(100);
            player.Bet(chips: 25, score: 1);
            player.Bet(chips: 30, score: 2);

            CollectionAssert.AreEquivalent(new [] {new Bet(25, 1), new Bet(30, 2)}, player.Bets);
        }

        [Test]
        public void PlayerCanLose() {
            var player = new Player();
            player.BuyChips(100);
            player.Bet(chips: 25, score: 1);

            player.Lose();

            CollectionAssert.AreEquivalent(new Bet[] {}, player.Bets);
            Assert.AreEqual(100 - 25, player.Chips);
        }

        [Test]
        public void PlayerCanWin() {
            var player = new Player();
            player.BuyChips(100);
            player.Bet(chips: 25, score: 1);

            player.Win(200);

            CollectionAssert.AreEquivalent(new Bet[] {}, player.Bets);
            Assert.AreEqual(100 - 25 + 200, player.Chips);
        }
    }
}