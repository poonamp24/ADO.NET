using Cafe_Management_Syatem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CMS
{
    public partial class AddCust : Base
    {
        public AddCust()
        {
            InitializeComponent();
            GetMaxID();
            LoadGrid();
        }
        bool recfnd = false;
        DAL d = new DAL();

        public void GetMaxID()
        {

            try
            {
                d.isProcall = true;
                d.clearparameter();
                d.AddParameters("@action", "getmax");
                d.AddParameters("@CustoNo", "0");

                object maxid = d.GetID("Proc_Customer");
                txtcustNo.Text = maxid.ToString();
                d.isProcall = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void LoadGrid()
        {
            try
            {
                DataTable dt = d.GetTable("select * from Customer");
                dgcust.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string Query = "";
            if (!recfnd)
            {
                Query = $"insert into Customer values('{txtcustNo.Text}','{txtname.Text}','{cmbgen.Text}','{txtmob.Text}')";
            }
            else
            {
                Query = $"update Customer set CustoNo='{txtcustNo.Text}',Name='{txtname.Text}',gen='{cmbgen.Text}',@mobno  varchar(50)='{txtmob.Text}' where CustoNo='{txtcustNo.Text}'";
            }
            try
            {

                int res = d.ExecuteQuery(Query);

                if (res > 0)
                {
                    MessageBox.Show("Customer Added Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadGrid();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            ClearControls(txtcustNo, Controls);
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete Record ?", "delcust", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            string Query = "";
            if (recfnd)
            {
                Query = $"delete from Customer where CustoNo='{txtcustNo.Text}'";
            }
            try
            {

                int res = d.ExecuteQuery(Query);
                if (res > 0)
                {
                    MessageBox.Show("Record Deleted Successfully!!");
                    ClearControls(txtcustNo, Controls);
                    txtcustNo.Focus();
                    GetMaxID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadGrid();
        }

        private void txtcustNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {

                string Query = "select * from Customer where CustoNo=" + txtcustNo.Text;
                SqlDataReader rdr = d.GetReader(Query);
                if (rdr != null && rdr.HasRows)
                {
                    recfnd = true;
                    rdr.Read();
                    txtname.Text = rdr["Name"].ToString();
                    cmbgen.Text = rdr["gen"].ToString();
                    txtmob.Text = rdr["mobno"].ToString();
                }
                else
                {
                    txtname.Text = "";
                    cmbgen.SelectedIndex = 0;
                    txtmob.Text = "";

                }
                rdr.Close();
                // con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnaddcat_MouseHover(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.ForeColor = Color.White;
        }

        private void btnaddcat_MouseLeave(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.ForeColor = Color.Black;
        }

        private void btnadditem_Click(object sender, EventArgs e)
        {
            AddItem ai = new AddItem();
            ai.Show();
            this.Hide();
        }

        private void btnaddcat_Click(object sender, EventArgs e)
        {
            AddCat ai = new AddCat();
            ai.Show();
            this.Hide();
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            a.Show();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            First f = new First();
            f.Show();
            this.Hide();
        }
    }
}
