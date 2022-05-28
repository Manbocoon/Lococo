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
        public UI.Bar.s_browser ChildForm { get; set; }
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

        private byte opacityUI_value = 80;
        public byte opacityUI
        {
            get
            {
                return opacity_value;
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

        public void SetUIOpacity(byte value)
        {
            float valueF = (float)value / 100;

            if (Program.IsActivated(ChildBar))
            {
                ChildBar.Opacity = valueF;
            }
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
                MessageBox.Show("모험의 서 단축키 기능(→ ←)이 작동하지 않을 수 있습니다.\r\n\r\n" + appPath + @"\db\map_list.ini" + " 파일이 발견되지 않았습니다.", "알림", 0, MessageBoxIcon.Exclamation);
                return;
            }

            map_list.Clear();

            string file_data = File.ReadAllText(appPath + @"\db\map_list.ini", Encoding.UTF8);
            string[] map_codes = file_data.Split(' ');
            for (int index = 0; index < map_codes.Length; ++index)
                map_list.Add(map_codes[index]);
        }

        private void LoadSettings()
        {
            using (var config = new Config.browser())
            {
                config.LoadSettings();

                this.Bounds = config.globalSettings.bounds;
                this.URL = config.globalSettings.URL;
                this.clickable = config.globalSettings.clickable;
                this.opacity = config.globalSettings.opacity;
                this.zoom = config.globalSettings.zoom;
            }
        }

        public void SaveSettings()
        {
            hotkeyThread.Abort();

            using (var config = new Config.browser())
            {
                config.ParentForm = this;

                config.SaveSettings();
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
            if (ChildBar != null && ChildBar.IsHandleCreated)
            {
                ChildBar.Location = new Point(this.Left, this.Top - ChildBar.Height);
            }

            if (ChildForm != null && ChildForm.IsHandleCreated)
            {
                ChildForm.Location = new Point(this.Right + 5, this.Top);
            }

            if (SliderForm != null && SliderForm.IsHandleCreated)
            {
                SliderForm.Location = new Point(ChildBar.Right + 5, ChildBar.Top);
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

            LoadSettings();

            ShowChildBar();



            /* using (var IEClass = new Functions.changeIEVersion())
            {
                if (!IEClass.IsBrowserEmulationSet())
                    IEClass.SetBrowserEmulationVersion();
            } */
           
        }

        private void overlayForm_Resize(object sender, EventArgs e)
        {
            webViewer.Size = new Size(this.Width - 10, this.Height - 35);

            RelocateChildForms();
        }

        private void overlayForm_Move(object sender, EventArgs e)
        {
            RelocateChildForms();
        }

        private void overlayForm_Paint(object sender, PaintEventArgs e)
        {
            if (clickable)
                drawShadowText(e.Graphics, "여기를 드래그하여 이동", new Font("굴림", 10), Color.White, Color.Black, 255, new PointF(10, 10));
        }



        private void webViewer_ZoomFactorChanged(object sender, EventArgs e)
        {
            if (ChildForm != null && ChildForm.IsHandleCreated)
            {
                ChildForm.zoomValue = zoom;
            }
        }
    }
}
