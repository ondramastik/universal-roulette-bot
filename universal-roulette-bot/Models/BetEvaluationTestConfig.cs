namespace RouletteBot.Models
{
    public class BetEvaluationTestConfig : BetEvaluationConfig
    {
        public BetEvaluationTestConfig()
        {
            EnableNeutralBet = false;
            SixLineBet = true;
            SixLineBetAmount = 1;
            SixLineBetNumberBefore = true;
            SixLineBetNumberBeforeAmount = 1;
            SecondSixLineBet = true;
            SecondSixLineBetAmount = 1;
            SecondSixLineBetNumberBefore = true;
            SecondSixLineBetNumberBeforeAmount = 1;
            ThreeOfFour = true;
            ThreeOfFourAmount = 1;
            FirstFiveBlack = true;
            FirstFiveBlackAmount = 1;
            ColorSwitching = true;
            ColorSwitchingAmount = 1;
            TwoColorsInRow = true;
            TwoColorsInRowAmount = 1;
            ColorStreakAfterZero = true;
            ColorStreakAfterZeroAmount = 1;
            RedAfterZero = true;
            RedAfterZeroAmount = 1;
            LongTimeNoSee = false;
            LongTimeNoSeeAmount = 1;
            LongTimeNoSeeFrom = 1;
            LongTimeNoSeeTo = 1;
        }
    }
}