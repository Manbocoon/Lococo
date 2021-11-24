using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using Microsoft.Win32;
using System.Security;





namespace Lococo.Forms
{
    public partial class overlayForm_boss : Form
    {
        #region Windows API
        [DllImport("user32")]
        public static extern Int32 SetWindowLong(IntPtr hWnd, Int32 nIndex, Int32 dwNewLong);
        [DllImport("user32")]
        public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 nIndex);

        [DllImport("user32")]
        public static extern Int32 GetCursorPos(out POINT pt);

        [DllImport("user32")]
        public static extern UInt16 GetAsyncKeyState(Int32 vKey);

        [DllImport("user32")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32")]
        public static extern IntPtr GetForegroundWindow();


        public struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        #endregion


        #region Global Variables
        private int originalStyle;

        private bool transparent_value;

        public string imgPath { get; set; }
        public bool load_by_originalSize { get; set; }
        #endregion



    

        public overlayForm_boss()
        {
            InitializeComponent();
        }

        #region Form - Hide from Alt+Tab Switcher / Show Shadow
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;
                Params.ExStyle |= 0x80;

                return Params;
            }
        }
        #endregion

        #region Form - Make Borderless Form as Resizable
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }
        #endregion



        #region Public Functions
        public void setTransparent(bool value)
        {//마우스 클릭, 키보드 입력 등이 관통되어 다른 앱에 전달되도록

            if (value)
                SetWindowLong(this.Handle, -20, originalStyle | 0x80000 | 0x20);

            else
                SetWindowLong(this.Handle, -20, originalStyle);


            transparent_value = value;
            this.Invalidate();
        }

        public void updateImage()
        {
            if (load_by_originalSize)
                main_picture.SizeMode = PictureBoxSizeMode.AutoSize;

            using (var img = new Functions.loadImage())
            {
                main_picture.Image = img.loadImageFromFile(imgPath);
            }

            if (load_by_originalSize)
                this.Size = new Size(main_picture.Image.Width + 2, main_picture.Image.Height + 2);
            
            main_picture.SizeMode = PictureBoxSizeMode.Zoom;
        }

        #endregion

        #region Draw Text With Shadow
        protected void drawShadowText(Graphics graphics, string text, Font textFont, Color textColor, Color shadowColor, int shadowAlpha, PointF location)
        {
            const int DISTANCE = 2;
            for (int offset = 1; 0 <= offset; offset--)
            {
                Color color = ((offset < 1) ?
                    textColor : Color.FromArgb(shadowAlpha, shadowColor));
                using (var brush = new SolidBrush(color))
                {
                    var point = new PointF()
                    {
                        X = location.X + (offset * DISTANCE),
                        Y = location.Y + (offset * DISTANCE)
                    };
                    graphics.DrawString(text, textFont, brush, point);
                }
            }
        }
        #endregion





        private void overlayForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;

            originalStyle = GetWindowLong(this.Handle, -20);

            this.WindowState = FormWindowState.Normal;

            
            using (var shadowClass = new Functions.UI.dropShadow())
            {
                shadowClass.top = 1;
                shadowClass.bottom = 1;
                shadowClass.left = 1;
                shadowClass.right = 1;

                shadowClass.ApplyShadows(this);
            }

            main_picture.Location = new Point(5, 35);
            main_picture.Size = new Size(this.Width - 10, this.Height - 40);

            updateImage();
        }

        private void overlayForm_Resize(object sender, EventArgs e)
        {
            main_picture.Location = new Point(5, 35);
            main_picture.Size = new Size(this.Width - 10, this.Height - 40);
        }

        private void overlayForm_Paint(object sender, PaintEventArgs e)
        {       
            if (!transparent_value)
            {
                drawShadowText(e.Graphics, "여기를 드래그하여 이동", new Font("굴림", 10), Color.White, Color.Black, 255, new PointF(10, 10));

                using (var shadowClass = new Functions.UI.dropShadow())
                {
                    shadowClass.top = 1;
                    shadowClass.bottom = 1;
                    shadowClass.left = 1;
                    shadowClass.right = 1;

                    shadowClass.ApplyShadows(this);
                }
            }

            else
            {
                using (var shadowClass = new Functions.UI.dropShadow())
                {
                    shadowClass.top = 0;
                    shadowClass.bottom = 0;
                    shadowClass.left = 0;
                    shadowClass.right = 0;

                    shadowClass.ApplyShadows(this);
                }
            }

        }
    }
}
