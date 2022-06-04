using RouletteBot.Controllers;

namespace RouletteBot.Models.Bets
{
    public abstract class Bet
    {
        public int Multiplier { get; set; }
        public string RuleName { get; set; }
        public bool IsVirtualBet { get; set; }

        protected Bet(string initiatedByRule = "Unspecified")
        {
            Multiplier = 1;
            RuleName = initiatedByRule;
            IsVirtualBet = false;
        }

        public abstract void Place(IRouletteControls rouletteControls);

        public abstract int CalculateBetResult(int lastNumber);
    }
}