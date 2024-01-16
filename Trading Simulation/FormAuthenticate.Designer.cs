namespace Trading_Simulation
{
    partial class FormAuthenticate
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_UserID = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2_password = new System.Windows.Forms.TextBox();
            this.button1_submit = new System.Windows.Forms.Button();
            this.button2_cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.button2_cancel);
            this.panel1.Controls.Add(this.button1_submit);
            this.panel1.Controls.Add(this.textBox2_password);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.Password);
            this.panel1.Controls.Add(this.label_UserID);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(493, 340);
            this.panel1.TabIndex = 0;
            // 
            // label_UserID
            // 
            this.label_UserID.AutoSize = true;
            this.label_UserID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_UserID.Location = new System.Drawing.Point(36, 111);
            this.label_UserID.Name = "label_UserID";
            this.label_UserID.Size = new System.Drawing.Size(70, 25);
            this.label_UserID.TabIndex = 0;
            this.label_UserID.Text = "UserID ";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Password.Location = new System.Drawing.Point(13, 169);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(87, 25);
            this.Password.TabIndex = 1;
            this.Password.Text = "Password";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(308, 31);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2_password
            // 
            this.textBox2_password.Location = new System.Drawing.Point(108, 169);
            this.textBox2_password.Name = "textBox2_password";
            this.textBox2_password.Size = new System.Drawing.Size(308, 31);
            this.textBox2_password.TabIndex = 3;
            // 
            // button1_submit
            // 
            this.button1_submit.Location = new System.Drawing.Point(235, 237);
            this.button1_submit.Name = "button1_submit";
            this.button1_submit.Size = new System.Drawing.Size(167, 61);
            this.button1_submit.TabIndex = 4;
            this.button1_submit.Text = "Submit";
            this.button1_submit.UseVisualStyleBackColor = true;
            this.button1_submit.Click += new System.EventHandler(this.button1_submit_Click);
            // 
            // button2_cancel
            // 
            this.button2_cancel.Location = new System.Drawing.Point(36, 237);
            this.button2_cancel.Name = "button2_cancel";
            this.button2_cancel.Size = new System.Drawing.Size(167, 61);
            this.button2_cancel.TabIndex = 5;
            this.button2_cancel.Text = "Canceel\\ Exit";
            this.button2_cancel.UseVisualStyleBackColor = true;
            this.button2_cancel.Click += new System.EventHandler(this.button2_cancel_Click);
            // 
            // FormAuthenticate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(525, 366);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAuthenticate";
            this.Text = "FormAuthenticate";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private Label Password;
        private Label label_UserID;
        public Button button2_cancel;
        public Button button1_submit;
        public TextBox textBox2_password;
    }
}