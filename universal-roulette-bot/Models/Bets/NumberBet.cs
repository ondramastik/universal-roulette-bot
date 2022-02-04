using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RouletteBot.Models
{
    public class NumberBet : Bet
    {
        public int Number { get; }


        public NumberBet(int number)
        {
            this.Number = number;
        }

        public override void place(IRouletteControls rouletteControls)
        {
            rouletteControls.betOnNumber(Number, Multiplier);
        }

        public override int calculateBetResult(int lastNumber)
        {
            if(Number == lastNumber)
            {
                return Multiplier * 36;
            }
            return 0;
        }
    }
}
