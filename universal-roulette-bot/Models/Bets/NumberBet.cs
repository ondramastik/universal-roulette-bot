using RouletteBot.Controllers;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models
{
    public class NumberBet : Bet
    {
        public int Number { get; }

        public NumberBet(int number)
        {
            Number = number;
        }

        public override void Place(IRouletteControls rouletteControls)
        {
            if (!IsVirtualBet)
            {
                rouletteControls.betOnNumber(Number, Multiplier);
            }
        }

        public override int CalculateBetResult(int lastNumber)
        {
            if (Number == lastNumber)
            {
                return Multiplier * 36;
            }

            return 0;
        }
    }
}