using System.Windows.Forms;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace RouletteBot.Views
{
    public partial class UIMappingConfigurator : Form
    {
        private string configPath;

        public UIMappingConfigurator(string configPath = null)
        {
            InitializeComponent();

            if (configPath == null)
            {
                configPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\RouletteBot\roulette-config.conf";
            }

            if(File.Exists(configPath))
            {
                string data = File.ReadAllText(configPath);
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
            data.Add("spinX", SpinX.Text);
            data.Add("spinY", SpinY.Text);
            data.Add("spinReadyCheckX", SpinReadyCheckX.Text);
            data.Add("spinReadyCheckY", SpinReadyCheckY.Text);


            File.WriteAllText(configPath, JsonConvert.SerializeObject(data));
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
            formData.TryGetValue("spinX", out string spinX);
            formData.TryGetValue("spinY", out string spinY);
            formData.TryGetValue("spinReadyCheckX", out string spinReadyCheckX);
            formData.TryGetValue("spinReadyCheckY", out string spinReadyCheckY);

            GridLeftTopCornerX.Text = gridLeftTopCornerX;
            GridLeftTopCornerY.Text = gridLeftTopCornerY;
            GridRightBottomCornerX.Text = gridRightBottomCornerX;
            GridRightBottomCornerY.Text = gridRightBottomCornerY;
            BlackBetX.Text = blackBetX;
            BlackBetY.Text = blackBetY;
            RedBetX.Text = redBetX;
            RedBetY.Text = redBetY;
            SpinX.Text = spinX;
            SpinY.Text = spinY;
            SpinReadyCheckX.Text = spinReadyCheckX;
            SpinReadyCheckY.Text = spinReadyCheckY;
        }
    }
}
