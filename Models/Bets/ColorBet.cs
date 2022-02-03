using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

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
            rouletteControls.betOnColor(Red, multiplier);
        }
    }
}
