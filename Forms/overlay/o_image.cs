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
    public partial class o_image : Form
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
        public o_image_sizer SizerForm { get; set; }

        private int originalStyle;
        private bool clickable_value = true;
        public bool clickable
        {
            get
            {
                return clickable_value;
            }

            set
            {
                clickable_value = value;

                if (!IsHandleCreated)
                {
                    return;
                }


                if (value)
                {
                    SetWindowLong(Handle, -20, originalStyle);

                    Invoke((MethodInvoker)delegate
                    {
                        using (var shadowClass = new Functions.UI.dropShadow())
                        {
                            shadowClass.ApplyShadows(this, 1, 1, 1, 1);
                        }
                    });
                }

                else
                {
                    SetWindowLong(Handle, -20, originalStyle | 0x80000 | 0x20);

                    Invoke((MethodInvoker)delegate
                    {
                        using (var shadowClass = new Functions.UI.dropShadow())
                        {
                            shadowClass.ApplyShadows(this, 0, 0, 0, 0);
                        }
                    });
                }

                Invalidate();
            }
        }

        private byte opacity_value = 80;
        public byte opacity
        {
            get
            {
                return opacity_value;
            }

            set
            {
                opacity_value = value;

                if (IsHandleCreated)
                {
                    updateOpacity();
                }
            }
        }

        private Rectangle bounds_value;
        public Rectangle bounds
        {
            get
            {
                return bounds_value;
            }

            set
            {
                bounds_value = value;

                Location = value.Location;

                updateImage(imgPath, opacity, value.Width, value.Height);
            }
        }

        private string imgPath_value;
        public string imgPath
        {
            get
            {
                return imgPath_value;
            }

            set
            {
                if (File.Exists(value))
                {
                    imgPath_value = value;
                }
            }
        }

        public bool useOriginalSize { get; set; }
        #endregion

        #region Private Variables
        private Bitmap target_img;

        private readonly string appPath = Application.StartupPath;
        #endregion


        
        public void DisposeChilds()
        {

            if (Program.IsActivated(SizerForm))
            {
                SizerForm.DisposeChilds();

                SizerForm.Dispose();
                SizerForm.Close();
            }
        }

        public o_image()
        {
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            Load += PerPixelAlphaForm_Load;
        }

        private void LoadSettings()
        {
            using (config.image config = new config.image())
            {
                config.ResetSettings();
                config.LoadSettings();

                imgPath = config.globalSettings.imgPath;
                opacity = config.globalSettings.opacity;
                bounds = config.globalSettings.bounds;

                useOriginalSize = config.globalSettings.useOriginalSize;
            }
        }

        public void SaveSettings()
        {
            using (config.image config = new config.image())
            {
                config.ParentForm = this;
                config.SizerForm = this.SizerForm;

                config.SaveSettings();
            }
        }

        void PerPixelAlphaForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            originalStyle = GetWindowLong(Handle, -20);
            clickable = false;

            LoadSettings();

            SizerForm = new o_image_sizer();
            SizerForm.Bounds = Bounds;
            SizerForm.ParentForm = this;
            SizerForm.Show();
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




        #region Functions for Image
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
                Point newLocation = new Point(Left, Top);
                BLENDFUNCTION blend = new BLENDFUNCTION();
                blend.BlendOp = AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = (byte)opacity;
                blend.AlphaFormat = AC_SRC_ALPHA;

                // Update the window.
                UpdateLayeredWindow(
                    Handle,     // Handle to the layered window
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






        private void SaveResizedImage(string original_filePath, int new_width, int new_height)
        {
            Image image = Image.FromFile(original_filePath, true);
            int original_width = image.Width, original_height = image.Height;

            if ((useOriginalSize && !SizerForm.ResizedByUser) 
                || (original_width == new_width && original_height == new_height))
            {
                image.Save(appPath + @"\db\lococo_target_image.png", ImageFormat.Png);
                File.SetAttributes(appPath + @"\db\lococo_target_image.png", FileAttributes.Hidden);

                image.Dispose();
                return;
            }

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


            if (File.Exists(appPath + @"\db\lococo_target_image.png"))
            {
                try { File.Delete(appPath + @"\db\lococo_target_image.png"); }

                catch (Exception) { }
            }

            thumbnail.Save(appPath + @"\db\lococo_target_image.png", ImageFormat.Png);
            File.SetAttributes(appPath + @"\db\lococo_target_image.png", FileAttributes.Hidden);

            thumbnail.Dispose();
            image.Dispose();
        }

        public void updateImage(string img_path, byte opacity, int new_width, int new_height)
        {
            if (!File.Exists(img_path))
            {
                SelectBitmap(Properties.Resources.no_image, 255);
            }

            else
            {
                if (target_img != null)
                    target_img.Dispose();
                
                SaveResizedImage(img_path, new_width, new_height);

                target_img = new Bitmap(appPath + @"\db\lococo_target_image.png");
                SelectBitmap(target_img, (int)(255 * (float)opacity / 100));
                target_img.Dispose();

            }

            // Form(이미지)의 Width/Height 값을 정상적으로 받아오려면 폼을 1회 움직여야함
            Invoke((MethodInvoker)delegate () 
            {
                ++Left;
                --Left;
            });

            if (Program.IsActivated(SizerForm) && Size != SizerForm.Size)
            {
                SizerForm.ResizedByParent = true;
                SizerForm.Size = Size;
                SizerForm.ResizedByParent = false;
            }
        }

        private void updateOpacity()
        {
            if (target_img != null)
                target_img.Dispose();

            if (File.Exists(Program.path + @"\db\lococo_target_image.png"))
            {
                target_img = new Bitmap(Program.path + @"\db\lococo_target_image.png");
                SelectBitmap(target_img, (int)(255 * (float)opacity / 100));
                target_img.Dispose();
            }
        }
        #endregion

    }
}