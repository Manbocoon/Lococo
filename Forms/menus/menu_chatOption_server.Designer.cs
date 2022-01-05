
namespace Lococo.Forms.menus
{
    partial class menu_chatOption_server
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
            this.top_logo = new System.Windows.Forms.PictureBox();
            this.close_top = new System.Windows.Forms.PictureBox();
            this.Caption = new System.Windows.Forms.Label();
            this.title_panel = new System.Windows.Forms.Panel();
            this.password = new System.Windows.Forms.TextBox();
            this.state_label = new System.Windows.Forms.Label();
            this.upload = new System.Windows.Forms.LinkLabel();
            this.download = new System.Windows.Forms.LinkLabel();
            this.extend_date = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.top_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_top)).BeginInit();
            this.title_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // top_logo
            // 
            this.top_logo.BackColor = System.Drawing.Color.Transparent;
            this.top_logo.Location = new System.Drawing.Point(3, 1);
            this.top_logo.Name = "top_logo";
            this.top_logo.Size = new System.Drawing.Size(32, 32);
            this.top_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.top_logo.TabIndex = 3;
            this.top_logo.TabStop = false;
            // 
            // close_top
            // 
            this.close_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.close_top.Location = new System.Drawing.Point(579, 1);
            this.close_top.Name = "close_top";
            this.close_top.Size = new System.Drawing.Size(30, 30);
            this.close_top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.close_top.TabIndex = 21;
            this.close_top.TabStop = false;
            this.close_top.Click += new System.EventHandler(this.close_top_Click);
            this.close_top.MouseEnter += new System.EventHandler(this.close_top_MouseEnter);
            this.close_top.MouseLeave += new System.EventHandler(this.close_top_MouseLeave);
            // 
            // Caption
            // 
            this.Caption.AutoSize = true;
            this.Caption.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Caption.ForeColor = System.Drawing.Color.DarkGray;
            this.Caption.Location = new System.Drawing.Point(41, 6);
            this.Caption.Name = "Caption";
            this.Caption.Size = new System.Drawing.Size(300, 25);
            this.Caption.TabIndex = 22;
            this.Caption.Text = "게임설정 서버에서 백업/불러오기";
            // 
            // title_panel
            // 
            this.title_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.title_panel.Controls.Add(this.top_logo);
            this.title_panel.Controls.Add(this.close_top);
            this.title_panel.Controls.Add(this.Caption);
            this.title_panel.Location = new System.Drawing.Point(0, 0);
            this.title_panel.Name = "title_panel";
            this.title_panel.Size = new System.Drawing.Size(612, 35);
            this.title_panel.TabIndex = 23;
            this.title_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_panel_MouseDown);
            this.title_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title_panel_MouseMove);
            this.title_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.title_panel_MouseUp);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.password.ForeColor = System.Drawing.Color.LightGray;
            this.password.Location = new System.Drawing.Point(12, 86);
            this.password.MaxLength = 30;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(295, 25);
            this.password.TabIndex = 24;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // state_label
            // 
            this.state_label.BackColor = System.Drawing.Color.Transparent;
            this.state_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.state_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.state_label.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.state_label.ForeColor = System.Drawing.Color.LightGray;
            this.state_label.Location = new System.Drawing.Point(5, 38);
            this.state_label.Name = "state_label";
            this.state_label.Size = new System.Drawing.Size(598, 21);
            this.state_label.TabIndex = 27;
            this.state_label.Text = "↓ 불러올 때 사용할 비밀번호를 입력해주세요. (영어 소문자/숫자만 사용, 6~30자 사이의 비밀번호)";
            this.state_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // upload
            // 
            this.upload.AutoSize = true;
            this.upload.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.upload.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.upload.Location = new System.Drawing.Point(12, 133);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(34, 17);
            this.upload.TabIndex = 29;
            this.upload.TabStop = true;
            this.upload.Text = "백업";
            this.upload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.upload.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // download
            // 
            this.download.AutoSize = true;
            this.download.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.download.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.download.Location = new System.Drawing.Point(12, 170);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(60, 17);
            this.download.TabIndex = 30;
            this.download.TabStop = true;
            this.download.Text = "불러오기";
            this.download.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.download.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // extend_date
            // 
            this.extend_date.AutoSize = true;
            this.extend_date.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.extend_date.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.extend_date.Location = new System.Drawing.Point(12, 261);
            this.extend_date.Name = "extend_date";
            this.extend_date.Size = new System.Drawing.Size(91, 17);
            this.extend_date.TabIndex = 31;
            this.extend_date.TabStop = true;
            this.extend_date.Text = "유효기간 연장";
            this.extend_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.extend_date.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.extend_date.Click += new System.EventHandler(this.extend_date_Click);
            // 
            // menu_chatOption_server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(614, 307);
            this.Controls.Add(this.extend_date);
            this.Controls.Add(this.download);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.state_label);
            this.Controls.Add(this.password);
            this.Controls.Add(this.title_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "menu_chatOption_server";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.messageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.top_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_top)).EndInit();
            this.title_panel.ResumeLayout(false);
            this.title_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox top_logo;
        private System.Windows.Forms.PictureBox close_top;
        private System.Windows.Forms.Label Caption;
        private System.Windows.Forms.Panel title_panel;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label state_label;
        private System.Windows.Forms.LinkLabel upload;
        private System.Windows.Forms.LinkLabel download;
        private System.Windows.Forms.LinkLabel extend_date;
    }
}