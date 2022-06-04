using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace RouletteBot.Models
{
    public class GameTableReader
    {
        private readonly MappingConfig _config;

        private static string _readyCheckColor;
        private static string _readySkipColor;

        private readonly Dictionary<int, Color> _defaultNumberColors;
        private readonly Dictionary<int, Color> _activeNumberColors;

        public GameTableReader(MappingConfig config)
        {
            _config = config;
            _defaultNumberColors = ReadNumberColors();
            _activeNumberColors = ReadActiveNumberColors();
        }

        public void ReadReadyCheckColor()
        {
            _readyCheckColor = WinAPI.CreateScreenshot(_config.SpinReadyCheckX, _config.SpinReadyCheckY,
                _config.SpinReadyCheckX + 1, _config.SpinReadyCheckY + 1).GetPixel(0, 0).ToString();
        }

        public int ReadNumber()
        {
            var checkColors = ReadNumberColors();
            while (true)
            {
                foreach (var entry in checkColors)
                {
                    if (_defaultNumberColors.TryGetValue(entry.Key, out var color) && entry.Value.ToString() !=
                        color.ToString()
                        && (
                            entry.Key == 0 ||
                            _activeNumberColors.TryGetValue(
                                entry.Key, out var activeColor) &&
                            entry.Value.ToString() ==
                            activeColor.ToString())
                       )
                    {
                        return entry.Key;
                    }
                }

                Thread.Sleep(5);
            }
        }

        public bool IsRoundReady()
        {
            var check = WinAPI.CreateScreenshot(_config.SpinReadyCheckX, _config.SpinReadyCheckY,
                _config.SpinReadyCheckX + 1, _config.SpinReadyCheckY + 1);

            return check.GetPixel(0, 0).ToString() == _readyCheckColor;
        }

        public bool IsSkipReady()
        {
            if (_readySkipColor == null)
            {
                Thread.Sleep(3000);
                _readySkipColor = WinAPI.CreateScreenshot(_config.ConfirmBetX, _config.ConfirmBetY,
                    _config.ConfirmBetX + 1,
                    _config.ConfirmBetY + 1).GetPixel(0, 0).ToString();
            }

            var checkSkip = WinAPI.CreateScreenshot(_config.ConfirmBetX, _config.ConfirmBetY, _config.ConfirmBetX + 1,
                _config.ConfirmBetY + 1);
            return checkSkip.GetPixel(0, 0).ToString() == _readySkipColor;
        }

        public void HighlightConfiguredMapping(int duration = 5000)
        {
            const int thickness = 4;
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (duration > 0)
                {
                    Thread.Sleep(50);
                    HighlightNumbersGrid(thickness);
                    HighlightNumberCheckPixels(thickness);

                    duration -= 50;
                }
            }).Start();
        }

        private void HighlightNumbersGrid(int thickness)
        {
            // Top line
            WinAPI.draw(
                new Rectangle(_config.GridLeftTopCornerX, _config.GridLeftTopCornerY - thickness,
                    _config.GridRightBottomCornerX - _config.GridLeftTopCornerX, thickness), Brushes.Black);
            // Bottom line
            WinAPI.draw(
                new Rectangle(_config.GridLeftTopCornerX, _config.GridRightBottomCornerY,
                    _config.GridRightBottomCornerX - _config.GridLeftTopCornerX, thickness), Brushes.Black);
            // Left line
            WinAPI.draw(
                new Rectangle(_config.GridLeftTopCornerX - thickness, _config.GridLeftTopCornerY - thickness, thickness,
                    _config.GridRightBottomCornerY - _config.GridLeftTopCornerY + (thickness * 2)), Brushes.Black);
            // Right line
            WinAPI.draw(
                new Rectangle(_config.GridRightBottomCornerX, _config.GridLeftTopCornerY - thickness, thickness,
                    _config.GridRightBottomCornerY - _config.GridLeftTopCornerY + (thickness * 2)), Brushes.Black);
        }

        private void HighlightNumberCheckPixels(int thickness)
        {
            var grid = RouletteHelper.getNumbersGrid();

            var gridLocX = _config.GridLeftTopCornerX;
            var gridLocY = _config.GridLeftTopCornerY;

            var gridTileWidth = (_config.GridRightBottomCornerX - gridLocX) / 12;
            var gridTileHeight = (_config.GridRightBottomCornerY - gridLocY) / 3;

            for (var y = 0; y < grid.Length; y++)
            {
                for (var x = -1; x < grid[y].Length - 1; x++)
                {
                    if (grid[y][x + 1] >= 0)
                    {
                        WinAPI.draw(
                            new Rectangle(gridLocX + (x * gridTileWidth) - (thickness / 2) + _config.NumberCheckOffsetX,
                                gridLocY + (y * gridTileHeight) - (thickness / 2) + _config.NumberCheckOffsetY,
                                thickness, thickness), Brushes.Black);
                    }
                }
            }
        }

        private Dictionary<int, Color> ReadActiveNumberColors()
        {
            var grid = RouletteHelper.getNumbersGrid();
            var colors = new Dictionary<int, Color>();

            WinAPI.MouseMove(_config.RedBetX, _config.RedBetY);
            Thread.Sleep(1000);
            var gridScreenshotRedActive = GetGridScreenshot();

            WinAPI.MouseMove(_config.BlackBetX, _config.BlackBetY);
            Thread.Sleep(1000);
            var gridScreenshotBlackActive = GetGridScreenshot();

            for (var y = 0; y < grid.Length; y++)
            {
                for (var x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] < 0) continue;

                    if (Array.IndexOf(RouletteHelper.getRedNumbers(), grid[y][x]) >= 0)
                    {
                        colors.Add(grid[y][x], GetNumberColor(grid[y][x], gridScreenshotRedActive, x, y));
                    }
                    else if (grid[y][x] != 0)
                    {
                        colors.Add(grid[y][x], GetNumberColor(grid[y][x], gridScreenshotBlackActive, x, y));
                    }
                }
            }

            return colors;
        }

        private Dictionary<int, Color> ReadNumberColors()
        {
            var grid = RouletteHelper.getNumbersGrid();
            var colors = new Dictionary<int, Color>();

            var gridScreenshot = GetGridScreenshot();

            for (var y = 0; y < grid.Length; y++)
            {
                for (var x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] < 0) continue;
                    colors.Add(grid[y][x], GetNumberColor(grid[y][x], gridScreenshot, x, y));
                }
            }

            return colors;
        }

        private Color GetNumberColor(int number, Bitmap gridScreenshot, int x = -1, int y = -1)
        {
            var numberTileWidth = (_config.GridRightBottomCornerX - _config.GridLeftTopCornerX) / 12;
            var numberTileHeight = (_config.GridRightBottomCornerY - _config.GridLeftTopCornerY) / 3;
            var loc = x < 0 ? RouletteHelper.getNumberGridIndex(number) : new Point(x, y);

            var locX = (loc.X * numberTileWidth) + (number != 0 ? _config.NumberCheckOffsetX : 20);
            var loxY = (loc.Y * numberTileHeight) + _config.NumberCheckOffsetY;

            return gridScreenshot.GetPixel(locX, loxY);
        }

        private Bitmap GetGridScreenshot()
        {
            var numberTileWidth = (_config.GridRightBottomCornerX - _config.GridLeftTopCornerX) / 12;
            return WinAPI.CreateScreenshot(_config.GridLeftTopCornerX - numberTileWidth, _config.GridLeftTopCornerY,
                _config.GridRightBottomCornerX + numberTileWidth, _config.GridRightBottomCornerY);
        }
    }
}