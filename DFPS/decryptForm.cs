using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

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
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            ofd.Filter = "Encrypted files (*.enc)|*.enc";
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
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            FormUtility.disableButton(btnDecrypt);
            string messageTitle = "";
            string message = "";
            if (!FormUtility.validateDestination(txtDestination.Text.Trim()))
            {
                message += "Invalid destination. Please select an existed directory." + System.Environment.NewLine;
            }
            if (!FormUtility.validateFileExisted(txtFilePath.Text.Trim()))
            {
                message += "Invalid file. Please select an existed file." + System.Environment.NewLine;
            }
            if(!FormUtility.validateFileExtension(txtFilePath.Text, 4,".enc"))
            {
                message += "Invalid file type. Please select a file with .enc as file extension." + System.Environment.NewLine;
            }
            if (FormUtility.validateIfEmpty(txtPassword.Text.Trim()))
            {
                message += "Password is empty. Please enter the password to decrypt." + System.Environment.NewLine;
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
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string outFile = AESEncryption.Decrypt(pass, file, destPath);

                if (!String.IsNullOrEmpty(outFile))
                {
                    string tmpFile = outFile;
                    FileInfo dcmpFile = new FileInfo(tmpFile);
                    if (dcmpFile.Extension.Equals(".dfl"))
                    {
                        outFile = DeflateCompression.Decompression(dcmpFile, destPath);
                        File.Delete(dcmpFile.FullName);
                    }
                    
                    stopwatch.Stop();
                    TimeSpan ts = stopwatch.Elapsed;

                    if (!checkRemain.Checked)
                    {
                        File.Delete(file.FullName);
                    }
                    StringBuilder msg = new StringBuilder();
                    FileInfo outputFile = new FileInfo(outFile);
                    messageTitle = "Successful Decrypted";
                    msg.AppendFormat("File has been successfully decrypted." + System.Environment.NewLine +
                        "Decrypted file named: {0}" + System.Environment.NewLine +
                        "Used time: {1:00}:{2:00}:{3:00}.{4}", outputFile.Name, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                    clearForm();
                    lblModified.Text = "";
                    lblSize.Text = "";
                    lblType.Text = "";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, msg.ToString(), true);
                }
                else
                {
                    messageTitle = "Failed Decryption.";
                    message = "File has not been decrypted. Please try again";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
                }
            }
            FormUtility.reactivateButton(btnDecrypt);
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
