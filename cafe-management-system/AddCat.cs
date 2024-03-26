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

namespace CMS
{
    public partial class AddCat : Base
    {
        public AddCat()
        {
            InitializeComponent();
            GetMaxID();
            LoadGrid();
        }
        bool recfnd = false;
        DAL d = new DAL();


        public void LoadGrid()
        {
            try
            {
                DataTable dt = d.GetTable("select * from categories");
                dgcat.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetMaxID()
        {

            try
            {
                d.isProcall = true;
                d.clearparameter();
                d.AddParameters("@action", "getmax");
                d.AddParameters("@catNo", "0");
                object maxid1 = d.GetID("proc_Cat");
                txtcatNo.Text = maxid1.ToString();
                d.isProcall = false;

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
                Query = $"insert into categories values('{txtcatNo.Text}','{txtname.Text}')";
            }
            else
            {
                Query = $"update categories set catNo='{txtcatNo.Text}'catName='{txtname.Text}' where catNo='{txtcatNo.Text}'";
            }
            try
            {

                int res = d.ExecuteQuery(Query);

                if (res > 0)
                {
                    MessageBox.Show("Categories Inserted Successfully");
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
            ClearControls(txtcatNo, Controls);
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete Record ?", "delCat", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            string Query = "";
            if (recfnd)
            {
                Query = $"delete from categories where catNo='{txtcatNo.Text}'";
            }
            try
            {

                int res = d.ExecuteQuery(Query);
                if (res > 0)
                {
                    MessageBox.Show("Record Deleted Successfully!!");
                    ClearControls(txtcatNo, Controls);
                    txtcatNo.Focus();
                    GetMaxID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadGrid();
        }

        private void btnaddcust_Click(object sender, EventArgs e)
        {
            AddCust ac = new AddCust();
            ac.Show();
            this.Hide();
        }

        private void btnadditem_Click(object sender, EventArgs e)
        {
            AddItem ac = new AddItem();
            ac.Show();
            this.Hide();
        }

        private void btnaddcat_Click(object sender, EventArgs e)
        {
            AddCat ac = new AddCat();
            ac.Show();
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
            Admin a = new Admin();
            a.Show();
            this.Hide();
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
    }
}

