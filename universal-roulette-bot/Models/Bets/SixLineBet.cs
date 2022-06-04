using RouletteBot.Controllers;

namespace RouletteBot.Models
{
    public class SixLineBet : Bet
    {
        public int Index { get; }

        public SixLineBet(int number)
        {
            this.Index = number;
        }

        public override void place(IRouletteControls rouletteControls)
        {
            if (!isVirtualBet)
            {
                rouletteControls.betOnSixline(Index >= 0 ? Index : 0, Multiplier);
            }
        }

        public override int calculateBetResult(int lastNumber)
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
