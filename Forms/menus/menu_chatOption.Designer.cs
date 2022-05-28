
namespace Lococo.Forms.menus
{
    partial class menu_chatOption
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.state_label = new System.Windows.Forms.Label();
            this.title_available = new System.Windows.Forms.Label();
            this.line_1 = new System.Windows.Forms.Label();
            this.title_synchro = new System.Windows.Forms.Label();
            this.charCount_label = new System.Windows.Forms.Label();
            this.state_setChar = new System.Windows.Forms.Label();
            this.line_2 = new System.Windows.Forms.Label();
            this.title_backup = new System.Windows.Forms.Label();
            this.backup_pc = new System.Windows.Forms.LinkLabel();
            this.apply_pc = new System.Windows.Forms.LinkLabel();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.open_lostark = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // state_label
            // 
            this.state_label.AutoSize = true;
            this.state_label.BackColor = System.Drawing.Color.Transparent;
            this.state_label.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.state_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(81)))), ((int)(((byte)(36)))));
            this.state_label.Location = new System.Drawing.Point(80, 20);
            this.state_label.Name = "state_label";
            this.state_label.Size = new System.Drawing.Size(43, 17);
            this.state_label.TabIndex = 0;
            this.state_label.Text = "! 내용";
            // 
            // title_available
            // 
            this.title_available.AutoSize = true;
            this.title_available.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title_available.ForeColor = System.Drawing.Color.White;
            this.title_available.Location = new System.Drawing.Point(15, 15);
            this.title_available.Name = "title_available";
            this.title_available.Size = new System.Drawing.Size(50, 25);
            this.title_available.TabIndex = 1;
            this.title_available.Text = "상태";
            // 
            // line_1
            // 
            this.line_1.AutoSize = true;
            this.line_1.BackColor = System.Drawing.Color.Transparent;
            this.line_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_1.Location = new System.Drawing.Point(17, 54);
            this.line_1.Name = "line_1";
            this.line_1.Size = new System.Drawing.Size(491, 12);
            this.line_1.TabIndex = 2;
            this.line_1.Text = "---------------------------------------------------------------------------------" +
    "";
            // 
            // title_synchro
            // 
            this.title_synchro.AutoSize = true;
            this.title_synchro.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title_synchro.ForeColor = System.Drawing.Color.White;
            this.title_synchro.Location = new System.Drawing.Point(15, 85);
            this.title_synchro.Name = "title_synchro";
            this.title_synchro.Size = new System.Drawing.Size(69, 25);
            this.title_synchro.TabIndex = 3;
            this.title_synchro.Text = "동기화";
            // 
            // charCount_label
            // 
            this.charCount_label.AutoSize = true;
            this.charCount_label.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.charCount_label.ForeColor = System.Drawing.Color.Silver;
            this.charCount_label.Location = new System.Drawing.Point(17, 128);
            this.charCount_label.Name = "charCount_label";
            this.charCount_label.Size = new System.Drawing.Size(227, 21);
            this.charCount_label.TabIndex = 4;
            this.charCount_label.Text = "0개의 계정이 감지되었습니다.";
            // 
            // state_setChar
            // 
            this.state_setChar.AutoSize = true;
            this.state_setChar.BackColor = System.Drawing.Color.Transparent;
            this.state_setChar.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.state_setChar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(81)))), ((int)(((byte)(36)))));
            this.state_setChar.Location = new System.Drawing.Point(100, 90);
            this.state_setChar.Name = "state_setChar";
            this.state_setChar.Size = new System.Drawing.Size(129, 17);
            this.state_setChar.TabIndex = 6;
            this.state_setChar.Text = "! 제거된 기능입니다.";
            // 
            // line_2
            // 
            this.line_2.AutoSize = true;
            this.line_2.BackColor = System.Drawing.Color.Transparent;
            this.line_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_2.Location = new System.Drawing.Point(17, 168);
            this.line_2.Name = "line_2";
            this.line_2.Size = new System.Drawing.Size(491, 12);
            this.line_2.TabIndex = 9;
            this.line_2.Text = "---------------------------------------------------------------------------------" +
    "";
            // 
            // title_backup
            // 
            this.title_backup.AutoSize = true;
            this.title_backup.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title_backup.ForeColor = System.Drawing.Color.White;
            this.title_backup.Location = new System.Drawing.Point(15, 198);
            this.title_backup.Name = "title_backup";
            this.title_backup.Size = new System.Drawing.Size(217, 25);
            this.title_backup.TabIndex = 10;
            this.title_backup.Text = "게임설정 백업/불러오기";
            // 
            // backup_pc
            // 
            this.backup_pc.AutoSize = true;
            this.backup_pc.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.backup_pc.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.backup_pc.Location = new System.Drawing.Point(17, 237);
            this.backup_pc.Name = "backup_pc";
            this.backup_pc.Size = new System.Drawing.Size(67, 17);
            this.backup_pc.TabIndex = 11;
            this.backup_pc.TabStop = true;
            this.backup_pc.Text = "PC에 백업";
            this.backup_pc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.backup_pc.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.backup_pc.Click += new System.EventHandler(this.backup_pc_Click);
            // 
            // apply_pc
            // 
            this.apply_pc.AutoSize = true;
            this.apply_pc.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.apply_pc.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.apply_pc.Location = new System.Drawing.Point(17, 265);
            this.apply_pc.Name = "apply_pc";
            this.apply_pc.Size = new System.Drawing.Size(106, 17);
            this.apply_pc.TabIndex = 12;
            this.apply_pc.TabStop = true;
            this.apply_pc.Text = "PC에서 불러오기";
            this.apply_pc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.apply_pc.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.apply_pc.Click += new System.EventHandler(this.apply_pc_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "backup.zip";
            this.openFile.Title = "PC에서 불러오기";
            // 
            // open_lostark
            // 
            this.open_lostark.AutoSize = true;
            this.open_lostark.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.open_lostark.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.open_lostark.Location = new System.Drawing.Point(17, 294);
            this.open_lostark.Name = "open_lostark";
            this.open_lostark.Size = new System.Drawing.Size(135, 17);
            this.open_lostark.TabIndex = 15;
            this.open_lostark.TabStop = true;
            this.open_lostark.Text = "로스트아크 폴더 열기";
            this.open_lostark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.open_lostark.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.open_lostark.Click += new System.EventHandler(this.open_lostark_Click);
            // 
            // menu_chatOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.Controls.Add(this.open_lostark);
            this.Controls.Add(this.apply_pc);
            this.Controls.Add(this.backup_pc);
            this.Controls.Add(this.title_backup);
            this.Controls.Add(this.line_2);
            this.Controls.Add(this.state_setChar);
            this.Controls.Add(this.charCount_label);
            this.Controls.Add(this.title_synchro);
            this.Controls.Add(this.line_1);
            this.Controls.Add(this.title_available);
            this.Controls.Add(this.state_label);
            this.Name = "menu_chatOption";
            this.Size = new System.Drawing.Size(590, 546);
            this.Load += new System.EventHandler(this.menu_chatOption_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label state_label;
        private System.Windows.Forms.Label title_available;
        private System.Windows.Forms.Label line_1;
        private System.Windows.Forms.Label title_synchro;
        private System.Windows.Forms.Label charCount_label;
        private System.Windows.Forms.Label state_setChar;
        private System.Windows.Forms.Label line_2;
        private System.Windows.Forms.Label title_backup;
        private System.Windows.Forms.LinkLabel backup_pc;
        private System.Windows.Forms.LinkLabel apply_pc;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.LinkLabel open_lostark;
    }
}
