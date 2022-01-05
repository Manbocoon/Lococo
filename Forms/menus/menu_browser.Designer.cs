
namespace Lococo.Forms.menus
{
    partial class menu_browser
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
            this.opacity_label = new System.Windows.Forms.Label();
            this.label_map = new System.Windows.Forms.Label();
            this.line_1 = new System.Windows.Forms.Label();
            this.line_2 = new System.Windows.Forms.Label();
            this.line_3 = new System.Windows.Forms.Label();
            this.exp_map = new System.Windows.Forms.Label();
            this.exp_URL = new System.Windows.Forms.Label();
            this.label_URL = new System.Windows.Forms.Label();
            this.URL_map = new System.Windows.Forms.Button();
            this.URL_bingpago = new System.Windows.Forms.Button();
            this.URL_youtube = new System.Windows.Forms.Button();
            this.URL_input = new System.Windows.Forms.Button();
            this.map_URL = new System.Windows.Forms.TextBox();
            this.label_opacity = new System.Windows.Forms.Label();
            this.exp_ignore = new System.Windows.Forms.Label();
            this.label_ignore = new System.Windows.Forms.Label();
            this.line_4 = new System.Windows.Forms.Label();
            this.label_sources = new System.Windows.Forms.Label();
            this.exp_sources = new System.Windows.Forms.Label();
            this.map_ignore = new Lococo.Functions.UI.flatCheckBox();
            this.map = new Lococo.Functions.UI.flatCheckBox();
            this.opacity = new MetroFramework.Controls.MetroTrackBar();
            this.SuspendLayout();
            // 
            // opacity_label
            // 
            this.opacity_label.AutoSize = true;
            this.opacity_label.BackColor = System.Drawing.Color.Transparent;
            this.opacity_label.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.opacity_label.ForeColor = System.Drawing.Color.LightGray;
            this.opacity_label.Location = new System.Drawing.Point(540, 385);
            this.opacity_label.Name = "opacity_label";
            this.opacity_label.Size = new System.Drawing.Size(42, 21);
            this.opacity_label.TabIndex = 5;
            this.opacity_label.Text = "80%";
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
            // line_2
            // 
            this.line_2.AutoSize = true;
            this.line_2.BackColor = System.Drawing.Color.Transparent;
            this.line_2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_2.Location = new System.Drawing.Point(17, 340);
            this.line_2.Name = "line_2";
            this.line_2.Size = new System.Drawing.Size(568, 17);
            this.line_2.TabIndex = 35;
            this.line_2.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------";
            // 
            // line_3
            // 
            this.line_3.AutoSize = true;
            this.line_3.BackColor = System.Drawing.Color.Transparent;
            this.line_3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_3.Location = new System.Drawing.Point(18, 434);
            this.line_3.Name = "line_3";
            this.line_3.Size = new System.Drawing.Size(568, 17);
            this.line_3.TabIndex = 36;
            this.line_3.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------";
            // 
            // exp_map
            // 
            this.exp_map.AutoSize = true;
            this.exp_map.BackColor = System.Drawing.Color.Transparent;
            this.exp_map.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_map.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_map.Location = new System.Drawing.Point(17, 55);
            this.exp_map.Name = "exp_map";
            this.exp_map.Size = new System.Drawing.Size(486, 34);
            this.exp_map.TabIndex = 39;
            this.exp_map.Text = "Microsoft Edge 브라우저를 화면에 오버레이합니다. 전체 창모드를 사용해주세요.\r\n사용법은 일반적인 브라우저와 동일합니다.";
            // 
            // exp_URL
            // 
            this.exp_URL.AutoSize = true;
            this.exp_URL.BackColor = System.Drawing.Color.Transparent;
            this.exp_URL.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_URL.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_URL.Location = new System.Drawing.Point(17, 197);
            this.exp_URL.Name = "exp_URL";
            this.exp_URL.Size = new System.Drawing.Size(446, 34);
            this.exp_URL.TabIndex = 41;
            this.exp_URL.Text = "브라우저에 표시할 웹 컨텐츠를 변경합니다. URL을 직접 입력해도 됩니다.\r\n모험의 서 이용 시 ← → 키보드 방향키를 이용해 맵을 변경할 수 있" +
    "습니다.";
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
            this.label_URL.Text = "표시할 링크";
            // 
            // URL_map
            // 
            this.URL_map.Cursor = System.Windows.Forms.Cursors.Hand;
            this.URL_map.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.URL_map.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.URL_map.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.URL_map.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.URL_map.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.URL_map.ForeColor = System.Drawing.Color.LightGray;
            this.URL_map.Location = new System.Drawing.Point(20, 273);
            this.URL_map.Name = "URL_map";
            this.URL_map.Size = new System.Drawing.Size(90, 40);
            this.URL_map.TabIndex = 42;
            this.URL_map.Text = "모험의 서";
            this.URL_map.UseVisualStyleBackColor = true;
            this.URL_map.Click += new System.EventHandler(this.URL_map_Click);
            // 
            // URL_bingpago
            // 
            this.URL_bingpago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.URL_bingpago.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.URL_bingpago.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.URL_bingpago.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.URL_bingpago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.URL_bingpago.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.URL_bingpago.ForeColor = System.Drawing.Color.LightGray;
            this.URL_bingpago.Location = new System.Drawing.Point(125, 273);
            this.URL_bingpago.Name = "URL_bingpago";
            this.URL_bingpago.Size = new System.Drawing.Size(90, 40);
            this.URL_bingpago.TabIndex = 43;
            this.URL_bingpago.Text = "빙파고";
            this.URL_bingpago.UseVisualStyleBackColor = true;
            this.URL_bingpago.Click += new System.EventHandler(this.URL_bingpago_Click);
            // 
            // URL_youtube
            // 
            this.URL_youtube.Cursor = System.Windows.Forms.Cursors.Hand;
            this.URL_youtube.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.URL_youtube.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.URL_youtube.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.URL_youtube.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.URL_youtube.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.URL_youtube.ForeColor = System.Drawing.Color.LightGray;
            this.URL_youtube.Location = new System.Drawing.Point(230, 273);
            this.URL_youtube.Name = "URL_youtube";
            this.URL_youtube.Size = new System.Drawing.Size(90, 40);
            this.URL_youtube.TabIndex = 44;
            this.URL_youtube.Text = "유튜브";
            this.URL_youtube.UseVisualStyleBackColor = true;
            this.URL_youtube.Click += new System.EventHandler(this.URL_youtube_Click);
            // 
            // URL_input
            // 
            this.URL_input.Cursor = System.Windows.Forms.Cursors.Hand;
            this.URL_input.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.URL_input.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.URL_input.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.URL_input.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.URL_input.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.URL_input.ForeColor = System.Drawing.Color.LightGray;
            this.URL_input.Location = new System.Drawing.Point(399, 273);
            this.URL_input.Name = "URL_input";
            this.URL_input.Size = new System.Drawing.Size(90, 40);
            this.URL_input.TabIndex = 45;
            this.URL_input.Text = "직접 입력";
            this.URL_input.UseVisualStyleBackColor = true;
            this.URL_input.Click += new System.EventHandler(this.URL_input_Click);
            // 
            // map_URL
            // 
            this.map_URL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.map_URL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.map_URL.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.map_URL.ForeColor = System.Drawing.Color.LightGray;
            this.map_URL.Location = new System.Drawing.Point(139, 157);
            this.map_URL.MaxLength = 30;
            this.map_URL.Name = "map_URL";
            this.map_URL.Size = new System.Drawing.Size(295, 25);
            this.map_URL.TabIndex = 46;
            this.map_URL.Text = "https://lostark.inven.co.kr/dataninfo/world/?code=10201";
            this.map_URL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.map_URL.Visible = false;
            // 
            // label_opacity
            // 
            this.label_opacity.BackColor = System.Drawing.Color.Transparent;
            this.label_opacity.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_opacity.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_opacity.ForeColor = System.Drawing.Color.White;
            this.label_opacity.Location = new System.Drawing.Point(15, 385);
            this.label_opacity.Name = "label_opacity";
            this.label_opacity.Size = new System.Drawing.Size(95, 35);
            this.label_opacity.TabIndex = 47;
            this.label_opacity.Text = "불투명도";
            // 
            // exp_ignore
            // 
            this.exp_ignore.AutoSize = true;
            this.exp_ignore.BackColor = System.Drawing.Color.Transparent;
            this.exp_ignore.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_ignore.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_ignore.Location = new System.Drawing.Point(18, 519);
            this.exp_ignore.Name = "exp_ignore";
            this.exp_ignore.Size = new System.Drawing.Size(389, 34);
            this.exp_ignore.TabIndex = 52;
            this.exp_ignore.Text = "브라우저를 조작할 수 없도록 설정합니다.\r\n이 설정을 하면 화면에 브라우저가 보이지만 클릭할 수 없습니다.";
            // 
            // label_ignore
            // 
            this.label_ignore.BackColor = System.Drawing.Color.Transparent;
            this.label_ignore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_ignore.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_ignore.ForeColor = System.Drawing.Color.White;
            this.label_ignore.Location = new System.Drawing.Point(16, 479);
            this.label_ignore.Name = "label_ignore";
            this.label_ignore.Size = new System.Drawing.Size(570, 35);
            this.label_ignore.TabIndex = 51;
            this.label_ignore.Text = "클릭 불가";
            this.label_ignore.Click += new System.EventHandler(this.label_ignore_Click);
            // 
            // line_4
            // 
            this.line_4.AutoSize = true;
            this.line_4.BackColor = System.Drawing.Color.Transparent;
            this.line_4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_4.Location = new System.Drawing.Point(18, 579);
            this.line_4.Name = "line_4";
            this.line_4.Size = new System.Drawing.Size(568, 17);
            this.line_4.TabIndex = 37;
            this.line_4.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------";
            // 
            // label_sources
            // 
            this.label_sources.BackColor = System.Drawing.Color.Transparent;
            this.label_sources.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_sources.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_sources.ForeColor = System.Drawing.Color.White;
            this.label_sources.Location = new System.Drawing.Point(15, 624);
            this.label_sources.Name = "label_sources";
            this.label_sources.Size = new System.Drawing.Size(570, 35);
            this.label_sources.TabIndex = 54;
            this.label_sources.Text = "출처";
            // 
            // exp_sources
            // 
            this.exp_sources.AutoSize = true;
            this.exp_sources.BackColor = System.Drawing.Color.Transparent;
            this.exp_sources.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_sources.ForeColor = System.Drawing.Color.Silver;
            this.exp_sources.Location = new System.Drawing.Point(17, 664);
            this.exp_sources.Name = "exp_sources";
            this.exp_sources.Size = new System.Drawing.Size(198, 34);
            this.exp_sources.TabIndex = 55;
            this.exp_sources.Text = "모험의 서  →  로스트아크 인벤\r\n빙파고  →  github.com/ialy1595";
            // 
            // map_ignore
            // 
            this.map_ignore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.map_ignore.Location = new System.Drawing.Point(556, 479);
            this.map_ignore.Name = "map_ignore";
            this.map_ignore.Size = new System.Drawing.Size(29, 25);
            this.map_ignore.TabIndex = 53;
            this.map_ignore.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.map_ignore.Click += new System.EventHandler(this.map_ignore_Click);
            // 
            // map
            // 
            this.map.Cursor = System.Windows.Forms.Cursors.Hand;
            this.map.Location = new System.Drawing.Point(555, 15);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(29, 25);
            this.map.TabIndex = 17;
            this.map.Click += new System.EventHandler(this.map_Click);
            // 
            // opacity
            // 
            this.opacity.BackColor = System.Drawing.Color.Transparent;
            this.opacity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.opacity.Location = new System.Drawing.Point(125, 385);
            this.opacity.Minimum = 10;
            this.opacity.Name = "opacity";
            this.opacity.Size = new System.Drawing.Size(400, 23);
            this.opacity.TabIndex = 56;
            this.opacity.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.opacity.Value = 75;
            this.opacity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.opacity_Scroll);
            // 
            // menu_browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.Controls.Add(this.opacity);
            this.Controls.Add(this.exp_sources);
            this.Controls.Add(this.label_sources);
            this.Controls.Add(this.map_ignore);
            this.Controls.Add(this.exp_ignore);
            this.Controls.Add(this.label_ignore);
            this.Controls.Add(this.label_opacity);
            this.Controls.Add(this.map_URL);
            this.Controls.Add(this.URL_input);
            this.Controls.Add(this.URL_youtube);
            this.Controls.Add(this.URL_bingpago);
            this.Controls.Add(this.URL_map);
            this.Controls.Add(this.exp_URL);
            this.Controls.Add(this.label_URL);
            this.Controls.Add(this.exp_map);
            this.Controls.Add(this.line_4);
            this.Controls.Add(this.line_3);
            this.Controls.Add(this.line_2);
            this.Controls.Add(this.line_1);
            this.Controls.Add(this.map);
            this.Controls.Add(this.label_map);
            this.Controls.Add(this.opacity_label);
            this.Name = "menu_browser";
            this.Size = new System.Drawing.Size(630, 800);
            this.Load += new System.EventHandler(this.menu_browser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label opacity_label;
        private System.Windows.Forms.Label label_map;
        private Functions.UI.flatCheckBox map;
        private System.Windows.Forms.Label line_1;
        private System.Windows.Forms.Label line_2;
        private System.Windows.Forms.Label line_3;
        private System.Windows.Forms.Label exp_map;
        private System.Windows.Forms.Label exp_URL;
        private System.Windows.Forms.Label label_URL;
        private System.Windows.Forms.Button URL_map;
        private System.Windows.Forms.Button URL_bingpago;
        private System.Windows.Forms.Button URL_youtube;
        private System.Windows.Forms.Button URL_input;
        private System.Windows.Forms.TextBox map_URL;
        private System.Windows.Forms.Label label_opacity;
        private System.Windows.Forms.Label exp_ignore;
        private System.Windows.Forms.Label label_ignore;
        private Functions.UI.flatCheckBox map_ignore;
        private System.Windows.Forms.Label line_4;
        private System.Windows.Forms.Label label_sources;
        private System.Windows.Forms.Label exp_sources;
        private MetroFramework.Controls.MetroTrackBar opacity;
    }
}
