using System.Linq;
using RouletteBot.Controllers;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models.Bets
{
    public class ColorBet : Bet
    {
        public bool Red { get; set; }


        public ColorBet(bool red)
        {
            Red = red;
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
            if (Red == RouletteHelper.GetRedNumbers().Contains(lastNumber))
            {
                return Multiplier * 2;
            }

            return 0;
        }
    }
}