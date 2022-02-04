using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBot.Models
{
    public interface IStatsRecorder
    {
        void recordBetResult(Bet bet, int betAmount, int resultAmount);
    }
}
