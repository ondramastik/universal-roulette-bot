using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RouletteBot.Views
{
    public partial class BetEvaluationConfigurator : Form
    {
        private readonly string _path;

        public BetEvaluationConfigurator(string configPath = null)
        {
            InitializeComponent();

            if (configPath == null)
            {
                _path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                            @"\RouletteBot\bet-eval-config.conf";
            }
            else
            {
                _path = configPath;
            }

            if (!File.Exists(_path)) return;
            var data = File.ReadAllText(_path);
            AssignFormData(JsonConvert.DeserializeObject<Dictionary<string, string>>(data));
        }

        private void SaveClick(object sender, EventArgs e)
        {
            var data = new Dictionary<string, string>
            {
                { "SixLineBet", SixLineBet.Checked.ToString() },
                { "SixLineBetAmount", SixLineBetAmount.Text },
                { "SixLineBetNumberBefore", SixLineBetNumberBefore.Checked.ToString() },
                { "SixLineBetNumberBeforeAmount", SixLineBetNumberBeforeAmount.Text },
                { "SecondSixLineBet", SecondSixLineBet.Checked.ToString() },
                { "SecondSixLineBetAmount", SecondSixLineBetAmount.Text },
                { "SecondSixLineBetNumberBefore", SecondSixLineBetNumberBefore.Checked.ToString() },
                { "SecondSixLineBetNumberBeforeAmount", SecondSixLineBetNumberBeforeAmount.Text },
                { "ThreeOfFour", ThreeOfFour.Checked.ToString() },
                { "ThreeOfFourAmount", ThreeOfFourAmount.Text },
                { "FirstFiveBlack", FirstFiveBlack.Checked.ToString() },
                { "FirstFiveBlackAmount", FirstFiveBlackAmount.Text },
                { "ColorSwitching", ColorSwitching.Checked.ToString() },
                { "ColorSwitchingAmount", ColorSwitchingAmount.Text },
                { "TwoColorsInRow", TwoColorsInRow.Checked.ToString() },
                { "TwoColorsInRowAmount", TwoColorsInRowAmount.Text },
                { "ColorStreakAfterZero", ColorStreakAfterZero.Checked.ToString() },
                { "ColorStreakAfterZeroAmount", ColorStreakAfterZeroAmount.Text },
                { "RedAfterZero", RedAfterZero.Checked.ToString() },
                { "RedAfterZeroAmount", RedAfterZeroAmount.Text },
                { "LongTimeNoSee", LongTimeNoSee.Checked.ToString() },
                { "LongTimeNoSeeAmount", LongTimeNoSeeAmount.Text },
                { "LongTimeNoSeeFrom", LongTimeNoSeeFrom.Text },
                { "LongTimeNoSeeTo", LongTimeNoSeeTo.Text }
            };


            File.WriteAllText(_path, JsonConvert.SerializeObject(data));
            Close();
        }

        private void CloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void AssignFormData(IReadOnlyDictionary<string, string> formData)
        {
            formData.TryGetValue("SixLineBet", out var sixLineBet);
            formData.TryGetValue("SixLineBetAmount", out var sixLineBetAmount);
            formData.TryGetValue("SixLineBetNumberBefore", out var sixLineBetNumberBefore);
            formData.TryGetValue("SixLineBetNumberBeforeAmount", out var sixLineBetNumberBeforeAmount);
            formData.TryGetValue("SecondSixLineBet", out var secondSixLineBet);
            formData.TryGetValue("SecondSixLineBetAmount", out var secondSixLineBetAmount);
            formData.TryGetValue("SecondSixLineBetNumberBefore", out var secondSixLineBetNumberBefore);
            formData.TryGetValue("SecondSixLineBetNumberBeforeAmount", out var secondSixLineBetNumberBeforeAmount);
            formData.TryGetValue("ThreeOfFour", out var threeOfFour);
            formData.TryGetValue("ThreeOfFourAmount", out var threeOfFourAmount);
            formData.TryGetValue("FirstFiveBlack", out var firstFiveBlack);
            formData.TryGetValue("FirstFiveBlackAmount", out var firstFiveBlackAmount);
            formData.TryGetValue("ColorSwitching", out var colorSwitching);
            formData.TryGetValue("ColorSwitchingAmount", out var colorSwitchingAmount);
            formData.TryGetValue("TwoColorsInRow", out var twoColorsInRow);
            formData.TryGetValue("TwoColorsInRowAmount", out var twoColorsInRowAmount);
            formData.TryGetValue("ColorStreakAfterZero", out var colorStreakAfterZero);
            formData.TryGetValue("ColorStreakAfterZeroAmount", out var colorStreakAfterZeroAmount);
            formData.TryGetValue("RedAfterZero", out var redAfterZero);
            formData.TryGetValue("RedAfterZeroAmount", out var redAfterZeroAmount);
            formData.TryGetValue("LongTimeNoSee", out var longTimeNoSee);
            formData.TryGetValue("LongTimeNoSeeAmount", out var longTimeNoSeeAmount);
            formData.TryGetValue("LongTimeNoSeeFrom", out var longTimeNoSeeFrom);
            formData.TryGetValue("LongTimeNoSeeTo", out var longTimeNoSeeTo);

            SixLineBet.Checked = bool.Parse(sixLineBet);
            SixLineBetAmount.Text = sixLineBetAmount;
            SixLineBetNumberBefore.Checked = bool.Parse(sixLineBetNumberBefore);
            SixLineBetNumberBeforeAmount.Text = sixLineBetNumberBeforeAmount;
            SecondSixLineBet.Checked = bool.Parse(secondSixLineBet);
            SecondSixLineBetAmount.Text = secondSixLineBetAmount;
            SecondSixLineBetNumberBefore.Checked = bool.Parse(secondSixLineBetNumberBefore);
            SecondSixLineBetNumberBeforeAmount.Text = secondSixLineBetNumberBeforeAmount;
            ThreeOfFour.Checked = bool.Parse(threeOfFour);
            ThreeOfFourAmount.Text = threeOfFourAmount;
            FirstFiveBlack.Checked = bool.Parse(firstFiveBlack);
            FirstFiveBlackAmount.Text = firstFiveBlackAmount;
            ColorSwitching.Checked = bool.Parse(colorSwitching);
            ColorSwitchingAmount.Text = colorSwitchingAmount;
            TwoColorsInRow.Checked = bool.Parse(twoColorsInRow);
            TwoColorsInRowAmount.Text = twoColorsInRowAmount;
            ColorStreakAfterZero.Checked = bool.Parse(colorStreakAfterZero);
            ColorStreakAfterZeroAmount.Text = colorStreakAfterZeroAmount;
            RedAfterZero.Checked = bool.Parse(redAfterZero);
            RedAfterZeroAmount.Text = redAfterZeroAmount;
            LongTimeNoSee.Checked = longTimeNoSee != null && bool.Parse(longTimeNoSee);
            LongTimeNoSeeAmount.Text = longTimeNoSeeAmount;
            LongTimeNoSeeFrom.Text = longTimeNoSeeFrom;
            LongTimeNoSeeTo.Text = longTimeNoSeeTo;
        }

        private void BetEvaluationConfigurator_Load(object sender, EventArgs e)
        {
        }
    }
}