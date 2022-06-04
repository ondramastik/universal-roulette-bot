namespace RouletteBot.Controllers
{
    public interface IRouletteControls
    {
        /// <summary> Places a bet to a specific number. Returns false if parameters are invalid</summary>
        /// <param name="value">Number within range 0-36</param>
        /// <param name="amount">Amount of credit to bet</param>
        /// <returns>bool</returns>
        bool betOnNumber(int value, int amount);

        /// <summary> Places a bet to a specific color.</summary>
        /// <param name="value">True if red</param>
        /// <param name="amount">Amount of credit to bet</param>
        /// <returns>bool</returns>
        bool betOnColor(bool red, int amount);


        /// <summary> Places a bet to a row. Returns false if parameters are invalid</summary>
        /// <param name="index">Number within range 0-2</param>
        /// <param name="amount">Amount of credit to bet</param>
        /// <returns>bool</returns>
        bool betOnRow(int index, int amount);

        /// <summary> Places a bet to a row. Returns false if parameters are invalid</summary>
        /// <param name="index">Number within range 0-2</param>
        /// <param name="amount">Amount of credit to bet</param>
        /// <returns>bool</returns>
        bool betOnColumn(int index, int amount);

        bool betOnSixLine(int columnIndex, int amount);

        bool spin();
    }
}