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


namespace Tic_Tac_Toe
{
    public class Main : Form1
    {
        public static SQLiteConnection _Con;
        public static SQLiteConnection Con
        {
           get
           {
                 if (!File.Exists(Path.Combine(Application.StartupPath, "scores.db")))
                {
                _Con = new SQLiteConnection(string.Format("Data Source={0}", Path.Combine(Application.StartupPath, "scores.db")));
                _Con.Open();

                querySQL = string.Format("CREATE TABLE IF NOT EXISTS scores(Id INTEGER PRIMARY KEY AUTO INCREMENT, Date dataTime,Rounds NUMERIC(10),Winner TEXT)");
                Command = new SQLiteCommand(querySQL, Con);
                Command.ExecuteNonQuery();
                _Con.Close();
                }
                else
                {
                    if (_Con == null)
                        _Con = new SQLiteConnection(string.Format("Data Source = {0}", Path.Combine(Application.StartupPath, "scores.db")));
                }
                return _Con;
             
            }
        }
        public static string querySQL = "";
    }
}