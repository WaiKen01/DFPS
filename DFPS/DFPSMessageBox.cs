using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DFPS
{
    public partial class DFPSMessageBox : Form
    {
        static DFPSMessageBox newMessageBox;
        public DFPSMessageBox()
        {
            InitializeComponent();
        }

        public static void ShowBox(string message)
        {
            newMessageBox = new DFPSMessageBox();
            newMessageBox.lblMessage.Text = message;
            newMessageBox.ShowDialog();
        }

        public static void ShowBox(string messageTitle, string message)
        {
            newMessageBox = new DFPSMessageBox();
            newMessageBox.iconBox.Image = DFPS.Properties.Resources.fail11;
            newMessageBox.lblMessageTitle.Text = messageTitle;
            newMessageBox.lblMessage.Text = message;
            newMessageBox.ShowDialog();
        }

        public static void ShowBox(string messageTitle, string message, bool success)
        {
            newMessageBox = new DFPSMessageBox();
            if (success)
            {
                newMessageBox.iconBox.Image = DFPS.Properties.Resources.success11;
            }
            else
            {
                newMessageBox.iconBox.Image = DFPS.Properties.Resources.fail11;
            }
            newMessageBox.lblMessageTitle.Text = messageTitle;
            newMessageBox.lblMessage.Text = message;
            newMessageBox.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            newMessageBox.Dispose();
        }
    }
}
