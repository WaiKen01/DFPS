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
            if (!FormValidation.validateDestination(txtDest.Text))
            {
                message += "Invalid destination. Please select an existed directory." + System.Environment.NewLine;
            }
            if (!FormValidation.validateFileExisted(txtFileDecompress.Text))
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
                if (HuffmanCoding.Decompression(file, dest))
                {
                    messageTitle = "Successful Compressed";
                    message = "File has been successfully compressed.";
                    clearForm();
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, true);
                }
                else
                {
                    messageTitle = "Failed Decompression";
                    message = "File has not been decompressed. Please try again.";
                    DFPS.DFPSMessageBox.ShowBox(messageTitle, message, false);
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
