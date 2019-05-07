namespace CryptoTracker
{
    partial class Form1
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
            this.button1CPol = new System.Windows.Forms.Button();
            this.button2DPol = new System.Windows.Forms.Button();
            this.textBox1AskPolPrice = new System.Windows.Forms.TextBox();
            this.textBox1AskPolVol = new System.Windows.Forms.TextBox();
            this.textBox1BidPolVol = new System.Windows.Forms.TextBox();
            this.textBox1BidPolPrice = new System.Windows.Forms.TextBox();
            this.groupBox1Pol = new System.Windows.Forms.GroupBox();
            this.textBox1Channel = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button3Update = new System.Windows.Forms.Button();
            this.groupBox1Pol.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1CPol
            // 
            this.button1CPol.Location = new System.Drawing.Point(63, 79);
            this.button1CPol.Name = "button1CPol";
            this.button1CPol.Size = new System.Drawing.Size(75, 23);
            this.button1CPol.TabIndex = 0;
            this.button1CPol.Text = "Connect";
            this.button1CPol.UseVisualStyleBackColor = true;
            this.button1CPol.Click += new System.EventHandler(this.Button1CPol_Click);
            // 
            // button2DPol
            // 
            this.button2DPol.Location = new System.Drawing.Point(264, 79);
            this.button2DPol.Name = "button2DPol";
            this.button2DPol.Size = new System.Drawing.Size(75, 23);
            this.button2DPol.TabIndex = 1;
            this.button2DPol.Text = "Disconn";
            this.button2DPol.UseVisualStyleBackColor = true;
            this.button2DPol.Click += new System.EventHandler(this.Button2DPol_Click);
            // 
            // textBox1AskPolPrice
            // 
            this.textBox1AskPolPrice.Location = new System.Drawing.Point(63, 131);
            this.textBox1AskPolPrice.Name = "textBox1AskPolPrice";
            this.textBox1AskPolPrice.Size = new System.Drawing.Size(182, 22);
            this.textBox1AskPolPrice.TabIndex = 2;
            // 
            // textBox1AskPolVol
            // 
            this.textBox1AskPolVol.Location = new System.Drawing.Point(264, 131);
            this.textBox1AskPolVol.Name = "textBox1AskPolVol";
            this.textBox1AskPolVol.Size = new System.Drawing.Size(182, 22);
            this.textBox1AskPolVol.TabIndex = 3;
            // 
            // textBox1BidPolVol
            // 
            this.textBox1BidPolVol.Location = new System.Drawing.Point(264, 179);
            this.textBox1BidPolVol.Name = "textBox1BidPolVol";
            this.textBox1BidPolVol.Size = new System.Drawing.Size(182, 22);
            this.textBox1BidPolVol.TabIndex = 4;
            // 
            // textBox1BidPolPrice
            // 
            this.textBox1BidPolPrice.Location = new System.Drawing.Point(63, 179);
            this.textBox1BidPolPrice.Name = "textBox1BidPolPrice";
            this.textBox1BidPolPrice.Size = new System.Drawing.Size(182, 22);
            this.textBox1BidPolPrice.TabIndex = 5;
            // 
            // groupBox1Pol
            // 
            this.groupBox1Pol.Controls.Add(this.textBox1Channel);
            this.groupBox1Pol.Controls.Add(this.richTextBox1);
            this.groupBox1Pol.Controls.Add(this.button3Update);
            this.groupBox1Pol.Location = new System.Drawing.Point(43, 50);
            this.groupBox1Pol.Name = "groupBox1Pol";
            this.groupBox1Pol.Size = new System.Drawing.Size(566, 1013);
            this.groupBox1Pol.TabIndex = 6;
            this.groupBox1Pol.TabStop = false;
            this.groupBox1Pol.Text = "Poloniex";
            // 
            // textBox1Channel
            // 
            this.textBox1Channel.Location = new System.Drawing.Point(423, 80);
            this.textBox1Channel.Name = "textBox1Channel";
            this.textBox1Channel.Size = new System.Drawing.Size(124, 22);
            this.textBox1Channel.TabIndex = 9;
            this.textBox1Channel.Text = "USDT_BTC";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(20, 177);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(527, 818);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // button3Update
            // 
            this.button3Update.Location = new System.Drawing.Point(328, 29);
            this.button3Update.Name = "button3Update";
            this.button3Update.Size = new System.Drawing.Size(75, 23);
            this.button3Update.TabIndex = 7;
            this.button3Update.Text = "Update";
            this.button3Update.UseVisualStyleBackColor = true;
            this.button3Update.Click += new System.EventHandler(this.Button3Update_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1596, 1118);
            this.Controls.Add(this.textBox1BidPolPrice);
            this.Controls.Add(this.textBox1BidPolVol);
            this.Controls.Add(this.textBox1AskPolVol);
            this.Controls.Add(this.textBox1AskPolPrice);
            this.Controls.Add(this.button2DPol);
            this.Controls.Add(this.button1CPol);
            this.Controls.Add(this.groupBox1Pol);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1Pol.ResumeLayout(false);
            this.groupBox1Pol.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1CPol;
        private System.Windows.Forms.Button button2DPol;
        private System.Windows.Forms.TextBox textBox1AskPolPrice;
        private System.Windows.Forms.TextBox textBox1AskPolVol;
        private System.Windows.Forms.TextBox textBox1BidPolVol;
        private System.Windows.Forms.TextBox textBox1BidPolPrice;
        private System.Windows.Forms.GroupBox groupBox1Pol;
        private System.Windows.Forms.Button button3Update;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1Channel;
    }
}

