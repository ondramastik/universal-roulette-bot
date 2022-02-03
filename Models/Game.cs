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

        private List<int> numbers = new List<int>();

        private IRouletteControls rouletteControls;

        public Game(IRouletteControls rouletteControls)
        {
            this.rouletteControls = rouletteControls;
        }

        public int[] playRound(int number)
        {
            if(number >= 0)
            {
                numbers.Add(number);
            }
            BetEvaluator betEvaluator = new BetEvaluator();

            Bet[] suggestedBets = betEvaluator.getSuggestions(numbers.ToArray());

            BetProcessor betProcessor = new BetProcessor(rouletteControls);

            betProcessor.processBets(suggestedBets);

            return numbers.ToArray();
        }

        public bool isRoundReady()
        {
            Bitmap check = WinAPI.CreateScreenshot(readyCheckLocationX, readyCheckLocationY, readyCheckLocationX + 1, readyCheckLocationY + 1);


            //MessageBox.Show(check.GetPixel(0, 0).ToString() + " == " + readyCheckColor + " je " + (check.GetPixel(0, 0).ToString() == readyCheckBitmap.GetPixel(0, 0).ToString()).ToString());
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
