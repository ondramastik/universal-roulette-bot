using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;

namespace RouletteBot.Views
{

    public partial class BetEvaluationConfigurator : Form
    {
        private string path;

        public BetEvaluationConfigurator(string configPath = null)
        {
            InitializeComponent();

            if (configPath == null)
            {
                this.path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\RouletteBot\bet-eval-config.conf";
            }
            else
            {
                this.path = configPath;
            }

            if (File.Exists(this.path))
            {
                string data = File.ReadAllText(this.path);
                assignFormData(JsonConvert.DeserializeObject<Dictionary<string, string>>(data));
            }
        }

        private void saveClick(object sender, System.EventArgs e)
        {
            var data = new Dictionary<string, string>();

            data.Add("SixlineBet", SixlineBet.Checked.ToString());
            data.Add("SixlineBetAmount", SixlineBetAmount.Text);
            data.Add("SixlineBetNumberBefore", SixlineBetNumberBefore.Checked.ToString());
            data.Add("SixlineBetNumberBeforeAmount", SixlineBetNumberBeforeAmount.Text);
            data.Add("SecondSixlineBet", SecondSixlineBet.Checked.ToString());
            data.Add("SecondSixlineBetAmount", SecondSixlineBetAmount.Text);
            data.Add("SecondSixlineBetNumberBefore", SecondSixlineBetNumberBefore.Checked.ToString());
            data.Add("SecondSixlineBetNumberBeforeAmount", SecondSixlineBetNumberBeforeAmount.Text);
            data.Add("ThreeOfFour", ThreeOfFour.Checked.ToString());
            data.Add("ThreeOfFourAmount", ThreeOfFourAmount.Text);
            data.Add("FirstFiveBlack", FirstFiveBlack.Checked.ToString());
            data.Add("FirstFiveBlackAmount", FirstFiveBlackAmount.Text);
            data.Add("ColorSwitching", ColorSwitching.Checked.ToString());
            data.Add("ColorSwitchingAmount", ColorSwitchingAmount.Text);
            data.Add("TwoColorsInRow", TwoColorsInRow.Checked.ToString());
            data.Add("TwoColorsInRowAmount", TwoColorsInRowAmount.Text);
            data.Add("ColorStreakAfterZero", ColorStreakAfterZero.Checked.ToString());
            data.Add("ColorStreakAfterZeroAmount", ColorStreakAfterZeroAmount.Text);
            data.Add("RedAfterZero", RedAfterZero.Checked.ToString());
            data.Add("RedAfterZeroAmount", RedAfterZeroAmount.Text);
            data.Add("LongTimeNoSee", LongTimeNoSee.Checked.ToString());
            data.Add("LongTimeNoSeeAmount", LongTimeNoSeeAmount.Text);
            data.Add("LongTimeNoSeeFrom", LongTimeNoSeeFrom.Text);
            data.Add("LongTimeNoSeeTo", LongTimeNoSeeTo.Text);


            File.WriteAllText(this.path, JsonConvert.SerializeObject(data));
            this.Close();
        }

        private void closeClick(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void assignFormData(Dictionary<string, string> formData)
        {
            formData.TryGetValue("SixlineBet", out string sixlineBet);
            formData.TryGetValue("SixlineBetAmount", out string sixlineBetAmount);
            formData.TryGetValue("SixlineBetNumberBefore", out string sixlineBetNumberBefore);
            formData.TryGetValue("SixlineBetNumberBeforeAmount", out string sixlineBetNumberBeforeAmount);
            formData.TryGetValue("SecondSixlineBet", out string secondSixlineBet);
            formData.TryGetValue("SecondSixlineBetAmount", out string secondSixlineBetAmount);
            formData.TryGetValue("SecondSixlineBetNumberBefore", out string secondSixlineBetNumberBefore);
            formData.TryGetValue("SecondSixlineBetNumberBeforeAmount", out string secondSixlineBetNumberBeforeAmount);
            formData.TryGetValue("ThreeOfFour", out string threeOfFour);
            formData.TryGetValue("ThreeOfFourAmount", out string threeOfFourAmount);
            formData.TryGetValue("FirstFiveBlack", out string firstFiveBlack);
            formData.TryGetValue("FirstFiveBlackAmount", out string firstFiveBlackAmount);
            formData.TryGetValue("ColorSwitching", out string colorSwitching);
            formData.TryGetValue("ColorSwitchingAmount", out string colorSwitchingAmount);
            formData.TryGetValue("TwoColorsInRow", out string twoColorsInRow);
            formData.TryGetValue("TwoColorsInRowAmount", out string twoColorsInRowAmount);
            formData.TryGetValue("ColorStreakAfterZero", out string colorStreakAfterZero);
            formData.TryGetValue("ColorStreakAfterZeroAmount", out string colorStreakAfterZeroAmount);
            formData.TryGetValue("RedAfterZero", out string redAfterZero);
            formData.TryGetValue("RedAfterZeroAmount", out string redAfterZeroAmount);
            formData.TryGetValue("LongTimeNoSee", out string longTimeNoSee);
            formData.TryGetValue("LongTimeNoSeeAmount", out string longTimeNoSeeAmount);
            formData.TryGetValue("LongTimeNoSeeFrom", out string longTimeNoSeeFrom);
            formData.TryGetValue("LongTimeNoSeeTo", out string longTimeNoSeeTo);

            SixlineBet.Checked = Boolean.Parse(sixlineBet);
            SixlineBetAmount.Text = sixlineBetAmount;
            SixlineBetNumberBefore.Checked = Boolean.Parse(sixlineBetNumberBefore);
            SixlineBetNumberBeforeAmount.Text = sixlineBetNumberBeforeAmount;
            SecondSixlineBet.Checked = Boolean.Parse(secondSixlineBet);
            SecondSixlineBetAmount.Text = secondSixlineBetAmount;
            SecondSixlineBetNumberBefore.Checked = Boolean.Parse(secondSixlineBetNumberBefore);
            SecondSixlineBetNumberBeforeAmount.Text = secondSixlineBetNumberBeforeAmount;
            ThreeOfFour.Checked = Boolean.Parse(threeOfFour);
            ThreeOfFourAmount.Text = threeOfFourAmount;
            FirstFiveBlack.Checked = Boolean.Parse(firstFiveBlack);
            FirstFiveBlackAmount.Text = firstFiveBlackAmount;
            ColorSwitching.Checked = Boolean.Parse(colorSwitching);
            ColorSwitchingAmount.Text = colorSwitchingAmount;
            TwoColorsInRow.Checked = Boolean.Parse(twoColorsInRow);
            TwoColorsInRowAmount.Text = twoColorsInRowAmount;
            ColorStreakAfterZero.Checked = Boolean.Parse(colorStreakAfterZero);
            ColorStreakAfterZeroAmount.Text = colorStreakAfterZeroAmount;
            RedAfterZero.Checked = Boolean.Parse(redAfterZero);
            RedAfterZeroAmount.Text = redAfterZeroAmount;
            LongTimeNoSee.Checked = longTimeNoSee != null && Boolean.Parse(longTimeNoSee);
            LongTimeNoSeeAmount.Text = longTimeNoSeeAmount;
            LongTimeNoSeeFrom.Text = longTimeNoSeeFrom;
            LongTimeNoSeeTo.Text = longTimeNoSeeTo;
        }

        private void BetEvaluationConfigurator_Load(object sender, EventArgs e)
        {

        }
    }
}
