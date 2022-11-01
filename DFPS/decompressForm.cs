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
    public partial class decompressForm : Form
    {
        public decompressForm()
        {
            InitializeComponent();
            lblSize.Text = "";
            lblType.Text = "";
            lblModified.Text = "";
        }

        private void btnDecompress_Click(object sender, EventArgs e)
        {
            string messageTitle = "";
            string message = "";
            if (!FormUtility.validateDestination(txtDest.Text))
            {
                message += "Invalid destination. Please select an existed directory." + System.Environment.NewLine;
            }
            if (!FormUtility.validateFileExisted(txtFileDecompress.Text))
            {
                message += "Invalid file. Please select an existed file." + System.Environment.NewLine;
            }

            if (message != "")
            {
                messageTitle = "Invalid input detected";
                DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
            }
            else
            {
                FileInfo file = new FileInfo(txtFileDecompress.Text);
                string dest = txtDest.Text;
                if (DeflateCompression.Decompression(file, dest))
                {
                    messageTitle = "Successful Decompression";
                    message = "File has been returned to its original form.";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, true);
                    clearForm();
                }
            }
        }

        private void btnBrowseDecomp_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                lblSize.Text = FormUtility.fileSize(fi.Length);
                lblModified.Text = fi.LastWriteTime.ToString();
                lblType.Text = fi.Extension;
                txtFileDecompress.Text = ofd.FileName;
            }
        }

        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDest.Text = fbd.SelectedPath;
            }
        }
        private void clearForm()
        {
            foreach (Control c in Controls)
            {
                if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }
                else if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
            }
        }
    }
}
