using System;
using System.Collections.Generic;
using System.Linq;
using RouletteBot.Controllers;
using RouletteBot.Models.Bets;
using RouletteBot.Models.Rules;

namespace RouletteBot.Models
{
    public class Game
    {
        private readonly IRouletteControls _rouletteControls;

        private readonly IStatsLogger _statsLogger;

        private List<Rule> _activeRules;

        private readonly BetEvaluationFileConfig _evaluationConfig;

        public List<int> Numbers { get; }

        public string GameId { get; }

        public string RouletteType { get; }


        public Game(IRouletteControls rouletteControls, IStatsLogger statsLogger, BetEvaluationFileConfig config,
            string rouletteType)
        {
            _rouletteControls = rouletteControls;
            _statsLogger = statsLogger;
            _activeRules = new List<Rule>();
            Numbers = new List<int>();
            _evaluationConfig = config;
            RouletteType = rouletteType;
            GameId = Guid.NewGuid().ToString();
        }

        public void Evaluate(int number, int spin)
        {
            _activeRules.ForEach(rule => rule.EvaluateBets(number, spin, this, _statsLogger));
        }

        public int[] PlayRound(int number)
        {
            if (number >= 0)
            {
                Numbers.Add(number);
            }

            var rulesGenerator = new RulesFactory(_evaluationConfig);
            var suggestedRules = rulesGenerator.GetApplicableRules(Numbers.ToArray());

            _activeRules = _activeRules.Where(rule => !rule.Fulfilled).Concat(suggestedRules).ToList();

            foreach (var bet in _activeRules.SelectMany(rule =>
                         rule.IsApplicable(Numbers) ? rule.GetBets(Numbers) : new List<Bet>()))
            {
                bet.Place(_rouletteControls);
            }

            _rouletteControls.spin();

            return Numbers.ToArray();
        }
    }
}