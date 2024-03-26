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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

        }
        //int cpt = 1;
        //private void Home_Load(object sender, EventArgs e)
        //{
        //    guna2DataGridView1.Rows.Add(3);

        //    guna2DataGridView1.Rows[0].Cells[0].Value = Image.FromFile("E:\\ADO .net\\CMS\\imges\\chickebug.jpg");
        //    guna2DataGridView1.Rows[1].Cells[0].Value = Image.FromFile("E:\\ADO .net\\CMS\\imges\\ice-cream-4k.jpg");
        //    guna2DataGridView1.Rows[2].Cells[0].Value = Image.FromFile("E:\\ADO .net\\CMS\\imges\\momo-schezwan.jpg");

        //    guna2DataGridView1.Rows[0].Cells[1].Value = "waffel";
        //    guna2DataGridView1.Rows[1].Cells[1].Value = "Chickenburger";
        //    guna2DataGridView1.Rows[2].Cells[1].Value = "icecream";
        //}

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{

        //}

        private void Control_MouseHover(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.ForeColor = Color.White;
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.ForeColor = Color.Black;
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            menu m = new menu();
            m.Show();
            this.Hide();
        }

        private void btnabout_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Contact_Us cu = new Contact_Us();
            cu.Show();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            First f = new First();
            f.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        //  private void guna2CircleButton1_R_Click(object sender, EventArgs e)
        // {
        //    if (cpt < guna2DataGridView1.Rows.Count)
        //    {
        //        pbbug.Image = (Image)guna2DataGridView1.Rows[cpt - 1].Cells[0].Value;
        //        pbice.Load("E:\\ADO .net\\CMS\\imges\\" + cpt.ToString() + cpt.ToString() + ".jpg");
        //        pbmoms.Load("E:\\ADO .net\\CMS\\imges\\" + cpt.ToString() + cpt.ToString() + cpt.ToString() + ".jpg");
        //        pbmoms.Image = pbbug.Image;
        //        cpt++;
        //    }
        //    else
        //    {
        //        cpt = 1;
        //    }
        //}

        //private void guna2CircleButton2_L_Click(object sender, EventArgs e)
        //{
        //    if (cpt > 1)
        //    {
        //        pbbug.Image = (Image)guna2DataGridView1.Rows[cpt - 1].Cells[0].Value;
        //        pbice.Load("E:\\ADO .net\\CMS\\imges\\" + cpt.ToString() + cpt.ToString() + ".jpg");
        //        pbmoms.Load("E:\\ADO .net\\CMS\\imges\\" + cpt.ToString() + cpt.ToString() + cpt.ToString() + ".jpg");
        //        pbmoms.Image = pbbug.Image;
        //        cpt--;
        //    }
        //    else
        //    {
        //        cpt = 1;
        //    }
        //}

        //private void pbice_Click(object sender, EventArgs e)
        //{
        //    //pbbug.Image = pbice.Image;
        //}

        //private void pbmoms_Click(object sender, EventArgs e)
        //{
        //    //pbbug.Image = pbmoms.Image;
        //}


    }
}
