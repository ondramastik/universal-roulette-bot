using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RouletteBot.Models;
using System.Threading;

namespace RouletteBot.Views
{
    public partial class MainWindow : Form
    {
        private Game Game;

        private GameTableReader tableReader;

        public MainWindow()
        {
            InitializeComponent();
        }

        private string getRuletteType()
        {
            string result = IsMulti.Checked ? "multi" : "platinum";

            result += IsDemo.Checked ? "-demo" : "-real";

            return result;
        }

        private void playRoundClick(object sender, System.EventArgs e)
        {
            var mappingConf = new MappingConfig();
            Game = new Game(
                new MouseRouletteControls(mappingConf),
                new MysqlStatsRecorder(),
                new BetEvaluationConfig(),
                getRuletteType());

            this.tableReader = new GameTableReader(mappingConf);
            tableReader.readReadyCheckColor();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                var numbers = new List<int>();
                int counter = 1;
                while (true)
                {
                    int number = counter == 1 ? -1 : tableReader.ReadNumber();
                    if (number >= 0)
                    {
                        numbers.Add(number);
                        if (numbers.Count > 9)
                        {
                            numbers = numbers.Skip(1).ToList();
                        }

                        this.numbersView.Invoke((MethodInvoker)delegate
                        {
                            this.numbersView.Text = string.Format("Hraje se {0}. kolo", counter) + "\r\n" + string.Join(", ", numbers);
                        });
                    }

                    bool ready = false;
                    while(!ready)
                    {
                        Thread.Sleep(50);
                        ready = tableReader.IsRoundReady();
                    }

                    Game.playRound(number, counter);

                    while (ready)
                    {
                        Thread.Sleep(50);
                        ready = tableReader.IsRoundReady();
                    }

                    counter++;
                }
            }).Start();
        }

        private void showEditMappingForm(object sender, System.EventArgs e)
        {
            var configurator = new UIMappingConfigurator();

            configurator.Show();
        }

        private void showEditBettingForm(object sender, System.EventArgs e)
        {
            var configurator = new BetEvaluationConfigurator();

            configurator.Show();
        }

        private void highlightConfiguredMapping(object sender, System.EventArgs e)
        {
            MessageBox.Show("Nezkoušet na opravdové ruletě, místo toho udělat sceenshot rulety, otevřít ho na fullscreen a až poté testovat a upravovat. Ruleta se přerendrovává příliš vysokou frekvencí a tak to přepisuje a poblikává to.");
            var mappingConf = new MappingConfig();
            this.tableReader = new GameTableReader(mappingConf);
            tableReader.HighlightConfiguredMapping();
        }
    }
}
