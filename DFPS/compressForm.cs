using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace DFPS
{
    public partial class compressForm : Form
    {
        public compressForm()
        {
            InitializeComponent();
            lblSize.Text = "";
            lblType.Text = "";
            lblModified.Text = "";
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            FormUtility.disableButton(btnCompress);
            string message = "";
            string messageTitle = "";
            if (!FormUtility.validateDestination(txtDest.Text))
            {
                message += "Invalid destination. Please select an existed directory." + System.Environment.NewLine;
            }
            if (!FormUtility.validateFileExisted(txtFileCompress.Text))
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
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                
                FileInfo file = new FileInfo(txtFileCompress.Text);
                string dest = txtDest.Text;
                string outFile = DeflateCompression.Compress(file, dest);
                if (!String.IsNullOrEmpty(outFile))
                {
                    //Console.WriteLine("Elapsed Time is {0:00}:{1:00}:{2:00}.{3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                    string oriSize = FormUtility.fileSize(file.Length);
                    FileInfo cmpFile = new FileInfo(outFile);
                    string cmpSize = FormUtility.fileSize(cmpFile.Length);
                    StringBuilder str = new StringBuilder();
                    long savedSpace = file.Length - cmpFile.Length;
                    string saved = FormUtility.fileSize(savedSpace);
                    if (!checkRemain.Checked)
                    {
                        File.Delete(file.FullName);
                    }
                    stopwatch.Stop();
                    TimeSpan ts = stopwatch.Elapsed;
                    messageTitle = "Successful Compression";
                    str.AppendFormat("A compressed file has been generated " + System.Environment.NewLine +
                        "Original File Size     : {0}  " + System.Environment.NewLine +
                        "Compressed File Size   : {1} " + System.Environment.NewLine +
                        "Used time: {2:00}:{3:00}:{4:00}.{5}" + System.Environment.NewLine +
                        "Saved Space : {6}", oriSize, cmpSize, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds, saved);
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, str.ToString(), true);
                    clearForm();
                    lblModified.Text = "";
                    lblSize.Text = "";
                    lblType.Text = "";
                }
                else
                {
                    messageTitle = "Failed Compression";
                    message = "File is not compressed. Please try again.";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
                }
            }
            FormUtility.reactivateButton(btnCompress);
        }

        private void btnBrowseCompress_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                lblSize.Text = FormUtility.fileSize(fi.Length);
                lblModified.Text = fi.LastWriteTime.ToString();
                lblType.Text = fi.Extension;
                txtFileCompress.Text = ofd.FileName;
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
