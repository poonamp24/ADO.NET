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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void BTNADDCUST_Click(object sender, EventArgs e)
        {
            AddCust ac = new AddCust();
            ac.Show();
            this.Hide();
        }

        private void BTNADDITEM_Click(object sender, EventArgs e)
        {
            AddItem ai = new AddItem();
            ai.Show();
            this.Hide();
        }

        private void BTNADDCAT_Click(object sender, EventArgs e)
        {
            AddCat ai = new AddCat();
            ai.Show();
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
