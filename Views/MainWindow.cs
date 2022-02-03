﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RouletteBot.Models;
using System.Threading;
using IronOcr;

namespace RouletteBot
{
    public partial class MainWindow : Form
    {
        private static int newNumberPositionX = 647;
        private static int newNumberPositionY = 325;
        private static int newNumberWidth = 24;
        private static int newNumberHeight = 17;

        private Game game;

        public MainWindow(Game game)
        {
            InitializeComponent();
            this.game = game;
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

                if (game.isRoundReady())
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
                        game.playRound(number);
                        counter++;
                    }

                    Thread.Sleep(300);
                }
            }).Start();
        }
        private int readNumber()
        {
            Bitmap newNumber = WinAPI.CreateScreenshot(newNumberPositionX, newNumberPositionY, newNumberWidth + newNumberPositionX, newNumberHeight + newNumberPositionY);

            var conf = new TesseractConfiguration
            {
                WhiteListCharacters = "0123456789",
                PageSegmentationMode = TesseractPageSegmentationMode.SingleLine,
                EngineMode = TesseractEngineMode.TesseractOnly
            };

            var Ocr = new IronTesseract(conf);

            using (var Input = new OcrInput(newNumber))
            {
                OcrResult result = Ocr.Read(Input);

                try
                {
                    return Int32.Parse(result.Text);
                }
                catch (Exception ex)
                {
                    /* For some reason 4 is the only number that wont get recoginzed */
                    return 4;
                }
            }
        }
    }
}