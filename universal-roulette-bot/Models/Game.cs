using System.Collections.Generic;
using System;

namespace RouletteBot.Models
{
    public class Game
    {

        private List<int> Numbers { get; }

        private IRouletteControls rouletteControls;

        private IStatsRecorder statsRecorder;

        private Bet[] previousBets;

        private string GameId;

        public BetEvaluationConfig EvaluationConfig { get; set; }



        public Game(IRouletteControls rouletteControls, IStatsRecorder statsRecorder, BetEvaluationConfig config, List<int> initialNumbers = null)
        {
            this.GameId = Guid.NewGuid().ToString();
            this.rouletteControls = rouletteControls;
            this.statsRecorder = statsRecorder;
            this.previousBets = new Bet[0];

            if (initialNumbers == null)
            {
                Numbers = new List<int>();
            }
            else
            {
                Numbers = initialNumbers;
            }

            EvaluationConfig = config;
        }

        public int[] playRound(int number, int spin)
        {
            if(number >= 0)
            {
                Numbers.Add(number);
            }

            foreach (Bet sb in previousBets)
            {
                statsRecorder.recordBetResult(sb, sb.Multiplier, sb.calculateBetResult(number), GameId, spin, number);
            }

            BetEvaluator betEvaluator = new BetEvaluator(EvaluationConfig);

            Bet[] suggestedBets = betEvaluator.getSuggestions(Numbers.ToArray());

            BetProcessor betProcessor = new BetProcessor(rouletteControls);

            betProcessor.processBets(suggestedBets);
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
