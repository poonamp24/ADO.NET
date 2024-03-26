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
    public partial class cake : Form
    {
        public cake()
        {
            InitializeComponent();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            Billing f = new Billing();
            f.Show();
            this.Hide();
        }

        private void btnbuy_Click(object sender, EventArgs e)
        {
            Billing f = new Billing();
            f.Show();
            this.Hide();
        }
    }
}
