namespace Trading_Simulation
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1_ltp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_trades = new System.Windows.Forms.DataGridView();
            this.button3_sell = new System.Windows.Forms.Button();
            this.button2_buy = new System.Windows.Forms.Button();
            this.button1_starttradong = new System.Windows.Forms.Button();
            this.panel2_chart = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_trades)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2_chart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1584, 947);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.textBox1_ltp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgv_trades);
            this.panel1.Controls.Add(this.button3_sell);
            this.panel1.Controls.Add(this.button2_buy);
            this.panel1.Controls.Add(this.button1_starttradong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(15, 330);
            this.panel1.Margin = new System.Windows.Forms.Padding(15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1554, 285);
            this.panel1.TabIndex = 0;
            // 
            // textBox1_ltp
            // 
            this.textBox1_ltp.Location = new System.Drawing.Point(415, 12);
            this.textBox1_ltp.Name = "textBox1_ltp";
            this.textBox1_ltp.ReadOnly = true;
            this.textBox1_ltp.Size = new System.Drawing.Size(184, 31);
            this.textBox1_ltp.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(346, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tick";
            // 
            // dgv_trades
            // 
            this.dgv_trades.AllowUserToAddRows = false;
            this.dgv_trades.AllowUserToDeleteRows = false;
            this.dgv_trades.AllowUserToResizeColumns = false;
            this.dgv_trades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_trades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_trades.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_trades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_trades.Location = new System.Drawing.Point(11, 93);
            this.dgv_trades.Name = "dgv_trades";
            this.dgv_trades.ReadOnly = true;
            this.dgv_trades.RowHeadersVisible = false;
            this.dgv_trades.RowHeadersWidth = 62;
            this.dgv_trades.RowTemplate.Height = 30;
            this.dgv_trades.Size = new System.Drawing.Size(1532, 184);
            this.dgv_trades.TabIndex = 3;
            // 
            // button3_sell
            // 
            this.button3_sell.Location = new System.Drawing.Point(1276, 14);
            this.button3_sell.Name = "button3_sell";
            this.button3_sell.Size = new System.Drawing.Size(213, 47);
            this.button3_sell.TabIndex = 2;
            this.button3_sell.Text = "Sell";
            this.button3_sell.UseVisualStyleBackColor = true;
            this.button3_sell.Click += new System.EventHandler(this.button3_sell_Click);
            // 
            // button2_buy
            // 
            this.button2_buy.Location = new System.Drawing.Point(950, 14);
            this.button2_buy.Name = "button2_buy";
            this.button2_buy.Size = new System.Drawing.Size(213, 47);
            this.button2_buy.TabIndex = 1;
            this.button2_buy.Text = "Buy";
            this.button2_buy.UseVisualStyleBackColor = true;
            this.button2_buy.Click += new System.EventHandler(this.button2_buy_Click);
            // 
            // button1_starttradong
            // 
            this.button1_starttradong.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1_starttradong.Location = new System.Drawing.Point(19, 14);
            this.button1_starttradong.Name = "button1_starttradong";
            this.button1_starttradong.Size = new System.Drawing.Size(213, 47);
            this.button1_starttradong.TabIndex = 0;
            this.button1_starttradong.Text = "Start Trading";
            this.button1_starttradong.UseVisualStyleBackColor = true;
            this.button1_starttradong.Click += new System.EventHandler(this.button1_starttradong_Click);
            // 
            // panel2_chart
            // 
            this.panel2_chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2_chart.Location = new System.Drawing.Point(12, 12);
            this.panel2_chart.Margin = new System.Windows.Forms.Padding(12);
            this.panel2_chart.Name = "panel2_chart";
            this.panel2_chart.Size = new System.Drawing.Size(1546, 291);
            this.panel2_chart.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Location = new System.Drawing.Point(20, 650);
            this.panel2.Margin = new System.Windows.Forms.Padding(20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1544, 277);
            this.panel2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 947);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Trading X";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_trades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private DataGridView dgv_trades;
        private Button button3_sell;
        private Button button2_buy;
        private Button button1_starttradong;
        private TextBox textBox1_ltp;
        private Label label1;
        private Panel panel2_chart;
        private Panel panel2;
    }
}