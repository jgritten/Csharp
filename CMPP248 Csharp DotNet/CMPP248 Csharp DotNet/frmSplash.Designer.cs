namespace CMPP248_Csharp_DotNet
{
    partial class frmSplash
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
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.pbxTEMLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTEMLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(20, 266);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(278, 17);
            this.progressBar1.TabIndex = 5;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Enabled = true;
            this.tmrTimer.Interval = 50;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // pbxTEMLogo
            // 
            this.pbxTEMLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxTEMLogo.BackgroundImage = global::CMPP248_Csharp_DotNet.Properties.Resources.Travel_Experts_Welcome;
            this.pbxTEMLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxTEMLogo.Location = new System.Drawing.Point(-16, 0);
            this.pbxTEMLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbxTEMLogo.Name = "pbxTEMLogo";
            this.pbxTEMLogo.Size = new System.Drawing.Size(352, 306);
            this.pbxTEMLogo.TabIndex = 6;
            this.pbxTEMLogo.TabStop = false;
            this.pbxTEMLogo.Click += new System.EventHandler(this.pbxTEMLogo_Click);
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 306);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pbxTEMLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmSplash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            ((System.ComponentModel.ISupportInitialize)(this.pbxTEMLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer tmrTimer;
        private System.Windows.Forms.PictureBox pbxTEMLogo;
    }
}