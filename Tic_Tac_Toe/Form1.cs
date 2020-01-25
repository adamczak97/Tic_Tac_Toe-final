using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.IO;
using System.Data.Common;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_count = 0;
        string querySQL = "";
        public static SQLiteCommand Command;
        public static SQLiteDataReader Reader;
        public static string QuerySQL = "";


        public Form1()
        {
            InitializeComponent();
        }

        string data = DateTime.Now.ToString();

            string data1 = DateTime.Now.ToString();
            private SQLiteConnection sql_con;
            private SQLiteCommand sql_cmd;
            private SQLiteDataAdapter DB;
            private DataSet DS = new DataSet();
            private DataTable DT = new DataTable();


        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source = scores.db; Version=3;New= False;Compress=True;");
        }
        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gracze obejmują pola na przemian dążąc do objęcia trzech pól w jednej linii,"
                + " przy jednoczesnym uniemożliwieniu tego samego przeciwnikowi.");
        }
            /*
            con.Open();
            if(con.State == ConnectionState.Open)
            {
            querySQL = string.Format("CREATE TABLE scores(Id INTEGER PRIMARY KEY AUTOINCREMENT, Date dataTime,Rounds NUMERIC(10),Winner TEXT)");
            Command = new SQLiteCommand(querySQL, con);
            Command.ExecuteNonQuery();
            }
            con.Close();
            */


            /*
                con.Open();
                if(con.State == ConnectionState.Open)
                { 
                querySQL = string.Format("INSERT INTO scores(Date, Rounds, Winner) VALUES ('{0}','{1}','{2}')", data1, r, win); ;
                Command.CommandText = querySQL;
                Command.ExecuteNonQuery();
                }
                con.Close();
             */



        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void b_click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            int newSize = 75;
            b.Font = new Font(Button.DefaultFont.FontFamily, newSize);

            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false;
            turn_count++;

            check();
        }



        private void check()
        {
            bool winner = false;

            //horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winner = true;

            // vertical
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;


            //diagonal
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                winner = true;

            // winning
            string txtQuery = "";
            string win = "";
            if (winner == true)
            {
                disableButtons();
                string who_win = "";
                if (turn)
                    who_win = "O";
                else
                    who_win = "X";

                MessageBox.Show(who_win + " wins!");
                if (turn_count % 2 == 0)
                {
                    win = "O";
                }
                else if (turn_count % 2 != 0 && winner == true)
                {
                    win = "X";
                }
                //zapis wyników do bazy
                txtQuery = "INSERT INTO scores(Date, Rounds, Winner) VALUES ('" + data1 + "','" + turn_count + "','" + win + "')";
                ExecuteQuery(txtQuery);
            }
            else if (winner == false)
            {

                if (turn_count == 9)
                {
                    MessageBox.Show("Draw!");
                    win = "DRAW";
                    txtQuery = "INSERT INTO scores(Date, Rounds, Winner) VALUES ('" + data1 + "','" + turn_count + "','" + win + "')";
                    ExecuteQuery(txtQuery
                        );
                }
            }

            

        }

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        //new game
        private void nowaGraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            A1.Enabled = true;
            A2.Enabled = true;
            A3.Enabled = true;
            B1.Enabled = true;
            B2.Enabled = true;
            B3.Enabled = true;
            C1.Enabled = true;
            C2.Enabled = true;
            C3.Enabled = true;

            turn_count = 0;
            foreach (var item in this.Controls)
            {
                if (item.GetType().Equals(typeof(Button)))
                {
                    Button A1 = item as Button;
                    A1.Text = string.Empty;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void wynikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Window2 w2 = new Window2();
            w2.ShowDialog();
        }
    }
}


