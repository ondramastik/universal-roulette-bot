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

        public void HighlightConfiguredMapping(int duration = 5000)
        {
            int thickness = 4;
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (duration > 0)
                {
                    Thread.Sleep(50);
                    HighlightNumbersGrid(thickness);
                    highlightNumberCheckPixels(thickness);

                    duration-= 50;
                }
            }).Start();
        }

        private void HighlightNumbersGrid(int thickness)
        {
            // Top line
            WinAPI.draw(new Rectangle(config.GridLeftTopCornerX, config.GridLeftTopCornerY - thickness, config.GridRightBottomCornerX - config.GridLeftTopCornerX, thickness), Brushes.Black);
            // Bottom line
            WinAPI.draw(new Rectangle(config.GridLeftTopCornerX, config.GridRightBottomCornerY, config.GridRightBottomCornerX - config.GridLeftTopCornerX, thickness), Brushes.Black);
            // Left line
            WinAPI.draw(new Rectangle(config.GridLeftTopCornerX - thickness, config.GridLeftTopCornerY - thickness, thickness, config.GridRightBottomCornerY - config.GridLeftTopCornerY + (thickness * 2)), Brushes.Black);
            // Right line
            WinAPI.draw(new Rectangle(config.GridRightBottomCornerX, config.GridLeftTopCornerY - thickness, thickness, config.GridRightBottomCornerY - config.GridLeftTopCornerY + (thickness * 2)), Brushes.Black);
        }

        private void highlightNumberCheckPixels(int thickness)
        {
            var grid = RouletteHelper.getNumbersGrid();

            int gridLocX = config.GridLeftTopCornerX;
            int gridLocY = config.GridLeftTopCornerY;

            int gridTileWidth = (config.GridRightBottomCornerX - gridLocX) / 12;
            int gridTileHeight = (config.GridRightBottomCornerY - gridLocY) / 3;

            for (int y = 0; y < grid.Length; y++)
            {
                for(int x = -1; x < grid[y].Length - 1; x++)
                {
                    if(grid[y][x + 1] >= 0)
                    {
                        WinAPI.draw(new Rectangle(gridLocX + (x * gridTileWidth) - (thickness / 2) + config.NumberCheckOffsetX, gridLocY + (y * gridTileHeight) - (thickness / 2) + config.NumberCheckOffsetY, thickness, thickness), Brushes.Black);
                    }
                }
            }
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
