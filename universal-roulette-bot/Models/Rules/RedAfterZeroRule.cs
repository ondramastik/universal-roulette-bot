using System.Collections.Generic;
using System.Linq;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models.Rules
{
    public class RedAfterZeroRule : Rule
    {
        public RedAfterZeroRule(BetEvaluationConfig evaluationConfig) : base(evaluationConfig)
        {
            RuleName = "RedAfterZero";
        }

        public override bool IsApplicable(IReadOnlyCollection<int> numbers)
        {
            return numbers.Count >= 1 && numbers.Last() == 0;
        }

        protected override IReadOnlyCollection<Bet> GenerateBets(IReadOnlyCollection<int> numbers)
        {
            return new Bet[]
                { new ColorBet(true) { Multiplier = EvaluationConfig.RedAfterZeroAmount, RuleName = RuleName } };
        }
    }
}