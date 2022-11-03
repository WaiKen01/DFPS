using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DFPS
{
    public partial class Dashboard : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse

        );
        public Dashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.pnlFormLoader.Controls.Clear();
            homeForm homeFormContent = new homeForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            homeFormContent.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(homeFormContent);
            homeFormContent.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnHome.PerformClick();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Welcome to DFPS";
            this.pnlFormLoader.Controls.Clear();
            homeForm homeFormContent = new homeForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            homeFormContent.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(homeFormContent);
            homeFormContent.Show();
            btnActive(btnHome);
        }

        private void btnEncryptNav_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "File Encryption";
            this.pnlFormLoader.Controls.Clear();
            encryptForm encryptFormContent = new encryptForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            encryptFormContent.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(encryptFormContent);
            encryptFormContent.Show();
            btnActive(btnEncryptNav);
        }

        private void btnDecryptNav_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "File Decryption";
            this.pnlFormLoader.Controls.Clear();
            decryptForm decryptFormContent = new decryptForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            decryptFormContent.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(decryptFormContent);
            decryptFormContent.Show();
            btnActive(btnDecryptNav);
        }

        private void btnStegoNav_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "File Hiding";
            this.pnlFormLoader.Controls.Clear();
            hideForm hideFormContent = new hideForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            hideFormContent.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(hideFormContent);
            hideFormContent.Show();
            btnActive(btnStegoNav);
        }

        private void btnExtractNav_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "File Extraction";
            this.pnlFormLoader.Controls.Clear();
            extractForm extractFormContent = new extractForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            extractFormContent.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(extractFormContent);
            extractFormContent.Show();
            btnActive(btnExtractNav);
        }

        private void btnCompressNav_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "File Compression";
            this.pnlFormLoader.Controls.Clear();
            compressForm compressFormContent = new compressForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            compressFormContent.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(compressFormContent);
            compressFormContent.Show();
            btnActive(btnCompressNav);
        }

        private void btnDecompressNav_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "File Decompression";
            this.pnlFormLoader.Controls.Clear();
            decompressForm decompressFormContent = new decompressForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            decompressFormContent.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(decompressFormContent);
            decompressFormContent.Show();
            btnActive(btnDecompressNav);
        }

        private void btnHome_Leave(object sender, EventArgs e)
        {
            btnLeave(btnHome);
        }

        private void btnEncryptNav_Leave(object sender, EventArgs e)
        {
            btnLeave(btnEncryptNav);
        }

        private void btnDecryptNav_Leave(object sender, EventArgs e)
        {
            btnLeave(btnDecryptNav);
        }

        private void btnStegoNav_Leave(object sender, EventArgs e)
        {
            btnLeave(btnStegoNav);
        }

        private void btnExtractNav_Leave(object sender, EventArgs e)
        {
            btnLeave(btnExtractNav);
        }

        private void btnDecompressNav_Leave(object sender, EventArgs e)
        {
            btnLeave(btnDecompressNav);
        }

        private void btnCompressNav_Leave(object sender, EventArgs e)
        {
            btnLeave(btnCompressNav);
        }

        private void btnActive(Button btn)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is Button)
                {
                    btnLeave((Button)c);
                }
            }

            pnlNav.Height = btn.Height;
            pnlNav.Top = btn.Top;
            pnlNav.Left = btn.Left;
            btn.BackColor = Color.FromArgb(198, 198, 198);
            btn.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void btnLeave(Button btn)
        {
            btn.BackColor = Color.FromArgb(0, 161, 156);
            btn.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void showForm(Object obj)
        {

            encryptForm encryptFormContent = new encryptForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            encryptFormContent.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(encryptFormContent);
            encryptFormContent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
