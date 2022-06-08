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
    /// <summary>
    /// 이미지 오버레이의 크기조절 편의성 향상을 위해 꼼수로 만든 창입니다. 이미지 창 위에 포개 올리고 항상 같은 크기를 유지하도록 합니다. 이 창의 이벤트 처리에 따라 이미지를 재구성합니다.
    /// </summary>
    public partial class o_image_sizer : Form
    {
        #region Windows API
        [DllImport("user32")]
        public static extern Int32 SetWindowLong(IntPtr hWnd, Int32 nIndex, Int32 dwNewLong);
        [DllImport("user32")]
        public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 nIndex);

        #endregion


        #region Global Variables
        public o_image owner { get; set; }

        public int originalStyle { get; set; }
        #endregion



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





        public void ResizeImage()
        {
            if (Program.IsActivated(owner))
            {
                owner.Location = this.Location;
                owner.updateImage(owner.imgPath, owner.opacity, Width, Height);
            }

        }

        /// <summary>
        /// 이미지 오버레이에 표시된 이미지와 거의 동일한 비율로 폼 크기를 수정합니다.
        /// </summary>
        /// <param name="forced">실제로 유저가 크기를 조절하지 않았더라도 강제로 수정합니다.</param>
        public void CorrectFormRatio(bool forced)
        {
            if (!Program.IsActivated(owner) || !File.Exists(owner.imgPath))            
                return;

            Point original_ratio = Imaging.GetImageRatio(Imaging.GetImageSize(owner.imgPath));

            float ratio_width = (float)original_ratio.X / original_ratio.Y;
            float ratio_height = (float)original_ratio.Y / original_ratio.X;

            int new_width = (int)(Height * ratio_width);
            int new_height = (int)(Width * ratio_height);

            if (forced)
            {
                Height = new_height;
                return;
            }

            if (width_delta > 0 && height_delta == 0)          
                Height = new_height;
            
            else if (height_delta > 0 && width_delta == 0)           
                Width = new_width;        

            // 가로와 세로 넓이가 모두 변한 경우에는, 더 변화량이 큰 축을 기준으로 변경
            else if (width_delta > 0 && height_delta > 0)
            {
                if (width_delta >= height_delta)              
                    Height = new_height;
                
                else               
                    Width = new_width;
            }

        }

        /// <summary>
        /// 이미지 오버레이에 표시된 이미지와 거의 동일한 비율로 폼 크기를 수정합니다.
        /// </summary>
        public void CorrectFormRatio()
        {
            CorrectFormRatio(false);
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
                shadowClass.ApplyShadows(this, 1, 1, 1, 1);

            owner = (o_image)Owner;
        }

        private void image_sizer_Move(object sender, EventArgs e)
        {
            if (Program.IsActivated(owner))
                owner.Location = this.Location;
            
            _public.PlaceChilds(owner);
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
                return;           

            if (Size == _previousFormSize)          
                return;

            width_delta = Math.Abs(Width - _previousFormSize.Width);
            height_delta = Math.Abs(Height - _previousFormSize.Height);

            if (owner.keepRatio)          
                CorrectFormRatio(); 

            ResizedByUser = true;
            ResizeImage();
            ResizedByUser = false;

            width_delta = 0;
            height_delta = 0;

            _public.PlaceChilds(owner);

            _previousFormSize = Size;

            base.OnResizeEnd(e);
        }

        private void o_image_sizer_Resize(object sender, EventArgs e)
        {
            _public.PlaceChilds(owner);
        }


        public void CallResizeEvent()
        {
            ResizedByParent = true;
            ++this.Width;

            ResizedByParent = false;
            --this.Width;
        }
        #endregion


    }
}
