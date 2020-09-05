namespace GhepHinh
{
    partial class frmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Finish = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Label();
            this.cbHelp = new System.Windows.Forms.CheckBox();
            this.nmudColumn = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nmudLine = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lv = new System.Windows.Forms.ListView();
            this.btnsend = new System.Windows.Forms.Button();
            this.txbmess = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.Finish);
            this.groupBox1.Controls.Add(this.Start);
            this.groupBox1.Controls.Add(this.cbHelp);
            this.groupBox1.Controls.Add(this.nmudColumn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nmudLine);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // Finish
            // 
            this.Finish.AutoSize = true;
            this.Finish.Font = new System.Drawing.Font("Viner Hand ITC", 19.8F, System.Drawing.FontStyle.Bold);
            this.Finish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Finish.Location = new System.Drawing.Point(436, 23);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(126, 53);
            this.Finish.TabIndex = 7;
            this.Finish.Text = "Finish";
            this.Finish.Click += new System.EventHandler(this.Finish_Click);
            // 
            // Start
            // 
            this.Start.AutoSize = true;
            this.Start.Font = new System.Drawing.Font("Viner Hand ITC", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Start.Location = new System.Drawing.Point(13, 76);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(115, 53);
            this.Start.TabIndex = 6;
            this.Start.Text = "Start";
            this.Start.Click += new System.EventHandler(this.Label4_Click);
            // 
            // cbHelp
            // 
            this.cbHelp.AutoSize = true;
            this.cbHelp.Enabled = false;
            this.cbHelp.Font = new System.Drawing.Font("Viner Hand ITC", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbHelp.Location = new System.Drawing.Point(637, 21);
            this.cbHelp.Name = "cbHelp";
            this.cbHelp.Size = new System.Drawing.Size(121, 57);
            this.cbHelp.TabIndex = 3;
            this.cbHelp.Text = "Help";
            this.cbHelp.UseVisualStyleBackColor = true;
            this.cbHelp.CheckedChanged += new System.EventHandler(this.CbHelp_CheckedChanged);
            // 
            // nmudColumn
            // 
            this.nmudColumn.Location = new System.Drawing.Point(286, 33);
            this.nmudColumn.Name = "nmudColumn";
            this.nmudColumn.Size = new System.Drawing.Size(52, 27);
            this.nmudColumn.TabIndex = 1;
            this.nmudColumn.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(196, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số cột :";
            // 
            // nmudLine
            // 
            this.nmudLine.Location = new System.Drawing.Point(114, 33);
            this.nmudLine.Name = "nmudLine";
            this.nmudLine.Size = new System.Drawing.Size(52, 27);
            this.nmudLine.TabIndex = 1;
            this.nmudLine.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(19, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số dòng :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(0, 0);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(253, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 507);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(0, 0);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.tbxName);
            this.pnlMain.Controls.Add(this.lv);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.btnsend);
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.Controls.Add(this.txbmess);
            this.pnlMain.Location = new System.Drawing.Point(12, 180);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(827, 596);
            this.pnlMain.TabIndex = 5;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlMain_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Viner Hand ITC", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(218, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 53);
            this.label1.TabIndex = 8;
            this.label1.Text = "Amazing Puzzle Game";
            // 
            // lv
            // 
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(10, 201);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(237, 226);
            this.lv.TabIndex = 22;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.List;
            // 
            // btnsend
            // 
            this.btnsend.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsend.Location = new System.Drawing.Point(10, 534);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(235, 41);
            this.btnsend.TabIndex = 20;
            this.btnsend.Text = "Gửi";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.Btnsend_Click);
            // 
            // txbmess
            // 
            this.txbmess.Location = new System.Drawing.Point(10, 471);
            this.txbmess.Multiline = true;
            this.txbmess.Name = "txbmess";
            this.txbmess.Size = new System.Drawing.Size(237, 57);
            this.txbmess.TabIndex = 19;
            this.txbmess.Text = " ";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(130, 433);
            this.tbxName.Multiline = true;
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(117, 32);
            this.tbxName.TabIndex = 23;
            this.tbxName.Text = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Name";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GhepHinh.Properties.Resources.backgroung1;
            this.ClientSize = new System.Drawing.Size(848, 788);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "Puzzle Game";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nmudLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nmudColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbHelp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Finish;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.TextBox txbmess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxName;
    }
}