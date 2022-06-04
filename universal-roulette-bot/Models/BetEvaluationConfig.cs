namespace RouletteBot.Models
{
    public abstract class BetEvaluationConfig
    {
        public bool EnableNeutralBet { get; set; }
        public bool SixlineBet { get; set; }
        public int SixlineBetAmount { get; set; }
        public bool SixlineBetNumberBefore { get; set; }
        public int SixlineBetNumberBeforeAmount { get; set; }
        public bool SecondSixlineBet { get; set; }
        public int SecondSixlineBetAmount { get; set; }
        public bool SecondSixlineBetNumberBefore { get; set; }
        public int SecondSixlineBetNumberBeforeAmount { get; set; }
        public bool ThreeOfFour { get; set; }
        public int ThreeOfFourAmount { get; set; }
        public bool FirstFiveBlack { get; set; }
        public int FirstFiveBlackAmount { get; set; }
        public bool ColorSwitching { get; set; }
        public int ColorSwitchingAmount { get; set; }
        public bool TwoColorsInRow { get; set; }
        public int TwoColorsInRowAmount { get; set; }
        public bool ColorStreakAfterZero { get; set; }
        public int ColorStreakAfterZeroAmount { get; set; }
        public bool RedAfterZero { get; set; }
        public int RedAfterZeroAmount { get; set; }
        public bool LongTimeNoSee { get; set; }
        public int LongTimeNoSeeAmount { get; set; }
        public int LongTimeNoSeeFrom { get; set; }
        public int LongTimeNoSeeTo { get; set; }

    }
}
