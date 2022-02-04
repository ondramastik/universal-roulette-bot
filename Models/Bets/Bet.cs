namespace RouletteBot.Models
{
    public abstract class Bet
    {
        public int Multiplier { get; set; }
        public string RuleName { get; set; }

        protected Bet(string initiedByRule = "Unspecified")
        {
            Multiplier = 1;
            RuleName = initiedByRule;
        }

        public abstract void place(IRouletteControls rouletteControls);

        public abstract int calculateBetResult(int lastNumber);
    }
}
