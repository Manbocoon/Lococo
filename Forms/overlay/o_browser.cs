﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;



namespace Lococo.Forms.overlay
{

    /// <summary>
    /// 브라우저 오버레이 창입니다.
    /// </summary>
    public partial class o_browser : Form
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
        public Thread hotkeyThread;

        public UI.Bar.mainUI ChildBar { get; set; }
        public UI.Bar.s_browser SettingsForm { get; set; }
        public UI.Bar.slider SliderForm { get; set; }

        private string URL_value = "https://lostark.inven.co.kr/dataninfo/world/?code=10201";
        public string URL
        {
            get
            {
                return URL_value;
            }

            set
            {
                URL_value = value;

                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        try
                        {
                            webViewer.Source = new Uri(value);
                        }

                        catch (UriFormatException)
                        {

                        }
                    });
                }
            }
        }

        private ushort zoom_value = 100;
        public ushort zoom
        {
            get
            {
                this.Invoke((MethodInvoker)delegate
                {
                    zoom_value = (ushort)(webViewer.ZoomFactor * 100);
                });

                return zoom_value;
            }

            set
            {
                zoom_value = value;

                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker) delegate
                    {
                        webViewer.ZoomFactor = (double)value / 100;
                    });
                }
            }
        }

        private byte opacity_value = 80;
        public byte opacity
        {
            get
            {
                this.Invoke((MethodInvoker)delegate
                {
                    opacity_value = (byte)(this.Opacity * 100);
                });

                return opacity_value;
            }

            set
            {
                opacity_value = value;

                if (this.IsHandleCreated)
                {
                    this.Opacity = (double)value / 100;
                }
            }
        }

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
        #endregion

        #region Private Variables
        private readonly string appPath = Application.StartupPath;

        private List<string> map_list = new List<string>();

        #endregion


        public void DisposeChilds()
        {
            if (Program.IsActivated(ChildBar))         
                ChildBar.Dispose();
            
            if (Program.IsActivated(SettingsForm))           
                SettingsForm.Dispose();
            
            if (Program.IsActivated(SliderForm))
                SliderForm.Dispose();
        }



        public o_browser()
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


        /// <summary>
        /// 키보드 방향키 <- -> 를 실시간으로 감지하고 로스트아크 인벤 지도의 현재 맵을 변경시키는 스레드에 사용될 함수입니다.
        /// </summary>
        private void hotkeyFunc()
        {
            byte pressedKey = 0;
            IntPtr currentHwnd = IntPtr.Zero;
            StringBuilder currentHwnd_Caption = new StringBuilder(null, 1000);

            // 핫키 감지를 위해 UI와 다른 쓰레드에서 35ms마다 무한 반복
            while (true)
            {
                if (pressedKey > 0)
                {
                    Thread.Sleep(35);
                    continue;
                }

                // 올바른 키가 눌렸다면 현재 단축키 사용이 유효한 창인지 확인
                // 로스트아크, 로코코에서만 단축키가 발동하도록 최상단 창의 캡션을 가져와 구분
                if (GetAsyncKeyState((int)Keys.Left) > 32767 || GetAsyncKeyState((int)Keys.Right) > 32767)
                {
                    currentHwnd = GetForegroundWindow();

                    currentHwnd_Caption.Clear();
                    GetWindowText(currentHwnd, currentHwnd_Caption, 900);

                    if (!currentHwnd_Caption.ToString().StartsWith("LOST ARK"))
                    {
                        if (currentHwnd_Caption.ToString() != "로코코" && currentHwnd_Caption.ToString() != "Lococo - Overlay")
                        {
                            Thread.Sleep(35);
                            continue;
                        }
                    }

                    // 현재 어떤 키를 눌렀는지 구분
                    if (GetAsyncKeyState((int)Keys.Left) > 32767)
                        pressedKey = 2;
                    else if (GetAsyncKeyState((int)Keys.Right) > 32767)
                        pressedKey = 3;

                    // GetAsyncKeyState API는 키의 다운과 업을 감지하지 못하고 눌림과 뗌만 감지하므로, 눌러져 있는 동안 쓰레드를 무한 중지시켜 임의로 구분
                    // 키가 떼지는 순간 재생. 키를 다시 한번 누르기 전까진 발동하지 않도록 하기 위함
                    while (true)
                    {
                        if (GetAsyncKeyState((int)Keys.Left) > 32767 || GetAsyncKeyState((int)Keys.Right) > 32767)
                        { Thread.Sleep(1); }

                        else
                            break;
                    }



                    // 현재 브라우저의 링크를 읽어오고, 로스트아크 인벤지도라면 어떤 맵인지 코드를 가져오기
                    string current_urlCode = webViewer.Source.ToString();
                    current_urlCode = current_urlCode.Remove(0, current_urlCode.IndexOf('=') + 1);

                    for (int index=0; index<map_list.Count; ++index)
                    {
                        // 현재 맵의 순서를 찾았다면
                        if (current_urlCode == map_list[index])
                        {
                            // ← 입력 시 이전 맵으로 이동
                            if (pressedKey == 2)
                            {
                                if (index > 0)
                                {
                                    URL = "https://lostark.inven.co.kr/dataninfo/world/?code=" + map_list[index - 1];
                                }
                            }

                            // → 입력 시 다음 맵으로 이동
                            else if (pressedKey == 3)
                            { 
                                if (index < map_list.Count - 1)
                                {
                                    URL = "https://lostark.inven.co.kr/dataninfo/world/?code=" + map_list[index + 1];
                                }
                            }
                        }
                    }

                }

                pressedKey = 0;
                Thread.Sleep(35);
            }
        }

        private void GetMapList()
        {
            if (!File.Exists(appPath + @"\db\map_list.ini"))
            {
                Program.ShowMsgbox("모험의 서 맵 변경 단축키(→ ←)가 작동하지 않을 수 있습니다.\r\n\r\n프로그램을 재시작하면 해결됩니다.", "알림");
                return;
            }

            map_list.Clear();

            string file_data = File.ReadAllText(appPath + @"\db\map_list.ini", Encoding.UTF8);
            string[] map_codes = file_data.Split(' ');
            for (int index = 0; index < map_codes.Length; ++index)
                map_list.Add(map_codes[index]);
        }

        public void SaveSettings()
        {
            hotkeyThread.Abort();

            using (var config = new Config.overlay())
            {
                config.Owner = this;

                config.SaveSettings();
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

            using (var shadowClass = new Functions.UI.dropShadow())
            {
                shadowClass.ApplyShadows(this, 1, 1, 1, 1);
            }

            GetMapList();

            // 설정 불러오기
            using (var config = new Config.overlay())
            {
                config.Owner = this;

                config.ReadSettings();
                config.ApplySettings();
            }

            _public.ShowChildBar(this);

            /* using (var IEClass = new Functions.changeIEVersion())
            {
                if (!IEClass.IsBrowserEmulationSet())
                    IEClass.SetBrowserEmulationVersion();
            } 
            */
        }

        private void overlayForm_Resize(object sender, EventArgs e)
        {
            webViewer.Size = new Size(this.Width - 10, this.Height - 35);

            _public.PlaceChilds(this);
        }

        private void overlayForm_Move(object sender, EventArgs e)
        {
            _public.PlaceChilds(this);
        }

        private void overlayForm_Paint(object sender, PaintEventArgs e)
        {
            if (clickable)
                drawShadowText(e.Graphics, "여기를 드래그하여 이동", new Font("굴림", 10), Color.White, Color.Black, 255, new PointF(10, 10));
        }



        private void webViewer_ZoomFactorChanged(object sender, EventArgs e)
        {
            if (Program.IsActivated(SettingsForm))
            {
                SettingsForm.zoomValue = zoom;
            }
        }
    }
}
