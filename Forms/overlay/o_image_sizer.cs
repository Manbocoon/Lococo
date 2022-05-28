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





namespace Lococo.Forms.overlay
{
    public partial class o_image_sizer : Form
    {
        #region Windows API
        [DllImport("user32")]
        public static extern Int32 SetWindowLong(IntPtr hWnd, Int32 nIndex, Int32 dwNewLong);
        [DllImport("user32")]
        public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 nIndex);

        #endregion


        #region Global Variables
        public o_image ParentForm { get; set; }
        public UI.Bar.mainUI ChildBar { get; set; }
        public UI.Bar.s_image ChildForm { get; set; }
        public UI.Bar.slider SliderForm { get; set; }

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

                if (!this.IsHandleCreated)
                {
                    return;
                }


                if (value)
                {
                    SetWindowLong(this.Handle, -20, originalStyle);

                    this.Invoke((MethodInvoker)delegate
                    {
                        using (var shadowClass = new Functions.UI.dropShadow())
                        {
                            shadowClass.ApplyShadows(this, 1, 1, 1, 1);
                        }
                    });
                }

                else
                {
                    SetWindowLong(this.Handle, -20, originalStyle | 0x80000 | 0x20);

                    this.Invoke((MethodInvoker)delegate
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

        private byte opacityUI_value = 80;
        public byte opacityUI
        {
            get
            {
                return opacityUI_value;
            }

            set
            {
                opacityUI_value = value;

                if (Program.IsActivated(ChildBar))
                {
                    ChildBar.opacityUI = value;
                }

                if (Program.IsActivated(ChildForm))
                {
                    ChildForm.opacityUI = value;
                }

                if (Program.IsActivated(SliderForm))
                {
                    SliderForm.opacityUI = value;
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

        public bool keepRatio { get; set; }

        private readonly string appPath = Application.StartupPath;
        #endregion



        public void DisposeChilds()
        {
            if (ChildBar != null && ChildBar.IsHandleCreated)
            {
                ChildBar.Dispose();
                ChildBar.Close();
            }

            if (ChildForm != null && ChildForm.IsHandleCreated)
            {
                ChildForm.Dispose();
                ChildForm.Close();
            }

            if (SliderForm != null && SliderForm.IsHandleCreated)
            {
                SliderForm.Dispose();
                SliderForm.Close();
            }
        }

        public o_image_sizer()
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


        public void SetUIOpacity(byte value)
        {
            float valueF = (float)value / 100;

            if (Program.IsActivated(ChildBar))
            {
                ChildBar.Opacity = valueF;
            }
        }


        private void ShowChildBar()
        {
            ChildBar = new UI.Bar.mainUI();
            ChildBar.ParentForm = this;
            ChildBar.Location = new Point(this.Left, this.Top - ChildBar.Height);
            ChildBar.Show();
        }

        private void RelocateChildForms()
        {
            if (Program.IsActivated(ChildBar))
            {
                ChildBar.Location = new Point(this.Left, this.Top - ChildBar.Height);
            }

            if (Program.IsActivated(ChildForm))
            {
                ChildForm.Location = new Point(this.Right + 5, this.Top);
            }

            if (Program.IsActivated(SliderForm))
            {
                SliderForm.Location = new Point(ChildBar.Right + 5, ChildBar.Top);
            }
        }

        public void ResizeImage()
        {
            if (Program.IsActivated(ParentForm))
            {
                ParentForm.bounds = this.Bounds;

                GC.Collect(0);
            }

        }

        public void CorrectFormRatio(bool forced)
        {
            if (!Program.IsActivated(ParentForm))
            {
                return;
            }

            Point original_ratio = Imaging.GetImageRatio(Imaging.GetImageSize(ParentForm.imgPath));

            float ratio_width = (float)original_ratio.X / original_ratio.Y;
            float ratio_height = (float)original_ratio.Y / original_ratio.X;

            int new_width = (int)(Height * ratio_width);
            int new_height = (int)(Width * ratio_height);

            if (width_delta > 0 && height_delta == 0)
            {
                Height = new_height;
            }

            else if (height_delta > 0 && width_delta == 0)
            {
                Width = new_width;
            }

            // 가로와 세로 넓이가 모두 변한 경우에는, 더 변화량이 큰 축을 기준으로 변경
            else if (width_delta > 0 && height_delta > 0)
            {
                if (width_delta >= height_delta)
                {
                    Height = new_height;
                }

                else
                {
                    Width = new_width;
                }
            }

            // 강제로 비율 수정
            else if (forced)
            {
                Height = new_height;
            }
        }

        public void CorrectFormRatio()
        {
            CorrectFormRatio(false);
        }

        private void LoadSettings()
        {
            using (var config = new Config.image())
            {
                config.LoadSettings();

                clickable = config.globalSettings.clickable;
                keepRatio = config.globalSettings.keepRatio;
            }
        }

        #region Event Handlers - Form
        private void overlayForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;

            originalStyle = GetWindowLong(this.Handle, -20);

            this.WindowState = FormWindowState.Normal;     
         
            using (var shadowClass = new Functions.UI.dropShadow())
            {
                shadowClass.ApplyShadows(this, 1, 1, 1, 1);
            }

            LoadSettings();

            ShowChildBar();
        }

        private void image_sizer_Move(object sender, EventArgs e)
        {
            if (Program.IsActivated(ParentForm))
            {
                ParentForm.Location = this.Location;
            }

            RelocateChildForms();
        }

        // CPU, 메모리 부하를 줄이기 위해 크기 조절이 끝난 이후에만 이미지 조정
        // Move 시에도 ResizeEnd 이벤트가 발생하는 것을 방지하기 위해 크기 비교를 한 이후에 이벤트 발동
        protected override void OnShown(EventArgs e)
        {
            _previousFormSize = Size;
            base.OnShown(e);
        }

        private Size _previousFormSize = Size.Empty;
        private int width_delta = 0, height_delta = 0;
        public bool ResizedByParent = false, ResizedByUser = false;
        protected override void OnResizeEnd(EventArgs e)
        {
            if (ResizedByParent)
            {
                return;
            }

            if (Size == _previousFormSize)
            { 
                return;
            }

            width_delta = Math.Abs(Width - _previousFormSize.Width);
            height_delta = Math.Abs(Height - _previousFormSize.Height);

            _previousFormSize = Size;

            if (keepRatio)
            {
                CorrectFormRatio();
            }

            ResizedByUser = true;
            ResizeImage();
            ResizedByUser = false;

            base.OnResizeEnd(e);
        }

        private void o_image_sizer_Resize(object sender, EventArgs e)
        {
            RelocateChildForms();
        }

        #endregion


    }
}
