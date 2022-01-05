
namespace Lococo.Forms.menus
{
    partial class menu_chatOption_setChar
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
            this.top_logo = new System.Windows.Forms.PictureBox();
            this.close_top = new System.Windows.Forms.PictureBox();
            this.Caption = new System.Windows.Forms.Label();
            this.title_panel = new System.Windows.Forms.Panel();
            this.main_char = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.searchChar = new System.Windows.Forms.Button();
            this.state_label = new System.Windows.Forms.Label();
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
            this.close_top.Location = new System.Drawing.Point(766, 3);
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
            this.Caption.Size = new System.Drawing.Size(216, 25);
            this.Caption.TabIndex = 22;
            this.Caption.Text = "동기화 대표캐릭터 지정";
            // 
            // title_panel
            // 
            this.title_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.title_panel.Controls.Add(this.top_logo);
            this.title_panel.Controls.Add(this.close_top);
            this.title_panel.Controls.Add(this.Caption);
            this.title_panel.Location = new System.Drawing.Point(0, 0);
            this.title_panel.Name = "title_panel";
            this.title_panel.Size = new System.Drawing.Size(799, 35);
            this.title_panel.TabIndex = 23;
            this.title_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_panel_MouseDown);
            this.title_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title_panel_MouseMove);
            this.title_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.title_panel_MouseUp);
            // 
            // main_char
            // 
            this.main_char.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.main_char.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.main_char.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.main_char.ForeColor = System.Drawing.Color.LightGray;
            this.main_char.Location = new System.Drawing.Point(12, 86);
            this.main_char.MaxLength = 12;
            this.main_char.Name = "main_char";
            this.main_char.Size = new System.Drawing.Size(196, 25);
            this.main_char.TabIndex = 24;
            this.main_char.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.main_char.Click += new System.EventHandler(this.main_char_Click);
            this.main_char.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.main_char_KeyPress);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 200;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // searchChar
            // 
            this.searchChar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchChar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.searchChar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.searchChar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.searchChar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchChar.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchChar.ForeColor = System.Drawing.Color.White;
            this.searchChar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchChar.Location = new System.Drawing.Point(226, 73);
            this.searchChar.Name = "searchChar";
            this.searchChar.Size = new System.Drawing.Size(75, 50);
            this.searchChar.TabIndex = 26;
            this.searchChar.Text = "검색";
            this.searchChar.UseVisualStyleBackColor = true;
            this.searchChar.Click += new System.EventHandler(this.searchChar_Click);
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
            this.state_label.Size = new System.Drawing.Size(790, 21);
            this.state_label.TabIndex = 27;
            this.state_label.Text = "↓ 동기화에 사용될 대표캐릭터를 검색해주세요. 닉네임에 포함된 단어 일부분만 검색해도 됩니다.";
            this.state_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menu_chatOption_setChar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(800, 670);
            this.Controls.Add(this.state_label);
            this.Controls.Add(this.searchChar);
            this.Controls.Add(this.main_char);
            this.Controls.Add(this.title_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "menu_chatOption_setChar";
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
        private System.Windows.Forms.TextBox main_char;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button searchChar;
        private System.Windows.Forms.Label state_label;
    }
}