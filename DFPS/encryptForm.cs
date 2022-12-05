using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DFPS
{
    public partial class encryptForm : Form
    {
        public encryptForm()
        {
            InitializeComponent();
            lblSize.Text = "";
            lblType.Text = "";
            lblModified.Text = "";
            txtPassword.Text = "";
            txtPassword.PasswordChar = '*';

            txtConPassword.Text = "";
            txtConPassword.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                lblSize.Text = FormUtility.fileSize(fi.Length);
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

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            FormUtility.disableButton(btnEncrypt);
            string messageTitle = "";
            string message = "";

            if (!FormUtility.validateMatch(txtPassword.Text.Trim(), txtConPassword.Text.Trim()))
            {
                message += "Password and Confirm Password don't match." + System.Environment.NewLine;
            }
            if (!FormUtility.validateLength(txtPassword.Text.Trim(), 12, 16))
            {
                message += "Password length must have at least 12 characters." + System.Environment.NewLine;
            }
            if (!FormUtility.validateDestination(txtDestination.Text))
            {
                message += "Invalid destination. Please select an existed directory." + System.Environment.NewLine;
            }
            if (!FormUtility.validateFileExisted(txtFilePath.Text))
            {
                message += "Invalid file. Please select an existed file." + System.Environment.NewLine;
            }

            if (message != "")
            {
                messageTitle = "Invalid input detected.";
                DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
            }
            else
            {
                FileInfo file = new FileInfo(txtFilePath.Text);
                string pass = txtPassword.Text;
                string destPath = txtDestination.Text;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string outFile = "";
                if (checkCompress.Checked)
                {
                    FileInfo compressedFile = new FileInfo(DeflateCompression.Compress(file, destPath));
                    outFile = AESEncryption.Encrypt(pass, compressedFile, destPath);
                    stopwatch.Stop();
                    //File.Delete(compressedFile.FullName);
                }
                else
                {
                    outFile = AESEncryption.Encrypt(pass, file, destPath);
                    stopwatch.Stop();
                }

                if (!String.IsNullOrEmpty(outFile))
                {
                    if (!checkRemain.Checked)
                    {
                        File.Delete(file.FullName);
                    }
                    TimeSpan ts = stopwatch.Elapsed;
                    StringBuilder msg = new StringBuilder();
                    messageTitle = "Successful Encrypted";
                    msg.AppendFormat("Encrypted file has been generated : {0}" + System.Environment.NewLine +
                        "Used time: {1:00}:{2:00}:{3:00}.{4}", outFile, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                    clearForm();
                    lblModified.Text = "";
                    lblSize.Text = "";
                    lblType.Text = "";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, msg.ToString(), true);
                }
                else
                {
                    stopwatch.Stop();
                    messageTitle = "Failed to encrypt";
                    message = "File is not encrypted. Please try again.";
                    clearForm();
                    lblModified.Text = "";
                    lblSize.Text = "";
                    lblType.Text = "";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
                }
            }
            FormUtility.reactivateButton(btnEncrypt);
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
