
namespace Lococo.Forms
{
    partial class overlayForm_boss
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
            this.main_picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.main_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // main_picture
            // 
            this.main_picture.BackColor = System.Drawing.Color.Transparent;
            this.main_picture.Location = new System.Drawing.Point(0, 40);
            this.main_picture.Name = "main_picture";
            this.main_picture.Size = new System.Drawing.Size(431, 408);
            this.main_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.main_picture.TabIndex = 0;
            this.main_picture.TabStop = false;
            // 
            // overlayForm_boss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.main_picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "overlayForm_boss";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.overlayForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.overlayForm_Paint);
            this.Resize += new System.EventHandler(this.overlayForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.main_picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox main_picture;
    }
}