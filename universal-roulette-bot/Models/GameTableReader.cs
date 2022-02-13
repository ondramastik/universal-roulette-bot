using System.Drawing;
using System.Threading;
using System.Collections.Generic;
using System;

namespace RouletteBot.Models
{
    public class GameTableReader
    {
        private MappingConfig config;

        private static string readyCheckColor;
        private static string readySkipColor = "Color [A=255, R=36, G=200, B=28]";

        private Dictionary<int, Color> defaultNumberColors;

        public GameTableReader(MappingConfig config)
        {
            this.config = config;
            defaultNumberColors = readNumberColors();
        }

        public void readReadyCheckColor()
        {
            readyCheckColor = WinAPI.CreateScreenshot(config.SpinReadyCheckX, config.SpinReadyCheckY, config.SpinReadyCheckX + 1, config.SpinReadyCheckY + 1).GetPixel(0, 0).ToString();
        }

        public void readReadySkipColor()
        {
            readySkipColor = WinAPI.CreateScreenshot(config.ConfirmBetX, config.ConfirmBetY, config.ConfirmBetX + 1, config.ConfirmBetY + 1).GetPixel(0, 0).ToString();
        }

        public int ReadNumber()
        {
            while(true)
            {
                Dictionary<int, Color> checkColors = readNumberColors();

                Color color;
                foreach (KeyValuePair<int, Color> entry in checkColors)
                {
                    if(defaultNumberColors.TryGetValue(entry.Key, out color) && entry.Value.ToString() != color.ToString())
                    {
                        return entry.Key;
                    }
                }

                Thread.Sleep(5);
            }
        }

        public bool IsRoundReady()
        {
            Bitmap check = WinAPI.CreateScreenshot(config.SpinReadyCheckX, config.SpinReadyCheckY, config.SpinReadyCheckX + 1, config.SpinReadyCheckY + 1);

            return check.GetPixel(0, 0).ToString() == readyCheckColor;
        }

        public bool IsSkipReady()
        {
            Bitmap checkSkip = WinAPI.CreateScreenshot(config.ConfirmBetX, config.ConfirmBetY, config.ConfirmBetX + 1, config.ConfirmBetY + 1);
            return checkSkip.GetPixel(0, 0).ToString() == readySkipColor;
        }


        private Dictionary<int, Color> readNumberColors()
        {
            var grid = RouletteHelper.getNumbersGrid();
            var colors = new Dictionary<int, Color>();

            var gridScreenshot = GetGridScreenshot();

            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] < 0) continue;
                    colors.Add(grid[y][x], getNumberColor(grid[y][x], gridScreenshot, x, y));
                }
            }

            return colors;
        }

        private Color getNumberColor(int number, Bitmap gridScreenshot, int x = -1, int y = -1)
        {
            int numberTileWidth = (config.GridRightBottomCornerX - config.GridLeftTopCornerX) / 12;
            int numberTileHeight = (config.GridRightBottomCornerY - config.GridLeftTopCornerY) / 3;
            Point loc = x < 0 ? RouletteHelper.getNumberGridIndex(number) : new Point(x, y);

            int locX = (loc.X * numberTileWidth) + (number != 0 ? config.NumberCheckOffsetX : 20);
            int loxY = (loc.Y * numberTileHeight) + config.NumberCheckOffsetY;

            return gridScreenshot.GetPixel(locX, loxY);
        }

        private Bitmap GetGridScreenshot()
        {
            int numberTileWidth = (config.GridRightBottomCornerX - config.GridLeftTopCornerX) / 12;
            return WinAPI.CreateScreenshot(config.GridLeftTopCornerX - numberTileWidth, config.GridLeftTopCornerY,
                config.GridRightBottomCornerX + numberTileWidth, config.GridRightBottomCornerY);
        }
    }
}
