using System.IO;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RouletteBot.Models
{
    public class MappingConfig
    {
        public int ForResolutionX { get; set; }
        public int ForResolutionY { get; set; }
        public int RecalculateForX { get; set; }
        public int RecalculateForY { get; set; }
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

                dictionary.TryGetValue("ForResolutionX", out string forResolutionX);
                dictionary.TryGetValue("ForResolutionY", out string forResolutionY);
                dictionary.TryGetValue("RecalculateForX", out string recalculateForX);
                dictionary.TryGetValue("RecalculateForY", out string recalculateForY);
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

                ForResolutionX = Int32.TryParse(forResolutionX, out int forResolutionXint) ? recalculateX(forResolutionXint) : 0;
                ForResolutionY = Int32.TryParse(forResolutionY, out int forResolutionYint) ? recalculateY(forResolutionYint) : 0;
                RecalculateForX = Int32.TryParse(recalculateForX, out int recalculateForXint) ? recalculateX(recalculateForXint) : 0;
                RecalculateForY = Int32.TryParse(recalculateForY, out int recalculateForYint) ? recalculateY(recalculateForYint) : 0;
                GridLeftTopCornerX = Int32.TryParse(gridLeftTopCornerX, out int gridLeftTopCornerXint) ? recalculateX(gridLeftTopCornerXint) : 0;
                GridLeftTopCornerY = Int32.TryParse(gridLeftTopCornerY, out int gridLeftTopCornerYint) ? recalculateY(gridLeftTopCornerYint) : 0;
                GridRightBottomCornerX = Int32.TryParse(gridRightBottomCornerX, out int gridRightBottomCornerXint) ? recalculateX(gridRightBottomCornerXint) : 0;
                GridRightBottomCornerY = Int32.TryParse(gridRightBottomCornerY, out int gridRightBottomCornerYint) ? recalculateY(gridRightBottomCornerYint) : 0;
                BlackBetX = Int32.TryParse(blackBetX, out int blackBetXint) ? recalculateX(blackBetXint) : 0;
                BlackBetY = Int32.TryParse(blackBetY, out int blackBetYint) ? recalculateY(blackBetYint) : 0;
                RedBetX = Int32.TryParse(redBetX, out int redBetXint) ? recalculateX(redBetXint) : 0;
                RedBetY = Int32.TryParse(redBetY, out int redBetYint) ? recalculateY(redBetYint) : 0;
                ConfirmBetX = Int32.TryParse(confirmBetX, out int confirmBetXint) ? recalculateX(confirmBetXint) : 0;
                ConfirmBetY = Int32.TryParse(confirmBetY, out int confirmBetYint) ? recalculateY(confirmBetYint) : 0;
                SpinReadyCheckX = Int32.TryParse(spinReadyCheckX, out int spinReadyCheckXint) ? recalculateX(spinReadyCheckXint) : 0;
                SpinReadyCheckY = Int32.TryParse(spinReadyCheckY, out int spinReadyCheckYint) ? recalculateY(spinReadyCheckYint) : 0;
                SixLineBetY = Int32.TryParse(sixLineBetY, out int sixLineBetYint) ? recalculateY(sixLineBetYint) : 0;
            }
        }

        private int recalculateX(int toRecalculateX)
        {
            if(RecalculateForX > 0)
            {
                return RecalculateForX / ForResolutionX * toRecalculateX;
            }

            return toRecalculateX;
        }
        private int recalculateY(int toRecalculateY)
        {
            if (RecalculateForY > 0)
            {
                return RecalculateForY / ForResolutionY * toRecalculateY;
            }

            return toRecalculateY;
        }
    }
}
