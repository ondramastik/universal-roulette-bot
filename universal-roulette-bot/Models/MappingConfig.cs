using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace RouletteBot.Models
{
    public class MappingConfig
    {
        public double ForResolutionX { get; set; }
        public double ForResolutionY { get; set; }
        public double RecalculateForX { get; set; }
        public double RecalculateForY { get; set; }
        public int GridLeftTopCornerX { get; set; }
        public int GridLeftTopCornerY { get; set; }
        public int GridRightBottomCornerX { get; set; }
        public int GridRightBottomCornerY { get; set; }
        public int BlackBetX { get; set; }
        public int BlackBetY { get; set; }
        public int RedBetX { get; set; }
        public int RedBetY { get; set; }
        public int ConfirmBetX { get; set; }
        public int ConfirmBetY { get; set; }
        public int SpinReadyCheckX { get; set; }
        public int SpinReadyCheckY { get; set; }
        public int SixLineBetY { get; set; }
        public int NumberCheckOffsetX { get; set; }
        public int NumberCheckOffsetY { get; set; }
        public bool IsMulti { get; set; }
        public bool IsDemo { get; set; }

        public MappingConfig(string configPath = null)
        {
            if (configPath == null)
            {
                configPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                             @"\RouletteBot\roulette-config.conf";
            }

            if (!File.Exists(configPath)) return;
            var data = File.ReadAllText(configPath);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

            if (dictionary == null)
            {
                throw new InvalidDataException("Invalid config file");
            }

            dictionary.TryGetValue("forResolutionX", out var forResolutionX);
            dictionary.TryGetValue("forResolutionY", out var forResolutionY);
            dictionary.TryGetValue("recalculateForX", out var recalculateForX);
            dictionary.TryGetValue("recalculateForY", out var recalculateForY);
            dictionary.TryGetValue("gridLeftTopCornerX", out var gridLeftTopCornerX);
            dictionary.TryGetValue("gridLeftTopCornerY", out var gridLeftTopCornerY);
            dictionary.TryGetValue("gridRightBottomCornerX", out var gridRightBottomCornerX);
            dictionary.TryGetValue("gridRightBottomCornerY", out var gridRightBottomCornerY);
            dictionary.TryGetValue("blackBetX", out var blackBetX);
            dictionary.TryGetValue("blackBetY", out var blackBetY);
            dictionary.TryGetValue("redBetX", out var redBetX);
            dictionary.TryGetValue("redBetY", out var redBetY);
            dictionary.TryGetValue("confirmBetX", out var confirmBetX);
            dictionary.TryGetValue("confirmBetY", out var confirmBetY);
            dictionary.TryGetValue("spinReadyCheckX", out var spinReadyCheckX);
            dictionary.TryGetValue("spinReadyCheckY", out var spinReadyCheckY);
            dictionary.TryGetValue("SixLineBetY", out var sixLineBetY);
            dictionary.TryGetValue("numberCheckOffsetX", out var numberCheckOffsetX);
            dictionary.TryGetValue("numberCheckOffsetY", out var numberCheckOffsetY);
            dictionary.TryGetValue("isMulti", out var isMulti);
            dictionary.TryGetValue("isDemo", out var isDemo);

            ForResolutionX = double.TryParse(forResolutionX, out var forResolutionXDouble)
                ? forResolutionXDouble
                : 0;
            ForResolutionY = double.TryParse(forResolutionY, out var forResolutionYDouble)
                ? forResolutionYDouble
                : 0;
            RecalculateForX = double.TryParse(recalculateForX, out var recalculateForXDouble)
                ? recalculateForXDouble
                : 0;
            RecalculateForY = double.TryParse(recalculateForY, out var recalculateForYDouble)
                ? recalculateForYDouble
                : 0;
            GridLeftTopCornerX = int.TryParse(gridLeftTopCornerX, out var gridLeftTopCornerXInt)
                ? RecalculateX(gridLeftTopCornerXInt)
                : 0;
            GridLeftTopCornerY = int.TryParse(gridLeftTopCornerY, out var gridLeftTopCornerYInt)
                ? RecalculateY(gridLeftTopCornerYInt)
                : 0;
            GridRightBottomCornerX = int.TryParse(gridRightBottomCornerX, out var gridRightBottomCornerXInt)
                ? RecalculateX(gridRightBottomCornerXInt)
                : 0;
            GridRightBottomCornerY = int.TryParse(gridRightBottomCornerY, out var gridRightBottomCornerYInt)
                ? RecalculateY(gridRightBottomCornerYInt)
                : 0;
            BlackBetX = int.TryParse(blackBetX, out var blackBetXInt) ? RecalculateX(blackBetXInt) : 0;
            BlackBetY = int.TryParse(blackBetY, out var blackBetYInt) ? RecalculateY(blackBetYInt) : 0;
            RedBetX = int.TryParse(redBetX, out var redBetXInt) ? RecalculateX(redBetXInt) : 0;
            RedBetY = int.TryParse(redBetY, out var redBetYInt) ? RecalculateY(redBetYInt) : 0;
            ConfirmBetX = int.TryParse(confirmBetX, out var confirmBetXInt) ? RecalculateX(confirmBetXInt) : 0;
            ConfirmBetY = int.TryParse(confirmBetY, out var confirmBetYInt) ? RecalculateY(confirmBetYInt) : 0;
            SpinReadyCheckX = int.TryParse(spinReadyCheckX, out var spinReadyCheckXInt)
                ? RecalculateX(spinReadyCheckXInt)
                : 0;
            SpinReadyCheckY = int.TryParse(spinReadyCheckY, out var spinReadyCheckYInt)
                ? RecalculateY(spinReadyCheckYInt)
                : 0;
            SixLineBetY = int.TryParse(sixLineBetY, out var sixLineBetYInt) ? RecalculateY(sixLineBetYInt) : 0;
            NumberCheckOffsetX = int.TryParse(numberCheckOffsetX, out var numberCheckOffsetXInt)
                ? RecalculateX(numberCheckOffsetXInt)
                : 0;
            NumberCheckOffsetY = int.TryParse(numberCheckOffsetY, out var numberCheckOffsetYInt)
                ? RecalculateY(numberCheckOffsetYInt)
                : 0;
            IsMulti = bool.TryParse(isMulti, out var isMultiBool) && isMultiBool;
            IsDemo = !bool.TryParse(isDemo, out var isDemoBool) || isDemoBool;
        }

        private int RecalculateX(int toRecalculateX)
        {
            return RecalculateForX > 0
                ? Convert.ToInt32(RecalculateForX / ForResolutionX * Convert.ToDouble(toRecalculateX))
                : toRecalculateX;
        }

        private int RecalculateY(int toRecalculateY)
        {
            return RecalculateForY > 0
                ? Convert.ToInt32(RecalculateForY / ForResolutionY * Convert.ToDouble(toRecalculateY))
                : toRecalculateY;
        }
    }
}