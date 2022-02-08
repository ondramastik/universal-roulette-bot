using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RouletteBot.Models
{
    public class MysqlStatsRecorder : IStatsRecorder
    {
        private string connString = "server=roulette-statistics.cqrjm7r3gxpp.us-east-1.rds.amazonaws.com;uid=naxmars;pwd=jrMXcKIRzgYBfVwso9m1;database=roulette_bot";

        MySqlConnection conn;

        public MysqlStatsRecorder()
        {
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

        public void recordBetResult(Bet bet, int betAmount, int resultAmount, string gameId, int spin, int number)
        {
            string sql = string.Format("INSERT INTO bets(game_id, client_id, bet_name, rule_name, bet_amount, bet_result, spin, number, version) VALUES('{0}','{1}','{2}','{3}',{4},{5},{6},{7},'{6}')",
             gameId, Environment.UserName, bet.GetType().Name, bet.RuleName, betAmount.ToString(), resultAmount.ToString(), spin, number, "0.1.0");

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
