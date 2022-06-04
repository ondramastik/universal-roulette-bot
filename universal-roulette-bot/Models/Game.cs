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
        private List<int> Numbers { get; }

        private IRouletteControls rouletteControls;

        private IStatsRecorder statsRecorder;

        private List<Rule> activeRules;

        private IReadOnlyCollection<Bet> previousBets;

        private string GameId;

        private string RouletteType;

        public BetEvaluationFileConfig EvaluationConfig { get; set; }


        public Game(IRouletteControls rouletteControls, IStatsRecorder statsRecorder, BetEvaluationFileConfig config,
            string rouletteType)
        {
            GameId = Guid.NewGuid().ToString();
            this.rouletteControls = rouletteControls;
            this.statsRecorder = statsRecorder;
            activeRules = new List<Rule>();
            previousBets = Array.Empty<Bet>();
            Numbers = new List<int>();
            EvaluationConfig = config;
            RouletteType = rouletteType;
        }

        public int[] PlayRound(int number, int spin)
        {
            if (number >= 0)
            {
                Numbers.Add(number);
            }

            foreach (var sb in previousBets)
            {
                statsRecorder.RecordBetResult(sb, sb.Multiplier, sb.CalculateBetResult(number), GameId, spin, number,
                    RouletteType, RouletteHelper.GetLastOccurance(Numbers.ToArray(), number, true));
            }

            foreach (var rule in activeRules)
            {
                rule.Evaluate(number);
            }

            var rulesEvaluator = new RulesEvaluator(EvaluationConfig);
            var suggestedRules = rulesEvaluator.GetEligibleRules(Numbers.ToArray());

            activeRules = activeRules.Where(rule => !rule.Fulfilled).ToList();
            activeRules.AddRange(suggestedRules);
            
            var suggestedBets = activeRules.SelectMany(rule => rule.GetBets(Numbers, spin, EvaluationConfig)).ToList();
            suggestedBets.Add(new ColorBet(true) { RuleName = "NeutralBet" });
            suggestedBets.Add(new ColorBet(false) { RuleName = "NeutralBet" });
            
            var betProcessor = new BetProcessor(rouletteControls);
            betProcessor.ProcessBets(suggestedBets.ToArray());
            rouletteControls.spin();
            previousBets = suggestedBets;

            return Numbers.ToArray();
        }

        public bool Spin()
        {
            rouletteControls.spin();
            return true;
        }
    }
}