
namespace DFPS
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCompressNav = new System.Windows.Forms.Button();
            this.btnDecompressNav = new System.Windows.Forms.Button();
            this.btnExtractNav = new System.Windows.Forms.Button();
            this.btnStegoNav = new System.Windows.Forms.Button();
            this.btnDecryptNav = new System.Windows.Forms.Button();
            this.btnEncryptNav = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlNav = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFormLoader = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.panel1.Controls.Add(this.btnCompressNav);
            this.panel1.Controls.Add(this.btnDecompressNav);
            this.panel1.Controls.Add(this.btnExtractNav);
            this.panel1.Controls.Add(this.btnStegoNav);
            this.panel1.Controls.Add(this.btnDecryptNav);
            this.panel1.Controls.Add(this.btnEncryptNav);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 557);
            this.panel1.TabIndex = 0;
            // 
            // btnCompressNav
            // 
            this.btnCompressNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(156)))));
            this.btnCompressNav.FlatAppearance.BorderSize = 0;
            this.btnCompressNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompressNav.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCompressNav.ForeColor = System.Drawing.Color.White;
            this.btnCompressNav.Location = new System.Drawing.Point(0, 350);
            this.btnCompressNav.Name = "btnCompressNav";
            this.btnCompressNav.Size = new System.Drawing.Size(186, 42);
            this.btnCompressNav.TabIndex = 1;
            this.btnCompressNav.Text = "File Compression";
            this.btnCompressNav.UseVisualStyleBackColor = false;
            this.btnCompressNav.Click += new System.EventHandler(this.btnCompressNav_Click);
            this.btnCompressNav.Leave += new System.EventHandler(this.btnCompressNav_Leave);
            // 
            // btnDecompressNav
            // 
            this.btnDecompressNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(156)))));
            this.btnDecompressNav.FlatAppearance.BorderSize = 0;
            this.btnDecompressNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecompressNav.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDecompressNav.ForeColor = System.Drawing.Color.White;
            this.btnDecompressNav.Location = new System.Drawing.Point(0, 392);
            this.btnDecompressNav.Name = "btnDecompressNav";
            this.btnDecompressNav.Size = new System.Drawing.Size(186, 42);
            this.btnDecompressNav.TabIndex = 1;
            this.btnDecompressNav.Text = "File Decompression";
            this.btnDecompressNav.UseVisualStyleBackColor = false;
            this.btnDecompressNav.Click += new System.EventHandler(this.btnDecompressNav_Click);
            this.btnDecompressNav.Leave += new System.EventHandler(this.btnDecompressNav_Leave);
            // 
            // btnExtractNav
            // 
            this.btnExtractNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(156)))));
            this.btnExtractNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExtractNav.FlatAppearance.BorderSize = 0;
            this.btnExtractNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtractNav.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExtractNav.ForeColor = System.Drawing.Color.White;
            this.btnExtractNav.Location = new System.Drawing.Point(0, 312);
            this.btnExtractNav.Name = "btnExtractNav";
            this.btnExtractNav.Size = new System.Drawing.Size(186, 42);
            this.btnExtractNav.TabIndex = 1;
            this.btnExtractNav.Text = "Flie Extraction";
            this.btnExtractNav.UseVisualStyleBackColor = false;
            this.btnExtractNav.Click += new System.EventHandler(this.btnExtractNav_Click);
            this.btnExtractNav.Leave += new System.EventHandler(this.btnExtractNav_Leave);
            // 
            // btnStegoNav
            // 
            this.btnStegoNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(156)))));
            this.btnStegoNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStegoNav.FlatAppearance.BorderSize = 0;
            this.btnStegoNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStegoNav.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStegoNav.ForeColor = System.Drawing.Color.White;
            this.btnStegoNav.Location = new System.Drawing.Point(0, 270);
            this.btnStegoNav.Name = "btnStegoNav";
            this.btnStegoNav.Size = new System.Drawing.Size(186, 42);
            this.btnStegoNav.TabIndex = 1;
            this.btnStegoNav.Text = "Steganography";
            this.btnStegoNav.UseVisualStyleBackColor = false;
            this.btnStegoNav.Click += new System.EventHandler(this.btnStegoNav_Click);
            this.btnStegoNav.Leave += new System.EventHandler(this.btnStegoNav_Leave);
            // 
            // btnDecryptNav
            // 
            this.btnDecryptNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(156)))));
            this.btnDecryptNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDecryptNav.FlatAppearance.BorderSize = 0;
            this.btnDecryptNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecryptNav.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDecryptNav.ForeColor = System.Drawing.Color.White;
            this.btnDecryptNav.Location = new System.Drawing.Point(0, 228);
            this.btnDecryptNav.Name = "btnDecryptNav";
            this.btnDecryptNav.Size = new System.Drawing.Size(186, 42);
            this.btnDecryptNav.TabIndex = 1;
            this.btnDecryptNav.Text = "Decryption";
            this.btnDecryptNav.UseVisualStyleBackColor = false;
            this.btnDecryptNav.Click += new System.EventHandler(this.btnDecryptNav_Click);
            this.btnDecryptNav.Leave += new System.EventHandler(this.btnDecryptNav_Leave);
            // 
            // btnEncryptNav
            // 
            this.btnEncryptNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(156)))));
            this.btnEncryptNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEncryptNav.FlatAppearance.BorderSize = 0;
            this.btnEncryptNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncryptNav.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEncryptNav.ForeColor = System.Drawing.Color.White;
            this.btnEncryptNav.Location = new System.Drawing.Point(0, 186);
            this.btnEncryptNav.Name = "btnEncryptNav";
            this.btnEncryptNav.Size = new System.Drawing.Size(186, 42);
            this.btnEncryptNav.TabIndex = 1;
            this.btnEncryptNav.Text = "Encryption";
            this.btnEncryptNav.UseVisualStyleBackColor = false;
            this.btnEncryptNav.Click += new System.EventHandler(this.btnEncryptNav_Click);
            this.btnEncryptNav.Leave += new System.EventHandler(this.btnEncryptNav_Leave);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(156)))));
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(0, 144);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(186, 42);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnHome.Leave += new System.EventHandler(this.btnHome_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 144);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 193);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(3, 100);
            this.pnlNav.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(903, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(156)))));
            this.lblTitle.Location = new System.Drawing.Point(204, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(366, 46);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Welcome to DFPS";
            // 
            // pnlFormLoader
            // 
            this.pnlFormLoader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFormLoader.Location = new System.Drawing.Point(186, 80);
            this.pnlFormLoader.Name = "pnlFormLoader";
            this.pnlFormLoader.Size = new System.Drawing.Size(765, 477);
            this.pnlFormLoader.TabIndex = 8;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(951, 557);
            this.Controls.Add(this.pnlFormLoader);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digital File Protection System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnCompressNav;
        private System.Windows.Forms.Button btnDecompressNav;
        private System.Windows.Forms.Button btnExtractNav;
        private System.Windows.Forms.Button btnStegoNav;
        private System.Windows.Forms.Button btnDecryptNav;
        private System.Windows.Forms.Button btnEncryptNav;
        private System.Windows.Forms.FlowLayoutPanel pnlNav;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFormLoader;
    }
}

