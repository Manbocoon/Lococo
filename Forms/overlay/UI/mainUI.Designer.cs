
namespace Lococo.Forms.overlay
{
    partial class mainUI
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
            this.open_text = new System.Windows.Forms.Button();
            this.open_image = new System.Windows.Forms.Button();
            this.open_browser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // open_text
            // 
            this.open_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.open_text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.open_text.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.open_text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_text.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.open_text.ForeColor = System.Drawing.Color.White;
            this.open_text.Image = global::Lococo.Properties.Resources.menu_text;
            this.open_text.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.open_text.Location = new System.Drawing.Point(104, 37);
            this.open_text.Name = "open_text";
            this.open_text.Size = new System.Drawing.Size(45, 45);
            this.open_text.TabIndex = 32;
            this.open_text.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.open_text.UseVisualStyleBackColor = false;
            this.open_text.Click += new System.EventHandler(this.menu_text_Click);
            // 
            // open_image
            // 
            this.open_image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.open_image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.open_image.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.open_image.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_image.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.open_image.ForeColor = System.Drawing.Color.White;
            this.open_image.Image = global::Lococo.Properties.Resources.menu_image;
            this.open_image.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.open_image.Location = new System.Drawing.Point(53, 37);
            this.open_image.Name = "open_image";
            this.open_image.Size = new System.Drawing.Size(45, 45);
            this.open_image.TabIndex = 30;
            this.open_image.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.open_image.UseVisualStyleBackColor = false;
            this.open_image.Click += new System.EventHandler(this.menu_image_Click);
            // 
            // open_browser
            // 
            this.open_browser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.open_browser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.open_browser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.open_browser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_browser.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.open_browser.ForeColor = System.Drawing.Color.White;
            this.open_browser.Image = global::Lococo.Properties.Resources.menu_browser;
            this.open_browser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.open_browser.Location = new System.Drawing.Point(2, 37);
            this.open_browser.Name = "open_browser";
            this.open_browser.Size = new System.Drawing.Size(45, 45);
            this.open_browser.TabIndex = 29;
            this.open_browser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.open_browser.UseVisualStyleBackColor = false;
            this.open_browser.Click += new System.EventHandler(this.menu_browser_Click);
            // 
            // mainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(151, 84);
            this.Controls.Add(this.open_text);
            this.Controls.Add(this.open_image);
            this.Controls.Add(this.open_browser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(150, 50);
            this.Name = "mainUI";
            this.Opacity = 0.85D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lococo - Overlay";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.overlayForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button open_text;
        private System.Windows.Forms.Button open_image;
        private System.Windows.Forms.Button open_browser;
    }
}