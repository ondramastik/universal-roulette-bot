using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RouletteBot.Models;
using System.Threading;

namespace RouletteBot
{
    public partial class MainWindow : Form
    {
        private Game Game;

        public MainWindow(Game game)
        {
            InitializeComponent();
            this.Game = game;
        }

        private void playRoundClick(object sender, System.EventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                var numbers = new List<int>();
                int counter = 1;
                while (true)
                {
                    int number = readNumber();

                if (Game.isRoundReady())
                {

                        if (number >= 0)
                        {
                            numbers.Add(number);
                            if (numbers.Count > 12)
                            {
                                numbers = numbers.Skip(1).ToList();
                            }

                            this.numbersView.Invoke((MethodInvoker)delegate
                            {
                                this.numbersView.Text = "round " + counter + ", " + string.Join(", ", numbers);
                            });
                        }
                        Game.playRound(number);
                        counter++;
                    }

                    Thread.Sleep(300);
                }
            }).Start();
        }

        private void doubleSixLineBetsChanged(object sender, System.EventArgs e)
        {
            Game.EvaluationConfig.DoubleSixLineBets = doubleSixLineBets.Checked;
        }

        private int readNumber()
        {
            return 4;
        }
    }
}
