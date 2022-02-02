using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_roulette_bot.Models
{
    internal class Bet
    {
        private Dictionary<int, int> numberBets;

        private int redBetMultiplier;

        private int blackBetMultiplier;

        private List<int> sixlineBets;

        public Dictionary<int, int> NumberBets { get => numberBets; }
        public int RedBetMultiplier { get => redBetMultiplier; }
        public int BlackBetMultiplier { get => blackBetMultiplier; }
        public List<int> SixlineBets { get => sixlineBets; }

        public Bet()
        {
            numberBets = new Dictionary<int,int>();
            redBetMultiplier = 0;
            blackBetMultiplier = 0;
            sixlineBets = new List<int>();
        }

        public void betNumber(int number, int betMultiplier = 1)
        {
            int currentBetMultiplier;

            numberBets.TryGetValue(number, out currentBetMultiplier);

            numberBets[number] = currentBetMultiplier + betMultiplier;
        }

        public void betColor(bool red)
        {
            if(red) redBetMultiplier++;
            else blackBetMultiplier++;
        }

        public void betSixline(int column)
        {
            sixlineBets.Add(column);
        }
    }
}
