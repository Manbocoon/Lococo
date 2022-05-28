
namespace Lococo.Forms.menus
{
    partial class menu_text
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
            this.label_map = new System.Windows.Forms.Label();
            this.line_1 = new System.Windows.Forms.Label();
            this.exp_overlay = new System.Windows.Forms.Label();
            this.label_URL = new System.Windows.Forms.Label();
            this.exp_URL = new System.Windows.Forms.Label();
            this.setFont = new System.Windows.Forms.Button();
            this.content = new System.Windows.Forms.TextBox();
            this.setFont_title = new System.Windows.Forms.Label();
            this.setBackColor_title = new System.Windows.Forms.Label();
            this.setForeColor_title = new System.Windows.Forms.Label();
            this.setForeColor = new Lococo.Functions.UI.ColorLabel();
            this.setTransparent_backColor = new Lococo.Functions.UI.flatCheckBox();
            this.setBackColor = new Lococo.Functions.UI.ColorLabel();
            this.open_overlay = new Lococo.Functions.UI.flatCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_map
            // 
            this.label_map.BackColor = System.Drawing.Color.Transparent;
            this.label_map.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_map.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_map.ForeColor = System.Drawing.Color.White;
            this.label_map.Location = new System.Drawing.Point(15, 15);
            this.label_map.Name = "label_map";
            this.label_map.Size = new System.Drawing.Size(570, 35);
            this.label_map.TabIndex = 8;
            this.label_map.Text = "오버레이 표시";
            this.label_map.Click += new System.EventHandler(this.label_map_Click);
            // 
            // line_1
            // 
            this.line_1.AutoSize = true;
            this.line_1.BackColor = System.Drawing.Color.Transparent;
            this.line_1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_1.Location = new System.Drawing.Point(17, 112);
            this.line_1.Name = "line_1";
            this.line_1.Size = new System.Drawing.Size(568, 17);
            this.line_1.TabIndex = 31;
            this.line_1.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------";
            // 
            // exp_overlay
            // 
            this.exp_overlay.AutoSize = true;
            this.exp_overlay.BackColor = System.Drawing.Color.Transparent;
            this.exp_overlay.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_overlay.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_overlay.Location = new System.Drawing.Point(17, 55);
            this.exp_overlay.Name = "exp_overlay";
            this.exp_overlay.Size = new System.Drawing.Size(377, 17);
            this.exp_overlay.TabIndex = 39;
            this.exp_overlay.Text = "텍스트를 화면에 오버레이합니다. 전체 창모드를 사용해주세요.";
            // 
            // label_URL
            // 
            this.label_URL.BackColor = System.Drawing.Color.Transparent;
            this.label_URL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_URL.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_URL.ForeColor = System.Drawing.Color.White;
            this.label_URL.Location = new System.Drawing.Point(15, 155);
            this.label_URL.Name = "label_URL";
            this.label_URL.Size = new System.Drawing.Size(474, 35);
            this.label_URL.TabIndex = 40;
            this.label_URL.Text = "표시할 텍스트";
            // 
            // exp_URL
            // 
            this.exp_URL.AutoSize = true;
            this.exp_URL.BackColor = System.Drawing.Color.Transparent;
            this.exp_URL.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_URL.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_URL.Location = new System.Drawing.Point(17, 197);
            this.exp_URL.Name = "exp_URL";
            this.exp_URL.Size = new System.Drawing.Size(291, 17);
            this.exp_URL.TabIndex = 41;
            this.exp_URL.Text = "오버레이에 표시할 텍스트와 효과를 설정합니다.";
            // 
            // setFont
            // 
            this.setFont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setFont.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.setFont.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.setFont.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.setFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setFont.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.setFont.ForeColor = System.Drawing.Color.LightGray;
            this.setFont.Location = new System.Drawing.Point(367, 550);
            this.setFont.Name = "setFont";
            this.setFont.Size = new System.Drawing.Size(96, 30);
            this.setFont.TabIndex = 45;
            this.setFont.Text = "변경";
            this.setFont.UseVisualStyleBackColor = true;
            this.setFont.Click += new System.EventHandler(this.setFont_Click);
            // 
            // content
            // 
            this.content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.content.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.content.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.content.ForeColor = System.Drawing.Color.LightGray;
            this.content.Location = new System.Drawing.Point(20, 242);
            this.content.MaxLength = 99999;
            this.content.Multiline = true;
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(564, 97);
            this.content.TabIndex = 46;
            this.content.Text = "텍스트 오버레이 예시입니다.\r\n어때요? 후기좀.\r\n괜찮습니까?";
            // 
            // setFont_title
            // 
            this.setFont_title.AutoSize = true;
            this.setFont_title.BackColor = System.Drawing.Color.Transparent;
            this.setFont_title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setFont_title.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.setFont_title.ForeColor = System.Drawing.Color.White;
            this.setFont_title.Location = new System.Drawing.Point(20, 556);
            this.setFont_title.Name = "setFont_title";
            this.setFont_title.Size = new System.Drawing.Size(202, 15);
            this.setFont_title.TabIndex = 48;
            this.setFont_title.Text = "폰트        ▷  맑은 고딕, 10pt, Bold";
            // 
            // setBackColor_title
            // 
            this.setBackColor_title.AutoSize = true;
            this.setBackColor_title.BackColor = System.Drawing.Color.Transparent;
            this.setBackColor_title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setBackColor_title.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.setBackColor_title.ForeColor = System.Drawing.Color.White;
            this.setBackColor_title.Location = new System.Drawing.Point(20, 496);
            this.setBackColor_title.Name = "setBackColor_title";
            this.setBackColor_title.Size = new System.Drawing.Size(75, 15);
            this.setBackColor_title.TabIndex = 49;
            this.setBackColor_title.Text = "배경 색상 ▷";
            // 
            // setForeColor_title
            // 
            this.setForeColor_title.AutoSize = true;
            this.setForeColor_title.BackColor = System.Drawing.Color.Transparent;
            this.setForeColor_title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setForeColor_title.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.setForeColor_title.ForeColor = System.Drawing.Color.White;
            this.setForeColor_title.Location = new System.Drawing.Point(20, 589);
            this.setForeColor_title.Name = "setForeColor_title";
            this.setForeColor_title.Size = new System.Drawing.Size(75, 15);
            this.setForeColor_title.TabIndex = 50;
            this.setForeColor_title.Text = "글자 색상 ▷";
            // 
            // setForeColor
            // 
            this.setForeColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setForeColor.ForeColor = System.Drawing.Color.LightGray;
            this.setForeColor.Location = new System.Drawing.Point(365, 585);
            this.setForeColor.Name = "setForeColor";
            this.setForeColor.Size = new System.Drawing.Size(96, 30);
            this.setForeColor.TabIndex = 52;
            this.setForeColor.Text = "#000000";
            // 
            // setTransparent_backColor
            // 
            this.setTransparent_backColor.Checked = true;
            this.setTransparent_backColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.setTransparent_backColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setTransparent_backColor.ForeColor = System.Drawing.Color.LightGray;
            this.setTransparent_backColor.Location = new System.Drawing.Point(490, 490);
            this.setTransparent_backColor.Name = "setTransparent_backColor";
            this.setTransparent_backColor.Size = new System.Drawing.Size(94, 30);
            this.setTransparent_backColor.TabIndex = 51;
            this.setTransparent_backColor.Text = "투명화";
            this.setTransparent_backColor.UseVisualStyleBackColor = true;
            // 
            // setBackColor
            // 
            this.setBackColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setBackColor.ForeColor = System.Drawing.Color.LightGray;
            this.setBackColor.Location = new System.Drawing.Point(365, 491);
            this.setBackColor.Name = "setBackColor";
            this.setBackColor.Size = new System.Drawing.Size(96, 30);
            this.setBackColor.TabIndex = 47;
            this.setBackColor.Text = "#000000";
            // 
            // open_overlay
            // 
            this.open_overlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.open_overlay.Location = new System.Drawing.Point(555, 15);
            this.open_overlay.Name = "open_overlay";
            this.open_overlay.Size = new System.Drawing.Size(29, 25);
            this.open_overlay.TabIndex = 17;
            this.open_overlay.Click += new System.EventHandler(this.open_overlay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(20, 449);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 17);
            this.label1.TabIndex = 54;
            this.label1.Text = "텍스트의 스타일을 설정하고 관리합니다.";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(474, 35);
            this.label2.TabIndex = 53;
            this.label2.Text = "스타일팩";
            // 
            // menu_text
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.setForeColor);
            this.Controls.Add(this.setTransparent_backColor);
            this.Controls.Add(this.setForeColor_title);
            this.Controls.Add(this.setBackColor_title);
            this.Controls.Add(this.setFont_title);
            this.Controls.Add(this.setBackColor);
            this.Controls.Add(this.content);
            this.Controls.Add(this.setFont);
            this.Controls.Add(this.exp_URL);
            this.Controls.Add(this.label_URL);
            this.Controls.Add(this.exp_overlay);
            this.Controls.Add(this.line_1);
            this.Controls.Add(this.open_overlay);
            this.Controls.Add(this.label_map);
            this.Name = "menu_text";
            this.Size = new System.Drawing.Size(630, 800);
            this.Load += new System.EventHandler(this.menu_browser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_map;
        private Functions.UI.flatCheckBox open_overlay;
        private System.Windows.Forms.Label line_1;
        private System.Windows.Forms.Label exp_overlay;
        private System.Windows.Forms.Label label_URL;
        private System.Windows.Forms.Label exp_URL;
        private System.Windows.Forms.Button setFont;
        private System.Windows.Forms.TextBox content;
        private Functions.UI.ColorLabel setBackColor;
        private System.Windows.Forms.Label setFont_title;
        private System.Windows.Forms.Label setBackColor_title;
        private System.Windows.Forms.Label setForeColor_title;
        private Functions.UI.flatCheckBox setTransparent_backColor;
        private Functions.UI.ColorLabel setForeColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
