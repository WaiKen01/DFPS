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
    public partial class decryptForm : Form
    {
        public decryptForm()
        {
            InitializeComponent();
            lblSize.Text = "";
            lblType.Text = "";
            lblModified.Text = "";
            txtPassword.Text = "";
            txtPassword.PasswordChar = '*';
            txtPassword.MaxLength = 16;
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
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
                lblSize.Text = size.ToString() + sizeWord;
                lblModified.Text = fi.LastWriteTime.ToString();
                lblType.Text = fi.Extension;
                txtFilePath.Text = ofd.FileName;
            }
        }
        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDestination.Text = fbd.SelectedPath;
            }
        }
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string messageTitle = "";
            string message = "";
            if (!validateDestination())
            {
                message += "Invalid destination. Please select an existed directory." + System.Environment.NewLine;
            }
            if (!validateFileExisted())
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
                FileInfo file = new FileInfo(txtFilePath.Text);
                string pass = txtPassword.Text;
                string destPath = txtDestination.Text;
                if(AESEncryption.Decrypt(pass, file, destPath))
                {
                    if (!checkRemain.Checked)
                    {
                        File.Delete(file.FullName);
                    }
                    messageTitle = "Successful Decrypted";
                    message = "File has been successfully decrypted. Please check your file at " + destPath + "folder";
                    clearForm();
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, true);
                }
                else
                {
                    messageTitle = "Failed Decryption.";
                    message = "File has not been decrypted. Please try again";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
                }
            }
        }
        private bool validateDestination()
        {
            return System.IO.Directory.Exists(txtDestination.Text) && txtDestination.Text != "";
        }
        private bool validateFileExisted()
        {
            return System.IO.File.Exists(txtFilePath.Text) && txtDestination.Text != "";
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
