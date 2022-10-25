using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace DFPS
{
    public partial class hideForm : Form
    {
        public hideForm()
        {
            InitializeComponent();
            lblSizeCover.Text = "";
            lblTypeCover.Text = "";
            lblModifiedCover.Text = "";
            lblSizeSecret.Text = "";
            lblTypeSecret.Text = "";
            lblModifiedSecret.Text = "";
            txtPassword.Text = "";
            txtPassword.PasswordChar = '*';
            txtPassword.MaxLength = 16;

            txtConPassword.Text = "";
            txtConPassword.PasswordChar = '*';
            txtConPassword.MaxLength = 16;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            string messageTitle = "";
            string message = "";

            if (!FormValidation.validatePassword(txtPassword.Text.Trim(),txtConPassword.Text.Trim()))
            {
                message += "Password and Confirm Password don't match." + System.Environment.NewLine;
            }
            if (!FormValidation.validateDestination(txtDest.Text))
            {
                message += "Invalid destination. Please select an existed directory." + System.Environment.NewLine;
            }
            if (!FormValidation.validateFileExisted(txtFileCover.Text))
            {
                message += "Invalid cover file. Please select an existed file." + System.Environment.NewLine;
            }
            if (!FormValidation.validateFileExisted(txtFileSecret.Text))
            {
                message += "Invalid secret file. Please select an existed file." + System.Environment.NewLine;
            }

            if (message != "")
            {
                messageTitle = "Invalid input detected";
                DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
            }
            else
            {
                FileInfo coverFile = new FileInfo(txtFileCover.Text);
                FileInfo secretFile = new FileInfo(txtFileSecret.Text);
                string pass = txtConPassword.Text.Trim();
                string dest = txtDest.Text;

                if (Steganography.Hide(secretFile, coverFile, pass, dest))
                {
                    messageTitle = "Successful Hiding";
                    message = "A new file has been generated sucessfully.";
                    clearForm();
                    lblSizeCover.Text = "";
                    lblTypeCover.Text = "";
                    lblModifiedCover.Text = "";
                    lblSizeSecret.Text = "";
                    lblTypeSecret.Text = "";
                    lblModifiedSecret.Text = "";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, true);
                }
                else
                {
                    messageTitle = "Failed Hiding.";
                    message = "No file is generated, hide file unsuccessful.";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
                }
            }
        }

        private void btnBrowseCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            ofd.Filter = "Image Files (*.bmp; *.jpg; *.png)| *.bmp; *.jpg; *.png | PDF Files (*.pdf) | *.pdf";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                long size = fi.Length;
                int sizeCheck = 0;
                string sizeWord = "byte";

                for (int i = 0; size >= 1024; i++)
                {
                    size = size / 1024;
                    sizeCheck++;
                }
                if (sizeCheck == 1)
                {
                    sizeWord = "KB";
                }
                else if (sizeCheck == 2)
                {
                    sizeWord = "MB";
                }
                else if (sizeCheck == 3)
                {
                    sizeWord = "GB";
                }
                lblSizeCover.Text = size.ToString() + sizeWord;
                lblModifiedCover.Text = fi.LastWriteTime.ToString();
                lblTypeCover.Text = fi.Extension;
                txtFileCover.Text = ofd.FileName;
            }
        }

        private void btnBrowseSecret_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                long size = fi.Length;
                int sizeCheck = 0;
                string sizeWord = "byte";

                for (int i = 0; size >= 1024; i++)
                {
                    size = size / 1024;
                    sizeCheck++;
                }
                if (sizeCheck == 1)
                {
                    sizeWord = "KB";
                }
                else if (sizeCheck == 2)
                {
                    sizeWord = "MB";
                }
                else if (sizeCheck == 3)
                {
                    sizeWord = "GB";
                }
                lblSizeSecret.Text = size.ToString() + sizeWord;
                lblModifiedSecret.Text = fi.LastWriteTime.ToString();
                lblTypeSecret.Text = fi.Extension;
                txtFileSecret.Text = ofd.FileName;
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
