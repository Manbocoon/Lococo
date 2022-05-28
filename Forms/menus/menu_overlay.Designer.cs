
namespace Lococo.Forms.menus
{
    partial class menu_overlay
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
            this.label_overlay = new System.Windows.Forms.Label();
            this.line_1 = new System.Windows.Forms.Label();
            this.exp_overlay = new System.Windows.Forms.Label();
            this.exp_relying = new System.Windows.Forms.Label();
            this.line_2 = new System.Windows.Forms.Label();
            this.label_relying = new System.Windows.Forms.Label();
            this.exp_opacity = new System.Windows.Forms.Label();
            this.label_opacity = new System.Windows.Forms.Label();
            this.opacity_value = new System.Windows.Forms.Label();
            this.opacity = new Lococo.Functions.UI.Slider();
            this.relying = new Lococo.Functions.UI.flatCheckBox();
            this.open_overlay = new Lococo.Functions.UI.flatCheckBox();
            this.SuspendLayout();
            // 
            // label_overlay
            // 
            this.label_overlay.BackColor = System.Drawing.Color.Transparent;
            this.label_overlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_overlay.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_overlay.ForeColor = System.Drawing.Color.White;
            this.label_overlay.Location = new System.Drawing.Point(15, 15);
            this.label_overlay.Name = "label_overlay";
            this.label_overlay.Size = new System.Drawing.Size(570, 35);
            this.label_overlay.TabIndex = 8;
            this.label_overlay.Text = "오버레이 표시";
            this.label_overlay.Click += new System.EventHandler(this.label_overlay_Click);
            // 
            // line_1
            // 
            this.line_1.AutoSize = true;
            this.line_1.BackColor = System.Drawing.Color.Transparent;
            this.line_1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_1.Location = new System.Drawing.Point(17, 102);
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
            this.exp_overlay.Size = new System.Drawing.Size(252, 17);
            this.exp_overlay.TabIndex = 39;
            this.exp_overlay.Text = "게임 도우미 UI를 화면에 오버레이합니다.";
            // 
            // exp_relying
            // 
            this.exp_relying.AutoSize = true;
            this.exp_relying.BackColor = System.Drawing.Color.Transparent;
            this.exp_relying.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_relying.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_relying.Location = new System.Drawing.Point(17, 190);
            this.exp_relying.Name = "exp_relying";
            this.exp_relying.Size = new System.Drawing.Size(283, 17);
            this.exp_relying.TabIndex = 43;
            this.exp_relying.Text = "게임이 켜져 있을 때만 오버레이를 표시합니다.";
            // 
            // line_2
            // 
            this.line_2.AutoSize = true;
            this.line_2.BackColor = System.Drawing.Color.Transparent;
            this.line_2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_2.Location = new System.Drawing.Point(17, 237);
            this.line_2.Name = "line_2";
            this.line_2.Size = new System.Drawing.Size(568, 17);
            this.line_2.TabIndex = 42;
            this.line_2.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------";
            // 
            // label_relying
            // 
            this.label_relying.BackColor = System.Drawing.Color.Transparent;
            this.label_relying.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_relying.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_relying.ForeColor = System.Drawing.Color.White;
            this.label_relying.Location = new System.Drawing.Point(15, 150);
            this.label_relying.Name = "label_relying";
            this.label_relying.Size = new System.Drawing.Size(570, 35);
            this.label_relying.TabIndex = 40;
            this.label_relying.Text = "게임 기반 실행";
            this.label_relying.Click += new System.EventHandler(this.label_relying_Click);
            // 
            // exp_opacity
            // 
            this.exp_opacity.AutoSize = true;
            this.exp_opacity.BackColor = System.Drawing.Color.Transparent;
            this.exp_opacity.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_opacity.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_opacity.Location = new System.Drawing.Point(17, 320);
            this.exp_opacity.Name = "exp_opacity";
            this.exp_opacity.Size = new System.Drawing.Size(265, 17);
            this.exp_opacity.TabIndex = 73;
            this.exp_opacity.Text = "게임 도우미 UI들의 불투명도를 설정합니다.";
            // 
            // label_opacity
            // 
            this.label_opacity.BackColor = System.Drawing.Color.Transparent;
            this.label_opacity.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_opacity.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_opacity.ForeColor = System.Drawing.Color.White;
            this.label_opacity.Location = new System.Drawing.Point(15, 278);
            this.label_opacity.Name = "label_opacity";
            this.label_opacity.Size = new System.Drawing.Size(95, 35);
            this.label_opacity.TabIndex = 71;
            this.label_opacity.Text = "불투명도";
            // 
            // opacity_value
            // 
            this.opacity_value.AutoSize = true;
            this.opacity_value.BackColor = System.Drawing.Color.Transparent;
            this.opacity_value.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.opacity_value.ForeColor = System.Drawing.Color.LightGray;
            this.opacity_value.Location = new System.Drawing.Point(533, 278);
            this.opacity_value.Name = "opacity_value";
            this.opacity_value.Size = new System.Drawing.Size(42, 21);
            this.opacity_value.TabIndex = 70;
            this.opacity_value.Text = "80%";
            // 
            // opacity
            // 
            this.opacity.BarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.opacity.BarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.opacity.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.opacity.Location = new System.Drawing.Point(113, 277);
            this.opacity.Max = 100;
            this.opacity.Min = 0;
            this.opacity.Name = "opacity";
            this.opacity.Size = new System.Drawing.Size(406, 25);
            this.opacity.SmallestChange = 1;
            this.opacity.TabIndex = 72;
            this.opacity.UseBox = true;
            this.opacity.Value = 80;
            this.opacity.ValueChanged += new System.EventHandler(this.opacity_ValueChanged);
            // 
            // relying
            // 
            this.relying.Cursor = System.Windows.Forms.Cursors.Hand;
            this.relying.Location = new System.Drawing.Point(555, 150);
            this.relying.Name = "relying";
            this.relying.Size = new System.Drawing.Size(29, 25);
            this.relying.TabIndex = 41;
            this.relying.Click += new System.EventHandler(this.relying_Click);
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
            // menu_overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.Controls.Add(this.exp_opacity);
            this.Controls.Add(this.opacity);
            this.Controls.Add(this.label_opacity);
            this.Controls.Add(this.opacity_value);
            this.Controls.Add(this.exp_relying);
            this.Controls.Add(this.line_2);
            this.Controls.Add(this.relying);
            this.Controls.Add(this.label_relying);
            this.Controls.Add(this.exp_overlay);
            this.Controls.Add(this.line_1);
            this.Controls.Add(this.open_overlay);
            this.Controls.Add(this.label_overlay);
            this.Name = "menu_overlay";
            this.Size = new System.Drawing.Size(630, 446);
            this.Load += new System.EventHandler(this.menu_browser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_overlay;
        private Functions.UI.flatCheckBox open_overlay;
        private System.Windows.Forms.Label line_1;
        private System.Windows.Forms.Label exp_overlay;
        private System.Windows.Forms.Label exp_relying;
        private System.Windows.Forms.Label line_2;
        private Functions.UI.flatCheckBox relying;
        private System.Windows.Forms.Label label_relying;
        private System.Windows.Forms.Label exp_opacity;
        private Functions.UI.Slider opacity;
        private System.Windows.Forms.Label label_opacity;
        private System.Windows.Forms.Label opacity_value;
    }
}
