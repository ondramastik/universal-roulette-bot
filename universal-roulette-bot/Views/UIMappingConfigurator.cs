using System.Windows.Forms;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace RouletteBot.Views
{
    public partial class UIMappingConfigurator : Form
    {
        private string path;

        public UIMappingConfigurator(string configPath = null)
        {
            InitializeComponent();

            if (configPath == null)
            {
                this.path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\RouletteBot\roulette-config.conf";
            }
            else
            {
                this.path = configPath;
            }

            if(File.Exists(this.path))
            {
                string data = File.ReadAllText(this.path);
                assignFormData(JsonConvert.DeserializeObject<Dictionary<string, string>>(data));
            }
        }

        private void saveClick(object sender, System.EventArgs e)
        {
            var data = new Dictionary<string, string>();

            data.Add("gridLeftTopCornerX", GridLeftTopCornerX.Text);
            data.Add("gridLeftTopCornerY", GridLeftTopCornerY.Text);
            data.Add("gridRightBottomCornerX", GridRightBottomCornerX.Text);
            data.Add("gridRightBottomCornerY", GridRightBottomCornerY.Text);
            data.Add("blackBetX", BlackBetX.Text);
            data.Add("blackBetY", BlackBetY.Text);
            data.Add("redBetX", RedBetX.Text);
            data.Add("redBetY", RedBetY.Text);
            data.Add("confirmBetX", ConfirmBetX.Text);
            data.Add("confirmBetY", ConfirmBetY.Text);
            data.Add("spinReadyCheckX", SpinReadyCheckX.Text);
            data.Add("spinReadyCheckY", SpinReadyCheckY.Text);
            data.Add("sixLineBetY", SixLineBetY.Text);
            data.Add("numberCheckOffsetX", NumberCheckOffsetX.Text);
            data.Add("numberCheckOffsetY", NumberCheckOffsetY.Text);
            data.Add("forResolutionX", ForResolutionX.Text);
            data.Add("forResolutionY", ForResolutionY.Text);
            data.Add("recalculateForX", RecalculateForX.Text);
            data.Add("recalculateForY", RecalculateForY.Text);


            File.WriteAllText(this.path, JsonConvert.SerializeObject(data));
            this.Close();
        }
          
        private void closeClick(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void assignFormData(Dictionary<string, string> formData)
        {
            formData.TryGetValue("gridLeftTopCornerX", out string gridLeftTopCornerX);
            formData.TryGetValue("gridLeftTopCornerY", out string gridLeftTopCornerY);
            formData.TryGetValue("gridRightBottomCornerX", out string gridRightBottomCornerX);
            formData.TryGetValue("gridRightBottomCornerY", out string gridRightBottomCornerY);
            formData.TryGetValue("blackBetX", out string blackBetX);
            formData.TryGetValue("blackBetY", out string blackBetY);
            formData.TryGetValue("redBetX", out string redBetX);
            formData.TryGetValue("redBetY", out string redBetY);
            formData.TryGetValue("confirmBetX", out string confirmBetX);
            formData.TryGetValue("confirmBetY", out string confirmBetY);
            formData.TryGetValue("spinReadyCheckX", out string spinReadyCheckX);
            formData.TryGetValue("spinReadyCheckY", out string spinReadyCheckY);
            formData.TryGetValue("sixLineBetY", out string sixLineBetY);
            formData.TryGetValue("numberCheckOffsetX", out string numberCheckOffsetX);
            formData.TryGetValue("numberCheckOffsetY", out string numberCheckOffsetY);
            formData.TryGetValue("forResolutionX", out string forResolutionX);
            formData.TryGetValue("forResolutionY", out string forResolutionY);
            formData.TryGetValue("recalculateForX", out string recalculateForX);
            formData.TryGetValue("recalculateForY", out string recalculateForY);

            GridLeftTopCornerX.Text = gridLeftTopCornerX;
            GridLeftTopCornerY.Text = gridLeftTopCornerY;
            GridRightBottomCornerX.Text = gridRightBottomCornerX;
            GridRightBottomCornerY.Text = gridRightBottomCornerY;
            BlackBetX.Text = blackBetX;
            BlackBetY.Text = blackBetY;
            RedBetX.Text = redBetX;
            RedBetY.Text = redBetY;
            ConfirmBetX.Text = confirmBetX;
            ConfirmBetY.Text = confirmBetY;
            SpinReadyCheckX.Text = spinReadyCheckX;
            SpinReadyCheckY.Text = spinReadyCheckY;
            SixLineBetY.Text = sixLineBetY;
            NumberCheckOffsetX.Text = numberCheckOffsetX;
            NumberCheckOffsetY.Text = numberCheckOffsetY;
            ForResolutionX.Text = forResolutionX;
            ForResolutionY.Text = forResolutionY;
            RecalculateForX.Text = recalculateForX;
            RecalculateForY.Text = recalculateForY;
        }
    }
}
