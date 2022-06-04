using System;
using System.Threading;
using RouletteBot.Models;

namespace RouletteBot.Controllers
{

    public class MouseRouletteControls : IRouletteControls
    {   
        static int delay = 150;

        private MappingConfig config;

        public MouseRouletteControls(MappingConfig config)
        {
            this.config = config;
        }

        bool IRouletteControls.betOnColumn(int index, int amount)
        {
            return true;
        }

        bool IRouletteControls.betOnNumber(int value, int amount)
        {
            int numberTileWidth = (config.GridRightBottomCornerX - config.GridLeftTopCornerX) / 12;
            int numberTileHeight = (config.GridRightBottomCornerY - config.GridLeftTopCornerY) / 3;

            var grid = RouletteHelper.getNumbersGrid();

            for(int y = 0; y < grid.Length; y++)
            {
                for (int x = y == 1 ? 0 : 1; x < grid[y].Length; x++)
                {
                    if(grid[y][x] == value)
                    {
                        int middleONumberLocationX = ((x - 1) * numberTileWidth) + (numberTileWidth / 2)  + config.GridLeftTopCornerX;
                        int middleONumberLocationY = (y * numberTileHeight) + (numberTileHeight / 2)  + config.GridLeftTopCornerY;

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
                WinAPI.MouseMove(config.RedBetX, config.RedBetY);
            }
            else
            {
                WinAPI.MouseMove(config.BlackBetX, config.BlackBetY);
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
            int numberTileWidth = (config.GridRightBottomCornerX - config.GridLeftTopCornerX) / 12;
            WinAPI.MouseMove(config.GridLeftTopCornerX - numberTileWidth + (columnIndex * numberTileWidth), config.SixLineBetY);
            Thread.Sleep(delay);
            click(amount);

            return true;
        }

        bool IRouletteControls.spin()
        {
            WinAPI.MouseMove(config.ConfirmBetX, config.ConfirmBetY);
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
