namespace RouletteBot.Models
{
    public interface IStatsRecorder
    {
        void recordBetResult(Bet bet, int betAmount, int resultAmount, string gameId, int spin, int number, string rouletteType);
    }
}
