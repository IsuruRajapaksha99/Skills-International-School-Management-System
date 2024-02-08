using System;
using System.Windows.Forms;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Skills_International
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=(LocalDb)\\LocalDBDemo;Initial Catalog=StudentMangement;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_login", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = textBox2.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //MessageBox.Show("Login Success");
                Reg registerPage = new Reg();
                registerPage.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid Login credentials. please check Username, Password and Try again later");
            }

            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}