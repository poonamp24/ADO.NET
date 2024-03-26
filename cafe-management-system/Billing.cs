using Cafe_Management_Syatem;
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
using System.Xml.Linq;

namespace CMS
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
            LoadGrid();
        }
        bool recfnd = false;
        DAL d = new DAL();
        public void LoadGrid()
        {
            if (catcb.SelectedIndex == 0)
            {
                try
                {
                    DataTable dt = d.GetTable("select * from pizza");
                    ItemGV.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (catcb.SelectedIndex == 1)
            {
                try
                {
                    DataTable dt = d.GetTable("select * from cake");
                    ItemGV.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (catcb.SelectedIndex == 2)
            {
                try
                {
                    DataTable dt = d.GetTable("select * from Burger");
                    ItemGV.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (catcb.SelectedIndex == 3)
            {
                try
                {
                    DataTable dt = d.GetTable("select * from iceCream");
                    ItemGV.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void catcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void OrderGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void qtytxt_Validating(object sender, CancelEventArgs e)
        {
            txtamt.Text = (trypass.cDouble(txtprice.Text) * trypass.cDouble(qtytxt.Text)).ToString();

        }

        private void txtid_Validating(object sender, CancelEventArgs e)
        {
            if (catcb.SelectedIndex == 0)
            {
                try
                {

                    string Query = "select * from pizza where P_No=" + txtid.Text;
                    SqlDataReader rdr = d.GetReader(Query);
                    if (rdr != null && rdr.HasRows)
                    {
                        recfnd = true;
                        rdr.Read();
                        txtcat.Text = rdr["Category"].ToString();
                        txtitem.Text = rdr["PName"].ToString();
                        txtprice.Text = rdr["Price"].ToString();
                    }
                    else
                    {
                        txtcat.Text = "";
                        txtitem.Text = "";
                        txtprice.Text = "";

                    }
                    rdr.Close();
                    // con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (catcb.SelectedIndex == 1)
            {
                try
                {

                    string Query = "select * from cake where C_No=" + txtid.Text;
                    SqlDataReader rdr = d.GetReader(Query);
                    if (rdr != null && rdr.HasRows)
                    {
                        recfnd = true;
                        rdr.Read();
                        txtcat.Text = rdr["Category"].ToString();
                        txtitem.Text = rdr["CName"].ToString();
                        txtprice.Text = rdr["Price"].ToString();
                    }
                    else
                    {
                        txtcat.Text = "";
                        txtitem.Text = "";
                        txtprice.Text = "";

                    }
                    rdr.Close();
                    // con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (catcb.SelectedIndex == 2)
            {
                try
                {

                    string Query = "select * from Burger where B_No=" + txtid.Text;
                    SqlDataReader rdr = d.GetReader(Query);
                    if (rdr != null && rdr.HasRows)
                    {
                        recfnd = true;
                        rdr.Read();
                        txtcat.Text = rdr["Category"].ToString();
                        txtitem.Text = rdr["BName"].ToString();
                        txtprice.Text = rdr["Price"].ToString();
                    }
                    else
                    {
                        txtcat.Text = "";
                        txtitem.Text = "";
                        txtprice.Text = "";

                    }
                    rdr.Close();
                    // con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (catcb.SelectedIndex == 3)
            {
                try
                {

                    string Query = "select * from iceCream where i_No=" + txtid.Text;
                    SqlDataReader rdr = d.GetReader(Query);
                    if (rdr != null && rdr.HasRows)
                    {
                        recfnd = true;
                        rdr.Read();
                        txtcat.Text = rdr["Category"].ToString();
                        txtitem.Text = rdr["iName"].ToString();
                        txtprice.Text = rdr["Price"].ToString();
                    }
                    else
                    {
                        txtcat.Text = "";
                        txtitem.Text = "";
                        txtprice.Text = "";

                    }
                    rdr.Close();
                    // con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnplaceorder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order Placed Successfully");
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            Dashboard m = new Dashboard();
            m.Show();
            this.Hide();
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            menu m = new menu();
            m.Show();
            this.Hide();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            Billing m = new Billing();
            m.Show();
            this.Hide();
        }

        private void btnabout_Click(object sender, EventArgs e)
        {
            About m = new About();
            m.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Contact_Us m = new Contact_Us();
            m.Show();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            First m = new First();
            m.Show();
            this.Hide();
        }

        private void btnBilling_MouseHover(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.ForeColor = Color.White;
        }

        private void btnBilling_MouseLeave(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.ForeColor = Color.Black;
        }
    }
}
