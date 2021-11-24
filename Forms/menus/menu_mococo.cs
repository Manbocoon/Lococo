using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;





namespace Lococo.Forms.menus
{
    public partial class menu_mococo : UserControl
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

        private const Int32 CB_SETITEMHEIGHT = 0x153;
        #endregion

        #region Global Variables
        private messageForm messageForm = new messageForm();
        private overlayForm_mococo overlayForm = new overlayForm_mococo();

        private bool dragging = false;
        private POINT tempPoint;
        private IntPtr appHwnd;
        private RECT rect;

        private string workingFile = Application.StartupPath + "\\db\\settings\\menu_mococo.xml";
        private int app_left;

        private int bar_value;

        public bool opened { get; set; } = false;
        #endregion



        public menu_mococo(IntPtr parentHwnd)
        {
            appHwnd = parentHwnd;
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
        public void saveSettings()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml("<Mococo></Mococo>");

            XmlElement controls = document.CreateElement("Controls");

            XmlElement element = document.CreateElement("Ignore");
            element.InnerText = map_ignore.Checked.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("Opacity");
            element.InnerText = bar_value.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("URL");
            element.InnerText = map_URL.Text;
            controls.AppendChild(element);

            element = document.CreateElement("DualMonitor");
            element.InnerText = map_dualMonitor.Checked.ToString();
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

                    XmlNode node = original_doc.SelectSingleNode("Mococo/Overlay/Bounds");
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
            bool ignore, dualMonitor;
            int opacity;

            if (!File.Exists(workingFile))
                return;

            XmlDocument document = new XmlDocument();
            document.Load(workingFile);

            XmlNode singleNode = document.SelectSingleNode("Mococo/Controls/Ignore");
            if (singleNode != null)
            if (bool.TryParse(singleNode.InnerText, out ignore))
                map_ignore.Checked = ignore;

            singleNode = document.SelectSingleNode("Mococo/Controls/DualMonitor");
            if (singleNode != null)
            if (bool.TryParse(singleNode.InnerText, out dualMonitor))
                map_dualMonitor.Checked = dualMonitor;

            singleNode = document.SelectSingleNode("Mococo/Controls/Opacity");
            if (singleNode != null)
            if (int.TryParse(singleNode.InnerText, out opacity))
                bar_value = opacity;

            singleNode = document.SelectSingleNode("Mococo/Controls/URL");
            if (singleNode != null)
            if (singleNode.InnerText.Length > 10)
                map_URL.Text = singleNode.InnerText;

        }

        public Rectangle getOverlaySettings()
        {
            Rectangle bounds = new Rectangle(0, 0, 500, 500);
            
            if (File.Exists(workingFile))
            {
                XmlDocument document = new XmlDocument();
                document.Load(workingFile);

                XmlNode singleNode = document.SelectSingleNode("Mococo/Overlay/Bounds");
                if (singleNode != null)
                    bounds = (Rectangle)new RectangleConverter().ConvertFromString(singleNode.InnerText);

            }

            return bounds;
        }



        private void addHoverTooltip()
        {
            label_map.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "표시";
                toolTip.SetToolTip(label_map, "오버레이를 켜거나 끕니다.");
            };

            label_mapURL.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "링크";
                toolTip.SetToolTip(label_mapURL, "오버레이된 Internet Explorer 브라우저에서 접속할 웹사이트(URL)을 설정합니다.\r\n예를 들어, https:/www.naver.com을 입력하면 네이버가 접속됩니다.\r\n\r\n기본값은 로스트아크 인벤지도 웹사이트입니다.");
            };

            label_mapTran.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "불투명도 조절";
                toolTip.SetToolTip(label_mapTran, "화면에 표시되는 브라우저의 불투명도를 조절합니다.");
            };

            label_mapIgnore.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "클릭 불가";
                toolTip.SetToolTip(label_mapIgnore, "화면에 표시된 브라우저의 UI를 숨기고, 게임에 방해되지 않도록 클릭 불가능하도록 변경합니다.\r\n\r\n단, 내실할 때는 추천하지 않는 기능입니다.\r\n맵 변경 단축키가 있지만 클릭해야할 일이 많을 것입니다.");
            };

            label_mapTran.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "불투명도 조절";
                toolTip.SetToolTip(label_mapTran, "화면에 표시되는 브라우저의 불투명도를 조절합니다.");
            };

            help_key.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "단축키";
                toolTip.SetToolTip(help_key, "게임할 때 번거로움을 줄이기 위한 단축키가 있습니다.\r\n\r\n게임 도중 ← → 키를 눌러 로스트아크 인벤지도 맵을 변경할 수 있습니다.");
            };
        }
        #endregion




        private void menu_mococo_Load(object sender, EventArgs e)
        {
            using (var img = new Functions.loadImage())
            {      
                scrollBar_back.Image = img.loadImageFromFile(Application.StartupPath + "\\db\\images\\scrollbar_back.db");
                scrollBar_point.Image = img.loadImageFromFile(Application.StartupPath + "\\db\\images\\scrollbar_point.db");
            }

            bar_value = 75;

            loadMenuSettings();

            scrollBar_point.Left = (int)(((float)(bar_value - 8) / ((float)100 / scrollBar_back.Width)) + scrollBar_back.Left);
            label_mapTran.Text = "불투명도 (" + bar_value.ToString() + "%)";

            if (Screen.AllScreens.Length == 1)
            {
                map_dualMonitor.Checked = false;
                map_dualMonitor.Enabled = false;

                label_mapDual.Enabled = false;
            }

            addHoverTooltip();
        }


        #region Event Handlers - About Map
        private void scrollBar_point_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dragging)
            {
                dragging = true;

                GetWindowRect(appHwnd, ref rect);

                app_left = rect.left;
            }
        }

        private void scrollBar_point_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                GetCursorPos(out tempPoint);

                if (tempPoint.x > app_left + 201 + scrollBar_back.Left 
                    && tempPoint.x < app_left + 201 + scrollBar_back.Right)
                {
                    scrollBar_point.Left = tempPoint.x - (app_left + 201) - 15;

                    bar_value = (int)((float)(scrollBar_point.Left - scrollBar_back.Left) * ((float)100 / scrollBar_back.Width)) + 8;

                    if (bar_value > 95)
                        bar_value = 100;

                    else if (bar_value < 10)
                        bar_value = 10;

                    label_mapTran.Text = "불투명도 (" + bar_value.ToString() + "%)";


                    if (overlayForm.IsHandleCreated)
                        overlayForm.Opacity = (float)bar_value / 100;
                }
            }
        }

        private void scrollBar_point_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }


        private void scrollBar_back_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dragging)
            {
                dragging = true;

                GetWindowRect(appHwnd, ref rect);

                app_left = rect.left;

            }
        }

        private void scrollBar_back_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                GetCursorPos(out tempPoint);

                if (tempPoint.x > app_left + 201 + scrollBar_back.Left 
                    && tempPoint.x < app_left + 201 + scrollBar_back.Right)
                {
                    scrollBar_point.Left = tempPoint.x - (app_left + 201) - 15;

                    bar_value = (int)((float)(scrollBar_point.Left - scrollBar_back.Left) * ((float)100 / scrollBar_back.Width)) + 8;

                    if (bar_value > 95)
                        bar_value = 100;

                    else if (bar_value < 10)
                        bar_value = 10;

                    label_mapTran.Text = "불투명도 (" + bar_value.ToString() + "%)";


                    if (overlayForm.IsHandleCreated)
                        overlayForm.Opacity = (float)bar_value / 100;
                }
            }
        }

        private void scrollBar_back_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }





        private void map_Click(object sender, EventArgs e)
        {
            if (map.Checked 
                && !overlayForm.IsHandleCreated)
            {
                overlayForm = new Forms.overlayForm_mococo();

                overlayForm.webURL = map_URL.Text;
                overlayForm.Opacity = (float)bar_value / 100;

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

        private void map_applyURL_Click(object sender, EventArgs e)
        {
            if (map.Checked)
            {
                overlayForm.webURL = map_URL.Text;
                overlayForm.navigateBrowser();
            }
        }

        private void map_resetURL_Click(object sender, EventArgs e)
        {
            map_URL.Text = "https://lostark.inven.co.kr/dataninfo/world/?code=10201";

            if (map.Checked)
            {
                overlayForm.webURL = map_URL.Text;
                overlayForm.navigateBrowser();
            }
        }


        #endregion

        #region Event Handlers - Label Click
        private void label_map_Click(object sender, EventArgs e)
        {
            map.Checked = !map.Checked;
            map_Click(map, new EventArgs());
        }

        private void label_mapIgnore_Click(object sender, EventArgs e)
        {
            map_ignore.Checked = !map_ignore.Checked;
            map_ignore_Click(map_ignore, new EventArgs());
        }

        private void label_mapDual_Click(object sender, EventArgs e)
        {
            map_dualMonitor.Checked = !map_dualMonitor.Checked;
        }

        #endregion


    }
}
