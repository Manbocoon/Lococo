
namespace Lococo.Forms.overlay.UI.Bar
{
    partial class s_image
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
            this.update_file = new System.Windows.Forms.Button();
            this.line_1 = new System.Windows.Forms.Label();
            this.exp_file = new System.Windows.Forms.Label();
            this.label_file = new System.Windows.Forms.Label();
            this.browse_file = new System.Windows.Forms.Button();
            this.file_path = new System.Windows.Forms.TextBox();
            this.exp_original = new System.Windows.Forms.Label();
            this.label_original = new System.Windows.Forms.Label();
            this.line_2 = new System.Windows.Forms.Label();
            this.exp_ratio = new System.Windows.Forms.Label();
            this.label_ratio = new System.Windows.Forms.Label();
            this.ratio = new Lococo.Functions.UI.flatCheckBox();
            this.original = new Lococo.Functions.UI.flatCheckBox();
            this.SuspendLayout();
            // 
            // update_file
            // 
            this.update_file.Cursor = System.Windows.Forms.Cursors.Hand;
            this.update_file.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.update_file.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.update_file.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.update_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update_file.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.update_file.ForeColor = System.Drawing.Color.LightGray;
            this.update_file.Location = new System.Drawing.Point(20, 140);
            this.update_file.Name = "update_file";
            this.update_file.Size = new System.Drawing.Size(543, 40);
            this.update_file.TabIndex = 77;
            this.update_file.Text = "업데이트";
            this.update_file.UseVisualStyleBackColor = true;
            this.update_file.Click += new System.EventHandler(this.update_file_Click);
            // 
            // line_1
            // 
            this.line_1.AutoSize = true;
            this.line_1.BackColor = System.Drawing.Color.Transparent;
            this.line_1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_1.Location = new System.Drawing.Point(17, 210);
            this.line_1.Name = "line_1";
            this.line_1.Size = new System.Drawing.Size(568, 17);
            this.line_1.TabIndex = 76;
            this.line_1.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------";
            // 
            // exp_file
            // 
            this.exp_file.AutoSize = true;
            this.exp_file.BackColor = System.Drawing.Color.Transparent;
            this.exp_file.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_file.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_file.Location = new System.Drawing.Point(17, 57);
            this.exp_file.Name = "exp_file";
            this.exp_file.Size = new System.Drawing.Size(386, 34);
            this.exp_file.TabIndex = 75;
            this.exp_file.Text = "오버레이에 표시할 이미지를 변경합니다.\r\nPC에 있는 이미지의 경로를 입력하거나 직접 파일을 선택합니다.";
            // 
            // label_file
            // 
            this.label_file.BackColor = System.Drawing.Color.Transparent;
            this.label_file.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_file.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_file.ForeColor = System.Drawing.Color.White;
            this.label_file.Location = new System.Drawing.Point(15, 15);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(474, 35);
            this.label_file.TabIndex = 74;
            this.label_file.Text = "표시할 이미지";
            // 
            // browse_file
            // 
            this.browse_file.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browse_file.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.browse_file.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.browse_file.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.browse_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browse_file.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.browse_file.ForeColor = System.Drawing.Color.LightGray;
            this.browse_file.Location = new System.Drawing.Point(486, 110);
            this.browse_file.Name = "browse_file";
            this.browse_file.Size = new System.Drawing.Size(77, 25);
            this.browse_file.TabIndex = 73;
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
            this.file_path.Location = new System.Drawing.Point(20, 110);
            this.file_path.Name = "file_path";
            this.file_path.Size = new System.Drawing.Size(460, 25);
            this.file_path.TabIndex = 72;
            // 
            // exp_original
            // 
            this.exp_original.AutoSize = true;
            this.exp_original.BackColor = System.Drawing.Color.Transparent;
            this.exp_original.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_original.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_original.Location = new System.Drawing.Point(23, 297);
            this.exp_original.Name = "exp_original";
            this.exp_original.Size = new System.Drawing.Size(327, 17);
            this.exp_original.TabIndex = 80;
            this.exp_original.Text = "이미지를 업데이트할 때 원본 크기 그대로 불러옵니다.";
            // 
            // label_original
            // 
            this.label_original.BackColor = System.Drawing.Color.Transparent;
            this.label_original.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_original.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_original.ForeColor = System.Drawing.Color.White;
            this.label_original.Location = new System.Drawing.Point(21, 255);
            this.label_original.Name = "label_original";
            this.label_original.Size = new System.Drawing.Size(570, 35);
            this.label_original.TabIndex = 79;
            this.label_original.Text = "원본 크기로 불러오기";
            this.label_original.Click += new System.EventHandler(this.label_original_Click);
            // 
            // line_2
            // 
            this.line_2.AutoSize = true;
            this.line_2.BackColor = System.Drawing.Color.Transparent;
            this.line_2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.line_2.Location = new System.Drawing.Point(22, 344);
            this.line_2.Name = "line_2";
            this.line_2.Size = new System.Drawing.Size(568, 17);
            this.line_2.TabIndex = 82;
            this.line_2.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------";
            // 
            // exp_ratio
            // 
            this.exp_ratio.AutoSize = true;
            this.exp_ratio.BackColor = System.Drawing.Color.Transparent;
            this.exp_ratio.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exp_ratio.ForeColor = System.Drawing.Color.DarkGray;
            this.exp_ratio.Location = new System.Drawing.Point(23, 433);
            this.exp_ratio.Name = "exp_ratio";
            this.exp_ratio.Size = new System.Drawing.Size(330, 17);
            this.exp_ratio.TabIndex = 84;
            this.exp_ratio.Text = "이미지의 가로, 세로 비율을 항상 비슷하게 유지합니다.";
            // 
            // label_ratio
            // 
            this.label_ratio.BackColor = System.Drawing.Color.Transparent;
            this.label_ratio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_ratio.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_ratio.ForeColor = System.Drawing.Color.White;
            this.label_ratio.Location = new System.Drawing.Point(21, 391);
            this.label_ratio.Name = "label_ratio";
            this.label_ratio.Size = new System.Drawing.Size(570, 35);
            this.label_ratio.TabIndex = 83;
            this.label_ratio.Text = "비율 유지";
            this.label_ratio.Click += new System.EventHandler(this.label_ratio_Click);
            // 
            // ratio
            // 
            this.ratio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ratio.Location = new System.Drawing.Point(561, 391);
            this.ratio.Name = "ratio";
            this.ratio.Size = new System.Drawing.Size(29, 25);
            this.ratio.TabIndex = 85;
            this.ratio.Click += new System.EventHandler(this.ratio_Click);
            // 
            // original
            // 
            this.original.Cursor = System.Windows.Forms.Cursors.Hand;
            this.original.Location = new System.Drawing.Point(561, 255);
            this.original.Name = "original";
            this.original.Size = new System.Drawing.Size(29, 25);
            this.original.TabIndex = 81;
            this.original.Click += new System.EventHandler(this.original_Click);
            // 
            // s_image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(612, 478);
            this.Controls.Add(this.ratio);
            this.Controls.Add(this.exp_ratio);
            this.Controls.Add(this.label_ratio);
            this.Controls.Add(this.line_2);
            this.Controls.Add(this.original);
            this.Controls.Add(this.exp_original);
            this.Controls.Add(this.label_original);
            this.Controls.Add(this.update_file);
            this.Controls.Add(this.line_1);
            this.Controls.Add(this.exp_file);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.browse_file);
            this.Controls.Add(this.file_path);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(150, 50);
            this.Name = "s_image";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.s_image_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button update_file;
        private System.Windows.Forms.Label line_1;
        private System.Windows.Forms.Label exp_file;
        private System.Windows.Forms.Label label_file;
        private System.Windows.Forms.Button browse_file;
        private System.Windows.Forms.TextBox file_path;
        private Functions.UI.flatCheckBox original;
        private System.Windows.Forms.Label exp_original;
        private System.Windows.Forms.Label label_original;
        private System.Windows.Forms.Label line_2;
        private Functions.UI.flatCheckBox ratio;
        private System.Windows.Forms.Label exp_ratio;
        private System.Windows.Forms.Label label_ratio;
    }
}