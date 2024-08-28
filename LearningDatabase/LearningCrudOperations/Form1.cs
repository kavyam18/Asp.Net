using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LearningCrudOperations
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            //string constring = "server=localhost;uid=root;pwd=Sa123;database=learning_db";
            //MySqlConnection con = new MySqlConnection(constring);
            //con.Open();
            //string update = "UPDATE learning_db.employee_primary_info SET " +
            //  "name = @name, " +
            //  "email_id = @email, " +
            //  "date_of_birth = @dob, " +
            //  "blood_group = @bloodGroup, " +
            //  "designation = @designation, " +
            //  "employee_status = @status, " +
            //  "gender = @gender, " +
            //  "nationality = @nationality, " +
            //  "dateof_joining = @dateOfJoining " +
            //  "WHERE employee_id = @employeeId";
            //MySqlCommand cmd = new MySqlCommand(update, con);

            //MySqlDataReader reader = cmd.ExecuteReader();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constring = "server=localhost;uid=root;pwd=Sa123;database=learning_db";
            MySqlConnection con = new MySqlConnection(constring);
            con.Open();
            string search = "select * from learning_db.employee_primary_info WHERE employee_id = @employeeId";
            MySqlCommand cmd = new MySqlCommand(search, con);
            cmd.Parameters.AddWithValue("@employeeId", textBox1.Text);
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Access data from the reader
                        string name = reader["name"].ToString();
                        int employeeId = Convert.ToInt32(reader["employee_id"]);
                        string email = reader["email_id"].ToString();
                        DateTime dateOfBirth = Convert.ToDateTime(reader["date_of_birth"]);
                        string bloodGroup = reader["blood_group"].ToString();
                        string designation = reader["designation"].ToString();
                        string employeeStatus = reader["employee_status"].ToString();
                        string gender = reader["gender"].ToString();
                        string nationality = reader["nationality"].ToString();
                        DateTime dateOfJoining = Convert.ToDateTime(reader["dateof_joining"]);

                        Console.WriteLine($"Name: {name}, Employee ID: {employeeId}, Email: {email}, DOB: {dateOfBirth.ToShortDateString()}, Blood Group: {bloodGroup}, Designation: {designation}, Status: {employeeStatus}, Gender: {gender}, Nationality: {nationality}, Date of Joining: {dateOfJoining.ToShortDateString()}");
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                // Close the reader
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }
    }
}

