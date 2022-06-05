
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
            this.components = new System.ComponentModel.Container();
            this.settingsButton = new System.Windows.Forms.Button();
            this.opacityButton = new System.Windows.Forms.Button();
            this.lockButton = new System.Windows.Forms.Button();
            this.favoritesButton = new System.Windows.Forms.Button();
            this.fav_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fav_add = new System.Windows.Forms.ToolStripMenuItem();
            this.fav_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.fav_del = new System.Windows.Forms.ToolStripMenuItem();
            this.fav_divLine = new System.Windows.Forms.ToolStripMenuItem();
            this.fav_menu.SuspendLayout();
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
            this.settingsButton.Location = new System.Drawing.Point(79, 1);
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
            // favoritesButton
            // 
            this.favoritesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.favoritesButton.ContextMenuStrip = this.fav_menu;
            this.favoritesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.favoritesButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.favoritesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.favoritesButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.favoritesButton.ForeColor = System.Drawing.Color.White;
            this.favoritesButton.Image = global::Lococo.Properties.Resources.star;
            this.favoritesButton.Location = new System.Drawing.Point(53, 1);
            this.favoritesButton.Name = "favoritesButton";
            this.favoritesButton.Size = new System.Drawing.Size(25, 25);
            this.favoritesButton.TabIndex = 36;
            this.favoritesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.favoritesButton.UseVisualStyleBackColor = false;
            this.favoritesButton.Click += new System.EventHandler(this.favoritesButton_Click);
            // 
            // fav_menu
            // 
            this.fav_menu.AllowDrop = true;
            this.fav_menu.AutoClose = false;
            this.fav_menu.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fav_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fav_add,
            this.fav_edit,
            this.fav_del,
            this.fav_divLine});
            this.fav_menu.Name = "fav_menu";
            this.fav_menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.fav_menu.Size = new System.Drawing.Size(192, 92);
            this.fav_menu.Click += new System.EventHandler(this.fav_menu_Click);
            // 
            // fav_add
            // 
            this.fav_add.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fav_add.Name = "fav_add";
            this.fav_add.Size = new System.Drawing.Size(191, 22);
            this.fav_add.Text = "추가";
            this.fav_add.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fav_edit
            // 
            this.fav_edit.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fav_edit.Name = "fav_edit";
            this.fav_edit.Size = new System.Drawing.Size(191, 22);
            this.fav_edit.Text = "수정";
            // 
            // fav_del
            // 
            this.fav_del.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fav_del.Name = "fav_del";
            this.fav_del.Size = new System.Drawing.Size(191, 22);
            this.fav_del.Text = "삭제";
            // 
            // fav_divLine
            // 
            this.fav_divLine.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fav_divLine.Name = "fav_divLine";
            this.fav_divLine.Size = new System.Drawing.Size(191, 22);
            this.fav_divLine.Text = "-----------------------";
            // 
            // mainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(105, 27);
            this.Controls.Add(this.favoritesButton);
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
            this.Move += new System.EventHandler(this.mainUI_Move);
            this.fav_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lockButton;
        private System.Windows.Forms.Button opacityButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button favoritesButton;
        private System.Windows.Forms.ContextMenuStrip fav_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fav_add;
        private System.Windows.Forms.ToolStripMenuItem fav_edit;
        private System.Windows.Forms.ToolStripMenuItem fav_del;
        private System.Windows.Forms.ToolStripMenuItem fav_divLine;
    }
}