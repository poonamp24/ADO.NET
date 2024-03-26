using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class First : Form
    {
        public First()
        {
            InitializeComponent();
           
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EN04RVE\\SQLEXPRESS01;Initial Catalog=Cafe_Project;Integrated Security=True");


        

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUN.Text=="Admin" && txtpass.Text == "Admin@123")
            {
                Admin a = new Admin();
                a.Show();
                this.Hide();
            }
            else
            {
            con.Open();
            SqlCommand cmd = new SqlCommand("CProc_Login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Username", SqlDbType.NChar).Value = txtUN.Text;
            cmd.Parameters.Add("@Password", SqlDbType.NChar).Value = txtpass.Text;
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("Login Succefully");
                Dashboard d = new Dashboard();
                d.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
            con.Close();
        }
        }
    }
    }

