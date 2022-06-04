using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models
{
    class BulkInsertRow
    {
        Bet bet;
        string gameId;
        int betAmount;
        int resultAmount;
        int spin;
        int number;
        string rouletteType;
        int lastBefore;

        public BulkInsertRow(Bet bet, string gameId, int betAmount, int resultAmount, int spin, int number,
            string rouletteType, int lastBefore)
        {
            this.bet = bet;
            this.gameId = gameId;
            this.betAmount = betAmount;
            this.resultAmount = resultAmount;
            this.spin = spin;
            this.number = number;
            this.rouletteType = rouletteType;
            this.lastBefore = lastBefore;
        }

        public string getInsertRow()
        {
            return string.Format("('{0}','{1}','{2}','{3}',{4},{5},{6},{7},'{8}','{9}',{10})", gameId,
                Environment.UserName, bet.GetType().Name, bet.RuleName, betAmount.ToString(), resultAmount.ToString(),
                spin, number, "1.4.0", rouletteType, lastBefore);
        }
    }

    public class MysqlStatsRecorder : IStatsRecorder
    {
        private string connString =
            "server=roulette-statistics.cqrjm7r3gxpp.us-east-1.rds.amazonaws.com;uid=naxmars;pwd=jrMXcKIRzgYBfVwso9m1;database=roulette_bot";

        MySqlConnection conn;

        private List<BulkInsertRow> rows;

        public MysqlStatsRecorder()
        {
            rows = new List<BulkInsertRow>();
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void recordBetResult(Bet bet, int betAmount, int resultAmount, string gameId, int spin, int number,
            string rouletteType, int lastBefore)
        {
            rows.Add(new BulkInsertRow(bet, gameId, betAmount, resultAmount, spin, number, rouletteType, lastBefore));


            if (rows.Count > 20)
            {
                List<string> data = new List<string>();
                foreach (BulkInsertRow row in rows)
                {
                    data.Add(row.getInsertRow());
                }

                string sql =
                    string.Format(
                        "INSERT INTO bets(game_id, client_id, bet_name, rule_name, bet_amount, bet_result, spin, number, version, roulette_type, last_before) VALUES{0};",
                        String.Join(",", data));


                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                rows.Clear();
            }
        }
    }
}