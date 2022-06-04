using System;
using System.Collections.Generic;
using RouletteBot.Controllers;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models
{
    public class Game
    {
        private List<int> Numbers { get; }

        private IRouletteControls rouletteControls;

        private IStatsRecorder statsRecorder;

        private Bet[] previousBets;

        private string GameId;

        private string RouletteType;

        public BetEvaluationFileConfig EvaluationConfig { get; set; }


        public Game(IRouletteControls rouletteControls, IStatsRecorder statsRecorder, BetEvaluationFileConfig config,
            string rouletteType)
        {
            GameId = Guid.NewGuid().ToString();
            this.rouletteControls = rouletteControls;
            this.statsRecorder = statsRecorder;
            previousBets = new Bet[0];
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

            foreach (Bet sb in previousBets)
            {
                statsRecorder.RecordBetResult(sb, sb.Multiplier, sb.CalculateBetResult(number), GameId, spin, number,
                    RouletteType, RouletteHelper.GetLastOccurance(Numbers.ToArray(), number, true));
            }

            BetEvaluator betEvaluator = new BetEvaluator(EvaluationConfig);
            Bet[] suggestedBets = betEvaluator.GetSuggestions(Numbers.ToArray(), previousBets);
            BetProcessor betProcessor = new BetProcessor(rouletteControls);
            betProcessor.ProcessBets(suggestedBets);
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