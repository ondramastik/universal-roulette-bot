using System.Linq;
using RouletteBot.Controllers;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models
{
    public class ColorBet : Bet
    {
        public bool Red { get; set; }


        public ColorBet(bool red)
        {
            this.Red = red;
        }

        public override void Place(IRouletteControls rouletteControls)
        {
            if (!IsVirtualBet)
            {
                rouletteControls.betOnColor(Red, Multiplier);
            }
        }

        public override int CalculateBetResult(int lastNumber)
        {
            if (lastNumber == 0) return 0;
            else if (Red == RouletteHelper.getRedNumbers().Contains(lastNumber))
            {
                return Multiplier * 2;
            }

            return 0;
        }
    }
}