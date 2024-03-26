﻿using System;
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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            Pizaa p = new Pizaa();
            p.Show();
            this.Hide();
        }

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

        private void btnhome_Click(object sender, EventArgs e)
        {
            Dashboard h = new Dashboard();
            h.Show();
            this.Hide();
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

        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            Icecream i = new Icecream();
            i.Show();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            First f = new First();
            f.Show();
            this.Hide();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void btncategories_Click(object sender, EventArgs e)
        {

        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            Billing f = new Billing();
            f.Show();
            this.Hide();
        }
    }
}
