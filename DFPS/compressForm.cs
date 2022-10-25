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
            FileInfo file = new FileInfo(txtFileCompress.Text);
            string dest = txtDest.Text;
            HuffmanTree huffmanTree = new HuffmanTree();
            var fileBytes = File.ReadAllBytes(file.FullName);
            string fileString = Encoding.ASCII.GetString(fileBytes);

            try
            {
                huffmanTree.Build(fileString);
                BitArray encoded = huffmanTree.Encode(fileString);

                byte[] encodedBytes = new byte[encoded.Length / 8 + (encoded.Length % 8 == 0 ? 0 : 1)];
                encoded.CopyTo(encodedBytes, 0);

                string output = Path.Combine(dest, Path.ChangeExtension(file.Name, ".bin"));
                File.WriteAllBytes(output, encodedBytes);

                var encodedBit = new BitArray(encodedBytes);
                string decoded = huffmanTree.Decode(encodedBit);

                var decodedBytes = Encoding.ASCII.GetBytes(decoded);

                string output2 = Path.Combine(dest, Path.ChangeExtension(file.Name, ".txt"));
                File.WriteAllBytes(output2, decodedBytes);

            }
            catch (Exception ex)
            {

            }
        }

        private void btnBrowseCompress_Click(object sender, EventArgs e)
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
