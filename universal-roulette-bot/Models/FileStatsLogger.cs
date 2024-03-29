﻿using System.IO;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models
{
    public class FileStatsLogger : IStatsLogger
    {
        private string fileName;

        public FileStatsLogger(string fileName)
        {
            this.fileName = fileName;

            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName,
                    "Bet name, Rule name, Bet amount,Result amount,=SUBTOTAL(9;C2:C100000),=SUBTOTAL(9;D2:D100000),=(FLOOR((F1/E1) * 100) - 100)\r\n");
            }
        }

        public void RecordBetResult(Bet bet, int betAmount, int resultAmount, string gameId, int spin, int number,
            string rouletteType, int lastbefore)
        {
            File.AppendAllText(fileName, string.Format("{0},{1},{2},{3}\r\n",
                bet.GetType().Name, bet.RuleName, betAmount.ToString(), resultAmount.ToString()));
        }
    }
}