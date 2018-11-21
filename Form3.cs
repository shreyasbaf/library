using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace mini_project
{
    public partial class Form3 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        OleDbDataAdapter oda;
        DataSet ds;
        public Form3()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP-PC\Documents\MiniProject.accdb;
Persist Security Info=False;";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds.Clear();

            string cmd = "Select b.bookid,b.title,a.authorName from Books b,Authors a where b.title = '" + textBox1.Text + "' and b.bookid = a.bookid;";
            oda = new OleDbDataAdapter(cmd, connection);
            oda.Fill(ds);

            if (ds.Tables[0].Rows.Count >= 1)
            {

                dataGridView1.Visible = true;
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("Sorry Records doesn't exist");
                dataGridView1.Visible = false;
               // textBox2.Clear();
            }
        }
    }
}
