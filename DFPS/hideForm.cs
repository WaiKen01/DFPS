using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

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

            txtConPassword.Text = "";
            txtConPassword.PasswordChar = '*';
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            FormUtility.disableButton(btnHide);
            string messageTitle = "";
            string message = "";

            if (!FormUtility.validateMatch(txtPassword.Text.Trim(),txtConPassword.Text.Trim()))
            {
                message += "Password and Confirm Password don't match." + System.Environment.NewLine;
            }
            if (!FormUtility.validateLength(txtPassword.Text.Trim(), 12, 16))
            {
                message += "Password length must have at least 12 characters." + System.Environment.NewLine;
            }
            if (!FormUtility.validateDestination(txtDest.Text))
            {
                message += "Invalid destination. Please select an existed directory." + System.Environment.NewLine;
            }
            if (!FormUtility.validateFileExisted(txtFileCover.Text))
            {
                message += "Invalid cover file. Please select an existed file." + System.Environment.NewLine;
            }
            if (!FormUtility.validateFileExisted(txtFileSecret.Text))
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
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string outFile = Steganography.Hide(secretFile, coverFile, pass, dest);
                if (!String.IsNullOrEmpty(outFile))
                {
                    stopwatch.Stop();
                    TimeSpan ts = stopwatch.Elapsed;
                    StringBuilder msg = new StringBuilder();
                    messageTitle = "Successful Hiding";
                    msg.AppendFormat("New file: {0} has been generated with embedded content." + System.Environment.NewLine +
                        "Used time: {1:00}:{2:00}:{3:00}.{4}", outFile, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                    clearForm();
                    lblModifiedCover.Text = "";
                    lblSizeCover.Text = "";
                    lblTypeCover.Text = "";
                    lblModifiedSecret.Text = "";
                    lblSizeSecret.Text = "";
                    lblTypeSecret.Text = "";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, msg.ToString(), true);
                }
                else
                {
                    messageTitle = "Failed Hiding.";
                    message = "No file is generated, hide file unsuccessful.";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
                }
            }
            FormUtility.reactivateButton(btnHide);
        }

        private void btnBrowseCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            ofd.Filter = "Image and Media Files(*.BMP;*.JPG;*.GIF;*.PNG;*.PDF;*.MOV;*.MP4;*.WAV;*.MP3)|*.BMP;*.JPG;*.GIF;*.PNG;*.PDF;*.MOV;*.MP4;*.WAV;*.MP3";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                lblSizeCover.Text = FormUtility.fileSize(fi.Length);
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
                lblSizeSecret.Text = FormUtility.fileSize(fi.Length);
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
