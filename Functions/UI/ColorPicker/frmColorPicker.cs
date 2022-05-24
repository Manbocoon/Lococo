/******************************************************************/
/*****                                                        *****/
/*****     Project:           Adobe Color Picker Clone 1      *****/
/*****     Filename:          frmColorPicker.cs               *****/
/*****     Original Author:   Danny Blanchard                 *****/
/*****                        - scrabcakes@gmail.com          *****/
/*****     Updates:	                                          *****/
/*****      3/28/2005 - Initial Version : Danny Blanchard     *****/
/*****                                                        *****/
/******************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Lococo.Functions.UI.ColorPicker
{
	/// <summary>
	/// Summary description for frmColorPicker.
	/// </summary>
	public class frmColorPicker : System.Windows.Forms.Form
	{
		#region API
		[DllImport("user32")]
		public static extern Int32 GetCursorPos(out POINT pt);

		public struct POINT
		{
			public Int32 x;
			public Int32 y;
		}

		private bool form_dragging = false;
		private POINT firstPoint;
		private int form_left, form_top;
		#endregion


		#region Class Variables

		private AdobeColors.HSL		m_hsl;
		private Color				m_rgb;
		private AdobeColors.CMYK	m_cmyk;

		public enum eDrawStyle
		{
			Hue,
			Saturation,
			Brightness,
			Red,
			Green,
			Blue
		}


		#endregion

		#region Designer Generated Variables

		private System.Windows.Forms.Label m_lbl_SelectColor;
		private System.Windows.Forms.PictureBox m_pbx_BlankBox;
		private System.Windows.Forms.Button m_cmd_OK;
		private System.Windows.Forms.Button m_cmd_Cancel;
		private System.Windows.Forms.TextBox m_txt_Red;
		private System.Windows.Forms.TextBox m_txt_Green;
		private System.Windows.Forms.TextBox m_txt_Blue;
		private System.Windows.Forms.TextBox m_txt_Hex;
		private System.Windows.Forms.Label m_lbl_HexPound;
		private System.Windows.Forms.Label m_lbl_Primary_Color;
		private System.Windows.Forms.Label m_lbl_Secondary_Color;
		private ctrlVerticalColorSlider m_ctrl_ThinBox;
		private ctrl2DColorBox m_ctrl_BigBox;
		private System.Windows.Forms.Label m_lbl_Key_Symbol;
        private Panel top_panel;
        private PictureBox close_top;
        private Label m_label_blue;
        private Label m_label_green;
        private Label m_label_red;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		#endregion

		#region Constructors / Destructors

		public frmColorPicker(Color starting_color)
		{
			InitializeComponent();

			m_rgb = starting_color;
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);
			
			m_txt_Red.Text =		m_rgb.R.ToString();
			m_txt_Green.Text =		m_rgb.G.ToString();
			m_txt_Blue.Text =		m_rgb.B.ToString();

			m_txt_Red.Update();
			m_txt_Green.Update();
			m_txt_Blue.Update();

			m_ctrl_BigBox.HSL = m_hsl;
			m_ctrl_ThinBox.HSL = m_hsl;

			m_lbl_Primary_Color.BackColor = starting_color;
			m_lbl_Secondary_Color.BackColor = starting_color;

			this.WriteHexData(m_rgb);
		}


		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Lococo.Functions.UI.ColorPicker.AdobeColors.HSL hsl7 = new Lococo.Functions.UI.ColorPicker.AdobeColors.HSL();
            Lococo.Functions.UI.ColorPicker.AdobeColors.HSL hsl8 = new Lococo.Functions.UI.ColorPicker.AdobeColors.HSL();
            this.m_lbl_SelectColor = new System.Windows.Forms.Label();
            this.m_pbx_BlankBox = new System.Windows.Forms.PictureBox();
            this.m_cmd_OK = new System.Windows.Forms.Button();
            this.m_cmd_Cancel = new System.Windows.Forms.Button();
            this.m_txt_Red = new System.Windows.Forms.TextBox();
            this.m_txt_Green = new System.Windows.Forms.TextBox();
            this.m_txt_Blue = new System.Windows.Forms.TextBox();
            this.m_txt_Hex = new System.Windows.Forms.TextBox();
            this.m_lbl_HexPound = new System.Windows.Forms.Label();
            this.m_lbl_Primary_Color = new System.Windows.Forms.Label();
            this.m_lbl_Secondary_Color = new System.Windows.Forms.Label();
            this.m_lbl_Key_Symbol = new System.Windows.Forms.Label();
            this.top_panel = new System.Windows.Forms.Panel();
            this.close_top = new System.Windows.Forms.PictureBox();
            this.m_label_blue = new System.Windows.Forms.Label();
            this.m_label_green = new System.Windows.Forms.Label();
            this.m_label_red = new System.Windows.Forms.Label();
            this.m_ctrl_BigBox = new Lococo.Functions.UI.ColorPicker.ctrl2DColorBox();
            this.m_ctrl_ThinBox = new Lococo.Functions.UI.ColorPicker.ctrlVerticalColorSlider();
            ((System.ComponentModel.ISupportInitialize)(this.m_pbx_BlankBox)).BeginInit();
            this.top_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close_top)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lbl_SelectColor
            // 
            this.m_lbl_SelectColor.BackColor = System.Drawing.Color.Transparent;
            this.m_lbl_SelectColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lbl_SelectColor.ForeColor = System.Drawing.Color.White;
            this.m_lbl_SelectColor.Location = new System.Drawing.Point(7, 37);
            this.m_lbl_SelectColor.Name = "m_lbl_SelectColor";
            this.m_lbl_SelectColor.Size = new System.Drawing.Size(312, 21);
            this.m_lbl_SelectColor.TabIndex = 0;
            this.m_lbl_SelectColor.Text = "색상을 선택하세요:";
            // 
            // m_pbx_BlankBox
            // 
            this.m_pbx_BlankBox.BackColor = System.Drawing.Color.LightGray;
            this.m_pbx_BlankBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_pbx_BlankBox.Location = new System.Drawing.Point(379, 64);
            this.m_pbx_BlankBox.Name = "m_pbx_BlankBox";
            this.m_pbx_BlankBox.Size = new System.Drawing.Size(107, 76);
            this.m_pbx_BlankBox.TabIndex = 3;
            this.m_pbx_BlankBox.TabStop = false;
            // 
            // m_cmd_OK
            // 
            this.m_cmd_OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.m_cmd_OK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.m_cmd_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.m_cmd_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.m_cmd_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmd_OK.ForeColor = System.Drawing.Color.LightGray;
            this.m_cmd_OK.Location = new System.Drawing.Point(504, 64);
            this.m_cmd_OK.Name = "m_cmd_OK";
            this.m_cmd_OK.Size = new System.Drawing.Size(87, 25);
            this.m_cmd_OK.TabIndex = 4;
            this.m_cmd_OK.Text = "확인";
            this.m_cmd_OK.UseVisualStyleBackColor = false;
            this.m_cmd_OK.Click += new System.EventHandler(this.m_cmd_OK_Click);
            // 
            // m_cmd_Cancel
            // 
            this.m_cmd_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.m_cmd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmd_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.m_cmd_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.m_cmd_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.m_cmd_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmd_Cancel.ForeColor = System.Drawing.Color.LightGray;
            this.m_cmd_Cancel.Location = new System.Drawing.Point(504, 94);
            this.m_cmd_Cancel.Name = "m_cmd_Cancel";
            this.m_cmd_Cancel.Size = new System.Drawing.Size(87, 25);
            this.m_cmd_Cancel.TabIndex = 5;
            this.m_cmd_Cancel.Text = "취소";
            this.m_cmd_Cancel.UseVisualStyleBackColor = false;
            this.m_cmd_Cancel.Click += new System.EventHandler(this.m_cmd_Cancel_Click);
            // 
            // m_txt_Red
            // 
            this.m_txt_Red.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.m_txt_Red.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Red.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txt_Red.ForeColor = System.Drawing.Color.White;
            this.m_txt_Red.Location = new System.Drawing.Point(418, 158);
            this.m_txt_Red.Name = "m_txt_Red";
            this.m_txt_Red.Size = new System.Drawing.Size(67, 21);
            this.m_txt_Red.TabIndex = 9;
            this.m_txt_Red.Leave += new System.EventHandler(this.m_txt_Red_Leave);
            // 
            // m_txt_Green
            // 
            this.m_txt_Green.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.m_txt_Green.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Green.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txt_Green.ForeColor = System.Drawing.Color.White;
            this.m_txt_Green.Location = new System.Drawing.Point(418, 185);
            this.m_txt_Green.Name = "m_txt_Green";
            this.m_txt_Green.Size = new System.Drawing.Size(67, 21);
            this.m_txt_Green.TabIndex = 10;
            this.m_txt_Green.Leave += new System.EventHandler(this.m_txt_Green_Leave);
            // 
            // m_txt_Blue
            // 
            this.m_txt_Blue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.m_txt_Blue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Blue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txt_Blue.ForeColor = System.Drawing.Color.White;
            this.m_txt_Blue.Location = new System.Drawing.Point(418, 212);
            this.m_txt_Blue.Name = "m_txt_Blue";
            this.m_txt_Blue.Size = new System.Drawing.Size(67, 21);
            this.m_txt_Blue.TabIndex = 11;
            this.m_txt_Blue.Leave += new System.EventHandler(this.m_txt_Blue_Leave);
            // 
            // m_txt_Hex
            // 
            this.m_txt_Hex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.m_txt_Hex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_Hex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txt_Hex.ForeColor = System.Drawing.Color.White;
            this.m_txt_Hex.Location = new System.Drawing.Point(418, 264);
            this.m_txt_Hex.Name = "m_txt_Hex";
            this.m_txt_Hex.Size = new System.Drawing.Size(67, 21);
            this.m_txt_Hex.TabIndex = 19;
            this.m_txt_Hex.Leave += new System.EventHandler(this.m_txt_Hex_Leave);
            // 
            // m_lbl_HexPound
            // 
            this.m_lbl_HexPound.ForeColor = System.Drawing.Color.LightGray;
            this.m_lbl_HexPound.Location = new System.Drawing.Point(379, 269);
            this.m_lbl_HexPound.Name = "m_lbl_HexPound";
            this.m_lbl_HexPound.Size = new System.Drawing.Size(33, 15);
            this.m_lbl_HexPound.TabIndex = 27;
            this.m_lbl_HexPound.Text = "Hex:";
            // 
            // m_lbl_Primary_Color
            // 
            this.m_lbl_Primary_Color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_lbl_Primary_Color.Location = new System.Drawing.Point(381, 65);
            this.m_lbl_Primary_Color.Name = "m_lbl_Primary_Color";
            this.m_lbl_Primary_Color.Size = new System.Drawing.Size(104, 37);
            this.m_lbl_Primary_Color.TabIndex = 36;
            this.m_lbl_Primary_Color.Click += new System.EventHandler(this.m_lbl_Primary_Color_Click);
            // 
            // m_lbl_Secondary_Color
            // 
            this.m_lbl_Secondary_Color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_lbl_Secondary_Color.Location = new System.Drawing.Point(381, 102);
            this.m_lbl_Secondary_Color.Name = "m_lbl_Secondary_Color";
            this.m_lbl_Secondary_Color.Size = new System.Drawing.Size(104, 37);
            this.m_lbl_Secondary_Color.TabIndex = 37;
            this.m_lbl_Secondary_Color.Click += new System.EventHandler(this.m_lbl_Secondary_Color_Click);
            // 
            // m_lbl_Key_Symbol
            // 
            this.m_lbl_Key_Symbol.Location = new System.Drawing.Point(577, 241);
            this.m_lbl_Key_Symbol.Name = "m_lbl_Key_Symbol";
            this.m_lbl_Key_Symbol.Size = new System.Drawing.Size(120, 25);
            this.m_lbl_Key_Symbol.TabIndex = 0;
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.top_panel.Controls.Add(this.close_top);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(607, 27);
            this.top_panel.TabIndex = 46;
            this.top_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseDown);
            this.top_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseMove);
            this.top_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseUp);
            // 
            // close_top
            // 
            this.close_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.close_top.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_top.Location = new System.Drawing.Point(581, 3);
            this.close_top.Name = "close_top";
            this.close_top.Size = new System.Drawing.Size(22, 22);
            this.close_top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.close_top.TabIndex = 20;
            this.close_top.TabStop = false;
            this.close_top.Click += new System.EventHandler(this.close_top_Click);
            this.close_top.MouseEnter += new System.EventHandler(this.close_top_MouseEnter);
            this.close_top.MouseLeave += new System.EventHandler(this.close_top_MouseLeave);
            // 
            // m_label_blue
            // 
            this.m_label_blue.ForeColor = System.Drawing.Color.LightGray;
            this.m_label_blue.Location = new System.Drawing.Point(381, 215);
            this.m_label_blue.Name = "m_label_blue";
            this.m_label_blue.Size = new System.Drawing.Size(19, 17);
            this.m_label_blue.TabIndex = 49;
            this.m_label_blue.Text = "B:";
            // 
            // m_label_green
            // 
            this.m_label_green.ForeColor = System.Drawing.Color.LightGray;
            this.m_label_green.Location = new System.Drawing.Point(381, 189);
            this.m_label_green.Name = "m_label_green";
            this.m_label_green.Size = new System.Drawing.Size(19, 17);
            this.m_label_green.TabIndex = 48;
            this.m_label_green.Text = "G:";
            // 
            // m_label_red
            // 
            this.m_label_red.ForeColor = System.Drawing.Color.LightGray;
            this.m_label_red.Location = new System.Drawing.Point(381, 163);
            this.m_label_red.Name = "m_label_red";
            this.m_label_red.Size = new System.Drawing.Size(19, 18);
            this.m_label_red.TabIndex = 47;
            this.m_label_red.Text = "R:";
            // 
            // m_ctrl_BigBox
            // 
            this.m_ctrl_BigBox.DrawStyle = Lococo.Functions.UI.ColorPicker.ctrl2DColorBox.eDrawStyle.Hue;
            hsl7.H = 0D;
            hsl7.L = 1D;
            hsl7.S = 1D;
            this.m_ctrl_BigBox.HSL = hsl7;
            this.m_ctrl_BigBox.Location = new System.Drawing.Point(10, 66);
            this.m_ctrl_BigBox.Name = "m_ctrl_BigBox";
            this.m_ctrl_BigBox.RGB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_ctrl_BigBox.Size = new System.Drawing.Size(312, 280);
            this.m_ctrl_BigBox.TabIndex = 39;
            this.m_ctrl_BigBox.Scroll += new Lococo.Functions.UI.ColorPicker.EventHandler(this.m_ctrl_BigBox_Scroll);
            // 
            // m_ctrl_ThinBox
            // 
            this.m_ctrl_ThinBox.DrawStyle = Lococo.Functions.UI.ColorPicker.ctrlVerticalColorSlider.eDrawStyle.Hue;
            hsl8.H = 0D;
            hsl8.L = 1D;
            hsl8.S = 1D;
            this.m_ctrl_ThinBox.HSL = hsl8;
            this.m_ctrl_ThinBox.Location = new System.Drawing.Point(323, 64);
            this.m_ctrl_ThinBox.Name = "m_ctrl_ThinBox";
            this.m_ctrl_ThinBox.RGB = System.Drawing.Color.Red;
            this.m_ctrl_ThinBox.Size = new System.Drawing.Size(48, 284);
            this.m_ctrl_ThinBox.TabIndex = 38;
            this.m_ctrl_ThinBox.Scroll += new Lococo.Functions.UI.ColorPicker.EventHandler(this.m_ctrl_ThinBox_Scroll);
            // 
            // frmColorPicker
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(607, 365);
            this.Controls.Add(this.m_label_blue);
            this.Controls.Add(this.m_label_green);
            this.Controls.Add(this.m_label_red);
            this.Controls.Add(this.top_panel);
            this.Controls.Add(this.m_lbl_Key_Symbol);
            this.Controls.Add(this.m_ctrl_BigBox);
            this.Controls.Add(this.m_ctrl_ThinBox);
            this.Controls.Add(this.m_lbl_Secondary_Color);
            this.Controls.Add(this.m_lbl_Primary_Color);
            this.Controls.Add(this.m_lbl_HexPound);
            this.Controls.Add(this.m_txt_Hex);
            this.Controls.Add(this.m_txt_Blue);
            this.Controls.Add(this.m_txt_Green);
            this.Controls.Add(this.m_txt_Red);
            this.Controls.Add(this.m_cmd_Cancel);
            this.Controls.Add(this.m_cmd_OK);
            this.Controls.Add(this.m_pbx_BlankBox);
            this.Controls.Add(this.m_lbl_SelectColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmColorPicker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Picker";
            this.Load += new System.EventHandler(this.frmColorPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_pbx_BlankBox)).EndInit();
            this.top_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.close_top)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}


		#endregion

		#region Events

		#region General Events

		#region Form - Make Shadow
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams crp = base.CreateParams;
				crp.ClassStyle = 0x00020000;
				return crp;
			}
		}
		#endregion

		private void close_top_MouseEnter(object sender, EventArgs e)
		{
			close_top.BackColor = Color.FromArgb(180, 35, 35);
		}

		private void close_top_MouseLeave(object sender, EventArgs e)
		{
			close_top.BackColor = Color.FromArgb(25, 25, 25);
		}

		private void close_top_Click(object sender, EventArgs e)
		{
			close_top.BackColor = Color.FromArgb(255, 15, 15);

			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void top_panel_MouseDown(object sender, MouseEventArgs e)
		{
			if (!form_dragging)
			{
				form_dragging = true;
				form_left = this.Left;
				form_top = this.Top;

				GetCursorPos(out firstPoint);
			}
		}

		private void top_panel_MouseMove(object sender, MouseEventArgs e)
		{
			POINT secondPoint;

			if (form_dragging)
			{
				GetCursorPos(out secondPoint);

				this.Left = form_left + secondPoint.x - firstPoint.x;
				this.Top = form_top + secondPoint.y - firstPoint.y;
			}
		}

		private void top_panel_MouseUp(object sender, MouseEventArgs e)
		{
			form_dragging = false;
		}

		private void frmColorPicker_Load(object sender, EventArgs e)
		{
			close_top.Image = Properties.Resources.close_top;

			using (var shadowClass = new Functions.UI.dropShadow())
			{
				shadowClass.ApplyShadows(this, 1, 1, 1, 1);
			}

			m_ctrl_ThinBox.DrawStyle = ctrlVerticalColorSlider.eDrawStyle.Hue;
			m_ctrl_BigBox.DrawStyle = ctrl2DColorBox.eDrawStyle.Hue;

		}

		private void m_cmd_OK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}


		private void m_cmd_Cancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}


		#endregion

		#region Primary Picture Box (m_ctrl_BigBox)

		private void m_ctrl_BigBox_Scroll(object sender, System.EventArgs e)
		{
			m_hsl = m_ctrl_BigBox.HSL;
			m_rgb = AdobeColors.HSL_to_RGB(m_hsl);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);
			
			m_txt_Red.Text =		m_rgb.R.ToString();
			m_txt_Green.Text =		m_rgb.G.ToString();
			m_txt_Blue.Text =		m_rgb.B.ToString();

			m_txt_Red.Update();
			m_txt_Green.Update();
			m_txt_Blue.Update();

			m_ctrl_ThinBox.HSL = m_hsl;

			m_lbl_Primary_Color.BackColor = m_rgb;
			m_lbl_Primary_Color.Update();

			WriteHexData(m_rgb);
		}


		#endregion

		#region Secondary Picture Box (m_ctrl_ThinBox)

		private void m_ctrl_ThinBox_Scroll(object sender, System.EventArgs e)
		{
			m_hsl = m_ctrl_ThinBox.HSL;
			m_rgb = AdobeColors.HSL_to_RGB(m_hsl);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);
			
			m_txt_Red.Text =		m_rgb.R.ToString();
			m_txt_Green.Text =		m_rgb.G.ToString();
			m_txt_Blue.Text =		m_rgb.B.ToString();

			m_txt_Red.Update();
			m_txt_Green.Update();
			m_txt_Blue.Update();

			m_ctrl_BigBox.HSL = m_hsl;

			m_lbl_Primary_Color.BackColor = m_rgb;
			m_lbl_Primary_Color.Update();

			WriteHexData(m_rgb);
		}


		#endregion

		#region Hex Box (m_txt_Hex)

		private void m_txt_Hex_Leave(object sender, System.EventArgs e)
		{
			string text = m_txt_Hex.Text.ToUpper().Replace("#", null);
			bool has_illegal_chars = false;

			if ( text.Length <= 0 )
				has_illegal_chars = true;
			foreach ( char letter in text )
			{
				if ( !char.IsNumber(letter) )
				{
					if ( letter >= 'A' && letter <= 'F' )
						continue;
					has_illegal_chars = true;
					break;
				}
			}

			if ( has_illegal_chars )
			{
				MessageBox.Show("0x000000 ~ 0xFFFFFF 사이의 값만 사용 가능합니다.", "알림", 0, MessageBoxIcon.Exclamation);
				WriteHexData(m_rgb);
				return;
			}

			m_rgb = ParseHexData(text);
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);

			m_ctrl_BigBox.HSL = m_hsl;
			m_ctrl_ThinBox.HSL = m_hsl;
			m_lbl_Primary_Color.BackColor = m_rgb;

			UpdateTextBoxes();
		}


		#endregion

		#region Color Boxes

		private void m_lbl_Primary_Color_Click(object sender, System.EventArgs e)
		{
			m_rgb = m_lbl_Primary_Color.BackColor;
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);

			m_ctrl_BigBox.HSL = m_hsl;
			m_ctrl_ThinBox.HSL = m_hsl;

			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);
			
			m_txt_Red.Text =		m_rgb.R.ToString();
			m_txt_Green.Text =		m_rgb.G.ToString();
			m_txt_Blue.Text =		m_rgb.B.ToString();

			m_txt_Red.Update();
			m_txt_Green.Update();
			m_txt_Blue.Update();
		}


		private void m_lbl_Secondary_Color_Click(object sender, System.EventArgs e)
		{
			m_rgb = m_lbl_Secondary_Color.BackColor;
			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);

			m_ctrl_BigBox.HSL = m_hsl;
			m_ctrl_ThinBox.HSL = m_hsl;

			m_lbl_Primary_Color.BackColor = m_rgb;
			m_lbl_Primary_Color.Update();

			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);
			
			m_txt_Red.Text =		m_rgb.R.ToString();
			m_txt_Green.Text =		m_rgb.G.ToString();
			m_txt_Blue.Text =		m_rgb.B.ToString();

			m_txt_Red.Update();
			m_txt_Green.Update();
			m_txt_Blue.Update();
		}


		#endregion

		#region Text Boxes

		private void m_txt_Red_Leave(object sender, System.EventArgs e)
		{
			string text = m_txt_Red.Text;
			bool has_illegal_chars = false;

			if ( text.Length <= 0 )
				has_illegal_chars = true;
			else
				foreach ( char letter in text )
				{
					if ( !char.IsNumber(letter) )
					{
						has_illegal_chars = true;
						break;
					}
				}

			if ( has_illegal_chars )
			{
				MessageBox.Show("RGB 값은 0~255 범위의 수치만 입력 가능합니다.", "알림", 0, MessageBoxIcon.Exclamation);
				UpdateTextBoxes();
				return;
			}

			int red = int.Parse(text);

			if ( red < 0 )
			{
				m_rgb = Color.FromArgb(0, m_rgb.G, m_rgb.B);
				m_txt_Red.Text = "0";
			}

			else if ( red > 255 )
			{
				m_rgb = Color.FromArgb(255, m_rgb.G, m_rgb.B);
				m_txt_Red.Text = "255";
			}

			else
			{
				m_rgb = Color.FromArgb(red, m_rgb.G, m_rgb.B);
			}

			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);
			m_ctrl_BigBox.HSL = m_hsl;
			m_ctrl_ThinBox.HSL = m_hsl;
			m_lbl_Primary_Color.BackColor = m_rgb;

			UpdateTextBoxes();
		}


		private void m_txt_Green_Leave(object sender, System.EventArgs e)
		{
			string text = m_txt_Green.Text;
			bool has_illegal_chars = false;

			if ( text.Length <= 0 )
				has_illegal_chars = true;
			else
				foreach ( char letter in text )
				{
					if ( !char.IsNumber(letter) )
					{
						has_illegal_chars = true;
						break;
					}
				}

			if ( has_illegal_chars )
			{
				MessageBox.Show("RGB 값은 0~255 범위의 수치만 입력 가능합니다.", "알림", 0, MessageBoxIcon.Exclamation);
				UpdateTextBoxes();
				return;
			}

			int green = int.Parse(text);

			if ( green < 0 )
			{
				m_txt_Green.Text = "0";
				m_rgb = Color.FromArgb(m_rgb.R, 0, m_rgb.B);
			}
			else if ( green > 255 )
			{
				m_txt_Green.Text = "255";
				m_rgb = Color.FromArgb(m_rgb.R, 255, m_rgb.B);
			}
			else
			{
				m_rgb = Color.FromArgb(m_rgb.R, green, m_rgb.B);
			}

			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);
			m_ctrl_BigBox.HSL = m_hsl;
			m_ctrl_ThinBox.HSL = m_hsl;
			m_lbl_Primary_Color.BackColor = m_rgb;

			UpdateTextBoxes();
		}


		private void m_txt_Blue_Leave(object sender, System.EventArgs e)
		{
			string text = m_txt_Blue.Text;
			bool has_illegal_chars = false;

			if ( text.Length <= 0 )
				has_illegal_chars = true;
			else
				foreach ( char letter in text )
				{
					if ( !char.IsNumber(letter) )
					{
						has_illegal_chars = true;
						break;
					}
				}

			if ( has_illegal_chars )
			{
				MessageBox.Show("RGB 값은 0~255 범위의 수치만 입력 가능합니다.", "알림", 0, MessageBoxIcon.Exclamation);
				UpdateTextBoxes();
				return;
			}

			int blue = int.Parse(text);

			if ( blue < 0 )
			{
				m_txt_Blue.Text = "0";
				m_rgb = Color.FromArgb(m_rgb.R, m_rgb.G, 0);
			}
			else if ( blue > 255 )
			{
				m_txt_Blue.Text = "255";
				m_rgb = Color.FromArgb(m_rgb.R, m_rgb.G, 255);
			}
			else
			{
				m_rgb = Color.FromArgb(m_rgb.R, m_rgb.G, blue);
			}

			m_hsl = AdobeColors.RGB_to_HSL(m_rgb);
			m_cmyk = AdobeColors.RGB_to_CMYK(m_rgb);
			m_ctrl_BigBox.HSL = m_hsl;
			m_ctrl_ThinBox.HSL = m_hsl;
			m_lbl_Primary_Color.BackColor = m_rgb;

			UpdateTextBoxes();
		}





		#endregion

		#endregion

		#region Private Functions

		private int Round(double val)
		{
			int ret_val = (int)val;
			
			int temp = (int)(val * 100);

			if ( (temp % 100) >= 50 )
				ret_val += 1;

			return ret_val;
		}


		private void WriteHexData(Color rgb)
		{
			string red = Convert.ToString(rgb.R, 16);
			if ( red.Length < 2 ) red = "0" + red;
			string green = Convert.ToString(rgb.G, 16);
			if ( green.Length < 2 ) green = "0" + green;
			string blue = Convert.ToString(rgb.B, 16);
			if ( blue.Length < 2 ) blue = "0" + blue;

			m_txt_Hex.Text = "#" + red.ToUpper() + green.ToUpper() + blue.ToUpper();
			m_txt_Hex.Update();
		}


		private Color ParseHexData(string hex_data)
		{
			if ( hex_data.Length != 6 )
				return Color.Black;

			string r_text, g_text, b_text;
			int r, g, b;

			r_text = hex_data.Substring(0, 2);
			g_text = hex_data.Substring(2, 2);
			b_text = hex_data.Substring(4, 2);

			r = int.Parse(r_text, System.Globalization.NumberStyles.HexNumber);
			g = int.Parse(g_text, System.Globalization.NumberStyles.HexNumber);
			b = int.Parse(b_text, System.Globalization.NumberStyles.HexNumber);

			return Color.FromArgb(r, g, b);
		}


		private void UpdateTextBoxes()
		{
			m_txt_Red.Text =		m_rgb.R.ToString();
			m_txt_Green.Text =		m_rgb.G.ToString();
			m_txt_Blue.Text =		m_rgb.B.ToString();

			m_txt_Red.Update();
			m_txt_Green.Update();
			m_txt_Blue.Update();

			WriteHexData(m_rgb);
		}


		#endregion

		#region Public Methods

		public Color PrimaryColor
		{
			get
			{
				return m_rgb;
			}
			set
			{
				m_rgb = value;
				m_hsl = AdobeColors.RGB_to_HSL(m_rgb);

				m_txt_Red.Text =		m_rgb.R.ToString();
				m_txt_Green.Text =		m_rgb.G.ToString();
				m_txt_Blue.Text =		m_rgb.B.ToString();

				m_txt_Red.Update();
				m_txt_Green.Update();
				m_txt_Blue.Update();

				m_ctrl_BigBox.HSL = m_hsl;
				m_ctrl_ThinBox.HSL = m_hsl;

				m_lbl_Primary_Color.BackColor = m_rgb;
			}
		}



		public eDrawStyle DrawStyle
		{
			get
			{
				return eDrawStyle.Hue;
			}
		}


        #endregion
    }
}
