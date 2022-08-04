using System;
using System.Collections.Generic;
using System.Linq;
using RouletteBot.Models;
using RouletteBot.Models.Rules;

namespace RouletteBot.Controllers
{
    public class GameController
    {
        private readonly IRouletteControls _rouletteControls;

        private readonly IStatsLogger _statsLogger;

        private List<Rule> _activeRules;

        private readonly BetEvaluationFileConfig _evaluationConfig;

        public List<int> Numbers { get; }

        public string GameId { get; }

        public string RouletteType { get; }


        public GameController(IRouletteControls rouletteControls, IStatsLogger statsLogger,
            BetEvaluationFileConfig config,
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
            Numbers.Add(number);

            var rulesFactory = new RulesFactory(_evaluationConfig);
            var suggestedRules = rulesFactory.GetApplicableRules(Numbers.ToArray());

            _activeRules = _activeRules.Where(rule => !rule.Fulfilled).Concat(suggestedRules).ToList();

            var bets = _activeRules.SelectMany(rule => rule.GetBets(Numbers));

            if (!bets.Any() && _evaluationConfig.EnableNeutralBet)
            {
                new ColorBet(true) { RuleName = "NeutralBet", IsVirtualBet = false }.Place(_rouletteControls);
                new ColorBet(false) { RuleName = "NeutralBet", IsVirtualBet = false }.Place(_rouletteControls);
            }

            foreach (var bet in bets)
            {
                bet.Place(_rouletteControls);
            }

            _rouletteControls.spin();

            return Numbers.ToArray();
        }
    }
}