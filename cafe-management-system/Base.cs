using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Management_Syatem
{
    public partial class Base : Form
    {
        public Base()
        {
            InitializeComponent();
        }
        public void Control_Enter(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.Yellow;
        }
        public void Control_Leave(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;
        }
        public void Control_MouseHover(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.ForeColor = Color.White;
        }
        public void Control_MouseLeave(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.ForeColor = Color.Black;
        }
        public void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == 27)
            {
                SendKeys.Send("+" +
                    "{TAB}");
            }
            if (ctrl.Tag != null && ctrl.Tag.ToString() == "int")
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b'))
                {
                    e.KeyChar = (char)0;
                }
            }
            else if (ctrl.Tag != null && ctrl.Tag.ToString() == "string")
            {
                string validstr = "abcdefghijklmnopqrstuvwxyz @\b.-";
                if (!validstr.Contains(e.KeyChar.ToString().ToLower()))
                {
                    e.KeyChar = (char)0;
                }
                if (ctrl.Text.Split(' ').Length > 2 && e.KeyChar == ' ')
                {
                    e.KeyChar = (char)0;
                }
                if (ctrl.Text.Length > 0 && ctrl.Text.Substring(ctrl.Text.Length - 1) == " " && e.KeyChar == ' ')
                {
                    e.KeyChar = (char)0;
                }
            }
            else if (ctrl.Tag != null && ctrl.Tag.ToString() == "double")
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b' || e.KeyChar == '.'))
                {
                    e.KeyChar = (char)0;
                }
                if (ctrl.Text.Contains('.') && e.KeyChar == '.')
                    e.KeyChar = (char)0;

                int dotpos = ctrl.Text.IndexOf(".");
                if (dotpos >= 0 && e.KeyChar != '\b')
                {
                    if (ctrl.Text.Substring(dotpos).Length > 2)
                    {
                        e.KeyChar = (char)0;
                    }
                }
            }

        }

        public void ClearControls(Control FocusControl, Control.ControlCollection ctrl,
           bool ClearFocusControl = true)
        {
            string FocusControlValue = "";
            if (!ClearFocusControl)
                FocusControlValue = FocusControl.Text;

            foreach (Control item in ctrl)
            {
                if (item.Tag != null)
                    item.Text = "";
                if (item.GetType().Name == "ComboBox")
                {
                    ComboBox cmb = (ComboBox)item;
                    cmb.SelectedIndex = 0;
                }
                
            }

            if (!ClearFocusControl)
                FocusControl.Text = FocusControlValue;

            FocusControl.Focus();
        }
    }
}

