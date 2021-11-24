
namespace Lococo.Forms.menus
{
    partial class menu_boss
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
            this.label_imgTran = new System.Windows.Forms.Label();
            this.scrollBar_point = new System.Windows.Forms.PictureBox();
            this.scrollBar_back = new System.Windows.Forms.PictureBox();
            this.label_image = new System.Windows.Forms.Label();
            this.label_imgIgnore = new System.Windows.Forms.Label();
            this.label_imgDual = new System.Windows.Forms.Label();
            this.label_imgPath = new System.Windows.Forms.Label();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.label_imgRatio = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.browse_image = new System.Windows.Forms.Button();
            this.apply_image = new System.Windows.Forms.Button();
            this.image_path = new System.Windows.Forms.TextBox();
            this.line_label1 = new System.Windows.Forms.Label();
            this.line_label2 = new System.Windows.Forms.Label();
            this.line_label3 = new System.Windows.Forms.Label();
            this.line_label4 = new System.Windows.Forms.Label();
            this.line_label5 = new System.Windows.Forms.Label();
            this.image_ratio = new Lococo.Functions.UI.flatCheckBox();
            this.image_dualMonitor = new Lococo.Functions.UI.flatCheckBox();
            this.image_ignore = new Lococo.Functions.UI.flatCheckBox();
            this.image = new Lococo.Functions.UI.flatCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.scrollBar_point)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollBar_back)).BeginInit();
            this.SuspendLayout();
            // 
            // label_imgTran
            // 
            this.label_imgTran.BackColor = System.Drawing.Color.Transparent;
            this.label_imgTran.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_imgTran.ForeColor = System.Drawing.Color.LightGray;
            this.label_imgTran.Location = new System.Drawing.Point(16, 220);
            this.label_imgTran.Name = "label_imgTran";
            this.label_imgTran.Size = new System.Drawing.Size(471, 65);
            this.label_imgTran.TabIndex = 5;
            this.label_imgTran.Text = "불투명도";
            // 
            // scrollBar_point
            // 
            this.scrollBar_point.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.scrollBar_point.Location = new System.Drawing.Point(274, 217);
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
            this.scrollBar_back.Location = new System.Drawing.Point(259, 217);
            this.scrollBar_back.Name = "scrollBar_back";
            this.scrollBar_back.Size = new System.Drawing.Size(100, 50);
            this.scrollBar_back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.scrollBar_back.TabIndex = 6;
            this.scrollBar_back.TabStop = false;
            this.scrollBar_back.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollBar_back_MouseDown);
            this.scrollBar_back.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scrollBar_back_MouseMove);
            this.scrollBar_back.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollBar_back_MouseUp);
            // 
            // label_image
            // 
            this.label_image.BackColor = System.Drawing.Color.Transparent;
            this.label_image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_image.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_image.ForeColor = System.Drawing.Color.White;
            this.label_image.Location = new System.Drawing.Point(15, 15);
            this.label_image.Name = "label_image";
            this.label_image.Size = new System.Drawing.Size(474, 50);
            this.label_image.TabIndex = 8;
            this.label_image.Text = "표시";
            this.label_image.Click += new System.EventHandler(this.label_image_Click);
            // 
            // label_imgIgnore
            // 
            this.label_imgIgnore.BackColor = System.Drawing.Color.Transparent;
            this.label_imgIgnore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_imgIgnore.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_imgIgnore.ForeColor = System.Drawing.Color.LightGray;
            this.label_imgIgnore.Location = new System.Drawing.Point(18, 310);
            this.label_imgIgnore.Name = "label_imgIgnore";
            this.label_imgIgnore.Size = new System.Drawing.Size(471, 62);
            this.label_imgIgnore.TabIndex = 9;
            this.label_imgIgnore.Text = "클릭 불가";
            this.label_imgIgnore.Click += new System.EventHandler(this.label_imgIgnore_Click);
            // 
            // label_imgDual
            // 
            this.label_imgDual.BackColor = System.Drawing.Color.Transparent;
            this.label_imgDual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_imgDual.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_imgDual.ForeColor = System.Drawing.Color.LightGray;
            this.label_imgDual.Location = new System.Drawing.Point(18, 494);
            this.label_imgDual.Name = "label_imgDual";
            this.label_imgDual.Size = new System.Drawing.Size(472, 61);
            this.label_imgDual.TabIndex = 14;
            this.label_imgDual.Text = "보조 모니터에 표시";
            this.label_imgDual.Click += new System.EventHandler(this.label_imgDual_Click);
            // 
            // label_imgPath
            // 
            this.label_imgPath.BackColor = System.Drawing.Color.Transparent;
            this.label_imgPath.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_imgPath.ForeColor = System.Drawing.Color.LightGray;
            this.label_imgPath.Location = new System.Drawing.Point(16, 99);
            this.label_imgPath.Name = "label_imgPath";
            this.label_imgPath.Size = new System.Drawing.Size(472, 94);
            this.label_imgPath.TabIndex = 24;
            this.label_imgPath.Text = "이미지 경로";
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openFileDialog1";
            // 
            // label_imgRatio
            // 
            this.label_imgRatio.BackColor = System.Drawing.Color.Transparent;
            this.label_imgRatio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_imgRatio.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_imgRatio.ForeColor = System.Drawing.Color.LightGray;
            this.label_imgRatio.Location = new System.Drawing.Point(19, 401);
            this.label_imgRatio.Name = "label_imgRatio";
            this.label_imgRatio.Size = new System.Drawing.Size(471, 62);
            this.label_imgRatio.TabIndex = 25;
            this.label_imgRatio.Text = "원본 크기로 불러오기";
            this.label_imgRatio.Click += new System.EventHandler(this.label_imgRatio_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 200;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // browse_image
            // 
            this.browse_image.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.browse_image.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.browse_image.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.browse_image.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browse_image.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.browse_image.ForeColor = System.Drawing.Color.LightGray;
            this.browse_image.Location = new System.Drawing.Point(409, 161);
            this.browse_image.Name = "browse_image";
            this.browse_image.Size = new System.Drawing.Size(77, 25);
            this.browse_image.TabIndex = 29;
            this.browse_image.Text = "찾아보기";
            this.browse_image.UseVisualStyleBackColor = true;
            this.browse_image.Click += new System.EventHandler(this.browse_image_Click);
            // 
            // apply_image
            // 
            this.apply_image.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.apply_image.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.apply_image.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.apply_image.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply_image.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.apply_image.ForeColor = System.Drawing.Color.LightGray;
            this.apply_image.Location = new System.Drawing.Point(409, 130);
            this.apply_image.Name = "apply_image";
            this.apply_image.Size = new System.Drawing.Size(77, 25);
            this.apply_image.TabIndex = 28;
            this.apply_image.Text = "적용";
            this.apply_image.UseVisualStyleBackColor = true;
            this.apply_image.Click += new System.EventHandler(this.apply_image_Click);
            // 
            // image_path
            // 
            this.image_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.image_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image_path.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.image_path.ForeColor = System.Drawing.Color.LightGray;
            this.image_path.Location = new System.Drawing.Point(212, 99);
            this.image_path.Name = "image_path";
            this.image_path.Size = new System.Drawing.Size(274, 25);
            this.image_path.TabIndex = 27;
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
            this.line_label1.TabIndex = 30;
            this.line_label1.Text = "---------------------------------------------------------------------------------" +
    "----------------";
            // 
            // line_label2
            // 
            this.line_label2.AutoSize = true;
            this.line_label2.BackColor = System.Drawing.Color.Transparent;
            this.line_label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_label2.Location = new System.Drawing.Point(16, 193);
            this.line_label2.Name = "line_label2";
            this.line_label2.Size = new System.Drawing.Size(493, 17);
            this.line_label2.TabIndex = 31;
            this.line_label2.Text = "---------------------------------------------------------------------------------" +
    "----------------";
            // 
            // line_label3
            // 
            this.line_label3.AutoSize = true;
            this.line_label3.BackColor = System.Drawing.Color.Transparent;
            this.line_label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_label3.Location = new System.Drawing.Point(17, 284);
            this.line_label3.Name = "line_label3";
            this.line_label3.Size = new System.Drawing.Size(493, 17);
            this.line_label3.TabIndex = 32;
            this.line_label3.Text = "---------------------------------------------------------------------------------" +
    "----------------";
            // 
            // line_label4
            // 
            this.line_label4.AutoSize = true;
            this.line_label4.BackColor = System.Drawing.Color.Transparent;
            this.line_label4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_label4.Location = new System.Drawing.Point(17, 373);
            this.line_label4.Name = "line_label4";
            this.line_label4.Size = new System.Drawing.Size(493, 17);
            this.line_label4.TabIndex = 33;
            this.line_label4.Text = "---------------------------------------------------------------------------------" +
    "----------------";
            // 
            // line_label5
            // 
            this.line_label5.AutoSize = true;
            this.line_label5.BackColor = System.Drawing.Color.Transparent;
            this.line_label5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_label5.Location = new System.Drawing.Point(19, 463);
            this.line_label5.Name = "line_label5";
            this.line_label5.Size = new System.Drawing.Size(493, 17);
            this.line_label5.TabIndex = 34;
            this.line_label5.Text = "---------------------------------------------------------------------------------" +
    "----------------";
            // 
            // image_ratio
            // 
            this.image_ratio.Checked = true;
            this.image_ratio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.image_ratio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image_ratio.Location = new System.Drawing.Point(460, 401);
            this.image_ratio.Name = "image_ratio";
            this.image_ratio.Size = new System.Drawing.Size(30, 25);
            this.image_ratio.TabIndex = 26;
            this.image_ratio.Click += new System.EventHandler(this.image_ratio_Click);
            // 
            // image_dualMonitor
            // 
            this.image_dualMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image_dualMonitor.Location = new System.Drawing.Point(460, 494);
            this.image_dualMonitor.Name = "image_dualMonitor";
            this.image_dualMonitor.Size = new System.Drawing.Size(30, 25);
            this.image_dualMonitor.TabIndex = 20;
            // 
            // image_ignore
            // 
            this.image_ignore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image_ignore.Location = new System.Drawing.Point(460, 310);
            this.image_ignore.Name = "image_ignore";
            this.image_ignore.Size = new System.Drawing.Size(29, 25);
            this.image_ignore.TabIndex = 18;
            this.image_ignore.Click += new System.EventHandler(this.image_ignore_Click);
            // 
            // image
            // 
            this.image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image.Location = new System.Drawing.Point(457, 12);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(29, 25);
            this.image.TabIndex = 17;
            this.image.Click += new System.EventHandler(this.image_Click);
            // 
            // menu_boss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.Controls.Add(this.line_label5);
            this.Controls.Add(this.line_label4);
            this.Controls.Add(this.line_label3);
            this.Controls.Add(this.line_label2);
            this.Controls.Add(this.line_label1);
            this.Controls.Add(this.browse_image);
            this.Controls.Add(this.apply_image);
            this.Controls.Add(this.image_path);
            this.Controls.Add(this.image_ratio);
            this.Controls.Add(this.label_imgRatio);
            this.Controls.Add(this.label_imgPath);
            this.Controls.Add(this.image_dualMonitor);
            this.Controls.Add(this.image_ignore);
            this.Controls.Add(this.image);
            this.Controls.Add(this.label_imgDual);
            this.Controls.Add(this.label_imgIgnore);
            this.Controls.Add(this.label_image);
            this.Controls.Add(this.scrollBar_point);
            this.Controls.Add(this.scrollBar_back);
            this.Controls.Add(this.label_imgTran);
            this.Name = "menu_boss";
            this.Size = new System.Drawing.Size(708, 634);
            this.Load += new System.EventHandler(this.menu_mococo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scrollBar_point)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollBar_back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_imgTran;
        private System.Windows.Forms.PictureBox scrollBar_point;
        private System.Windows.Forms.PictureBox scrollBar_back;
        private System.Windows.Forms.Label label_image;
        private System.Windows.Forms.Label label_imgIgnore;
        private System.Windows.Forms.Label label_imgDual;
        private Functions.UI.flatCheckBox image;
        private Functions.UI.flatCheckBox image_ignore;
        private Functions.UI.flatCheckBox image_dualMonitor;
        private System.Windows.Forms.Label label_imgPath;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private Functions.UI.flatCheckBox image_ratio;
        private System.Windows.Forms.Label label_imgRatio;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button browse_image;
        private System.Windows.Forms.Button apply_image;
        private System.Windows.Forms.TextBox image_path;
        private System.Windows.Forms.Label line_label1;
        private System.Windows.Forms.Label line_label2;
        private System.Windows.Forms.Label line_label3;
        private System.Windows.Forms.Label line_label4;
        private System.Windows.Forms.Label line_label5;
    }
}
