using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_roulette_bot.Models
{
    internal class BetProcessor
    {
        private IRouletteControls rouletteControls;

        public BetProcessor(IRouletteControls rouletteControls)
        {
            this.rouletteControls = rouletteControls;
        }

        public void processBets(Bet[] bets, int betAmount = 1)
        {

            if (bets.Length == 0)
            {
                Bet bet = new Bet();
                bet.betColor(true);
                bet.betColor(false);
                bets = bets.Append(bet).ToArray();
            }

            foreach (Bet bet in bets)
            {
                foreach (var item in bet.NumberBets)
                {
                    rouletteControls.betOnNumber(item.Key, item.Value * betAmount);
                }


                if (bet.RedBetMultiplier > 0) rouletteControls.betOnColor(true, bet.RedBetMultiplier * betAmount);
                if (bet.BlackBetMultiplier > 0) rouletteControls.betOnColor(false, bet.BlackBetMultiplier * betAmount);

                foreach(int index in bet.SixlineBets)
                {
                    if(index == 0 || index == 12)
                    {
                        rouletteControls.betOnSixline(index, 4);
                    }
                    else if(index == 1)
                    {
                        rouletteControls.betOnSixline(index - 1, 1);
                        rouletteControls.betOnSixline(index, 3);
                    }
                    else
                    {
                        rouletteControls.betOnSixline(index - 1, 2);
                        rouletteControls.betOnSixline(index, 2);
                    }
                }
            }

            rouletteControls.spin();
        }
    }
}
