using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using System.IO;

namespace Tic_Tac_Toe.App
{
    public class Scores : Main
    {
        
        // Zwraca ostatnie id wyniku i zwiększa o 1
        /*
         public static int LastId
        {
            get
            {
                int id = 0;
                try
                {
                    if (Con.State == ConnectionState.Closed)
                        Con.Open();
                    querySQL = string.Format("SELECT Id FROM scores ORDER BY Id desc limit 1");
                    Command = new SQLiteCommand(querySQL, Con);
                    id = Convert.ToInt32(Command.ExecuteScalar());
                    ++id;
                }
                catch (Exception ex)
                {
                    string byk = string.Format("Błąd\n{0}", ex.Message);
                    MessageBox.Show(byk, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return id;
            }
        }
        */
    
    }

    public class Score
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Number_of_turns { get; set; }
        public string Who_won { get; set; }

        public Score() { }

        public Score(int id, DateTime data, int number_of_turns, string who_won)
        {
            this.Id = id;
            this.Data = data;
            this.Number_of_turns = number_of_turns;
            this.Who_won = who_won;
        }
    }
}



