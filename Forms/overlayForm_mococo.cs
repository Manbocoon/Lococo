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
    public partial class overlayForm_mococo : Form
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

        public Thread hotkeyThread;
        public string webURL { get; set; }
        #endregion



    

        public overlayForm_mococo()
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

        public void navigateBrowser()
        {
            browser.Navigate(webURL);
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

        private void hotkeyFunc()
        {
            byte pressedKey = 0;
            IntPtr currentHwnd = IntPtr.Zero;
            StringBuilder currentHwnd_Caption = new StringBuilder(null, 1000);

            while (true)
            {
                if (pressedKey > 0)
                {
                    Thread.Sleep(35);
                    continue;
                }


                if (GetAsyncKeyState((int)Keys.Left) > 32767 || GetAsyncKeyState((int)Keys.Right) > 32767)
                {
                    currentHwnd = GetForegroundWindow();

                    currentHwnd_Caption.Clear();
                    GetWindowText(currentHwnd, currentHwnd_Caption, 900);
                    
                    if (!currentHwnd_Caption.ToString().StartsWith("LOST ARK"))
                    {
                        Thread.Sleep(35);
                        continue;
                    }


                    if (GetAsyncKeyState((int)Keys.Left) > 32767)
                        pressedKey = 2;

                    else if (GetAsyncKeyState((int)Keys.Right) > 32767)
                        pressedKey = 3;


                    while (true)
                    {
                        if (GetAsyncKeyState((int)Keys.Left) > 32767 || GetAsyncKeyState((int)Keys.Right) > 32767)
                        { Thread.Sleep(1); }

                        else
                            break;
                    }


                    byte continent_count = 0;
                    byte area_count = 0;
                    string current_urlCode = browser.Url.ToString();
                    string workingDir = Application.StartupPath + "\\db\\maps";
                    current_urlCode = current_urlCode.Remove(0, current_urlCode.IndexOf('=') + 1);


                    using (var config = new Functions.manageConfig())
                    {
                        byte.TryParse(config.readConfig("Continent", "Count", workingDir + "\\list.ini"), out continent_count);

                        for (byte c_index = 1; c_index < continent_count + 1; ++c_index)
                        {
                            byte.TryParse(config.readConfig("Area", "Count", workingDir + "\\" + c_index.ToString() + "\\list.ini"), out area_count);

                            for (byte a_index = 0; a_index < area_count; ++a_index)
                            {
                                if (current_urlCode == config.readConfig("Area List", a_index.ToString(), workingDir + "\\" + c_index.ToString() + "\\list.ini"))
                                {
                                    // 현재 URL주소가 어떤 맵을 가리키는지 발견했다면
                                    if (pressedKey == 2)
                                    {// 이전 맵으로 이동
                                        if (c_index > 1)
                                        {
                                            if (a_index == 0)
                                            {
                                                byte previousArea_maxCount = 0;
                                                byte.TryParse(config.readConfig("Area", "Count", workingDir + "\\" + (c_index - 1).ToString() + "\\list.ini"), out previousArea_maxCount);

                                                browser.Navigate("https://lostark.inven.co.kr/dataninfo/world/?code=" + config.readConfig("Area List", (previousArea_maxCount - 1).ToString(), workingDir + "\\" + (c_index - 1).ToString() + "\\list.ini"));
                                            }

                                            else
                                                browser.Navigate("https://lostark.inven.co.kr/dataninfo/world/?code=" + config.readConfig("Area List", (a_index - 1).ToString(), workingDir + "\\" + c_index.ToString() + "\\list.ini"));
                                        }

                                        else if (a_index != 0)
                                            browser.Navigate("https://lostark.inven.co.kr/dataninfo/world/?code=" + config.readConfig("Area List", (a_index - 1).ToString(), workingDir + "\\" + c_index.ToString() + "\\list.ini"));
                                    }

                                    else if (pressedKey == 3)
                                    {// 다음 맵으로 이동
                                        if (c_index < continent_count)
                                        {
                                            if (a_index == area_count-1)
                                                browser.Navigate("https://lostark.inven.co.kr/dataninfo/world/?code=" + config.readConfig("Area List", "0", workingDir + "\\" + (c_index + 1).ToString() + "\\list.ini"));

                                            else
                                                browser.Navigate("https://lostark.inven.co.kr/dataninfo/world/?code=" + config.readConfig("Area List", (a_index+1).ToString(), workingDir + "\\" + c_index.ToString() + "\\list.ini"));
                                        }

                                        else if (a_index != area_count-1)
                                            browser.Navigate("https://lostark.inven.co.kr/dataninfo/world/?code=" + config.readConfig("Area List", (a_index + 1).ToString(), workingDir + "\\" + c_index.ToString() + "\\list.ini"));


                                    }

                                }
                            }
                        }
                    }


                }

                pressedKey = 0;
                Thread.Sleep(35);
            }
        }




        private void overlayForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;

            originalStyle = GetWindowLong(this.Handle, -20);

            this.WindowState = FormWindowState.Normal;
           

            hotkeyThread = new Thread(hotkeyFunc);
            hotkeyThread.IsBackground = true;
            hotkeyThread.Start();

            using (var IEClass = new Functions.changeIEVersion())
            {
                if (!IEClass.IsBrowserEmulationSet())
                    IEClass.SetBrowserEmulationVersion();
            }

            browser.Navigate(webURL);

            using (var shadowClass = new Functions.UI.dropShadow())
            {
                shadowClass.top = 1;
                shadowClass.bottom = 1;
                shadowClass.left = 1;
                shadowClass.right = 1;

                shadowClass.ApplyShadows(this);
            }

        }

        private void overlayForm_Resize(object sender, EventArgs e)
        {
            browser.Size = new Size(this.Width - 10, this.Height - 35);
        }

        private void overlayForm_Paint(object sender, PaintEventArgs e)
        {
            if (!transparent_value)
                drawShadowText(e.Graphics, "여기를 드래그하여 이동", new Font("굴림", 10), Color.White, Color.Black, 255, new PointF(10, 10));
        }
    }
}
