using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace LearningDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connstring = "server=localhost;uid=root;pwd=Sa123;database=learning_db";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                conn.Open();
                string sql = "insert into learning_db.employee_primary_info(name,employee_id,email_id,date_of_birth,blood_group,designation,employee_status,gender,nationality,dateof_joining) values('" + textBox1.Text + "', " + textBox2.Text + ", '" + textBox3.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + comboBox1.SelectedItem + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox2.SelectedItem + "','" + textBox7.Text + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                if (i > -1)
                {
                    MessageBox.Show("Data Inserted Succesfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "server=localhost;uid=root;pwd=Sa123;database=learning_db";
            MySqlConnection con = new MySqlConnection(constring);
            con.Open();
            string readtable = "select * from learning_db.employee_primary_info";
            MySqlCommand cmd = new MySqlCommand(readtable, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
            string constring = "server=localhost;uid=root;pwd=Sa123;database=learning_db";
            MySqlConnection con = new MySqlConnection(constring);
            con.Open();
            string update = "select count * from learning_db.employee_primary_info WHERE employee_id = @employee_id";
            MySqlCommand cmdcheck = new MySqlCommand(update, con);
            cmdcheck.Parameters.AddWithValue("@employee_id", textBox2.Text);
            int count = Convert.ToInt32(cmdcheck.ExecuteScalar());
            if (count == 0)
            {
                MessageBox.Show("EMployee Id not Found:" + textBox2.Text + "");
            }
            else
            {
                string query = "update learning_db.employee_primary_info set name='" + textBox1.Text + "',employee_id='" + textBox2.Text + ", email_id='" + textBox3.Text + "',date_of_birth='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',blood_group='" + comboBox1.SelectedItem + "',designation='" + textBox5.Text + "',employee_status='" + textBox6.Text + "',gender='" + comboBox2.SelectedItem + "',nationality='" + textBox7.Text + "',dateof_joining='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "WHERE employee_id=employee_id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", 2);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Data Updated successfully");
                }
                else
                {
                    MessageBox.Show("Nothing to update in given record\r\nPlease update somthing..");
                }
            }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string constring = "server=localhost;uid=root;pwd=Sa123;database=learning_db";
                MySqlConnection con = new MySqlConnection(constring);
                con.Open();
                string checkQuery = "SELECT COUNT(*) FROM learning_db.employee_primary_info WHERE employee_id = @employee_id";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@employee_id", textBox2.Text);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    MessageBox.Show("Details not found. Cannot delete.");
                }
                else
                {
                    string deleteQuery = "DELETE FROM learning_db.employee_primary_info WHERE employee_id = @employee_id";
                    MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, con);
                    deleteCmd.Parameters.AddWithValue("@employee_id", textBox2.Text);

                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Delete operation failed. Please try again.");
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}

