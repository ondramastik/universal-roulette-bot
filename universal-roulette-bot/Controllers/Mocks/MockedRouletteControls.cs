using System;
using RouletteBot.Controllers;

namespace RouletteBot.Models
{
    public class MockedRouletteControls : IRouletteControls
    {
        bool IRouletteControls.betOnColumn(int index, int amount)
        {
            return true;
        }

        bool IRouletteControls.betOnNumber(int value, int amount)
        {
            return true;
        }

        bool IRouletteControls.betOnColor(bool red, int amount)
        {
            return true;
        }

        bool IRouletteControls.betOnRow(int index, int amount)
        {
            throw new NotImplementedException();
        }

        bool IRouletteControls.betOnSixLine(int columnIndex, int amount)
        {
            return true;
        }

        bool IRouletteControls.spin()
        {
            return true;
        }
    }
}