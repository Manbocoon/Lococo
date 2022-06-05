using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;




namespace Lococo.Forms.menus
{
    public partial class menu_overlay : UserControl
    {
        #region API
        [DllImport("user32")]
        public static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        [DllImport("user32")]
        public static extern Int32 GetCursorPos(out POINT pt);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public struct POINT
        {
            public Int32 x;
            public Int32 y;
        }
        #endregion

        #region Private Variables
        private Thread mapInfoThread;
        #endregion

        #region Public Variables
        public overlay.mainUI overlayUIForm;

        public bool Overlay_Toggle
        {
            get
            {
                return open_overlay.Checked;
            }
        }

        public bool Relying_On_Game
        {
            get
            {
                return relying.Checked;
            }
        }

        public byte UI_Opacity
        {
            get
            {
                return (byte)opacity.Value;
            }
        }
        #endregion





        public menu_overlay()
        {
            InitializeComponent();
        }







        #region App Functions

        private List<string> map_list = new List<string>();
        /// <summary>
        /// 모험의 서 (로스트아크 인벤 지도)의 각 맵에 대한 링크 코드번호를 가져옵니다.
        /// </summary>
        private void getMapInfo()
        {
            map_list.Clear();
            string data = null;

            using (WebClient webClient = new WebClient())
            {
                string map_html = "";

                webClient.Encoding = Encoding.UTF8;

                try { map_html = webClient.DownloadString("https://lostark.inven.co.kr/dataninfo/world/"); }
                catch (Exception)
                { return; }

                // 각 맵에 대한 링크 번호 가져오기
                string[] map_html_line = map_html.Split('\n');
                for (uint index=0; index<map_html_line.Length; ++index)
                {
                    if (map_html_line[index].Contains("\"code\":"))
                    {
                        data = Regex.Replace(map_html_line[index], @"[\\].....", "");
                        data = data.Replace("\"name\":", null);

                        break;
                    }
                }

                // 링크 정보 코드만 가져오고, 항해쪽(50000이 넘는 코드)은 제외
                string[] codes = data.Split(new string[] { "\"code\":" }, StringSplitOptions.RemoveEmptyEntries );
                for (int index=1; index<codes.Length; ++index)
                {
                    string code = codes[index].Substring(0, 5);

                    uint.TryParse(code, out uint code_num);
                    if (code_num > 39999)
                        break;

                    else
                        map_list.Add(code);   
                }

                // 읽어온 맵 링크 코드번호를 파일로 작성
                string file_data = null;
                for (int index=0; index<map_list.Count; ++index)
                    file_data += map_list[index] + ' ';

                file_data = file_data.Remove(file_data.Length - 1, 1);

                Config._public.CreateDirectories();
                File.WriteAllText(Program.Path + @"\db\map_list.ini", file_data, Encoding.UTF8);           
            }
        }

        private bool checkWebview2RuntimeInstalled()
        {
            bool result = false;

            // 제어판 - 프로그램 삭제에서 나타나는 32비트 프로그램들 체크
            RegistryKey key_32bit = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall", false);

            string[] programs = key_32bit.GetSubKeyNames();
            for (uint index=0; index<programs.Length; ++index)
            {
                RegistryKey program = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\" + programs[index], false);

                string displayName = program.GetValue("DisplayName", "").ToString();
                if (displayName == "Microsoft Edge WebView2 런타임")
                {
                    result = true;
                    break;
                }
            }
            key_32bit.Close();

            return result;
        }

        private void ClearBrowsingData()
        {
            string cacheDirectory = null;

            string[] directories = Directory.GetDirectories(Program.Path);
            foreach (string dirPath in directories)
            {
                if (dirPath.ToLower().EndsWith(".exe.webview2"))
                    cacheDirectory = dirPath + "\\EBWebView";
            }

            if (cacheDirectory == null)
                return;

            string[] dir_exceptions = new string[] { "Default", "GrShaderCache", "ShaderCache" };
            string[] rootDirs = Directory.GetDirectories(cacheDirectory);
            foreach (string dir in rootDirs)
            {
                bool isException = false;
                foreach (string exception in dir_exceptions)
                {
                    if (dir.EndsWith(exception))
                    {
                        isException = true;
                        break;
                    }
                }

                if (!isException)
                {
                    try
                    { Directory.Delete(dir, true); }

                    catch (Exception) { }
                }
            }

            // 쿠키 = Network, Login Data, Local Storage
            dir_exceptions = new string[] { "Network", "GPUCache", "Local Storage" };
            string[] file_exceptions = new string[] { "Login Data", "History", "Visited Links", "Web Data", "WebAssistDatabase"};

            rootDirs = Directory.GetDirectories(cacheDirectory + "\\Default");
            foreach (string dir in rootDirs)
            {
                bool isException = false;
                foreach (string exception in dir_exceptions)
                {
                    if (dir.EndsWith(exception))
                    {
                        isException = true;
                        break;
                    }
                }

                if (!isException)
                {
                    try
                    { Directory.Delete(dir, true); }

                    catch (Exception) { }
                }
            }

            rootDirs = Directory.GetFiles(cacheDirectory + "\\Default");
            foreach (string file in rootDirs)
            {
                bool isException = false;
                foreach (string exception in file_exceptions)
                {
                    if (file.EndsWith(exception))
                    {
                        isException = true;
                        break;
                    }
                }

                if (!isException)
                {
                    try
                    { File.Delete(file); }

                    catch (Exception) { }
                }
            }
        }
        #endregion



        private void LoadSettings()
        {
            using (var config_ui = new Config.mainUI())
            {
                config_ui.ParentForm = this;

                config_ui.LoadSettings();

                open_overlay.Checked = config_ui.globalSettings.Overlay_Toggle;
                relying.Checked = config_ui.globalSettings.Relying_On_Game;
                opacity.Value = config_ui.globalSettings.UI_Opacity;

                open_overlay_Click(open_overlay, new EventArgs());
                relying_Click(relying, new EventArgs());
            }
        }

        private void menu_browser_Load(object sender, EventArgs e)
        {
            ClearBrowsingData();

            // .NET WebView2 런타임이 설치되지 않으면 안내 메세지 남기기
            if (!checkWebview2RuntimeInstalled())
            {
                Program.ShowMsgbox(".NET WebView2 런타임이 설치되지 않은 것 같습니다.\r\n\r\n브라우저 오버레이를 사용하시려면 \"MSEdge_Webview2_Runtime.exe\" 파일을 설치해주세요.", "알림", false);

                string search_result = _File.SearchFile(Program.Path, "MSEdge_Webview2_Runtime.exe");
                if (search_result != null)
                {
                    _File.SelectFileWithExplorer(search_result);
                }
            }


            // 인터넷이 연결되었고 서버가 정상인 경우 모험의 서(인벤 지도) → ← 단축키 사용을 위한 맵 링크 정보 가져오는 쓰레드 실행
            bool network_connected = NetworkInterface.GetIsNetworkAvailable();
            if (network_connected)
            {
                mapInfoThread = new Thread(getMapInfo);
                mapInfoThread.IsBackground = true;
                mapInfoThread.Start();
            }

            LoadSettings();
        }


        private void label_overlay_Click(object sender, EventArgs e)
        {
            open_overlay.Checked = !open_overlay.Checked;
            open_overlay_Click(open_overlay, new EventArgs());
        }

        private void open_overlay_Click(object sender, EventArgs e)
        {
            if (open_overlay.Checked)
            {
                overlayUIForm = new overlay.mainUI();
                overlayUIForm.Opacity = (float)opacity.Value / 100;
                overlayUIForm.relying = relying.Checked;
                overlayUIForm.Location = new Point((Program.screen.Width - overlayUIForm.Width) / 2, 0);
                overlayUIForm.Show(this);
            }

            else
            {
                if (Program.IsActivated(overlayUIForm))
                {
                    overlayUIForm._watcherThread.Abort();

                    if (Program.IsActivated(overlayUIForm.overlayForm_browser))
                    {
                        overlay.o_browser overlay_browser = overlayUIForm.overlayForm_browser;

                        overlay_browser.SaveSettings();

                        overlay_browser.DisposeChilds();
                        overlay_browser.Dispose();
                    }

                    if (Program.IsActivated(overlayUIForm.overlayForm_image))
                    {
                        overlay.o_image overlay_image = overlayUIForm.overlayForm_image;

                        overlay_image.SaveSettings();

                        overlay_image.DisposeChilds();
                        overlay_image.Dispose();
                    }

                    overlayUIForm.Dispose();
                }
            }

        }




        private void relying_Click(object sender, EventArgs e)
        {
            if (Program.IsActivated(overlayUIForm))
            {
                overlayUIForm.relying = relying.Checked;
            }
        }

        private void label_relying_Click(object sender, EventArgs e)
        {
            relying.Checked = !relying.Checked;
            relying_Click(relying, new EventArgs());
        }

        private void opacity_ValueChanged(object sender, EventArgs e)
        {
            opacity_value.Text = opacity.Value.ToString() + "%";

            if (Program.IsActivated(overlayUIForm))
            {
                overlayUIForm.Opacity = (float)opacity.Value / 100;

                overlay._public.SetChildOpacity(overlayUIForm, (float)opacity.Value / 100);
            }
        }
    }
}
