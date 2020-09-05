namespace GhepHinh
{
    partial class Help
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
            this.pitImageHelp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pitImageHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // pitImageHelp
            // 
            this.pitImageHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pitImageHelp.Location = new System.Drawing.Point(0, 0);
            this.pitImageHelp.Name = "pitImageHelp";
            this.pitImageHelp.Size = new System.Drawing.Size(490, 403);
            this.pitImageHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pitImageHelp.TabIndex = 0;
            this.pitImageHelp.TabStop = false;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 403);
            this.Controls.Add(this.pitImageHelp);
            this.HelpButton = true;
            this.Name = "Help";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pitImageHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pitImageHelp;
    }
}