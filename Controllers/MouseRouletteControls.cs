using System;
using System.Threading;

namespace RouletteBot.Models
{

    public class MouseRouletteControls : IRouletteControls
    {
        static int delay = 150; // TODO: Configuration file

        static int gridLocationX = 815;
        static int gridLocationY = 600;
        static int gridWidth = 642;
        static int gridHeight = 250;

        static int numberTileWidth = gridWidth / 12;
        static int numberTileHeight = gridHeight / 3;

        private static int locationOfTurnButtonX = 1533;
        private static int locationOfTurnButtonY = 1000;

        private static int locationOfRedButtonX = 1080;
        private static int locationOfRedButtonY = 885;

        private static int locationOfBlackButtonX = 1188;
        private static int locationOfBlackButtonY = 885;

        private static int locationOfSixlineY = 608;

        bool IRouletteControls.betOnColumn(int index, int amount)
        {
            return true;
        }

        bool IRouletteControls.betOnNumber(int value, int amount)
        {
            var grid = RouletteHelper.getNumbersGrid();

            for(int y = 0; y < grid.Length; y++)
            {
                for (int x = y == 1 ? 0 : 1; x < grid[y].Length; x++)
                {
                    if(grid[y][x] == value)
                    {
                        int middleONumberLocationX = ((x - 1) * numberTileWidth) + (numberTileWidth / 2)  + gridLocationX;
                        int middleONumberLocationY = (y * numberTileHeight) + (numberTileHeight / 2)  + gridLocationY;

                        WinAPI.MouseMove(middleONumberLocationX, middleONumberLocationY);
                        Thread.Sleep(delay);
                        click(amount);
                    }
                }
            }

            return true;
        }

        bool IRouletteControls.betOnColor(bool red, int amount)
        {
            if(red)
            {
                WinAPI.MouseMove(locationOfRedButtonX, locationOfRedButtonY);
            }
            else
            {
                WinAPI.MouseMove(locationOfBlackButtonX, locationOfBlackButtonY);
            }

            Thread.Sleep(delay);
            click(amount);

            return true;
        }

        bool IRouletteControls.betOnRow(int index, int amount)
        {
            throw new NotImplementedException();
        }

        bool IRouletteControls.betOnSixline(int columnIndex, int amount)
        {
            WinAPI.MouseMove(gridLocationX - numberTileWidth + (columnIndex * numberTileWidth), locationOfSixlineY);
            Thread.Sleep(delay);
            click(amount);

            return true;
        }

        bool IRouletteControls.spin()
        {
            WinAPI.MouseMove(locationOfTurnButtonX, locationOfTurnButtonY);
            Thread.Sleep(delay);
            click();

            return true;
        }

        private void click(int times = 1)
        {

            for (int i = 1; i <= times; i++) {
                WinAPI.MouseClick("left");
            }
            
        }
    }
}
