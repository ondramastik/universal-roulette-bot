using RouletteBot.Models.Bets;

namespace RouletteBot.Models
{
    public interface IStatsRecorder
    {
        void RecordBetResult(Bet bet, int betAmount, int resultAmount, string gameId, int spin, int number,
            string rouletteType, int lastBefore);
    }
}