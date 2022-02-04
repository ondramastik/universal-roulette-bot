using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RouletteBot.Models
{
    public class Game
    {

        private static int readyCheckLocationX = 1561;
        private static int readyCheckLocationY = 991;

        private static int readySkipLocationX = 1533;
        private static int readySkipLocationY = 1000;


        private string readyCheckColor = "Color [A=255, R=23, G=195, B=14]";
        private string readySkipColor = "Color [A=255, R=36, G=200, B=28]";

        private List<int> Numbers { get; }

        private IRouletteControls rouletteControls;

        private IStatsRecorder statsRecorder;

        private Bet[] previousBets;

        public BetEvaluationConfig EvaluationConfig { get; set; }

        public Game(IRouletteControls rouletteControls, IStatsRecorder statsRecorder, BetEvaluationConfig config, List<int> initialNumbers = null)
        {
            this.rouletteControls = rouletteControls;
            this.statsRecorder = statsRecorder;
            this.previousBets = new Bet[0];

            if(initialNumbers == null)
            {
                Numbers = new List<int>();
            }
            else
            {
                Numbers = initialNumbers;
            }

            EvaluationConfig = config;
        }

        public int[] playRound(int number)
        {
            if(number >= 0)
            {
                Numbers.Add(number);
            }

            foreach (Bet sb in previousBets)
            {
                statsRecorder.recordBetResult(sb, sb.Multiplier, sb.calculateBetResult(number));
            }

            BetEvaluator betEvaluator = new BetEvaluator(EvaluationConfig);

            Bet[] suggestedBets = betEvaluator.getSuggestions(Numbers.ToArray());

            BetProcessor betProcessor = new BetProcessor(rouletteControls);

            betProcessor.processBets(suggestedBets);
            previousBets = suggestedBets;

            return Numbers.ToArray();
        }

        public bool isRoundReady()
        {
            Bitmap check = WinAPI.CreateScreenshot(readyCheckLocationX, readyCheckLocationY, readyCheckLocationX + 1, readyCheckLocationY + 1);

            bool isReady = check.GetPixel(0, 0).ToString() == readyCheckColor;

            if (!isReady)
            {
                Bitmap checkSkip = WinAPI.CreateScreenshot(readySkipLocationX, readySkipLocationY, readySkipLocationX + 1, readySkipLocationY + 1);
                bool isSkipReady = checkSkip.GetPixel(0, 0).ToString() == readySkipColor;
                if(isSkipReady)
                {
                    /* This should skip it */
                    rouletteControls.spin();
                }

            }

            return isReady; 
            
        }

    }
}
