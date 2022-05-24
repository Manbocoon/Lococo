
namespace Lococo.Forms.overlay.UI.Bar
{
    partial class slider
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
            this.opacity = new Lococo.Functions.UI.Slider();
            this.SuspendLayout();
            // 
            // opacity
            // 
            this.opacity.BarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.opacity.BarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.opacity.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.opacity.Location = new System.Drawing.Point(-2, 0);
            this.opacity.Max = 100;
            this.opacity.Min = 0;
            this.opacity.Name = "opacity";
            this.opacity.Size = new System.Drawing.Size(400, 25);
            this.opacity.SmallestChange = 1;
            this.opacity.TabIndex = 58;
            this.opacity.UseBox = true;
            this.opacity.Value = 80;
            this.opacity.ValueChanged += new System.EventHandler(this.opacity_ValueChanged);
            // 
            // slider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(400, 25);
            this.Controls.Add(this.opacity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(50, 20);
            this.Name = "slider";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lococo - Overlay";
            this.Load += new System.EventHandler(this.overlayForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Functions.UI.Slider opacity;
    }
}