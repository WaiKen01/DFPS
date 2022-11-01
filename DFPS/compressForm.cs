using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;

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
                FileInfo file = new FileInfo(txtFileCompress.Text);
                string dest = txtDest.Text;
                if(DeflateCompression.Compression(file, dest))
                {
                    string oriSize = FormUtility.fileSize(file.Length);
                    string outFile = Path.Combine(dest, Path.ChangeExtension(file.Name, "dfl"));
                    FileInfo cmpFile = new FileInfo(outFile);
                    string cmpSize = FormUtility.fileSize(cmpFile.Length);
                    StringBuilder str = new StringBuilder();
                    long savedSpace = file.Length - cmpFile.Length;
                    string saved = FormUtility.fileSize(savedSpace);
                    messageTitle = "Successful Compression";
                    str.AppendFormat("A compressed file has been generated " + System.Environment.NewLine +
                        "Original File Size     : {0}  " + System.Environment.NewLine +
                        "Compressed File Size   : {1} " + System.Environment.NewLine +
                        "Saved Space : {2}", oriSize, cmpSize, saved);
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, str.ToString(), true);
                    clearForm();
                    lblOriSize.Text = oriSize;
                    lblCmpSize.Text = cmpSize;
                }
            }
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
