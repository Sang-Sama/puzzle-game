namespace sever
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
            this.btnsend = new System.Windows.Forms.Button();
            this.txbmess = new System.Windows.Forms.TextBox();
            this.lv = new System.Windows.Forms.ListView();
            this.ptbMain = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsend
            // 
            this.btnsend.Location = new System.Drawing.Point(332, 350);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(50, 48);
            this.btnsend.TabIndex = 5;
            this.btnsend.Text = "send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click_1);
            // 
            // txbmess
            // 
            this.txbmess.Location = new System.Drawing.Point(12, 350);
            this.txbmess.Multiline = true;
            this.txbmess.Name = "txbmess";
            this.txbmess.Size = new System.Drawing.Size(300, 48);
            this.txbmess.TabIndex = 4;
            this.txbmess.Text = " ";
            // 
            // lv
            // 
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(12, 12);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(356, 320);
            this.lv.TabIndex = 3;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.List;
            // 
            // ptbMain
            // 
            this.ptbMain.Location = new System.Drawing.Point(425, 13);
            this.ptbMain.Name = "ptbMain";
            this.ptbMain.Size = new System.Drawing.Size(402, 319);
            this.ptbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbMain.TabIndex = 6;
            this.ptbMain.TabStop = false;
            this.ptbMain.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(679, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 48);
            this.button1.TabIndex = 7;
            this.button1.Text = "Send Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 470);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ptbMain);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.txbmess);
            this.Controls.Add(this.lv);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.TextBox txbmess;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.PictureBox ptbMain;
        private System.Windows.Forms.Button button1;
    }
}

