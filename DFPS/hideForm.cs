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

        }

        private void btnBrowseCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            ofd.Filter = "PDF Document|*.pdf|Text Document|*.txt";
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
            ofd.Filter = "PDF Document|*.pdf|Text Document|*.txt";
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
    }
}
