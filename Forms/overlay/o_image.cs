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
    /// <summary>
    /// 이미지 오버레이 창입니다.
    /// </summary>
    public partial class o_image : Form
    {
        #region Windows API
        [DllImport("user32")]
        public static extern Int32 SetWindowLong(IntPtr hWnd, Int32 nIndex, Int32 dwNewLong);
        [DllImport("user32")]
        public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 nIndex);

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

        private const Int32 WS_EX_LAYERED = 0x80000;
        private const Int32 HTCAPTION = 0x02;
        private const Int32 WM_NCHITTEST = 0x84;
        private const Int32 ULW_ALPHA = 0x02;
        private const byte AC_SRC_OVER = 0x00;
        private const byte AC_SRC_ALPHA = 0x01;
        #endregion


        #region Global Variables
        public o_image_sizer SizerForm { get; set; }
        public UI.Bar.mainUI ChildBar { get; set; }
        public UI.Bar.s_image SettingsForm { get; set; }
        public UI.Bar.slider SliderForm { get; set; }

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

                if (!SizerForm.IsHandleCreated)
                {
                    return;
                }


                if (value)
                {
                    SetWindowLong(SizerForm.Handle, -20, SizerForm.originalStyle);

                    SizerForm.Invoke((MethodInvoker)delegate
                    {
                        using (var shadowClass = new Functions.UI.dropShadow())
                        {
                            shadowClass.ApplyShadows(SizerForm, 1, 1, 1, 1);
                        }
                    });
                }

                else
                {
                    SetWindowLong(SizerForm.Handle, -20, SizerForm.originalStyle | 0x80000 | 0x20);

                    SizerForm.Invoke((MethodInvoker)delegate
                    {
                        using (var shadowClass = new Functions.UI.dropShadow())
                        {
                            shadowClass.ApplyShadows(SizerForm, 0, 0, 0, 0);
                        }
                    });
                }

                SizerForm.Invalidate();
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

        private bool visible_value = true;
        public bool visible
        {
            get => visible_value;

            set
            {
                visible_value = value;

                if (IsHandleCreated)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        Visible = value;
                    });
                }
            }
        }

        public bool useOriginalSize { get; set; }

        public bool keepRatio { get; set; }
        #endregion

        #region Private Variables
        public Bitmap target_img;
        #endregion


        
        public void DisposeChilds()
        {
            if (target_img != null)
                target_img.Dispose();

            if (Program.IsActivated(ChildBar))           
                ChildBar.Dispose();
            
            if (Program.IsActivated(SettingsForm))
                SettingsForm.Dispose();
            
            if (Program.IsActivated(SliderForm))    
                SliderForm.Dispose();
            
            if (Program.IsActivated(SizerForm))
                SizerForm.Dispose();        
        }


        public o_image()
        {
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            Load += PerPixelAlphaForm_Load;
        }

        public void SaveSettings()
        {
            using (var config = new Config.overlay())
            {
                config.Owner = this;

                config.SaveSettings();
            }
        }



        void PerPixelAlphaForm_Load(object sender, EventArgs e)
        {
            TopMost = true;

            // 포개진 Sizer 폼이 클릭 가능하므로 클릭 불가능하도록 고정
            int myOriginalStyle = GetWindowLong(Handle, -20);
            SetWindowLong(Handle, -20, myOriginalStyle | 0x80000 | 0x20);

            // 이미지 위를 포개서 보여줄 크기조절 폼
            SizerForm = new o_image_sizer();
            SizerForm.Show(this);

            // 설정 불러오기
            using (var config = new Config.overlay())
            {
                config.Owner = this;

                config.ReadSettings();
                config.ApplySettings();
            }
            SizerForm.Bounds = Bounds;

            updateImage(imgPath, opacity, Width, Height);

            _public.ShowChildBar(this);
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
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new ApplicationException("알파 채널을 지닌 32비트 ARGB 포맷의 PNG 파일이어야 합니다.");
            }

            IntPtr screenDc = GetDC(IntPtr.Zero);
            IntPtr memDc = CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr hOldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                hOldBitmap = SelectObject(memDc, hBitmap);

                Size newSize = new Size(bitmap.Width, bitmap.Height);
                Point sourceLocation = new Point(0, 0);
                Point newLocation = new Point(Left, Top);
                BLENDFUNCTION blend = new BLENDFUNCTION();
                blend.BlendOp = AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = (byte)opacity;
                blend.AlphaFormat = AC_SRC_ALPHA;


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






        public Bitmap SaveResizedImage(string original_filePath, int new_width, int new_height)
        {
            Image image = Image.FromFile(original_filePath, true);
            int original_width = image.Width, original_height = image.Height;

            if ((useOriginalSize && !SizerForm.ResizedByUser) 
                || (original_width == new_width && original_height == new_height))
            {
                return (Bitmap)image;
            }

            Image resized_image = new Bitmap(new_width, new_height, PixelFormat.Format32bppArgb);
            Graphics graphic = Graphics.FromImage(resized_image);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            double ratioX = (double)new_width / (double)original_width;
            double ratioY = (double)new_height / (double)original_height;

            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            int newHeight = (int)(original_height * ratio);
            int newWidth = (int)(original_width * ratio);

            int posX = (int)((new_width - (original_width * ratio)) / 2);
            int posY = (int)((new_height - (original_height * ratio)) / 2);

            graphic.Clear(Color.Transparent); // padding
            graphic.DrawImage(image, posX, posY, newWidth, newHeight);

            image.Dispose();
            return (Bitmap)resized_image;
        }

        public void updateImage(string img_path, byte opacity, int new_width, int new_height)
        {
            if (!Imaging.IsSupportedImage(img_path))
            {
                target_img = new Bitmap(Properties.Resources.no_image);
                SelectBitmap(Properties.Resources.no_image, 255);

                SizerForm.Size = target_img.Size;

                return;
            }

            if (target_img == null)            
                target_img = new Bitmap(1, 1);
            
            if (target_img.Width != new_width || target_img.Height != new_height)
            {
                target_img.Dispose();

                target_img = SaveResizedImage(img_path, new_width, new_height);
                SelectBitmap(target_img, (int)(255 * (float)opacity / 100));
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

            GC.Collect(0);
        }

        private void updateOpacity()
        {
            if (target_img != null)
                SelectBitmap(target_img, (int)(255 * (float)opacity / 100));
        }
        #endregion

    }
}