using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RouletteBot.Models
{
    public class SixLineBet : Bet
    {
        public int Index { get; }

        public SixLineBet(int number)
        {
            this.Index = number;
        }

        public override void place(IRouletteControls rouletteControls)
        {
            rouletteControls.betOnSixline(Index, multiplier);
        }
    }
}
