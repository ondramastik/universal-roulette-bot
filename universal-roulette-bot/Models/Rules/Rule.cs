using System.Collections.Generic;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models.Rules
{
    public abstract class Rule
    {
        public string RuleName { get; set; }
        public bool Fulfilled { get; set; }

        protected Bet[] Bets;
        protected int RepeatTimes { get; set; }

        protected int RepeatedTimes { get; set; }

        protected Rule(Bet[] bets, int repeatTimes = 0)
        {
            Bets = bets;
            RepeatTimes = repeatTimes;
            RepeatedTimes = 0;
            Fulfilled = false;
        }

        public abstract Bet[] GetBets(IReadOnlyCollection<int> numbers, int currentSpin, BetEvaluationConfig config);

        public void Evaluate(int lastNumber)
        {
            int win = 0;
            foreach (var bet in Bets)
            {
                win += bet.CalculateBetResult(lastNumber);
            }

            if (win > 0)
            {
                Fulfilled = true;
                return;
            }

            if (RepeatedTimes >= RepeatTimes)
            {
                Fulfilled = true;
            }

            RepeatedTimes++;
        }
    }
}