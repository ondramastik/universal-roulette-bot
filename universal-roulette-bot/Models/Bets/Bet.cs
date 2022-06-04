using RouletteBot.Controllers;

namespace RouletteBot.Models
{
    public abstract class Bet
    {
        public int Multiplier { get; set; }
        public string RuleName { get; set; }
        public bool isVirtualBet { get; set; }

        protected Bet(string initiedByRule = "Unspecified")
        {
            Multiplier = 1;
            RuleName = initiedByRule;
            isVirtualBet = false;
        }

        public abstract void place(IRouletteControls rouletteControls);

        public abstract int calculateBetResult(int lastNumber);
    }
}
