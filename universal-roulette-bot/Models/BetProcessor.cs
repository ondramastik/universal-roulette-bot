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

        public void processBets(Bet[] bets, int betAmount = 1)
        {
            foreach (Bet bet in bets)
            {
                bet.Place(rouletteControls);
            }

            rouletteControls.spin();
        }
    }
}