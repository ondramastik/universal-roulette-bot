using System.IO;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RouletteBot.Models
{
    public class MappingConfig
    {
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

        public MappingConfig(string configPath = null)
        {
            if(configPath == null)
            {
                configPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\RouletteBot\roulette-config.conf";
            }

            if(File.Exists(configPath))
            {
                string data = File.ReadAllText(configPath);
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

                dictionary.TryGetValue("gridLeftTopCornerX", out string gridLeftTopCornerX);
                dictionary.TryGetValue("gridLeftTopCornerY", out string gridLeftTopCornerY);
                dictionary.TryGetValue("gridRightBottomCornerX", out string gridRightBottomCornerX);
                dictionary.TryGetValue("gridRightBottomCornerY", out string gridRightBottomCornerY);
                dictionary.TryGetValue("blackBetX", out string blackBetX);
                dictionary.TryGetValue("blackBetY", out string blackBetY);
                dictionary.TryGetValue("redBetX", out string redBetX);
                dictionary.TryGetValue("redBetY", out string redBetY);
                dictionary.TryGetValue("confirmBetX", out string confirmBetX);
                dictionary.TryGetValue("confirmBetY", out string confirmBetY);
                dictionary.TryGetValue("spinReadyCheckX", out string spinReadyCheckX);
                dictionary.TryGetValue("spinReadyCheckY", out string spinReadyCheckY);
                dictionary.TryGetValue("sixLineBetY", out string sixLineBetY);

                GridLeftTopCornerX = Int32.TryParse(gridLeftTopCornerX, out int gridLeftTopCornerXint) ? gridLeftTopCornerXint : 0;
                GridLeftTopCornerY = Int32.TryParse(gridLeftTopCornerY, out int gridLeftTopCornerYint) ? gridLeftTopCornerYint : 0;
                GridRightBottomCornerX = Int32.TryParse(gridRightBottomCornerX, out int gridRightBottomCornerXint) ? gridRightBottomCornerXint : 0;
                GridRightBottomCornerY = Int32.TryParse(gridRightBottomCornerY, out int gridRightBottomCornerYint) ? gridRightBottomCornerYint : 0;
                BlackBetX = Int32.TryParse(blackBetX, out int blackBetXint) ? blackBetXint : 0;
                BlackBetY = Int32.TryParse(blackBetY, out int blackBetYint) ? blackBetYint : 0;
                RedBetX = Int32.TryParse(redBetX, out int redBetXint) ? redBetXint : 0;
                RedBetY = Int32.TryParse(redBetY, out int redBetYint) ? redBetYint : 0;
                ConfirmBetX = Int32.TryParse(confirmBetX, out int confirmBetXint) ? confirmBetXint : 0;
                ConfirmBetY = Int32.TryParse(confirmBetY, out int confirmBetYint) ? confirmBetYint : 0;
                SpinReadyCheckX = Int32.TryParse(spinReadyCheckX, out int spinReadyCheckXint) ? spinReadyCheckXint : 0;
                SpinReadyCheckY = Int32.TryParse(spinReadyCheckY, out int spinReadyCheckYint) ? spinReadyCheckYint : 0;
                SixLineBetY = Int32.TryParse(sixLineBetY, out int sixLineBetYint) ? sixLineBetYint : 0;
            }
        }
    }
}
