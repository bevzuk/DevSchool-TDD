using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Join_IsInGame()
        {
            var player = new Player();
            var game = new RollDiceGame();

            player.Joins(game);

            Assert.True(player.IsInGame);
        }

        [Test]
        public void ByDefault_NotInGame()
        {
            var player = new Player();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void Leave_DefaultPlayer_ThrowsInvalidOperationException()
        {
            var player = new Player();

            Assert.Catch<InvalidOperationException>(() => player.LeaveGame());
        }

        [Test]
        public void Leave_AfterJoin_IsNotInGame()
        {
            var player = new Player();
            player.Joins(new RollDiceGame());

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void Leave_TwoTimesAfterJoin_ThrowsInvalidOperationException()
        {
            var player = new Player();
            player.Joins(new RollDiceGame());
            player.LeaveGame();

            Assert.Catch<InvalidOperationException>(() => player.LeaveGame());
        }

        [Test]
        public void JoinAnotherGame_AlreadyInGame_ThrowsInvalidOperationException()
        {
            var player = new Player();
            player.Joins(new RollDiceGame());

            Assert.Catch<InvalidOperationException>(() =>
                    player.Joins(new RollDiceGame()));
        }

        [Test]
        public void JoinTheSameGame_AlreadyInGame_ThrowsInvalidOperationException()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Joins(game);

            Assert.Catch<InvalidOperationException>(() =>
                    player.Joins(game));
        }

        [Test]
        public void CanJoinGame_AfterLeavingPreviousGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Joins(game);
            player.LeaveGame();

            player.Joins(game);

            Assert.True(player.IsInGame);
        }

        [Test]
        public void TwoPlayersCanJoinAGame()
        {
            var game = new RollDiceGame();
            new Player().Joins(game);
            var player = new Player();

            player.Joins(game);

            Assert.True(player.IsInGame);
        }

        [Test]
        public void SixPlayersCanJoinAGame()
        {
            var game = new RollDiceGame();
            new Player().Joins(game);
            new Player().Joins(game);
            new Player().Joins(game);
            new Player().Joins(game);
            new Player().Joins(game);
            var player6 = new Player();

            player6.Joins(game);

            Assert.True(player6.IsInGame);
        }

        [Test]
        public void SeventhPlayerCanNotJoinAGame()
        {
            var game = new RollDiceGame();
            new Player().Joins(game);
            new Player().Joins(game);
            new Player().Joins(game);
            new Player().Joins(game);
            new Player().Joins(game);
            new Player().Joins(game);
            var player7 = new Player();

            Assert.Catch<TooManyPlayersException>(() => player7.Joins(game));
        }
    }
}