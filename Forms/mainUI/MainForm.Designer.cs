
namespace Lococo.Forms.mainUI
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.top_panel = new System.Windows.Forms.Panel();
            this.top_text = new System.Windows.Forms.PictureBox();
            this.minimize_top = new System.Windows.Forms.PictureBox();
            this.close_top = new System.Windows.Forms.PictureBox();
            this.top_logo = new System.Windows.Forms.PictureBox();
            this.menu_panel_1 = new System.Windows.Forms.Panel();
            this.menu_panel_3 = new System.Windows.Forms.Panel();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.폼보이기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.check_version = new System.Windows.Forms.LinkLabel();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu_chatOption = new System.Windows.Forms.Button();
            this.menu_overlay = new System.Windows.Forms.Button();
            this.top_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.top_text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize_top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top_logo)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.top_panel.Controls.Add(this.top_text);
            this.top_panel.Controls.Add(this.minimize_top);
            this.top_panel.Controls.Add(this.close_top);
            this.top_panel.Controls.Add(this.top_logo);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(1034, 27);
            this.top_panel.TabIndex = 18;
            this.top_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseDown);
            this.top_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseMove);
            this.top_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseUp);
            // 
            // top_text
            // 
            this.top_text.Image = global::Lococo.Properties.Resources.lococo_text;
            this.top_text.Location = new System.Drawing.Point(26, 4);
            this.top_text.Name = "top_text";
            this.top_text.Size = new System.Drawing.Size(50, 20);
            this.top_text.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.top_text.TabIndex = 21;
            this.top_text.TabStop = false;
            // 
            // minimize_top
            // 
            this.minimize_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.minimize_top.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimize_top.Image = global::Lococo.Properties.Resources.minimize_top;
            this.minimize_top.Location = new System.Drawing.Point(988, 3);
            this.minimize_top.Name = "minimize_top";
            this.minimize_top.Size = new System.Drawing.Size(22, 22);
            this.minimize_top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimize_top.TabIndex = 19;
            this.minimize_top.TabStop = false;
            this.minimize_top.Click += new System.EventHandler(this.minimize_top_Click);
            this.minimize_top.MouseEnter += new System.EventHandler(this.minimize_top_MouseEnter);
            this.minimize_top.MouseLeave += new System.EventHandler(this.minimize_top_MouseLeave);
            // 
            // close_top
            // 
            this.close_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.close_top.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_top.Image = global::Lococo.Properties.Resources.close_top;
            this.close_top.Location = new System.Drawing.Point(1011, 3);
            this.close_top.Name = "close_top";
            this.close_top.Size = new System.Drawing.Size(22, 22);
            this.close_top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.close_top.TabIndex = 20;
            this.close_top.TabStop = false;
            this.close_top.Click += new System.EventHandler(this.close_top_Click);
            this.close_top.MouseEnter += new System.EventHandler(this.close_top_MouseEnter);
            this.close_top.MouseLeave += new System.EventHandler(this.close_top_MouseLeave);
            // 
            // top_logo
            // 
            this.top_logo.BackColor = System.Drawing.Color.Transparent;
            this.top_logo.Image = global::Lococo.Properties.Resources.top_logo;
            this.top_logo.Location = new System.Drawing.Point(3, 3);
            this.top_logo.Name = "top_logo";
            this.top_logo.Size = new System.Drawing.Size(20, 20);
            this.top_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.top_logo.TabIndex = 2;
            this.top_logo.TabStop = false;
            // 
            // menu_panel_1
            // 
            this.menu_panel_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.menu_panel_1.Location = new System.Drawing.Point(3, 71);
            this.menu_panel_1.Name = "menu_panel_1";
            this.menu_panel_1.Size = new System.Drawing.Size(5, 50);
            this.menu_panel_1.TabIndex = 21;
            // 
            // menu_panel_3
            // 
            this.menu_panel_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.menu_panel_3.Location = new System.Drawing.Point(3, 123);
            this.menu_panel_3.Name = "menu_panel_3";
            this.menu_panel_3.Size = new System.Drawing.Size(5, 50);
            this.menu_panel_3.TabIndex = 26;
            // 
            // Menu
            // 
            this.Menu.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.폼보이기ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(134, 48);
            // 
            // 폼보이기ToolStripMenuItem
            // 
            this.폼보이기ToolStripMenuItem.Name = "폼보이기ToolStripMenuItem";
            this.폼보이기ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.폼보이기ToolStripMenuItem.Text = "폼 보이기";
            this.폼보이기ToolStripMenuItem.Click += new System.EventHandler(this.폼보이기ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // check_version
            // 
            this.check_version.AutoSize = true;
            this.check_version.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.check_version.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.check_version.Location = new System.Drawing.Point(55, 40);
            this.check_version.Name = "check_version";
            this.check_version.Size = new System.Drawing.Size(91, 17);
            this.check_version.TabIndex = 27;
            this.check_version.TabStop = true;
            this.check_version.Text = "업데이트 확인";
            this.check_version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.check_version.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.check_version.Click += new System.EventHandler(this.check_version_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.Menu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Lococo";
            this.TrayIcon.Visible = true;
            // 
            // menu_chatOption
            // 
            this.menu_chatOption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_chatOption.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.menu_chatOption.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.menu_chatOption.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.menu_chatOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_chatOption.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menu_chatOption.ForeColor = System.Drawing.Color.White;
            this.menu_chatOption.Image = global::Lococo.Properties.Resources.menu_chatOption;
            this.menu_chatOption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_chatOption.Location = new System.Drawing.Point(3, 123);
            this.menu_chatOption.Name = "menu_chatOption";
            this.menu_chatOption.Size = new System.Drawing.Size(196, 50);
            this.menu_chatOption.TabIndex = 25;
            this.menu_chatOption.Text = "게임설정 백업           ";
            this.menu_chatOption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menu_chatOption.UseVisualStyleBackColor = true;
            this.menu_chatOption.Click += new System.EventHandler(this.menu_chatOption_Click);
            // 
            // menu_overlay
            // 
            this.menu_overlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_overlay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.menu_overlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.menu_overlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.menu_overlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_overlay.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menu_overlay.ForeColor = System.Drawing.Color.White;
            this.menu_overlay.Image = global::Lococo.Properties.Resources.overlap;
            this.menu_overlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_overlay.Location = new System.Drawing.Point(3, 71);
            this.menu_overlay.Name = "menu_overlay";
            this.menu_overlay.Size = new System.Drawing.Size(196, 50);
            this.menu_overlay.TabIndex = 16;
            this.menu_overlay.Text = "오버레이                 ";
            this.menu_overlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menu_overlay.UseVisualStyleBackColor = true;
            this.menu_overlay.Click += new System.EventHandler(this.menu_browser_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1034, 718);
            this.ControlBox = false;
            this.Controls.Add(this.check_version);
            this.Controls.Add(this.menu_panel_3);
            this.Controls.Add(this.menu_chatOption);
            this.Controls.Add(this.menu_panel_1);
            this.Controls.Add(this.top_panel);
            this.Controls.Add(this.menu_overlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로코코";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.top_text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize_top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top_logo)).EndInit();
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox top_logo;
        private System.Windows.Forms.Button menu_overlay;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.PictureBox minimize_top;
        private System.Windows.Forms.PictureBox close_top;
        private System.Windows.Forms.PictureBox top_text;
        private System.Windows.Forms.Panel menu_panel_1;
        private System.Windows.Forms.Panel menu_panel_3;
        private System.Windows.Forms.Button menu_chatOption;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem 폼보이기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.LinkLabel check_version;
        private System.Windows.Forms.NotifyIcon TrayIcon;
    }
}

