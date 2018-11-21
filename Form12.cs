using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace mini_project
{
    public partial class Form12 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public Form12()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP-PC\Documents\MiniProject.accdb;
Persist Security Info=False;";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "delete from Issue where bookid = " + textBox1.Text + " and usn = '" + textBox2.Text + "' ;";
                command.ExecuteNonQuery();

                MessageBox.Show("Book Returned");
                textBox1.Clear();
                textBox2.Clear();
               



            }
            catch (Exception exc)
            {
                MessageBox.Show("Error While Returning Book!!");

            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
}
