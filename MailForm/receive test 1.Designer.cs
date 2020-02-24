namespace MailForm
{
    partial class receive_test_1
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
            this.button1 = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.ListView();
            this.total = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get mail";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // title
            // 
            this.title.HideSelection = false;
            this.title.Location = new System.Drawing.Point(12, 47);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(515, 156);
            this.title.TabIndex = 2;
            this.title.UseCompatibleStateImageBehavior = false;
            // 
            // total
            // 
            this.total.Location = new System.Drawing.Point(48, 246);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(438, 25);
            this.total.TabIndex = 3;
            // 
            // receive_test_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.total);
            this.Controls.Add(this.title);
            this.Controls.Add(this.button1);
            this.Name = "receive_test_1";
            this.Text = "receive_test_1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView title;
        private System.Windows.Forms.TextBox total;
    }
}