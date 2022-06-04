using RouletteBot.Controllers;

namespace RouletteBot.Models.Bets
{
    public abstract class Bet
    {
        public int Multiplier { get; set; }
        public string RuleName { get; set; }
        public bool IsVirtualBet { get; set; }

        public int RepeatOnUnsuccessfulTimes { get; set; }

        public int RepeatNumber { get; set; }

        protected Bet(string initiatedByRule = "Unspecified", int repeatOnUnsuccessfulTimes = 0)
        {
            Multiplier = 1;
            RuleName = initiatedByRule;
            IsVirtualBet = false;
            RepeatOnUnsuccessfulTimes = repeatOnUnsuccessfulTimes;
            RepeatNumber = 0;
        }

        public abstract void Place(IRouletteControls rouletteControls);

        public abstract int CalculateBetResult(int lastNumber);
    }
}