using RouletteBot.Controllers;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models
{
    public class SixLineBet : Bet
    {
        public int Index { get; }

        public SixLineBet(int number)
        {
            Index = number;
        }

        public override void Place(IRouletteControls rouletteControls)
        {
            if (!IsVirtualBet)
            {
                rouletteControls.betOnSixLine(Index >= 0 ? Index : 0, Multiplier);
            }
        }

        public override int CalculateBetResult(int lastNumber)
        {
            int lastX = RouletteHelper.getNumberGridIndex(lastNumber).X;

            if (lastX == Index || lastX == Index + 1)
            {
                return Multiplier * 6;
            }

            return 0;
        }
    }
}