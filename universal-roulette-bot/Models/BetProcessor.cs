using RouletteBot.Controllers;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models
{
    internal class BetProcessor
    {
        private IRouletteControls rouletteControls;

        public BetProcessor(IRouletteControls rouletteControls)
        {
            this.rouletteControls = rouletteControls;
        }

        public void ProcessBets(Bet[] bets)
        {
            foreach (Bet bet in bets)
            {
                bet.Place(rouletteControls);
            }
        }
    }
}