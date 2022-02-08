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

        public MainWindow(Game game)
        {
            InitializeComponent();
            this.Game = game;
        }

        private void playRoundClick(object sender, System.EventArgs e)
        {
            this.tableReader = new GameTableReader(new MappingConfig());
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

        private void doubleSixLineBetsChanged(object sender, System.EventArgs e)
        {
            Game.EvaluationConfig.DoubleSixLineBets = doubleSixLineBets.Checked;
        }
    }
}
