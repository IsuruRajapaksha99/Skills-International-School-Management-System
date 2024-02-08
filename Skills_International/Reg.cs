using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Skills_International
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int regNo = 0; // Default value, assuming it's optional

                // Check if textBox9.Text is not empty before trying to parse it
                if (!string.IsNullOrEmpty(textBox9.Text))
                {
                    regNo = int.Parse(textBox9.Text);
                }

                String fname = textBox1.Text, lname = textBox2.Text, Pname = textBox3.Text, nic = textBox4.Text, cno = textBox5.Text, email = textBox6.Text, pno = textBox7.Text, address = textBox8.Text;
                String gender = GetSelectedGender();
                DateTime dateTime = dateTimePicker1.Value;

                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDb)\\LocalDBDemo;Initial Catalog=StudentMangement;Integrated Security=True"))
                {
                    connection.Open();

                    // Use a direct INSERT statement without a stored procedure
                    string insertQuery = "INSERT INTO registration (regNo, firstName, lastName, dateOfBirth, gender, address, email, mobilePhone, parentName, NIC, contactNo) VALUES (@regNo, @firstName, @lastName, @dateOfBirth, @gender, @address, @email, @mobilePhone, @parentName, @NIC, @contactNo)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        // Check if regNo is greater than 0 before adding it as a parameter
                        if (regNo > 0)
                        {
                            cmd.Parameters.AddWithValue("@regNo", regNo);
                        }

                        cmd.Parameters.AddWithValue("@firstName", fname);
                        cmd.Parameters.AddWithValue("@lastName", lname);
                        cmd.Parameters.AddWithValue("@dateOfBirth", dateTime);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@mobilePhone", pno);
                        cmd.Parameters.AddWithValue("@parentName", Pname);
                        cmd.Parameters.AddWithValue("@NIC", nic);
                        cmd.Parameters.AddWithValue("@contactNo", cno);

                        cmd.ExecuteNonQuery();

                        // If the code reaches here, the data was inserted successfully
                        MessageBox.Show("Data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // An error occurred, display an error message
                MessageBox.Show("Error inserting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private string GetSelectedGender()
        {
            // Check which radio button is checked and return the corresponding gender
            if (radioButton1.Checked)
            {
                return "Male";
            }
            else if (radioButton2.Checked)
            {
                return "Female";
            }
            else
            {
                // Handle the case when neither radio button is checked
                return string.Empty; // or another default value
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int regNo = 0; // Default value, assuming it's optional

                // Check if textBox9.Text is not empty before trying to parse it
                if (!string.IsNullOrEmpty(textBox9.Text))
                {
                    regNo = int.Parse(textBox9.Text);
                }

                String fname = textBox1.Text, lname = textBox2.Text, Pname = textBox3.Text, nic = textBox4.Text, cno = textBox5.Text, email = textBox6.Text, pno = textBox7.Text, address = textBox8.Text;
                String gender = GetSelectedGender();
                DateTime dateTime = dateTimePicker1.Value;

                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDb)\\LocalDBDemo;Initial Catalog=StudentMangement;Integrated Security=True"))
                {
                    connection.Open();

                    // Use a direct UPDATE statement without a stored procedure
                    string updateQuery = "UPDATE registration SET firstName = @firstName, lastName = @lastName, dateOfBirth = @dateOfBirth, gender = @gender, address = @address, email = @email, mobilePhone = @mobilePhone, parentName = @parentName, NIC = @NIC, contactNo = @contactNo WHERE regNo = @regNo";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        // Check if regNo is greater than 0 before adding it as a parameter
                        if (regNo > 0)
                        {
                            cmd.Parameters.AddWithValue("@regNo", regNo);
                        }

                        cmd.Parameters.AddWithValue("@firstName", fname);
                        cmd.Parameters.AddWithValue("@lastName", lname);
                        cmd.Parameters.AddWithValue("@dateOfBirth", dateTime);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@mobilePhone", pno);
                        cmd.Parameters.AddWithValue("@parentName", Pname);
                        cmd.Parameters.AddWithValue("@NIC", nic);
                        cmd.Parameters.AddWithValue("@contactNo", cno);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // If rows were affected, the update was successful
                            MessageBox.Show("Data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No records updated. Verify the regNo value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // An error occurred, display an error message
                MessageBox.Show("Error updating data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Clear text in TextBox controls
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

            // Uncheck RadioButtons
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            // Reset DateTimePicker
            dateTimePicker1.Value = DateTime.Now;


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {

                this.Close();

                Form1 loginForm = new Form1();
                loginForm.Show();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {

                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();

            search searchForm = new search();
            searchForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
