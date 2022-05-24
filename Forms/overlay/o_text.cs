using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;

namespace Lococo.Forms.overlay
{
    public partial class o_text : Form
    {
        #region Win32 API
        [DllImport("user32")]
        public static extern UInt16 GetAsyncKeyState(Int32 vKey);
        #endregion

        #region Native Methods and Structures

        const Int32 WS_EX_LAYERED = 0x80000;
        const Int32 HTCAPTION = 0x02;
        const Int32 WM_NCHITTEST = 0x84;
        const Int32 ULW_ALPHA = 0x02;
        const byte AC_SRC_OVER = 0x00;
        const byte AC_SRC_ALPHA = 0x01;

        [StructLayout(LayoutKind.Sequential)]
        struct Point
        {
            public Int32 x;
            public Int32 y;

            public Point(Int32 x, Int32 y)
            { this.x = x; this.y = y; }
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Size
        {
            public Int32 cx;
            public Int32 cy;

            public Size(Int32 cx, Int32 cy)
            { this.cx = cx; this.cy = cy; }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct ARGB
        {
            public byte Blue;
            public byte Green;
            public byte Red;
            public byte Alpha;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst,
            ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc,
            Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DeleteObject(IntPtr hObject);

        [DllImport("user32")]
        public static extern Int32 SetWindowLong(IntPtr hWnd, Int32 nIndex, Int32 dwNewLong);
        [DllImport("user32")]
        public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 nIndex);
        #endregion

        #region Global Variables
        private Bitmap target_img;

        public System.Drawing.Point form_loc = new System.Drawing.Point(0, 0);
        private int originalStyle;
        private string appPath = Application.StartupPath;
        #endregion


        public void setTransparent(bool value)
        {//마우스 클릭, 키보드 입력 등이 관통되어 다른 앱에 전달되도록

            if (value)
                SetWindowLong(this.Handle, -20, originalStyle | 0x80000 | 0x20);

            else
                SetWindowLong(this.Handle, -20, originalStyle);

            this.Invalidate();
        }

        public o_text()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.Load += PerPixelAlphaForm_Load;
        }

        void PerPixelAlphaForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Location = form_loc;

            originalStyle = GetWindowLong(this.Handle, -20);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                // Add the layered extended style (WS_EX_LAYERED) to this window.
                CreateParams createParams = base.CreateParams;

                if(!DesignMode)
                    createParams.ExStyle |= WS_EX_LAYERED;

                // Hide From Alt+Tab Switcher
                createParams.ExStyle |= 0x80;

                return createParams;
            }
        }

        /// <summary>
        /// Let Windows drag this window for us (thinks its hitting the title 
        /// bar of the window)
        /// </summary>
        /// <param name="message"></param>
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == WM_NCHITTEST)
            {
                // Tell Windows that the user is on the title bar (caption)
                message.Result = (IntPtr)HTCAPTION;
            }
            else
            {
                base.WndProc(ref message);
            }
        }


        private void resizeImage(string original_filePath, int new_width, int new_height)
        {
            Image image = Image.FromFile(original_filePath, true);
            int original_width = image.Width, original_height = image.Height;

            Image thumbnail = new Bitmap(new_width, new_height, PixelFormat.Format32bppArgb); // changed parm names
            Graphics graphic = Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            // Figure out the ratio
            double ratioX = (double)new_width / (double)original_width;
            double ratioY = (double)new_height / (double)original_height;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(original_height * ratio);
            int newWidth = Convert.ToInt32(original_width * ratio);

            // Now calculate the X,Y position of the upper-left corner 
            // (one of these will always be zero)
            int posX = Convert.ToInt32((new_width - (original_width * ratio)) / 2);
            int posY = Convert.ToInt32((new_height - (original_height * ratio)) / 2);

            graphic.Clear(Color.Transparent); // white padding
            graphic.DrawImage(image, posX, posY, newWidth, newHeight);


            if (File.Exists(appPath + @"\db\lococo_target_text.png"))
            {
                try { File.Delete(appPath + @"\db\lococo_target_text.png"); }

                catch (Exception) { }
            }

            thumbnail.Save(appPath + @"\db\lococo_target_text.png", ImageFormat.Png);
            File.SetAttributes(appPath + @"\db\lococo_target_text.png", FileAttributes.Hidden);

            thumbnail.Dispose();
            image.Dispose();
        }

        public void updateImage(string img_path, float opacity)
        {
            if (!File.Exists(img_path))
                return;

            if (target_img != null)
                target_img.Dispose();

            target_img = new Bitmap(appPath + @"\db\lococo_target_text.png");
            SelectBitmap(target_img, (int)(255 * opacity));
            target_img.Dispose();


            // Form(이미지)의 Width/Height 값을 정상적으로 받아오려면 폼을 1회 움직여야함
            this.Invoke((MethodInvoker)delegate () 
            {
                ++this.Left;
                --this.Left;
            });
        }




        // 32비트 ARGB 투명한 이미지 표시
        public void SelectBitmap(Bitmap bitmap)
        {
            SelectBitmap(bitmap, 255);
        }

        public void SelectBitmap(Bitmap bitmap, int opacity)
        {
            // Does this bitmap contain an alpha channel?
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new ApplicationException("알파 채널을 지닌 32비트 ARGB 포맷의 PNG 파일이어야 합니다.");
            }

            // Get device contexts
            IntPtr screenDc = GetDC(IntPtr.Zero);
            IntPtr memDc = CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr hOldBitmap = IntPtr.Zero;

            try
            {
                // Get handle to the new bitmap and select it into the current 
                // device context.
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                hOldBitmap = SelectObject(memDc, hBitmap);

                // Set parameters for layered window update.
                Size newSize = new Size(bitmap.Width, bitmap.Height);
                Point sourceLocation = new Point(0, 0);
                Point newLocation = new Point(this.Left, this.Top);
                BLENDFUNCTION blend = new BLENDFUNCTION();
                blend.BlendOp = AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = (byte)opacity;
                blend.AlphaFormat = AC_SRC_ALPHA;

                // Update the window.
                UpdateLayeredWindow(
                    this.Handle,     // Handle to the layered window
                    screenDc,        // Handle to the screen DC
                    ref newLocation, // New screen position of the layered window
                    ref newSize,     // New size of the layered window
                    memDc,           // Handle to the layered window surface DC
                    ref sourceLocation, // Location of the layer in the DC
                    0,               // Color key of the layered window
                    ref blend,       // Transparency of the layered window
                    ULW_ALPHA        // Use blend as the blend function
                    );
            }

            finally
            {
                // Release device context.
                ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    SelectObject(memDc, hOldBitmap);
                    DeleteObject(hBitmap);
                }
                DeleteDC(memDc);
            }
        }






    }
}