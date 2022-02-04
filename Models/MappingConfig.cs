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
        public int SpinX { get; set; }
        public int SpinY { get; set; }
        public int SpinReadyCheckX { get; set; }
        public int SpinReadyCheckY { get; set; }

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
                dictionary.TryGetValue("spinX", out string spinX);
                dictionary.TryGetValue("spinY", out string spinY);
                dictionary.TryGetValue("spinReadyCheckX", out string spinReadyCheckX);
                dictionary.TryGetValue("spinReadyCheckY", out string spinReadyCheckY);

                GridLeftTopCornerX = Int32.Parse(gridLeftTopCornerX);
                GridLeftTopCornerY = Int32.Parse(gridLeftTopCornerY);
                GridRightBottomCornerX = Int32.Parse(gridRightBottomCornerX);
                GridRightBottomCornerY = Int32.Parse(gridRightBottomCornerY);
                BlackBetX = Int32.Parse(blackBetX);
                BlackBetY = Int32.Parse(blackBetY);
                RedBetX = Int32.Parse(redBetX);
                RedBetY = Int32.Parse(redBetY);
                SpinX = Int32.Parse(spinX);
                SpinY = Int32.Parse(spinY);
                SpinReadyCheckX = Int32.Parse(spinReadyCheckX);
                SpinReadyCheckY = Int32.Parse(spinReadyCheckY);
            }
        }
    }
}
