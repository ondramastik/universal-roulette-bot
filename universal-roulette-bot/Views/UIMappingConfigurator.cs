using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RouletteBot.Views
{
    public partial class UiMappingConfigurator : Form
    {
        private readonly string _path;

        public UiMappingConfigurator(string configPath = null)
        {
            InitializeComponent();

            if (configPath == null)
            {
                _path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                            @"\RouletteBot\roulette-config.conf";
            }
            else
            {
                _path = configPath;
            }

            if (File.Exists(_path))
            {
                var data = File.ReadAllText(_path);
                AssignFormData(JsonConvert.DeserializeObject<Dictionary<string, string>>(data));
            }
        }

        private void SaveClick(object sender, EventArgs e)
        {
            var data = new Dictionary<string, string>
            {
                { "gridLeftTopCornerX", GridLeftTopCornerX.Text },
                { "gridLeftTopCornerY", GridLeftTopCornerY.Text },
                { "gridRightBottomCornerX", GridRightBottomCornerX.Text },
                { "gridRightBottomCornerY", GridRightBottomCornerY.Text },
                { "blackBetX", BlackBetX.Text },
                { "blackBetY", BlackBetY.Text },
                { "redBetX", RedBetX.Text },
                { "redBetY", RedBetY.Text },
                { "confirmBetX", ConfirmBetX.Text },
                { "confirmBetY", ConfirmBetY.Text },
                { "spinReadyCheckX", SpinReadyCheckX.Text },
                { "spinReadyCheckY", SpinReadyCheckY.Text },
                { "SixLineBetY", SixLineBetY.Text },
                { "numberCheckOffsetX", NumberCheckOffsetX.Text },
                { "numberCheckOffsetY", NumberCheckOffsetY.Text },
                { "forResolutionX", ForResolutionX.Text },
                { "forResolutionY", ForResolutionY.Text },
                { "recalculateForX", RecalculateForX.Text },
                { "recalculateForY", RecalculateForY.Text },
                { "isMulti", IsMulti.Checked.ToString() },
                { "isDemo", IsDemo.Checked.ToString() }
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
            formData.TryGetValue("gridLeftTopCornerX", out var gridLeftTopCornerX);
            formData.TryGetValue("gridLeftTopCornerY", out var gridLeftTopCornerY);
            formData.TryGetValue("gridRightBottomCornerX", out var gridRightBottomCornerX);
            formData.TryGetValue("gridRightBottomCornerY", out var gridRightBottomCornerY);
            formData.TryGetValue("blackBetX", out var blackBetX);
            formData.TryGetValue("blackBetY", out var blackBetY);
            formData.TryGetValue("redBetX", out var redBetX);
            formData.TryGetValue("redBetY", out var redBetY);
            formData.TryGetValue("confirmBetX", out var confirmBetX);
            formData.TryGetValue("confirmBetY", out var confirmBetY);
            formData.TryGetValue("spinReadyCheckX", out var spinReadyCheckX);
            formData.TryGetValue("spinReadyCheckY", out var spinReadyCheckY);
            formData.TryGetValue("SixLineBetY", out var sixLineBetY);
            formData.TryGetValue("numberCheckOffsetX", out var numberCheckOffsetX);
            formData.TryGetValue("numberCheckOffsetY", out var numberCheckOffsetY);
            formData.TryGetValue("forResolutionX", out var forResolutionX);
            formData.TryGetValue("forResolutionY", out var forResolutionY);
            formData.TryGetValue("recalculateForX", out var recalculateForX);
            formData.TryGetValue("recalculateForY", out var recalculateForY);
            formData.TryGetValue("isMulti", out var isMulti);
            formData.TryGetValue("isDemo", out var isDemo);

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
            IsMulti.Checked = bool.TryParse(isMulti, out var isMultiBool) && isMultiBool;
            IsDemo.Checked = !bool.TryParse(isDemo, out var isDemoBool) || isDemoBool;
        }
    }
}