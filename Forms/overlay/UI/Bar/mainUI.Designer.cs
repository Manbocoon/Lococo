
namespace Lococo.Forms.overlay.UI.Bar
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
            this.settingsButton = new System.Windows.Forms.Button();
            this.opacityButton = new System.Windows.Forms.Button();
            this.lockButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Image = global::Lococo.Properties.Resources.settings_small;
            this.settingsButton.Location = new System.Drawing.Point(53, 1);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(25, 25);
            this.settingsButton.TabIndex = 35;
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // opacityButton
            // 
            this.opacityButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.opacityButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.opacityButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.opacityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opacityButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.opacityButton.ForeColor = System.Drawing.Color.White;
            this.opacityButton.Image = global::Lococo.Properties.Resources.transBackground;
            this.opacityButton.Location = new System.Drawing.Point(27, 1);
            this.opacityButton.Name = "opacityButton";
            this.opacityButton.Size = new System.Drawing.Size(25, 25);
            this.opacityButton.TabIndex = 34;
            this.opacityButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opacityButton.UseVisualStyleBackColor = false;
            this.opacityButton.Click += new System.EventHandler(this.opacityButton_Click);
            // 
            // lockButton
            // 
            this.lockButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lockButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lockButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lockButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lockButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lockButton.ForeColor = System.Drawing.Color.White;
            this.lockButton.Image = global::Lococo.Properties.Resources.unlock;
            this.lockButton.Location = new System.Drawing.Point(1, 1);
            this.lockButton.Name = "lockButton";
            this.lockButton.Size = new System.Drawing.Size(25, 25);
            this.lockButton.TabIndex = 33;
            this.lockButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lockButton.UseVisualStyleBackColor = false;
            this.lockButton.Click += new System.EventHandler(this.lockButton_Click);
            // 
            // mainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(79, 27);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.opacityButton);
            this.Controls.Add(this.lockButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(50, 20);
            this.Name = "mainUI";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lococo - Overlay";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.mainUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lockButton;
        private System.Windows.Forms.Button opacityButton;
        private System.Windows.Forms.Button settingsButton;
    }
}