using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using RouletteBot.Controllers;

namespace RouletteBot.Models
{
    public class ColorBet : Bet
    {
        public bool Red { get; set; }


        public ColorBet(bool red)
        {
            this.Red = red;
        }

        public override void place(IRouletteControls rouletteControls)
        {
            if(!isVirtualBet)
            {
                rouletteControls.betOnColor(Red, Multiplier);
            }
        }

        public override int calculateBetResult(int lastNumber)
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
