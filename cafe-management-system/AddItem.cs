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

namespace CMS
{
    public partial class AddItem : Base
    {
        public AddItem()
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
                d.AddParameters("@itemNo", "0");

                object maxid = d.GetID("Proc_Item");
                txtitemNo.Text = maxid.ToString();
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
                DataTable dt = d.GetTable("select * from Item");
                dgitem.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Do you want to save Record ?", "saveEmp", MessageBoxButtons.YesNo) == DialogResult.No)
            //    return;
            string Query = "";
            if (!recfnd)
            {
                Query = $"insert into Item values('{txtitemNo.Text}','{cmbcat.Text}','{txtname.Text}','{txtprice.Text}','{txtqty.Text}')";
            }
            else
            {
                Query = $"update Item set itemNo='{txtitemNo.Text}'cat='{cmbcat.Text}',Name='{txtname.Text}',price ='{txtprice.Text}',qty='{txtqty.Text}' where itemNo='{txtitemNo.Text}'";
            }
            try
            {

                int res = d.ExecuteQuery(Query);

                if (res > 0)
                {
                    MessageBox.Show("Item Inserted Successfully");
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
            ClearControls(txtitemNo, Controls);
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete Record ?", "delEmp", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            string Query = "";
            if (recfnd)
            {
                Query = $"delete from Item where itemNo='{txtitemNo.Text}'";
            }
            try
            {

                int res = d.ExecuteQuery(Query);
                if (res > 0)
                {
                    MessageBox.Show("Record Deleted Successfully!!");
                    ClearControls(txtitemNo, Controls);
                    txtitemNo.Focus();
                    GetMaxID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadGrid();
        }

        private void txtitemNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {

                string Query = "select * from Item where itemNo=" + txtitemNo.Text;
                SqlDataReader rdr = d.GetReader(Query);
                if (rdr != null && rdr.HasRows)
                {
                    recfnd = true;
                    rdr.Read();
                    cmbcat.Text = rdr["cat"].ToString();
                    txtname.Text = rdr["Name"].ToString();
                    txtprice.Text = rdr["price"].ToString();
                    txtqty.Text = rdr["qty"].ToString();

                }
                else
                {
                    txtname.Text = "";
                    cmbcat.SelectedIndex = 0;
                    txtprice.Text = "";
                    txtqty.Text = "";
                }
                rdr.Close();
                // con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            a.Show();
            this.Hide();
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

