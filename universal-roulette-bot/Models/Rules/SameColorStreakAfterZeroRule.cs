using System.Collections.Generic;
using System.Linq;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models.Rules
{
    public class SameColorStreakAfterZeroRule : Rule
    {
        public SameColorStreakAfterZeroRule(BetEvaluationConfig evaluationConfig) : base(evaluationConfig, 0)
        {
            RuleName = "SameColorStreakAfterZero";
        }

        public override bool IsApplicable(IReadOnlyCollection<int> numbers)
        {
            if (numbers.Count < 3) return false;

            var colorsAfterZero = GetColorsAfterZero(numbers);

            var distinctValues = colorsAfterZero.Distinct().ToArray();

            return distinctValues.Length == 1;
        }

        protected override IReadOnlyCollection<Bet> GenerateBets(IReadOnlyCollection<int> numbers)
        {
            var colorsAfterZero = GetColorsAfterZero(numbers);

            var distinctValues = colorsAfterZero.Distinct().ToArray();

            return new Bet[]
            {
                new ColorBet(distinctValues[0])
                {
                    RuleName = RuleName, Multiplier = EvaluationConfig.ColorStreakAfterZeroAmount
                }
            };
        }

        private static IReadOnlyCollection<bool> GetColorsAfterZero(IEnumerable<int> numbers)
        {
            var colorsAfterZero = new List<bool>();
            var hasZero = false;

            foreach (var number in numbers)
            {
                if (number == 0)
                {
                    if (hasZero)
                    {
                        colorsAfterZero.Clear();
                    }
                    else
                    {
                        hasZero = true;
                    }
                }
                else if (hasZero)
                {
                    colorsAfterZero.Add(RouletteHelper.IsRed(number));
                }
            }

            return colorsAfterZero;
        }
    }
}