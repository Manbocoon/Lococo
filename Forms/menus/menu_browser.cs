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
    public partial class menu_browser : UserControl
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

        #region Global Variables
        private messageForm messageForm = new messageForm();
        private overlayForm_browser overlayForm = new overlayForm_browser();

        private Thread mapInfoThread;

        private string appPath = Application.StartupPath;
        private string workingFile = Application.StartupPath + "\\db\\settings\\menu_browser.xml";

        public bool opened { get; set; } = false;
        #endregion



        public menu_browser()
        {
            InitializeComponent();
        }




        #region Custom MessageBox
        private bool showMsgbox(string message, string caption, int width, int height, bool yesNo)
        {
            messageForm.Dispose();
            messageForm = new messageForm();

            bool result = false;

            messageForm.msg = message;
            messageForm.cap = caption;
            messageForm.width = width;
            messageForm.height = height;
            messageForm.yesNo = yesNo;

            messageForm.ShowDialog();

            if (messageForm.dialogResult == 1)
                result = true;

            return result;
        }
        #endregion


        #region App Functions
        // 모험의 서 (로스트아크 인벤 지도)의 각 맵에 대한 링크 코드번호를 가져오는 함수
        private List<string> map_list = new List<string>();
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

                File.WriteAllText(appPath + @"\db\map_list.ini", file_data, Encoding.UTF8);           
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

        private bool checkURLValid(ref string source)
        {
            bool result = false;

            if (!source.StartsWith("http://") || !source.StartsWith("https://"))
                source = "https://" + source;

            if (source.IndexOf('.') > -1)
                result = true;

            return result;
        }

        public void saveSettings()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml("<Browser></Browser>");

            XmlElement controls = document.CreateElement("Controls");

            XmlElement element = document.CreateElement("Ignore");
            element.InnerText = map_ignore.Checked.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("Opacity");
            element.InnerText = opacity.Value.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("URL");
            element.InnerText = map_URL.Text;
            controls.AppendChild(element);

            document.DocumentElement.AppendChild(controls);



            if (opened)
            {
                XmlElement overlay = document.CreateElement("Overlay");

                element = document.CreateElement("Bounds");
                element.InnerText = new RectangleConverter().ConvertToString(overlayForm.Bounds);
                overlay.AppendChild(element);

                document.DocumentElement.AppendChild(overlay);
            }

            else
            {
                Rectangle bounds = new Rectangle(0, 0, 500, 500);

                if (File.Exists(workingFile))
                {
                    XmlDocument original_doc = new XmlDocument();
                    original_doc.Load(workingFile);

                    XmlNode node = original_doc.SelectSingleNode("Browser/Overlay/Bounds");
                    if (node != null)
                        bounds = (Rectangle)new RectangleConverter().ConvertFromString(node.InnerText);

                }

                XmlElement overlay = document.CreateElement("Overlay");

                element = document.CreateElement("Bounds");
                element.InnerText = new RectangleConverter().ConvertToString(overlayForm.Bounds);
                overlay.AppendChild(element);


                document.DocumentElement.AppendChild(overlay);

            }




            using (XmlTextWriter writer = new XmlTextWriter(workingFile, new UTF8Encoding(false)))
            {
                writer.Formatting = Formatting.Indented;
                document.Save(writer);
            }

        }

        public void loadMenuSettings()
        {
            bool ignore;

            if (!File.Exists(workingFile))
                return;

            XmlDocument document = new XmlDocument();
            document.Load(workingFile);

            XmlNode singleNode = document.SelectSingleNode("Browser/Controls/Ignore");
            if (singleNode != null)
            if (bool.TryParse(singleNode.InnerText, out ignore))
                map_ignore.Checked = ignore;

            singleNode = document.SelectSingleNode("Browser/Controls/Opacity");
            if (singleNode != null)
            if (int.TryParse(singleNode.InnerText, out int opacity_value))
                opacity.Value = opacity_value;

            singleNode = document.SelectSingleNode("Browser/Controls/URL");
            if (singleNode != null)
            if (singleNode.InnerText.Length > 9)
                map_URL.Text = singleNode.InnerText;

        }

        public Rectangle getOverlaySettings()
        {
            Rectangle bounds = new Rectangle(0, 0, 500, 500);
            
            if (File.Exists(workingFile))
            {
                XmlDocument document = new XmlDocument();
                document.Load(workingFile);

                XmlNode singleNode = document.SelectSingleNode("Browser/Overlay/Bounds");
                if (singleNode != null)
                    bounds = (Rectangle)new RectangleConverter().ConvertFromString(singleNode.InnerText);

            }

            return bounds;
        }
        #endregion




        private void menu_browser_Load(object sender, EventArgs e)
        {
            // 저장된 설정이 있다면 불러오기
            loadMenuSettings();
            opacity_label.Text = opacity.Value.ToString() + "%";


            // .NET WebView2 브라우저 임시파일 삭제
            string exeName = Path.GetFileName(Application.ExecutablePath);
            try { Directory.Delete(Application.StartupPath + @"\" + exeName + ".WebView2", true); }
            catch (Exception) { }

            // .NET WebView2 런타임이 설치되지 않으면 안내 메세지 남기기
            if (!checkWebview2RuntimeInstalled())
                showMsgbox(".NET WebView2 런타임이 설치되지 않은 것 같습니다.\r\n\r\n브라우저 오버레이가 작동하지 않을 수 있으므로 꼭 설치해주세요.", "알림", 455, 225, false);


            // 인터넷이 연결되었고 서버가 정상인 경우 모험의 서(인벤 지도) → ← 단축키 사용을 위한 맵 링크 정보 가져오는 쓰레드 실행
            bool network_connected = NetworkInterface.GetIsNetworkAvailable();
            if (network_connected)
            {
                mapInfoThread = new Thread(getMapInfo);
                mapInfoThread.IsBackground = true;
                mapInfoThread.Start();
            }
        }


        #region Event Handlers - About Map

        private void map_Click(object sender, EventArgs e)
        {
            if (map.Checked 
                && !overlayForm.IsHandleCreated)
            {
                overlayForm = new overlayForm_browser();

                overlayForm.webURL = map_URL.Text;
                overlayForm.Opacity = (float)opacity.Value / 100;

                Rectangle formRect = getOverlaySettings();

                bool areaCorrect = false;
                for (byte index=0; index<Screen.AllScreens.Length; ++index)
                {
                    Rectangle screenBounds = Screen.AllScreens[index].Bounds;

                    if (formRect.Right > screenBounds.Left+50 
                        && formRect.Left < screenBounds.Right-50 
                        && formRect.Bottom > screenBounds.Top+50 
                        && formRect.Top < screenBounds.Bottom-50)
                    { 
                        areaCorrect = true;
                        break;
                    }

                }

                if (!areaCorrect)
                {
                    overlayForm.Bounds = new Rectangle(0, 0, 500, 500);

                    showMsgbox("마지막 지도 창의 위치가 그 어떤 화면에도 온전히 속해있지 않습니다.\r\n\r\n지도 위치를 초기화합니다.", "알림", 375, 225, false);
                }

                else
                    overlayForm.Bounds = formRect;

                overlayForm.Show();
                overlayForm.setTransparent(map_ignore.Checked);

                opened = true;
            }

            else
            {
                overlayForm.hotkeyThread.Abort();

                saveSettings();

                overlayForm.Dispose();
                overlayForm.Close();

                GC.Collect();
            }
        }

        private void map_ignore_Click(object sender, EventArgs e)
        {
            if (map.Checked)
            {
                if (map_ignore.Checked)
                    overlayForm.setTransparent(true);

                else
                    overlayForm.setTransparent(false);
            }
        }


        #endregion

        #region Event Handlers - Label Click
        private void label_map_Click(object sender, EventArgs e)
        {
            map.Checked = !map.Checked;
            map_Click(map, new EventArgs());
        }

        private void label_ignore_Click(object sender, EventArgs e)
        {
            map_ignore.Checked = !map_ignore.Checked;
            map_ignore_Click(map_ignore, new EventArgs());
        }

        #endregion

        #region Event Handlers - About URL
        private void URL_map_Click(object sender, EventArgs e)
        {
            map_URL.Text = "https://lostark.inven.co.kr/dataninfo/world/?code=10201";

            if (map.Checked)
            {
                overlayForm.webURL = map_URL.Text;
                overlayForm.navigateBrowser();
            }
        }

        private void URL_bingpago_Click(object sender, EventArgs e)
        {
            map_URL.Text = "https://ialy1595.me/kouku/";

            if (map.Checked)
            {
                overlayForm.webURL = map_URL.Text;
                overlayForm.navigateBrowser();
            }
        }

        private void URL_youtube_Click(object sender, EventArgs e)
        {
            map_URL.Text = "https://www.youtube.com";

            if (map.Checked)
            {
                overlayForm.webURL = map_URL.Text;
                overlayForm.navigateBrowser();
            }
        }

        private void URL_input_Click(object sender, EventArgs e)
        {
            string input_url = Microsoft.VisualBasic.Interaction.InputBox("오버레이에 표시할 웹사이트의 URL을 입력하세요.\r\n\r\n(예시) 네이버라면 https://www.naver.com 입력", "브라우저 오버레이 링크 입력", null);

            if (input_url.Length < 1)
                return;

            if (!checkURLValid(ref input_url))
            {
                showMsgbox("유효한 링크(URL)이 아닙니다.", "실패", 325, 175, false);
                return;
            }


            map_URL.Text = input_url;

            if (map.Checked)
            {
                overlayForm.webURL = map_URL.Text;
                overlayForm.navigateBrowser();
            }
        }

        #endregion

        #region Event Handlers - About Opacity
        private void opacity_Scroll(object sender, ScrollEventArgs e)
        {
            opacity_label.Text = opacity.Value.ToString() + "%";

            if (map.Checked)
            {
                overlayForm.Opacity = (float)opacity.Value / 100;
            }
        }
        #endregion

    }
}
