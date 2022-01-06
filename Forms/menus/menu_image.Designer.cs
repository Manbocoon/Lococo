
namespace Lococo.Forms.menus
{
    partial class menu_image
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
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.browse_file = new System.Windows.Forms.Button();
            this.file_path = new System.Windows.Forms.TextBox();
            this.exp_image = new System.Windows.Forms.Label();
            this.line_1 = new System.Windows.Forms.Label();
            this.label_image = new System.Windows.Forms.Label();
            this.exp_file = new System.Windows.Forms.Label();
            this.label_file = new System.Windows.Forms.Label();
            this.line_2 = new System.Windows.Forms.Label();
            this.opacity = new MetroFramework.Controls.MetroTrackBar();
            this.opacity_label = new System.Windows.Forms.Label();
            this.label_opacity = new System.Windows.Forms.Label();
            this.line_3 = new System.Windows.Forms.Label();
            this.exp_ignore = new System.Windows.Forms.Label();
            this.label_ignore = new System.Windows.Forms.Label();
            this.label_width = new System.Windows.Forms.Label();
            this.width = new MetroFramework.Controls.MetroTrackBar();
            this.width_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.height = new MetroFramework.Controls.MetroTrackBar();
            this.height_label = new System.Windows.Forms.Label();
            this.update_file = new System.Windows.Forms.Button();
            this.label_imgSize = new System.Windows.Forms.Label();
            this.ignore = new Lococo.Functions.UI.flatCheckBox();
            this.image = new Lococo.Functions.UI.flatCheckBox();
            this.SuspendLayout();
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openFileDialog1";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 200;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // browse_file
            // 
            this.browse_file.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.browse_file.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.browse_file.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.browse_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browse_file.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.browse_file.ForeColor = System.Drawing.Color.LightGray;
            this.browse_file.Location = new System.Drawing.Point(455, 250);
            this.browse_file.Name = "browse_file";
            this.browse_file.Size = new System.Drawing.Size(77, 25);
            this.browse_file.TabIndex = 29;
            this.browse_file.Text = "찾아보기";
            this.browse_file.UseVisualStyleBackColor = true;
            this.browse_file.Click += new System.EventHandler(this.browse_file_Click);
            // 
            // file_path
            // 
            this.file_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.file_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.file_path.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.file_path.ForeColor = System.Drawing.Color.LightGray;
            this.file_path.Location = new System.Drawing.Point(20, 250);
            this.file_path.Name = "file_path";
            this.file_path.Size = new System.Drawing.Size(425, 25);
            this.file_path.TabIndex = 27;
            // 
            // exp_image
            // 
            this.exp_image.AutoSize = true;
            this.exp_image.BackColor = System.Drawing.Color.Transparent;
            this.exp_image.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_image.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_image.Location = new System.Drawing.Point(17, 55);
            this.exp_image.Name = "exp_image";
            this.exp_image.Size = new System.Drawing.Size(415, 34);
            this.exp_image.TabIndex = 42;
            this.exp_image.Text = "특정 이미지를 화면에 오버레이합니다. 전체 창모드를 사용해주세요.\r\n이미지의 투명하지 않은 부분을 드래그하여 위치를 옮길 수 있습니다.";
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
            this.line_1.TabIndex = 41;
            this.line_1.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------";
            // 
            // label_image
            // 
            this.label_image.BackColor = System.Drawing.Color.Transparent;
            this.label_image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_image.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_image.ForeColor = System.Drawing.Color.White;
            this.label_image.Location = new System.Drawing.Point(15, 15);
            this.label_image.Name = "label_image";
            this.label_image.Size = new System.Drawing.Size(570, 35);
            this.label_image.TabIndex = 40;
            this.label_image.Text = "오버레이 표시";
            this.label_image.Click += new System.EventHandler(this.label_image_Click);
            // 
            // exp_file
            // 
            this.exp_file.AutoSize = true;
            this.exp_file.BackColor = System.Drawing.Color.Transparent;
            this.exp_file.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_file.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_file.Location = new System.Drawing.Point(17, 197);
            this.exp_file.Name = "exp_file";
            this.exp_file.Size = new System.Drawing.Size(386, 34);
            this.exp_file.TabIndex = 45;
            this.exp_file.Text = "오버레이에 표시할 이미지를 변경합니다.\r\nPC에 있는 이미지의 경로를 입력하거나 직접 파일을 선택합니다.";
            // 
            // label_file
            // 
            this.label_file.BackColor = System.Drawing.Color.Transparent;
            this.label_file.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_file.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_file.ForeColor = System.Drawing.Color.White;
            this.label_file.Location = new System.Drawing.Point(15, 155);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(474, 35);
            this.label_file.TabIndex = 44;
            this.label_file.Text = "표시할 이미지";
            // 
            // line_2
            // 
            this.line_2.AutoSize = true;
            this.line_2.BackColor = System.Drawing.Color.Transparent;
            this.line_2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_2.Location = new System.Drawing.Point(17, 305);
            this.line_2.Name = "line_2";
            this.line_2.Size = new System.Drawing.Size(568, 17);
            this.line_2.TabIndex = 46;
            this.line_2.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------";
            // 
            // opacity
            // 
            this.opacity.BackColor = System.Drawing.Color.Transparent;
            this.opacity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.opacity.Location = new System.Drawing.Point(130, 346);
            this.opacity.Minimum = 10;
            this.opacity.Name = "opacity";
            this.opacity.Size = new System.Drawing.Size(400, 23);
            this.opacity.TabIndex = 58;
            this.opacity.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.opacity.Value = 75;
            this.opacity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.opacity_KeyUp);
            this.opacity.MouseUp += new System.Windows.Forms.MouseEventHandler(this.opacity_MouseUp);
            // 
            // opacity_label
            // 
            this.opacity_label.AutoSize = true;
            this.opacity_label.BackColor = System.Drawing.Color.Transparent;
            this.opacity_label.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.opacity_label.ForeColor = System.Drawing.Color.LightGray;
            this.opacity_label.Location = new System.Drawing.Point(540, 346);
            this.opacity_label.Name = "opacity_label";
            this.opacity_label.Size = new System.Drawing.Size(42, 21);
            this.opacity_label.TabIndex = 57;
            this.opacity_label.Text = "80%";
            // 
            // label_opacity
            // 
            this.label_opacity.BackColor = System.Drawing.Color.Transparent;
            this.label_opacity.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_opacity.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_opacity.ForeColor = System.Drawing.Color.White;
            this.label_opacity.Location = new System.Drawing.Point(15, 346);
            this.label_opacity.Name = "label_opacity";
            this.label_opacity.Size = new System.Drawing.Size(96, 35);
            this.label_opacity.TabIndex = 59;
            this.label_opacity.Text = "불투명도";
            // 
            // line_3
            // 
            this.line_3.AutoSize = true;
            this.line_3.BackColor = System.Drawing.Color.Transparent;
            this.line_3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_3.Location = new System.Drawing.Point(17, 509);
            this.line_3.Name = "line_3";
            this.line_3.Size = new System.Drawing.Size(568, 17);
            this.line_3.TabIndex = 61;
            this.line_3.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------";
            // 
            // exp_ignore
            // 
            this.exp_ignore.AutoSize = true;
            this.exp_ignore.BackColor = System.Drawing.Color.Transparent;
            this.exp_ignore.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_ignore.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_ignore.Location = new System.Drawing.Point(17, 591);
            this.exp_ignore.Name = "exp_ignore";
            this.exp_ignore.Size = new System.Drawing.Size(389, 34);
            this.exp_ignore.TabIndex = 63;
            this.exp_ignore.Text = "이미지를 조작할 수 없도록 설정합니다.\r\n이 설정을 하면 화면에 이미지가 보이지만 드래그할 수 없습니다.";
            // 
            // label_ignore
            // 
            this.label_ignore.BackColor = System.Drawing.Color.Transparent;
            this.label_ignore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_ignore.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_ignore.ForeColor = System.Drawing.Color.White;
            this.label_ignore.Location = new System.Drawing.Point(15, 549);
            this.label_ignore.Name = "label_ignore";
            this.label_ignore.Size = new System.Drawing.Size(570, 35);
            this.label_ignore.TabIndex = 62;
            this.label_ignore.Text = "클릭 불가";
            this.label_ignore.Click += new System.EventHandler(this.label_ignore_Click);
            // 
            // label_width
            // 
            this.label_width.BackColor = System.Drawing.Color.Transparent;
            this.label_width.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_width.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_width.ForeColor = System.Drawing.Color.White;
            this.label_width.Location = new System.Drawing.Point(15, 388);
            this.label_width.Name = "label_width";
            this.label_width.Size = new System.Drawing.Size(96, 35);
            this.label_width.TabIndex = 67;
            this.label_width.Text = "가로";
            // 
            // width
            // 
            this.width.BackColor = System.Drawing.Color.Transparent;
            this.width.Cursor = System.Windows.Forms.Cursors.Hand;
            this.width.Location = new System.Drawing.Point(130, 388);
            this.width.Maximum = 1920;
            this.width.Minimum = 50;
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(400, 23);
            this.width.SmallChange = 5;
            this.width.TabIndex = 66;
            this.width.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.width.Value = 500;
            this.width.ValueChanged += new System.EventHandler(this.width_ValueChanged);
            this.width.KeyUp += new System.Windows.Forms.KeyEventHandler(this.width_KeyUp);
            this.width.MouseUp += new System.Windows.Forms.MouseEventHandler(this.width_MouseUp);
            // 
            // width_label
            // 
            this.width_label.AutoSize = true;
            this.width_label.BackColor = System.Drawing.Color.Transparent;
            this.width_label.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.width_label.ForeColor = System.Drawing.Color.LightGray;
            this.width_label.Location = new System.Drawing.Point(540, 388);
            this.width_label.Name = "width_label";
            this.width_label.Size = new System.Drawing.Size(84, 21);
            this.width_label.TabIndex = 65;
            this.width_label.Text = "1920 픽셀";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 35);
            this.label1.TabIndex = 70;
            this.label1.Text = "세로";
            // 
            // height
            // 
            this.height.BackColor = System.Drawing.Color.Transparent;
            this.height.Cursor = System.Windows.Forms.Cursors.Hand;
            this.height.Location = new System.Drawing.Point(130, 427);
            this.height.Maximum = 1080;
            this.height.Minimum = 50;
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(400, 23);
            this.height.SmallChange = 5;
            this.height.TabIndex = 69;
            this.height.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.height.Value = 500;
            this.height.ValueChanged += new System.EventHandler(this.height_ValueChanged);
            this.height.KeyUp += new System.Windows.Forms.KeyEventHandler(this.height_KeyUp);
            this.height.MouseUp += new System.Windows.Forms.MouseEventHandler(this.height_MouseUp);
            // 
            // height_label
            // 
            this.height_label.AutoSize = true;
            this.height_label.BackColor = System.Drawing.Color.Transparent;
            this.height_label.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.height_label.ForeColor = System.Drawing.Color.LightGray;
            this.height_label.Location = new System.Drawing.Point(540, 427);
            this.height_label.Name = "height_label";
            this.height_label.Size = new System.Drawing.Size(84, 21);
            this.height_label.TabIndex = 68;
            this.height_label.Text = "1080 픽셀";
            // 
            // update_file
            // 
            this.update_file.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.update_file.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.update_file.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.update_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update_file.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.update_file.ForeColor = System.Drawing.Color.LightGray;
            this.update_file.Location = new System.Drawing.Point(538, 250);
            this.update_file.Name = "update_file";
            this.update_file.Size = new System.Drawing.Size(77, 25);
            this.update_file.TabIndex = 71;
            this.update_file.Text = "적용";
            this.update_file.UseVisualStyleBackColor = true;
            this.update_file.Click += new System.EventHandler(this.update_file_Click);
            // 
            // label_imgSize
            // 
            this.label_imgSize.AutoSize = true;
            this.label_imgSize.BackColor = System.Drawing.Color.Transparent;
            this.label_imgSize.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_imgSize.ForeColor = System.Drawing.Color.DarkGray;
            this.label_imgSize.Location = new System.Drawing.Point(17, 474);
            this.label_imgSize.Name = "label_imgSize";
            this.label_imgSize.Size = new System.Drawing.Size(143, 17);
            this.label_imgSize.TabIndex = 72;
            this.label_imgSize.Text = "현재 이미지 원본 크기:";
            // 
            // ignore
            // 
            this.ignore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ignore.Location = new System.Drawing.Point(555, 549);
            this.ignore.Name = "ignore";
            this.ignore.Size = new System.Drawing.Size(29, 25);
            this.ignore.TabIndex = 64;
            this.ignore.Click += new System.EventHandler(this.ignore_Click);
            // 
            // image
            // 
            this.image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image.Location = new System.Drawing.Point(555, 15);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(29, 25);
            this.image.TabIndex = 43;
            this.image.Click += new System.EventHandler(this.image_Click);
            // 
            // menu_image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.Controls.Add(this.label_imgSize);
            this.Controls.Add(this.update_file);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.height);
            this.Controls.Add(this.height_label);
            this.Controls.Add(this.label_width);
            this.Controls.Add(this.width);
            this.Controls.Add(this.width_label);
            this.Controls.Add(this.ignore);
            this.Controls.Add(this.exp_ignore);
            this.Controls.Add(this.label_ignore);
            this.Controls.Add(this.line_3);
            this.Controls.Add(this.label_opacity);
            this.Controls.Add(this.opacity);
            this.Controls.Add(this.opacity_label);
            this.Controls.Add(this.line_2);
            this.Controls.Add(this.exp_file);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.image);
            this.Controls.Add(this.exp_image);
            this.Controls.Add(this.line_1);
            this.Controls.Add(this.label_image);
            this.Controls.Add(this.browse_file);
            this.Controls.Add(this.file_path);
            this.Name = "menu_image";
            this.Size = new System.Drawing.Size(667, 800);
            this.Load += new System.EventHandler(this.menu_mococo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button browse_file;
        private System.Windows.Forms.TextBox file_path;
        private System.Windows.Forms.Label exp_image;
        private System.Windows.Forms.Label line_1;
        private System.Windows.Forms.Label label_image;
        private Functions.UI.flatCheckBox image;
        private System.Windows.Forms.Label exp_file;
        private System.Windows.Forms.Label label_file;
        private System.Windows.Forms.Label line_2;
        private MetroFramework.Controls.MetroTrackBar opacity;
        private System.Windows.Forms.Label opacity_label;
        private System.Windows.Forms.Label label_opacity;
        private System.Windows.Forms.Label line_3;
        private System.Windows.Forms.Label exp_ignore;
        private System.Windows.Forms.Label label_ignore;
        private Functions.UI.flatCheckBox ignore;
        private System.Windows.Forms.Label label_width;
        private MetroFramework.Controls.MetroTrackBar width;
        private System.Windows.Forms.Label width_label;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTrackBar height;
        private System.Windows.Forms.Label height_label;
        private System.Windows.Forms.Button update_file;
        private System.Windows.Forms.Label label_imgSize;
    }
}
