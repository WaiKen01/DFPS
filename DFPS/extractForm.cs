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
    public partial class extractForm : Form
    {
        public extractForm()
        {
            InitializeComponent();
            lblSize.Text = "";
            lblType.Text = "";
            lblModified.Text = "";
            txtPassword.Text = "";
            txtPassword.PasswordChar = '*';
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            FormUtility.disableButton(btnExtract);
            string messageTitle = "";
            string message = "";

            if (FormUtility.validateIfEmpty(txtPassword.Text))
            {
                message += "Password is empty." + System.Environment.NewLine;
            }
            if (!FormUtility.validateDestination(txtDest.Text))
            {
                message += "Invalid destination. Please select an existed directory." + System.Environment.NewLine;
            }
            if (!FormUtility.validateFileExisted(txtFileExtract.Text))
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

                FileInfo stegoFile = new FileInfo(txtFileExtract.Text);
                string pass = txtPassword.Text.Trim();
                string dest = txtDest.Text;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string outFile = Steganography.Extract(stegoFile, pass, dest);
                if (!String.IsNullOrEmpty(outFile))
                {
                    if (outFile.Equals("corrupted"))
                    {
                        messageTitle = "Failed Extraction";
                        message = "The file is corrupted. No content is extracted.";
                        DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
                    }
                    else if (outFile.Equals("modified"))
                    {
                        messageTitle = "Failed Extraction";
                        message = "The file is modified. No content is extracted";
                        DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
                    }
                    else
                    {
                        stopwatch.Stop();
                        TimeSpan ts = stopwatch.Elapsed;
                        StringBuilder msg = new StringBuilder();
                        messageTitle = "Successful Extraction";
                        msg.AppendFormat("Extracted content have been saved in a new file." + System.Environment.NewLine +
                            "Used time: {0:00}:{1:00}:{2:00}.{3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                        clearForm();
                        lblSize.Text = "";
                        lblType.Text = "";
                        lblModified.Text = "";
                        DFPS.DFPSMessageBox.ShowBox(messageTitle, msg.ToString(), true);
                    }
                }
                else
                {
                    messageTitle = "Failed Extraction";
                    message = "No file has been extracted. Please try again.";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
                }
            }
            FormUtility.reactivateButton(btnExtract);
        }

        private void btnBrowseExtract_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                lblSize.Text = FormUtility.fileSize(fi.Length);
                lblModified.Text = fi.LastWriteTime.ToString();
                lblType.Text = fi.Extension;
                txtFileExtract.Text = ofd.FileName;
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
