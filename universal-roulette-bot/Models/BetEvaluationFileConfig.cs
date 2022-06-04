using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace RouletteBot.Models
{
    public class BetEvaluationFileConfig : BetEvaluationConfig
    {
        public BetEvaluationFileConfig(string configPath = null)
        {
            if (configPath == null)
            {
                configPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                             @"\RouletteBot\bet-eval-config.conf";
            }

            if (!File.Exists(configPath)) return;
            var data = File.ReadAllText(configPath);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

            if (dictionary == null)
            {
                throw new InvalidDataException(
                    "Could not parse bet evaluation config file. Delete the config file to reset.");
            }

            dictionary.TryGetValue("SixLineBet", out var sixLineBet);
            dictionary.TryGetValue("SixLineBetAmount", out var sixLineBetAmount);
            dictionary.TryGetValue("SixLineBetNumberBefore", out var sixLineBetNumberBefore);
            dictionary.TryGetValue("SixLineBetNumberBeforeAmount", out var sixLineBetNumberBeforeAmount);
            dictionary.TryGetValue("SecondSixLineBet", out var secondSixLineBet);
            dictionary.TryGetValue("SecondSixLineBetAmount", out var secondSixLineBetAmount);
            dictionary.TryGetValue("SecondSixLineBetNumberBefore", out var secondSixLineBetNumberBefore);
            dictionary.TryGetValue("SecondSixLineBetNumberBeforeAmount",
                out var secondSixLineBetNumberBeforeAmount);
            dictionary.TryGetValue("ThreeOfFour", out var threeOfFour);
            dictionary.TryGetValue("ThreeOfFourAmount", out var threeOfFourAmount);
            dictionary.TryGetValue("FirstFiveBlack", out var firstFiveBlack);
            dictionary.TryGetValue("FirstFiveBlackAmount", out var firstFiveBlackAmount);
            dictionary.TryGetValue("ColorSwitching", out var colorSwitching);
            dictionary.TryGetValue("ColorSwitchingAmount", out var colorSwitchingAmount);
            dictionary.TryGetValue("TwoColorsInRow", out var twoColorsInRow);
            dictionary.TryGetValue("TwoColorsInRowAmount", out var twoColorsInRowAmount);
            dictionary.TryGetValue("ColorStreakAfterZero", out var colorStreakAfterZero);
            dictionary.TryGetValue("ColorStreakAfterZeroAmount", out var colorStreakAfterZeroAmount);
            dictionary.TryGetValue("RedAfterZero", out var redAfterZero);
            dictionary.TryGetValue("RedAfterZeroAmount", out var redAfterZeroAmount);
            dictionary.TryGetValue("LongTimeNoSee", out var longTimeNoSee);
            dictionary.TryGetValue("LongTimeNoSeeAmount", out var longTimeNoSeeAmount);
            dictionary.TryGetValue("LongTimeNoSeeFrom", out var longTimeNoSeeFrom);
            dictionary.TryGetValue("LongTimeNoSeeTo", out var longTimeNoSeeTo);

            EnableNeutralBet = true;
            SixLineBet = bool.TryParse(sixLineBet, out var sixLineBetBool) && sixLineBetBool;
            SixLineBetAmount = int.TryParse(sixLineBetAmount, out var sixLineBetAmountInt)
                ? sixLineBetAmountInt
                : 0;
            SixLineBetNumberBefore =
                bool.TryParse(sixLineBetNumberBefore, out var sixLineBetNumberBeforeBool) &&
                sixLineBetNumberBeforeBool;
            SixLineBetNumberBeforeAmount =
                int.TryParse(sixLineBetNumberBeforeAmount, out var sixLineBetNumberBeforeAmountInt)
                    ? sixLineBetNumberBeforeAmountInt
                    : 0;
            SecondSixLineBet = bool.TryParse(secondSixLineBet, out var secondSixLineBetBool) &&
                               secondSixLineBetBool;
            SecondSixLineBetAmount = int.TryParse(secondSixLineBetAmount, out var secondSixLineBetAmountInt)
                ? secondSixLineBetAmountInt
                : 0;
            SecondSixLineBetNumberBefore =
                bool.TryParse(secondSixLineBetNumberBefore, out var secondSixLineBetNumberBeforeBool) &&
                secondSixLineBetNumberBeforeBool;
            SecondSixLineBetNumberBeforeAmount =
                int.TryParse(secondSixLineBetNumberBeforeAmount, out var secondSixLineBetNumberBeforeAmountInt)
                    ? secondSixLineBetNumberBeforeAmountInt
                    : 0;
            ThreeOfFour = bool.TryParse(threeOfFour, out var threeOfFourBool) && threeOfFourBool;
            ThreeOfFourAmount = int.TryParse(threeOfFourAmount, out var threeOfFourAmountInt)
                ? threeOfFourAmountInt
                : 0;
            FirstFiveBlack = bool.TryParse(firstFiveBlack, out var firstFiveBlackBool) && firstFiveBlackBool;
            FirstFiveBlackAmount = int.TryParse(firstFiveBlackAmount, out var firstFiveBlackAmountInt)
                ? firstFiveBlackAmountInt
                : 0;
            ColorSwitching = bool.TryParse(colorSwitching, out var colorSwitchingBool) && colorSwitchingBool;
            ColorSwitchingAmount = int.TryParse(colorSwitchingAmount, out var colorSwitchingAmountInt)
                ? colorSwitchingAmountInt
                : 0;
            TwoColorsInRow = bool.TryParse(twoColorsInRow, out var twoColorsInRowBool) && twoColorsInRowBool;
            TwoColorsInRowAmount = int.TryParse(twoColorsInRowAmount, out var twoColorsInRowAmountInt)
                ? twoColorsInRowAmountInt
                : 0;
            ColorStreakAfterZero = bool.TryParse(colorStreakAfterZero, out var colorStreakAfterZeroBool) &&
                                   colorStreakAfterZeroBool;
            ColorStreakAfterZeroAmount =
                int.TryParse(colorStreakAfterZeroAmount, out var colorStreakAfterZeroAmountInt)
                    ? colorStreakAfterZeroAmountInt
                    : 0;
            RedAfterZero = bool.TryParse(redAfterZero, out var redAfterZeroBool) && redAfterZeroBool;
            RedAfterZeroAmount = int.TryParse(redAfterZeroAmount, out var redAfterZeroAmountInt)
                ? redAfterZeroAmountInt
                : 0;
            LongTimeNoSee = bool.TryParse(longTimeNoSee, out var longTimeNoSeeBool) && longTimeNoSeeBool;
            LongTimeNoSeeAmount = int.TryParse(longTimeNoSeeAmount, out var longTimeNoSeeAmountInt)
                ? longTimeNoSeeAmountInt
                : 0;
            LongTimeNoSeeFrom = int.TryParse(longTimeNoSeeFrom, out var longTimeNoSeeFromInt)
                ? longTimeNoSeeFromInt
                : 0;
            LongTimeNoSeeTo = int.TryParse(longTimeNoSeeTo, out var longTimeNoSeeToInt) ? longTimeNoSeeToInt : 0;
        }
    }
}