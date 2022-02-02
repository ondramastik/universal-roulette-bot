using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_roulette_bot.Models
{
    internal class RouletteConstants
    {
        public static int[][] getNumbersGrid()
        {
            int[] first = new int[13] {0, 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36};
            int[] second = new int[13] {0, 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35};
            int[] third = new int[13] {0, 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34};

            return new int[][] {first, second, third};
        }
    }
}
