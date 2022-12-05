
namespace DFPS
{
    partial class encryptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblModified = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtConPassword = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.checkRemain = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPasswordTips = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkCompress = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label1.Location = new System.Drawing.Point(44, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a file to be encrypted: ";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtFilePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.txtFilePath.Location = new System.Drawing.Point(44, 37);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(554, 27);
            this.txtFilePath.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(598, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.panel1.Controls.Add(this.lblModified);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.lblSize);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(44, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 125);
            this.panel1.TabIndex = 3;
            // 
            // lblModified
            // 
            this.lblModified.AutoSize = true;
            this.lblModified.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblModified.Location = new System.Drawing.Point(131, 92);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(51, 20);
            this.lblModified.TabIndex = 5;
            this.lblModified.Text = "label7";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblType.Location = new System.Drawing.Point(90, 51);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(51, 20);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "label6";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSize.Location = new System.Drawing.Point(90, 13);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(51, 20);
            this.lblSize.TabIndex = 3;
            this.lblSize.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Last Modified: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "File Type: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "File Size: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label5.Location = new System.Drawing.Point(44, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Choose the file destination:";
            // 
            // txtDestination
            // 
            this.txtDestination.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDestination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.txtDestination.Location = new System.Drawing.Point(44, 271);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(554, 27);
            this.txtDestination.TabIndex = 5;
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.btnBrowseFolder.FlatAppearance.BorderSize = 0;
            this.btnBrowseFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBrowseFolder.Location = new System.Drawing.Point(598, 271);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(94, 27);
            this.btnBrowseFolder.TabIndex = 6;
            this.btnBrowseFolder.Text = "Browse";
            this.btnBrowseFolder.UseVisualStyleBackColor = false;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label6.Location = new System.Drawing.Point(44, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Set password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.txtPassword.Location = new System.Drawing.Point(44, 330);
            this.txtPassword.MaxLength = 16;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(554, 27);
            this.txtPassword.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label7.Location = new System.Drawing.Point(44, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Confirm password:";
            // 
            // txtConPassword
            // 
            this.txtConPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtConPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.txtConPassword.Location = new System.Drawing.Point(44, 389);
            this.txtConPassword.MaxLength = 16;
            this.txtConPassword.Name = "txtConPassword";
            this.txtConPassword.Size = new System.Drawing.Size(554, 27);
            this.txtConPassword.TabIndex = 10;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(156)))));
            this.btnEncrypt.FlatAppearance.BorderSize = 0;
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncrypt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEncrypt.ForeColor = System.Drawing.Color.White;
            this.btnEncrypt.Location = new System.Drawing.Point(44, 426);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(142, 32);
            this.btnEncrypt.TabIndex = 11;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // checkRemain
            // 
            this.checkRemain.AutoSize = true;
            this.checkRemain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkRemain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.checkRemain.Location = new System.Drawing.Point(190, 70);
            this.checkRemain.Name = "checkRemain";
            this.checkRemain.Size = new System.Drawing.Size(54, 24);
            this.checkRemain.TabIndex = 12;
            this.checkRemain.Text = "Yes";
            this.checkRemain.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label8.Location = new System.Drawing.Point(44, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Remain source file: ";
            // 
            // lblPasswordTips
            // 
            this.lblPasswordTips.AutoSize = true;
            this.lblPasswordTips.Font = new System.Drawing.Font("Segoe UI", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblPasswordTips.Location = new System.Drawing.Point(275, 360);
            this.lblPasswordTips.Name = "lblPasswordTips";
            this.lblPasswordTips.Size = new System.Drawing.Size(323, 17);
            this.lblPasswordTips.TabIndex = 14;
            this.lblPasswordTips.Text = "Recommended password length is 12-16 characters";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label9.Location = new System.Drawing.Point(43, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Selected file details:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label10.Location = new System.Drawing.Point(263, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Compress file: ";
            // 
            // checkCompress
            // 
            this.checkCompress.AutoSize = true;
            this.checkCompress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkCompress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.checkCompress.Location = new System.Drawing.Point(373, 70);
            this.checkCompress.Name = "checkCompress";
            this.checkCompress.Size = new System.Drawing.Size(54, 24);
            this.checkCompress.TabIndex = 17;
            this.checkCompress.Text = "Yes";
            this.checkCompress.UseVisualStyleBackColor = true;
            // 
            // encryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.ClientSize = new System.Drawing.Size(765, 477);
            this.Controls.Add(this.checkCompress);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblPasswordTips);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkRemain);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtConPassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "encryptForm";
            this.Text = "encryptForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblModified;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtConPassword;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.CheckBox checkRemain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPasswordTips;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkCompress;
    }
}