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
            FormUtility.disableButton(btnDecompress);
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
            if(!FormUtility.validateFileExtension(txtFileDecompress.Text, 4 , ".dfl"))
            {
                message += "File type is invalid. Only file with .dfl is accepted.";
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
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string outFile = DeflateCompression.Decompression(file, dest);
                if (!String.IsNullOrEmpty(outFile))
                {
                    if (!checkRemain.Checked)
                    {
                        File.Delete(file.FullName);
                    }
                    stopwatch.Stop();
                    TimeSpan ts = stopwatch.Elapsed;
                    StringBuilder msg = new StringBuilder();
                    messageTitle = "Successful Decompression";
                    msg.AppendFormat("File has been returned to its original form: {0}" + System.Environment.NewLine +
                        "Used time: {1:00}:{2:00}:{3:00}.{4}",outFile, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, msg.ToString(), true);
                    clearForm();
                    lblModified.Text = "";
                    lblSize.Text = "";
                    lblType.Text = "";
                }
                else
                {
                    messageTitle = "Failed Decompression";
                    message = "File is not decompressed. Please try again.";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
                }
            }
            FormUtility.reactivateButton(btnDecompress);
        }

        private void btnBrowseDecomp_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            ofd.Filter = "Deflate Compressed (*.dfl)|*.dfl";

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
