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
    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        OleDbDataAdapter oda;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP-PC\Documents\MiniProject.accdb;
Persist Security Info=False;";
            
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            label3.Visible = false;
            textBox3.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            radioButton1.Visible = true;
            button3.Visible = false;
            radioButton2.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button1.Visible = false;
           // button2.Visible = false;
           // label3.Visible = true;
            //textBox3.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             ds = new DataSet();
            ds.Clear();

            string cmd = "Select * From Login where userid = '" + textBox1.Text + "' and password = '" + textBox2.Text + "' and cat = 'student';";
            oda = new OleDbDataAdapter(cmd, connection);
            oda.Fill(ds);
           
            if (ds.Tables[0].Rows.Count == 1)
            {
                MessageBox.Show("Logged In Successfully");
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
              }
            else
            {
                MessageBox.Show("Sorry Records doesn't exist");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
         radioButton1.Visible = false;
            radioButton2.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            label3.Visible = false;
            textBox3.Visible = false;
            button1.Visible = true;
          //  button2.Visible = true;
        //    button3.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds.Clear();

            string cmd = "Select * From Login where userid = '" + textBox1.Text + "' and password = '" + textBox2.Text + "' and cat = 'staff';";
            oda = new OleDbDataAdapter(cmd, connection);
            oda.Fill(ds);

            if (ds.Tables[0].Rows.Count == 1)
            {
                MessageBox.Show("Logged In Successfully");
                this.Hide();
                Form6 f2 = new Form6();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sorry Records doesn't exist");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
               // string msg = "";
                if (radioButton1.Checked == true)
                {
                  //  msg = "student";
                    command.CommandText = "insert into Login values('" + textBox1.Text + "','" + textBox2.Text + "','student');";
                    command.ExecuteNonQuery();
                    
                }
                else if (radioButton2.Checked == true)
                {
               //     msg = "staff";

                    command.CommandText = "insert into Login values('" + textBox1.Text + "','" + textBox2.Text + "','staff');";
                    command.ExecuteNonQuery();
                   
                }
            //   command.CommandText = "insert into Login values('" + textBox1.Text + "','" + textBox2.Text + "','" + msg + "');";
            //   command.ExecuteNonQuery();

           
                MessageBox.Show("Successfully Registered");
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                button4.Visible = false;

                button1.Visible = true;
               // button2.Visible = true;
                button3.Visible = true;
                button5.Visible = false;
                textBox1.Clear();
                textBox2.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;


            }
           catch (Exception exc)
             {
                MessageBox.Show("Error While Registering");
              }
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            ds = new DataSet();
            ds.Clear();

            string cmd = "Select * From Login where userid = '" + textBox1.Text + "' and password = '" + textBox2.Text + "' and cat = '"+comboBox1.Text+"';";
            oda = new OleDbDataAdapter(cmd, connection);
            oda.Fill(ds);

            if (ds.Tables[0].Rows.Count == 1)
            {
                MessageBox.Show("Logged In Successfully");
                if (comboBox1.Text == "staff")
                {
                    this.Hide();
                    Form6 f2 = new Form6();
                    f2.ShowDialog();
                }
                else
                {
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Sorry Records doesn't exist");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

}

    

