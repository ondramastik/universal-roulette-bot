﻿using System.IO;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RouletteBot.Models
{
    public class BetEvaluationConfig
    {
        public bool SixlineBet { get; set; }
        public int SixlineBetAmount { get; set; }
        public bool SixlineBetNumberBefore { get; set; }
        public int SixlineBetNumberBeforeAmount { get; set; }
        public bool SecondSixlineBet { get; set; }
        public int SecondSixlineBetAmount { get; set; }
        public bool SecondSixlineBetNumberBefore { get; set; }
        public int SecondSixlineBetNumberBeforeAmount { get; set; }
        public bool ThreeOfFour { get; set; }
        public int ThreeOfFourAmount { get; set; }
        public bool FirstFiveBlack { get; set; }
        public int FirstFiveBlackAmount { get; set; }
        public bool ColorSwitching { get; set; }
        public int ColorSwitchingAmount { get; set; }
        public bool TwoColorsInRow { get; set; }
        public int TwoColorsInRowAmount { get; set; }
        public bool ColorStreakAfterZero { get; set; }
        public int ColorStreakAfterZeroAmount { get; set; }
        public bool RedAfterZero { get; set; }
        public int RedAfterZeroAmount { get; set; }

        public BetEvaluationConfig(string configPath = null)
        {
            if (configPath == null)
            {
                configPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\RouletteBot\bet-eval-config.conf";
            }

            if (File.Exists(configPath))
            {
                string data = File.ReadAllText(configPath);
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

                dictionary.TryGetValue("SixlineBet", out string sixlineBet);
                dictionary.TryGetValue("SixlineBetAmount", out string sixlineBetAmount);
                dictionary.TryGetValue("SixlineBetNumberBefore", out string sixlineBetNumberBefore);
                dictionary.TryGetValue("SixlineBetNumberBeforeAmount", out string sixlineBetNumberBeforeAmount);
                dictionary.TryGetValue("SecondSixlineBet", out string secondSixlineBet);
                dictionary.TryGetValue("SecondSixlineBetAmount", out string secondSixlineBetAmount);
                dictionary.TryGetValue("SecondSixlineBetNumberBefore", out string secondSixlineBetNumberBefore);
                dictionary.TryGetValue("SecondSixlineBetNumberBeforeAmount", out string secondSixlineBetNumberBeforeAmount);
                dictionary.TryGetValue("ThreeOfFour", out string threeOfFour);
                dictionary.TryGetValue("ThreeOfFourAmount", out string threeOfFourAmount);
                dictionary.TryGetValue("FirstFiveBlack", out string firstFiveBlack);
                dictionary.TryGetValue("FirstFiveBlackAmount", out string firstFiveBlackAmount);
                dictionary.TryGetValue("ColorSwitching", out string colorSwitching);
                dictionary.TryGetValue("ColorSwitchingAmount", out string colorSwitchingAmount);
                dictionary.TryGetValue("TwoColorsInRow", out string twoColorsInRow);
                dictionary.TryGetValue("TwoColorsInRowAmount", out string twoColorsInRowAmount);
                dictionary.TryGetValue("ColorStreakAfterZero", out string colorStreakAfterZero);
                dictionary.TryGetValue("ColorStreakAfterZeroAmount", out string colorStreakAfterZeroAmount);
                dictionary.TryGetValue("RedAfterZero", out string redAfterZero);
                dictionary.TryGetValue("RedAfterZeroAmount", out string redAfterZeroAmount);

                SixlineBet = Boolean.TryParse(sixlineBet, out bool sixlineBetBool) ? sixlineBetBool : false;
                SixlineBetAmount = Int32.TryParse(sixlineBetAmount, out int sixlineBetAmountInt) ? sixlineBetAmountInt : 0;
                SixlineBetNumberBefore = Boolean.TryParse(sixlineBetNumberBefore, out bool sixlineBetNumberBeforeBool) ? sixlineBetNumberBeforeBool : false;
                SixlineBetNumberBeforeAmount = Int32.TryParse(sixlineBetNumberBeforeAmount, out int sixlineBetNumberBeforeAmountInt) ? sixlineBetNumberBeforeAmountInt : 0;
                SecondSixlineBet = Boolean.TryParse(secondSixlineBet, out bool secondSixlineBetBool) ? secondSixlineBetBool : false;
                SecondSixlineBetAmount = Int32.TryParse(secondSixlineBetAmount, out int secondSixlineBetAmountInt) ? secondSixlineBetAmountInt : 0;
                SecondSixlineBetNumberBefore = Boolean.TryParse(secondSixlineBetNumberBefore, out bool secondSixlineBetNumberBeforeBool) ? secondSixlineBetNumberBeforeBool : false;
                SecondSixlineBetNumberBeforeAmount = Int32.TryParse(secondSixlineBetNumberBeforeAmount, out int secondSixlineBetNumberBeforeAmountInt) ? secondSixlineBetNumberBeforeAmountInt : 0;
                ThreeOfFour = Boolean.TryParse(threeOfFour, out bool threeOfFourBool) ? threeOfFourBool : false;
                ThreeOfFourAmount = Int32.TryParse(threeOfFourAmount, out int threeOfFourAmountInt) ? threeOfFourAmountInt : 0;
                FirstFiveBlack = Boolean.TryParse(firstFiveBlack, out bool firstFiveBlackBool) ? firstFiveBlackBool : false;
                FirstFiveBlackAmount = Int32.TryParse(firstFiveBlackAmount, out int firstFiveBlackAmountInt) ? firstFiveBlackAmountInt : 0;
                ColorSwitching = Boolean.TryParse(colorSwitching, out bool colorSwitchingBool) ? colorSwitchingBool : false;
                ColorSwitchingAmount = Int32.TryParse(colorSwitchingAmount, out int colorSwitchingAmountInt) ? colorSwitchingAmountInt : 0;
                TwoColorsInRow = Boolean.TryParse(twoColorsInRow, out bool twoColorsInRowBool) ? twoColorsInRowBool : false;
                TwoColorsInRowAmount = Int32.TryParse(twoColorsInRowAmount, out int twoColorsInRowAmountInt) ? twoColorsInRowAmountInt : 0;
                ColorStreakAfterZero = Boolean.TryParse(colorStreakAfterZero, out bool colorStreakAfterZeroBool) ? colorStreakAfterZeroBool : false;
                ColorStreakAfterZeroAmount = Int32.TryParse(colorStreakAfterZeroAmount, out int colorStreakAfterZeroAmountInt) ? colorStreakAfterZeroAmountInt : 0;
                RedAfterZero = Boolean.TryParse(redAfterZero, out bool redAfterZeroBool) ? redAfterZeroBool : false;
                RedAfterZeroAmount = Int32.TryParse(redAfterZeroAmount, out int redAfterZeroAmountInt) ? redAfterZeroAmountInt : 0;
            }
        }
    }
}
