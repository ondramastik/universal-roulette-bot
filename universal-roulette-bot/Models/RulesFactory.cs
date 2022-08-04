using System;
using System.Collections.Generic;
using System.Linq;
using RouletteBot.Models.Bets;
using RouletteBot.Models.Rules;

namespace RouletteBot.Models
{
    public class RulesFactory
    {
        private readonly BetEvaluationConfig _config;

        public RulesFactory(BetEvaluationConfig evaluationConfig = null)
        {
            _config = evaluationConfig ?? new BetEvaluationFileConfig();
        }

        public IReadOnlyCollection<Rule> GetApplicableRules(int[] numbers)
        {
            var rules = new List<Rule>();

            if (numbers.Length < 1) return rules;

            var lastNumber = numbers[numbers.Length - 1];
            if (_config.ThreeOfFour)
                rules.Add(new ThreeOfFourRule(_config));
            if (_config.ColorSwitching)
                rules.Add(new ColorsSwitchingRule(_config));
            if (_config.RedAfterZero)
                rules.Add(new RedAfterZeroRule(_config));
            if (_config.SixLineBet)
                rules.Add(new SixLineRule(RouletteHelper.FindIndex(lastNumber), _config));
            if (_config.ColorStreakAfterZero)
                rules.Add(new SameColorStreakAfterZeroRule(_config));
            if (_config.TwoColorsInRow)
                rules.Add(new TwoColorsInRowRule(_config));
            if (_config.FirstFiveBlack)
                rules.Add(new FirstFiveBlackRule(_config));


            return rules.Where(rule => rule.IsApplicable(numbers)) as IReadOnlyCollection<Rule>;
        }
    }
}