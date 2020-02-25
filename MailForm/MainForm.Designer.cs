namespace MailForm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.passwordt = new System.Windows.Forms.TextBox();
            this.PASSWORD = new System.Windows.Forms.Label();
            this.FROM = new System.Windows.Forms.Label();
            this.fromt = new System.Windows.Forms.TextBox();
            this.SEND = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordt
            // 
            this.passwordt.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordt.Location = new System.Drawing.Point(256, 108);
            this.passwordt.Name = "passwordt";
            this.passwordt.Size = new System.Drawing.Size(227, 21);
            this.passwordt.TabIndex = 7;
            this.passwordt.Text = "****************";
            this.passwordt.UseSystemPasswordChar = true;
            // 
            // PASSWORD
            // 
            this.PASSWORD.AutoSize = true;
            this.PASSWORD.BackColor = System.Drawing.Color.Transparent;
            this.PASSWORD.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.PASSWORD.ForeColor = System.Drawing.Color.White;
            this.PASSWORD.Location = new System.Drawing.Point(86, 108);
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.Size = new System.Drawing.Size(159, 31);
            this.PASSWORD.TabIndex = 6;
            this.PASSWORD.Text = "PASSWORD";
            // 
            // FROM
            // 
            this.FROM.AutoSize = true;
            this.FROM.BackColor = System.Drawing.Color.Transparent;
            this.FROM.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FROM.ForeColor = System.Drawing.Color.White;
            this.FROM.Location = new System.Drawing.Point(89, 52);
            this.FROM.Name = "FROM";
            this.FROM.Size = new System.Drawing.Size(94, 31);
            this.FROM.TabIndex = 5;
            this.FROM.Text = "FROM";
            // 
            // fromt
            // 
            this.fromt.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromt.Location = new System.Drawing.Point(256, 52);
            this.fromt.Name = "fromt";
            this.fromt.Size = new System.Drawing.Size(227, 21);
            this.fromt.TabIndex = 4;
            this.fromt.Text = "1985593610@qq.com";
            // 
            // SEND
            // 
            this.SEND.BackColor = System.Drawing.Color.Red;
            this.SEND.Font = new System.Drawing.Font("Vast Shadow", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEND.ForeColor = System.Drawing.Color.White;
            this.SEND.Image = ((System.Drawing.Image)(resources.GetObject("SEND.Image")));
            this.SEND.Location = new System.Drawing.Point(82, 206);
            this.SEND.Name = "SEND";
            this.SEND.Size = new System.Drawing.Size(163, 70);
            this.SEND.TabIndex = 8;
            this.SEND.Text = "SEND";
            this.SEND.UseVisualStyleBackColor = false;
            this.SEND.Click += new System.EventHandler(this.SEND_Click);
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.Color.Red;
            this.Log.Font = new System.Drawing.Font("Vast Shadow", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Log.ForeColor = System.Drawing.Color.White;
            this.Log.Image = ((System.Drawing.Image)(resources.GetObject("Log.Image")));
            this.Log.Location = new System.Drawing.Point(285, 206);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(163, 70);
            this.Log.TabIndex = 9;
            this.Log.Text = "Log In";
            this.Log.UseVisualStyleBackColor = false;
            this.Log.Click += new System.EventHandler(this.Log_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(571, 341);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.SEND);
            this.Controls.Add(this.passwordt);
            this.Controls.Add(this.PASSWORD);
            this.Controls.Add(this.FROM);
            this.Controls.Add(this.fromt);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordt;
        private System.Windows.Forms.Label PASSWORD;
        private System.Windows.Forms.Label FROM;
        private System.Windows.Forms.TextBox fromt;
        private System.Windows.Forms.Button SEND;
        private System.Windows.Forms.Button Log;
    }
}