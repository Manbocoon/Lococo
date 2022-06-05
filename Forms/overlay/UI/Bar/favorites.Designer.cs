
namespace Lococo.Forms.overlay.UI.Bar
{
    partial class favorites
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
            this.fav_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fav_title
            // 
            this.fav_title.AutoSize = true;
            this.fav_title.BackColor = System.Drawing.Color.Transparent;
            this.fav_title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fav_title.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fav_title.ForeColor = System.Drawing.Color.White;
            this.fav_title.Location = new System.Drawing.Point(15, 15);
            this.fav_title.Name = "fav_title";
            this.fav_title.Size = new System.Drawing.Size(145, 25);
            this.fav_title.TabIndex = 61;
            this.fav_title.Text = "즐겨찾기 관리: ";
            // 
            // favorites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(597, 444);
            this.Controls.Add(this.fav_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(50, 20);
            this.Name = "favorites";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lococo - Overlay";
            this.Load += new System.EventHandler(this.overlayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fav_title;
    }
}