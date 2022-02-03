using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBot.Models
{
    public abstract class Bet
    {
        protected int multiplier = 1;

        public int Multiplier { set => multiplier = value; }

        public abstract void place(IRouletteControls rouletteControls);
    }
}
