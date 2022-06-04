using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouletteBot.Models;
using System;
using System.Linq;

namespace RouletteBotTests
{

    [TestClass]
    public class BetEvaluatorTests
    {
        private BetEvaluator betEvaluator = new BetEvaluator(new BetEvaluationTestConfig());

        [TestMethod("Checks correct try sixline bets for normal case")]
        public void Sixlines_CorrectBetsAreCreated()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 7, 15 };

            // Act
            Bet[] bets = betEvaluator.getSuggestions(numbers);

            // Assert
            Assert.AreEqual(3, bets.Length, "There must be exactly 3 bets");

            int[] sixLineBetIndexes = Array.FindAll(bets, bet => bet is SixLineBet)
                .Select(bet => ((SixLineBet) bet).Index).ToArray();

            Assert.AreEqual(2, sixLineBetIndexes.Length, "There must be exactly 2 sixline bets");
            Assert.IsTrue(Math.Abs(sixLineBetIndexes[0] - sixLineBetIndexes[1]) == 1, "Sixline bets must be next to each other");

            int lastNumberX = RouletteHelper.getNumberGridIndex(numbers[4]).X;
            Array.Sort(sixLineBetIndexes);

            Assert.IsTrue(lastNumberX == sixLineBetIndexes[0], "First sixline bet index must be same as last number X");

            int[] numberBetNumbers = Array.FindAll(bets, bet => bet is NumberBet)
                .Select(bet => ((NumberBet) bet).Number).ToArray();

            Assert.AreEqual(1, numberBetNumbers.Length, "There must be exactly 1 number bet");
            Assert.IsTrue((numberBetNumbers[0] % 10 == numbers[3] % 10), "Incorrect number bet");
        }

        [TestMethod("Checks correct second try sixline bets for normal case")]
        public void Sixlines_CorrectBetsAreCreated_SecondTryCase()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 7, 15, 3};

            // Act
            Bet[] bets = betEvaluator.getSuggestions(numbers);

            // Assert
            Assert.AreEqual(3, bets.Length, "There must be exactly 3 bets");

            int[] sixLineBetIndexes = Array.FindAll(bets, bet => bet is SixLineBet)
                .Select(bet => ((SixLineBet)bet).Index).ToArray();

            Assert.AreEqual(2, sixLineBetIndexes.Length, "There must be exactly 3 sixline bets");
            Assert.IsTrue(Math.Abs(sixLineBetIndexes[0] - sixLineBetIndexes[1]) == 1, "Sixline bets must be next to each other");

            int beforeLastNumberX = RouletteHelper.getNumberGridIndex(numbers[4]).X;
            Array.Sort(sixLineBetIndexes);

            Assert.IsTrue(beforeLastNumberX == sixLineBetIndexes[0], "First sixline bet index must be same as last number X");
        }


        [TestMethod("Checks correct sixline bets for edge cases")]
        public void Sixlines_CorrectBetsAreCreated_EdgeCase()
        {
            // 0, 34, 35, 36
            for (int i = 0; i < 10;  i += (i == 0 ? 34 : 1))
            {
                int[] numbers = new int[] { 20, 20, 22, 13, i };

                // Act
                Bet[] bets = betEvaluator.getSuggestions(numbers);

                // Assert
                Assert.AreEqual(3, bets.Length, "There must be exactly 3 bets");

                NumberBet[] numberBets = bets.Where(bet => bet is NumberBet)
                    .Select(bet => (NumberBet)bet).ToArray();

                Assert.AreEqual(1, numberBets.Length, "There must be exactly 1 number bet");

                SixLineBet[] sixLineBets = bets.Where(bet => bet is SixLineBet)
                    .Select(bet => (SixLineBet)bet).ToArray();

                Assert.AreEqual(1, sixLineBets.Length, "There must be exactly 1 sixline bet");
            }
        }

        [TestMethod("Checks correct two colors bet")]
        public void TwoColors_CorrectBetIsCreated()
        {
            // Arrange
            int[] numbers = new int[] { 3, 2, 1, 3 };

            // Act
            Bet[] bets = betEvaluator.getSuggestions(numbers);

            // Assert
            Assert.AreEqual(1, bets.Length, "There must be exactly 1 bet");

            ColorBet[] colorBets = bets.Where(bet => bet is ColorBet)
                    .Select(bet => (ColorBet)bet).ToArray();

            Assert.AreEqual(1, colorBets.Length, "There must be exactly 1 color bet");
        }

        [TestMethod("Checks two colors bet won't be suggested when only two same color numbers are present")]
        public void TwoColors_BetIsNotCreated_EdgeCase()
        {
            // Arrange
            int[] numbers = new int[] { 9, 12 };

            // Act
            Bet[] bets = betEvaluator.getSuggestions(numbers);

            // Assert
            Assert.AreEqual(0, bets.Length, "There must be no bet");
        }

        [TestMethod("Checks correct switchnig colors bet")]
        public void SwitchingColor_CorrectBetIsCreated()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            // Act
            Bet[] bets = betEvaluator.getSuggestions(numbers);

            // Assert
            Assert.AreEqual(1, bets.Length, "There must be exactly 1 bet");

            ColorBet[] colorBets = bets.Where(bet => bet is ColorBet)
                    .Select(bet => (ColorBet)bet).ToArray();

            Assert.AreEqual(1, colorBets.Length, "There must be exactly 1 color bet");
            Assert.IsFalse(colorBets[0].Red, string.Format("Last color must be black after number {0}", numbers[4]));
        }

        [TestMethod("Checks three of four bet")]
        public void ThreeOfFour_CorrectBetsAreCreated()
        {
            // Arrange
            int[] numbers = new int[] { 3, 4, 3 };

            // Act
            Bet[] bets = betEvaluator.getSuggestions(numbers);

            // Assert
            Assert.AreEqual(4, bets.Length, "There must be exactly 4 bets");

            int[] numberBetsNumbers = bets.Where(bet => bet is NumberBet)
                .Select(bet => ((NumberBet)bet).Number).ToArray();

            Assert.AreEqual(4, numberBetsNumbers.Length, "There must be exactly 4 number bets");

            Array.Sort(numberBetsNumbers);
            int[] reference = new int[4] { 3, 13, 23, 33 };

            Assert.IsTrue(numberBetsNumbers.SequenceEqual(reference),
                string.Format("Values must be ({0}), but they are ({1})",
                string.Join(", ", reference), string.Join(", ", numberBetsNumbers)));
        }

        [TestMethod("Checks color streak after zero bet")]
        public void ColorStreakAfterZero_CorrectBetIsCreated()
        {
            // Arrange
            int[] numbers = new int[] { 1, 8, 9, 25, 12, 0, 9, 12 };

            // Act
            Bet[] bets = betEvaluator.getSuggestions(numbers);

            // Assert
            Assert.AreEqual(1, bets.Length, "There must be exactly 1 bet");


            Assert.AreEqual(true, bets[0] is ColorBet, "The bet must be ColorBet");
            Assert.AreEqual(true, ((ColorBet)bets[0]).Red, "The bet should be placed on red color");
        }

    }
}