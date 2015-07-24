using System;
using Xunit;

namespace Jokenpo.Tests
{
    public class JokenpoTests
    {
        [Fact]
        public void Stone_draw_with_stone()
        {
            // arrange
            var judge = new Judge
            {
                Player1 = new Player(Hand.Stone),
                Player2 = new Player(Hand.Stone)
            };

            // act
            judge.ShowYourHands();
            var winer = judge.Winer;

            // arrange
            Assert.Equal(Winer.Draw, winer);
        }

        [Theory]
        [InlineData(Hand.Stone, Hand.Scisor, Winer.Player1)]
        [InlineData(Hand.Scisor, Hand.Stone, Winer.Player2)]
        public void Stone_wins_scisor(Hand playter1Hand, Hand player2Hand, Winer expectedWiner)
        {
            // arrange
            var judge = new Judge
            {
                Player1 = new Player(playter1Hand),
                Player2 = new Player(player2Hand)
            };

            // act
            judge.ShowYourHands();
            var winer = judge.Winer;

            // assert
            Assert.Equal(expectedWiner, winer);
        }

        [Fact]
        public void Scisor_draw_scisor()
        {
            // arrange
            var judge = new Judge
            {
                Player1 = new Player(Hand.Scisor),
                Player2 = new Player(Hand.Scisor)
            };

            // act
            judge.ShowYourHands();
            var winer = judge.Winer;

            // assert
            Assert.Equal(Winer.Draw, winer);
        }

        [Theory]
        [InlineData(Hand.Scisor, Hand.Paper, Winer.Player1)]
        [InlineData(Hand.Paper, Hand.Scisor, Winer.Player2)]
        public void Scisor_wins_paper(Hand playter1Hand, Hand player2Hand, Winer expectedWiner)
        {
            // arrange
            var judge = new Judge
            {
                Player1 = new Player(playter1Hand),
                Player2 = new Player(player2Hand)
            };

            // act
            judge.ShowYourHands();
            var winer = judge.Winer;

            // assert
            Assert.Equal(expectedWiner, winer);
        }

        [Fact]
        public void Paper_draw_paper()
        {
            // arrange
            var judge = new Judge
            {
                Player1 = new Player(Hand.Paper),
                Player2 = new Player(Hand.Paper)
            };

            // act
            judge.ShowYourHands();
            var winer = judge.Winer;

            // assert
            Assert.Equal(Winer.Draw, winer);
        }

        [Theory]
        [InlineData(Hand.Paper, Hand.Stone, Winer.Player1)]
        [InlineData(Hand.Stone, Hand.Paper, Winer.Player2)]
        public void Paper_wins_stone(Hand playter1Hand, Hand player2Hand, Winer expectedWiner)
        {
            // arrange
            var judge = new Judge
            {
                Player1 = new Player(playter1Hand),
                Player2 = new Player(player2Hand)
            };

            // act
            judge.ShowYourHands();
            var winer = judge.Winer;

            // assert
            Assert.Equal(expectedWiner, winer);
        }

        [Fact]
        public void Show_your_hands_without_player_cause_exception()
        {
            // arrange
            var judgeWithoutPlayer2 = new Judge { Player1 = new Player(Hand.Scisor) };
            var judgeWithoutPlayer1 = new Judge { Player2 = new Player(Hand.Scisor)};
            var judgeWithoutPlayers = new Judge();

            // act
            Assert.Throws<InvalidOperationException>(() => judgeWithoutPlayer2.ShowYourHands());
            Assert.Throws<InvalidOperationException>(() => judgeWithoutPlayer1.ShowYourHands());
            Assert.Throws<InvalidOperationException>(() => judgeWithoutPlayers.ShowYourHands());
        }

    }
}
