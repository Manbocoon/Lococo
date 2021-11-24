
namespace Lococo.Forms.menus
{
    partial class menu_mococo
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
            this.components = new System.ComponentModel.Container();
            this.label_mapTran = new System.Windows.Forms.Label();
            this.scrollBar_point = new System.Windows.Forms.PictureBox();
            this.scrollBar_back = new System.Windows.Forms.PictureBox();
            this.label_map = new System.Windows.Forms.Label();
            this.label_mapIgnore = new System.Windows.Forms.Label();
            this.label_mapURL = new System.Windows.Forms.Label();
            this.label_mapDual = new System.Windows.Forms.Label();
            this.line_label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.map_resetURL = new System.Windows.Forms.Button();
            this.map_applyURL = new System.Windows.Forms.Button();
            this.map_URL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.help_key = new System.Windows.Forms.Label();
            this.map_dualMonitor = new Lococo.Functions.UI.flatCheckBox();
            this.map_ignore = new Lococo.Functions.UI.flatCheckBox();
            this.map = new Lococo.Functions.UI.flatCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.scrollBar_point)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollBar_back)).BeginInit();
            this.SuspendLayout();
            // 
            // label_mapTran
            // 
            this.label_mapTran.BackColor = System.Drawing.Color.Transparent;
            this.label_mapTran.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_mapTran.ForeColor = System.Drawing.Color.LightGray;
            this.label_mapTran.Location = new System.Drawing.Point(16, 219);
            this.label_mapTran.Name = "label_mapTran";
            this.label_mapTran.Size = new System.Drawing.Size(476, 56);
            this.label_mapTran.TabIndex = 5;
            this.label_mapTran.Text = "불투명도";
            // 
            // scrollBar_point
            // 
            this.scrollBar_point.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.scrollBar_point.Location = new System.Drawing.Point(271, 216);
            this.scrollBar_point.Name = "scrollBar_point";
            this.scrollBar_point.Size = new System.Drawing.Size(100, 50);
            this.scrollBar_point.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.scrollBar_point.TabIndex = 7;
            this.scrollBar_point.TabStop = false;
            this.scrollBar_point.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollBar_point_MouseDown);
            this.scrollBar_point.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scrollBar_point_MouseMove);
            this.scrollBar_point.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollBar_point_MouseUp);
            // 
            // scrollBar_back
            // 
            this.scrollBar_back.Location = new System.Drawing.Point(256, 216);
            this.scrollBar_back.Name = "scrollBar_back";
            this.scrollBar_back.Size = new System.Drawing.Size(100, 50);
            this.scrollBar_back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.scrollBar_back.TabIndex = 6;
            this.scrollBar_back.TabStop = false;
            this.scrollBar_back.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollBar_back_MouseDown);
            this.scrollBar_back.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scrollBar_back_MouseMove);
            this.scrollBar_back.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollBar_back_MouseUp);
            // 
            // label_map
            // 
            this.label_map.BackColor = System.Drawing.Color.Transparent;
            this.label_map.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_map.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_map.ForeColor = System.Drawing.Color.White;
            this.label_map.Location = new System.Drawing.Point(15, 15);
            this.label_map.Name = "label_map";
            this.label_map.Size = new System.Drawing.Size(474, 50);
            this.label_map.TabIndex = 8;
            this.label_map.Text = "표시";
            this.label_map.Click += new System.EventHandler(this.label_map_Click);
            // 
            // label_mapIgnore
            // 
            this.label_mapIgnore.BackColor = System.Drawing.Color.Transparent;
            this.label_mapIgnore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_mapIgnore.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_mapIgnore.ForeColor = System.Drawing.Color.LightGray;
            this.label_mapIgnore.Location = new System.Drawing.Point(18, 310);
            this.label_mapIgnore.Name = "label_mapIgnore";
            this.label_mapIgnore.Size = new System.Drawing.Size(474, 63);
            this.label_mapIgnore.TabIndex = 9;
            this.label_mapIgnore.Text = "클릭 불가";
            this.label_mapIgnore.Click += new System.EventHandler(this.label_mapIgnore_Click);
            // 
            // label_mapURL
            // 
            this.label_mapURL.BackColor = System.Drawing.Color.Transparent;
            this.label_mapURL.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_mapURL.ForeColor = System.Drawing.Color.LightGray;
            this.label_mapURL.Location = new System.Drawing.Point(16, 99);
            this.label_mapURL.Name = "label_mapURL";
            this.label_mapURL.Size = new System.Drawing.Size(472, 94);
            this.label_mapURL.TabIndex = 11;
            this.label_mapURL.Text = "링크";
            // 
            // label_mapDual
            // 
            this.label_mapDual.BackColor = System.Drawing.Color.Transparent;
            this.label_mapDual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_mapDual.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_mapDual.ForeColor = System.Drawing.Color.LightGray;
            this.label_mapDual.Location = new System.Drawing.Point(19, 397);
            this.label_mapDual.Name = "label_mapDual";
            this.label_mapDual.Size = new System.Drawing.Size(473, 63);
            this.label_mapDual.TabIndex = 14;
            this.label_mapDual.Text = "보조 모니터에 표시";
            this.label_mapDual.Click += new System.EventHandler(this.label_mapDual_Click);
            // 
            // line_label1
            // 
            this.line_label1.AutoSize = true;
            this.line_label1.BackColor = System.Drawing.Color.Transparent;
            this.line_label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_label1.Location = new System.Drawing.Point(16, 68);
            this.line_label1.Name = "line_label1";
            this.line_label1.Size = new System.Drawing.Size(493, 17);
            this.line_label1.TabIndex = 31;
            this.line_label1.Text = "---------------------------------------------------------------------------------" +
    "----------------";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 200;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // map_resetURL
            // 
            this.map_resetURL.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.map_resetURL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.map_resetURL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.map_resetURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.map_resetURL.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.map_resetURL.ForeColor = System.Drawing.Color.LightGray;
            this.map_resetURL.Location = new System.Drawing.Point(408, 161);
            this.map_resetURL.Name = "map_resetURL";
            this.map_resetURL.Size = new System.Drawing.Size(77, 25);
            this.map_resetURL.TabIndex = 34;
            this.map_resetURL.Text = "기본값";
            this.map_resetURL.UseVisualStyleBackColor = true;
            this.map_resetURL.Click += new System.EventHandler(this.map_resetURL_Click);
            // 
            // map_applyURL
            // 
            this.map_applyURL.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.map_applyURL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.map_applyURL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.map_applyURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.map_applyURL.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.map_applyURL.ForeColor = System.Drawing.Color.LightGray;
            this.map_applyURL.Location = new System.Drawing.Point(408, 130);
            this.map_applyURL.Name = "map_applyURL";
            this.map_applyURL.Size = new System.Drawing.Size(77, 25);
            this.map_applyURL.TabIndex = 33;
            this.map_applyURL.Text = "적용";
            this.map_applyURL.UseVisualStyleBackColor = true;
            this.map_applyURL.Click += new System.EventHandler(this.map_applyURL_Click);
            // 
            // map_URL
            // 
            this.map_URL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.map_URL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.map_URL.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.map_URL.ForeColor = System.Drawing.Color.LightGray;
            this.map_URL.Location = new System.Drawing.Point(212, 99);
            this.map_URL.Name = "map_URL";
            this.map_URL.Size = new System.Drawing.Size(274, 25);
            this.map_URL.TabIndex = 32;
            this.map_URL.Text = "https://lostark.inven.co.kr/dataninfo/world/?code=10201";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(16, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "----------------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(17, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(493, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "----------------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(17, 373);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(493, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "---------------------------------------------------------------------------------" +
    "----------------";
            // 
            // help_key
            // 
            this.help_key.BackColor = System.Drawing.Color.Transparent;
            this.help_key.Cursor = System.Windows.Forms.Cursors.Default;
            this.help_key.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.help_key.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(81)))), ((int)(((byte)(36)))));
            this.help_key.Location = new System.Drawing.Point(19, 479);
            this.help_key.Name = "help_key";
            this.help_key.Size = new System.Drawing.Size(473, 63);
            this.help_key.TabIndex = 38;
            this.help_key.Text = "단축키: ← →";
            // 
            // map_dualMonitor
            // 
            this.map_dualMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.map_dualMonitor.Location = new System.Drawing.Point(461, 397);
            this.map_dualMonitor.Name = "map_dualMonitor";
            this.map_dualMonitor.Size = new System.Drawing.Size(30, 25);
            this.map_dualMonitor.TabIndex = 20;
            // 
            // map_ignore
            // 
            this.map_ignore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.map_ignore.Location = new System.Drawing.Point(460, 310);
            this.map_ignore.Name = "map_ignore";
            this.map_ignore.Size = new System.Drawing.Size(29, 25);
            this.map_ignore.TabIndex = 18;
            this.map_ignore.Click += new System.EventHandler(this.map_ignore_Click);
            // 
            // map
            // 
            this.map.Cursor = System.Windows.Forms.Cursors.Hand;
            this.map.Location = new System.Drawing.Point(457, 12);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(29, 25);
            this.map.TabIndex = 17;
            this.map.Click += new System.EventHandler(this.map_Click);
            // 
            // menu_mococo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.Controls.Add(this.help_key);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.map_resetURL);
            this.Controls.Add(this.map_applyURL);
            this.Controls.Add(this.map_URL);
            this.Controls.Add(this.line_label1);
            this.Controls.Add(this.map_dualMonitor);
            this.Controls.Add(this.map_ignore);
            this.Controls.Add(this.map);
            this.Controls.Add(this.label_mapDual);
            this.Controls.Add(this.label_mapURL);
            this.Controls.Add(this.label_mapIgnore);
            this.Controls.Add(this.label_map);
            this.Controls.Add(this.scrollBar_point);
            this.Controls.Add(this.scrollBar_back);
            this.Controls.Add(this.label_mapTran);
            this.Name = "menu_mococo";
            this.Size = new System.Drawing.Size(708, 692);
            this.Load += new System.EventHandler(this.menu_mococo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scrollBar_point)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollBar_back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_mapTran;
        private System.Windows.Forms.PictureBox scrollBar_point;
        private System.Windows.Forms.PictureBox scrollBar_back;
        private System.Windows.Forms.Label label_map;
        private System.Windows.Forms.Label label_mapIgnore;
        private System.Windows.Forms.Label label_mapURL;
        private System.Windows.Forms.Label label_mapDual;
        private Functions.UI.flatCheckBox map;
        private Functions.UI.flatCheckBox map_ignore;
        private Functions.UI.flatCheckBox map_dualMonitor;
        private System.Windows.Forms.Label line_label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button map_resetURL;
        private System.Windows.Forms.Button map_applyURL;
        private System.Windows.Forms.TextBox map_URL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label help_key;
    }
}
