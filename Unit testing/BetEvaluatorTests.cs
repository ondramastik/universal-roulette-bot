using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouletteBot.Models;

namespace RouletteBotTests
{
    [TestClass]
    public class BetEvaluatorTests
    {
        private readonly RulesFactory _rulesFactory = new(new BetEvaluationTestConfig());

        [TestMethod("Checks correct try SixLine bets for normal case")]
        public void SixLines_CorrectBetsAreCreated()
        {
            // Arrange
            var numbers = new[] { 1, 2, 3, 7, 15 };

            // Act
            var rules = _rulesFactory.GetApplicableRules(numbers);

            // Assert
            Assert.AreEqual(3, rules.Count, "There must be exactly 3 bets");

            var sixLineBetIndexes = rules.SelectMany(rule => rule.GetBets(numbers)
                    .Where(bet => bet is SixLineBet))
                .Select(bet => ((SixLineBet)bet).Index).ToArray();

            Assert.AreEqual(2, sixLineBetIndexes.Length, "There must be exactly 2 SixLine bets");
            Assert.IsTrue(Math.Abs(sixLineBetIndexes[0] - sixLineBetIndexes[1]) == 1,
                "SixLine bets must be next to each other");

            var lastNumberX = RouletteHelper.getNumberGridIndex(numbers[4]).X;
            Array.Sort(sixLineBetIndexes);

            Assert.IsTrue(lastNumberX == sixLineBetIndexes[0], "First SixLine bet index must be same as last number X");

            var numberBetNumbers = rules.SelectMany(rule => rule.GetBets(numbers)
                    .Where(bet => bet is NumberBet))
                .Select(bet => ((NumberBet)bet).Number).ToArray();

            Assert.AreEqual(1, numberBetNumbers.Length, "There must be exactly 1 number bet");
            Assert.IsTrue((numberBetNumbers[0] % 10 == numbers[3] % 10), "Incorrect number bet");
        }

        [TestMethod("Checks correct second try SixLine bets for normal case")]
        public void SixLines_CorrectBetsAreCreated_SecondTryCase()
        {
            // Arrange
            var numbers = new[] { 1, 2, 3, 7, 15, 3 };

            // Act
            var rules = _rulesFactory.GetApplicableRules(numbers);

            // Assert
            Assert.AreEqual(3, rules.Count, "There must be exactly 3 bets");

            var sixLineBetIndexes = rules.SelectMany(rule => rule.GetBets(numbers)
                    .Where(bet => bet is SixLineBet))
                .Select(bet => ((SixLineBet)bet).Index).ToArray();

            Assert.AreEqual(2, sixLineBetIndexes.Length, "There must be exactly 3 SixLine bets");
            Assert.IsTrue(Math.Abs(sixLineBetIndexes[0] - sixLineBetIndexes[1]) == 1,
                "SixLine bets must be next to each other");

            var beforeLastNumberX = RouletteHelper.getNumberGridIndex(numbers[4]).X;
            Array.Sort(sixLineBetIndexes);

            Assert.IsTrue(beforeLastNumberX == sixLineBetIndexes[0],
                "First SixLine bet index must be same as last number X");
        }


        [TestMethod("Checks correct SixLine bets for edge cases")]
        public void SixLines_CorrectBetsAreCreated_EdgeCase()
        {
            // 0, 34, 35, 36
            for (var i = 0; i < 10; i += (i == 0 ? 34 : 1))
            {
                var numbers = new[] { 20, 20, 22, 13, i };

                // Act
                var rules = _rulesFactory.GetApplicableRules(numbers);

                // Assert
                Assert.AreEqual(4, rules.Count, "There must be exactly 4 bets");

                var numberBets = rules.OfType<NumberBet>().ToArray();

                if (i == 0)
                {
                    Assert.AreEqual(2, numberBets.Length, "There must be exactly 2 number bet");
                }
                else
                {
                    Assert.AreEqual(1, numberBets.Length, "There must be exactly 1 number bet");
                }

                var sixLineBets = rules.OfType<SixLineBet>().ToArray();

                Assert.AreEqual(1, numberBets.Length, "There must be exactly 1 SixLine bet");
            }
        }

        [TestMethod("Checks correct two colors bet")]
        public void TwoColors_CorrectBetIsCreated()
        {
            // Arrange
            var numbers = new[] { 3, 2, 1, 3 };

            // Act
            var rules = _rulesFactory.GetApplicableRules(numbers)
                .Where(v => v.RuleName == "TwoColorsInRow").ToArray();

            // Assert
            Assert.AreEqual(1, rules.Length, "There must be exactly 1 bet");

            var colorBets = rules.OfType<ColorBet>().ToArray();

            Assert.AreEqual(1, colorBets.Length, "There must be exactly 1 color bet");
        }

        [TestMethod("Checks two colors bet won't be suggested when only two same color numbers are present")]
        public void TwoColors_BetIsNotCreated_EdgeCase()
        {
            // Arrange
            var numbers = new[] { 9, 12 };

            // Act
            var rules = _rulesFactory.GetApplicableRules(numbers)
                .Where(v => v.RuleName == "TwoColorsInRow").ToArray();

            // Assert
            Assert.AreEqual(0, rules.Length, "There must be no bet");
        }

        [TestMethod("Checks correct switching colors bet")]
        public void ColorSwitching_CorrectBetIsCreated()
        {
            // Arrange
            var numbers = new[] { 1, 2, 3, 4, 5 };

            // Act
            var rules = _rulesFactory.GetApplicableRules(numbers)
                .Where(v => v.RuleName == "ColorsSwitching").ToArray();

            // Assert
            Assert.AreEqual(1, rules.Length, "There must be exactly 1 bet");

            var colorRules = rules.OfType<ColorBet>().ToArray();

            Assert.AreEqual(1, colorRules.Length, "There must be exactly 1 color bet");
            Assert.IsFalse(colorRules[0].Red, $"Last color must be black after number {numbers[4]}");
        }

        [TestMethod("Checks three of four bet")]
        public void ThreeOfFour_CorrectBetsAreCreated()
        {
            // Arrange
            var numbers = new[] { 3, 4, 3 };

            // Act
            var rules = _rulesFactory.GetApplicableRules(numbers)
                .Where(v => v.RuleName == "ThreeOfFour").ToArray();

            // Assert
            Assert.AreEqual(4, rules.Length, "There must be exactly 4 bets");

            var numberBetsNumbers = rules.SelectMany(rule => rule.GetBets(numbers)
                    .Where(bet => bet is NumberBet))
                .Select(bet => ((NumberBet)bet).Number).ToArray();

            Assert.AreEqual(4, numberBetsNumbers.Length, "There must be exactly 4 number bets");

            Array.Sort(numberBetsNumbers);
            var reference = new[] { 3, 13, 23, 33 };

            Assert.IsTrue(numberBetsNumbers.SequenceEqual(reference),
                $"Values must be ({string.Join(", ", reference)}), but they are ({string.Join(", ", numberBetsNumbers)})");
        }

        [TestMethod("Checks color streak after zero bet")]
        public void ColorStreakAfterZero_CorrectBetIsCreated()
        {
            // Arrange
            var numbers = new[] { 1, 8, 9, 25, 12, 0, 9, 12 };

            // Act
            var rules = _rulesFactory.GetApplicableRules(numbers);

            // Assert
            Assert.AreEqual(1, rules.Count, "There must be exactly 1 bet");


            Assert.AreEqual(true, rules.Single().GetBets(numbers).Any(bet => bet is ColorBet),
                "The bet must be ColorBet");
            Assert.AreEqual(true, ((ColorBet)rules.Single().GetBets(numbers).Single()).Red,
                "The bet should be placed on red color");
        }
    }
}