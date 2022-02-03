using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RouletteBot.Models
{
    public class ColorBet : Bet
    {
        private bool red;


        public ColorBet(bool red)
        {
            this.red = red;
        }

        public override void place(IRouletteControls rouletteControls)
        {
            rouletteControls.betOnColor(red, multiplier);
        }
    }
}
