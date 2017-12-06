using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace AI_Speech
{
    public partial class inputForm : Form
    {
        public inputForm()
        {
            InitializeComponent();
        }
        SQLiteConnection ob = new SQLiteConnection();
        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt1.Text != null && txt1.Text != "" && txt2.Text != "" && txt2.Text != "")
            {
                try
                {
                    if (ob.State != ConnectionState.Open)
                    {
                        ob.ConnectionString = "Data Source=Commands.sqlite;Version=3;";
                        ob.Open();
                    }
                    SQLiteCommand cmd = new SQLiteCommand("insert into cmd (command,responce) values (" + "'" + txt1.Text + "'," + "'" + txt2.Text + "')", ob);
                    cmd.ExecuteNonQuery();
                    ob.Close();
                    txt1.Text = "";
                    txt2.Text = "";
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("Pleas Enter All Filds");
            }
        }
    }
}
