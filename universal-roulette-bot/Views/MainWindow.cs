using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using RouletteBot.Controllers;
using RouletteBot.Models;

namespace RouletteBot.Views
{
    public partial class MainWindow : Form
    {
        private Game _game;

        private GameTableReader _tableReader;

        public MainWindow()
        {
            InitializeComponent();
        }

        private static string GetRouletteType(MappingConfig config)
        {
            string result = config.IsMulti ? "multi" : "platinum";

            result += config.IsDemo ? "-demo" : "-real";

            return result;
        }

        private void PlayRoundClick(object sender, EventArgs e)
        {
            int[] num = null;
            var mappingConf = new MappingConfig();
            IRouletteControls controls = new MouseRouletteControls(mappingConf);
            _game = new Game(
                controls,
                new MysqlStatsLogger(),
                new BetEvaluationFileConfig(),
                GetRouletteType(mappingConf));

            _tableReader = new GameTableReader(mappingConf);
            _tableReader.ReadReadyCheckColor();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                var numbers = new List<int>();
                var counter = 1;
                while (true)
                {
                    var number = counter == 1 ? -1 : _tableReader.ReadNumber();
                    if (number >= 0)
                    {
                        numbers.Add(number);
                        if (numbers.Count > 9)
                        {
                            numbers = numbers.Skip(1).ToList();
                        }

                        numbersView.Invoke((MethodInvoker)delegate
                        {
                            numbersView.Text = string.Format("Hraje se {0}. kolo", counter) + "\r\n" +
                                               string.Join(", ", numbers);

                            if (num != null && num.Length > 1)
                            {
                                numbersView.Text +=
                                    string.Format("\r\nNejvzácnější číslo 1: {0}\r\nVýskyt naposled před: {1}", num[0],
                                        num[1]);
                            }

                            if (num != null && num.Length > 3)
                            {
                                numbersView.Text +=
                                    string.Format("\r\nNejvzácnější číslo 2: {0}\r\nVýskyt naposled před: {1}", num[2],
                                        num[3]);
                            }

                            if (num != null && num.Length > 5)
                            {
                                numbersView.Text +=
                                    string.Format("\r\nNejvzácnější číslo 3: {0}\r\nVýskyt naposled před: {1}", num[4],
                                        num[5]);
                            }
                        });
                    }

                    bool ready = false;
                    while (!ready)
                    {
                        Thread.Sleep(50);
                        ready = _tableReader.IsRoundReady();
                    }

                    _game.Evaluate(number, counter);
                    num = getLongTimeNoSeeNumber(_game.PlayRound(number));

                    while (ready)
                    {
                        Thread.Sleep(50);
                        ready = _tableReader.IsRoundReady();
                    }

                    if (!mappingConf.IsMulti)
                    {
                        ready = false;

                        while (!ready)
                        {
                            Thread.Sleep(50);
                            ready = _tableReader.IsSkipReady();
                        }

                        controls.spin();
                    }

                    counter++;
                }
            }).Start();
        }

        private void showEditMappingForm(object sender, EventArgs e)
        {
            var configurator = new UiMappingConfigurator();

            configurator.Show();
        }

        private void showEditBettingForm(object sender, EventArgs e)
        {
            var configurator = new BetEvaluationConfigurator();

            configurator.Show();
        }

        private void highlightConfiguredMapping(object sender, EventArgs e)
        {
            //MessageBox.Show("Nezkoušet na opravdové ruletě, místo toho udělat sceenshot rulety, otevřít ho na fullscreen a až poté testovat a upravovat. Ruleta se přerendrovává příliš vysokou frekvencí a tak to přepisuje a poblikává to.");
            var mappingConf = new MappingConfig();
            _tableReader = new GameTableReader(mappingConf);
            _tableReader.HighlightConfiguredMapping();
        }

        private int[] getLongTimeNoSeeNumber(int[] numbers)
        {
            var lastSeeNumbers = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int roundsWithoutSeeTmp = RouletteHelper.GetLastOccurance(numbers, numbers[i]);

                if (lastSeeNumbers.ContainsKey(numbers[i]))
                {
                    lastSeeNumbers[numbers[i]] = roundsWithoutSeeTmp;
                }
                else
                {
                    lastSeeNumbers.Add(numbers[i], roundsWithoutSeeTmp);
                }
            }

            lastSeeNumbers = lastSeeNumbers.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            var result = new List<int>();

            foreach (var number in lastSeeNumbers.Skip(Math.Max(0, lastSeeNumbers.Count() - 3)))
            {
                result.Add(number.Key);
                result.Add(number.Value);
            }

            return result.ToArray();
        }
    }
}