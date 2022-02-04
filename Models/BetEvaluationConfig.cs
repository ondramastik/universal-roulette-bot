namespace RouletteBot.Models
{
    public class BetEvaluationConfig
    {
        /// <summary>
        /// Whether to suggest neutral bet when no bet is evaluated. Neutral bets are useful for rulettes with manual spin control. Default is true
        /// </summary>
        public bool NeutralBetOnEmpty { get; set; }

        /// <summary>
        /// Whether to bet double amount on six lines. Default is true
        /// </summary>
        public bool DoubleSixLineBets { get; set; }

        public BetEvaluationConfig()
        {
            NeutralBetOnEmpty = true;
            DoubleSixLineBets = true;
        }
    }
}
