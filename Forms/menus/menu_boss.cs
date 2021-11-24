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
    public partial class menu_boss : UserControl
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
        private overlayForm_boss overlayForm = new overlayForm_boss();

        private bool dragging = false;
        private POINT tempPoint;
        private IntPtr appHwnd;
        private RECT rect;

        private string workingFile = Application.StartupPath + "\\db\\settings\\menu_boss.xml";
        private int app_left;

        private int bar_value;

        public bool opened { get; set; } = false;
        #endregion



        public menu_boss(IntPtr parentHwnd)
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
            document.LoadXml("<Boss></Boss>");

            XmlElement controls = document.CreateElement("Controls");

            XmlElement element = document.CreateElement("Ignore");
            element.InnerText = image_ignore.Checked.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("Opacity");
            element.InnerText = bar_value.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("DualMonitor");
            element.InnerText = image_dualMonitor.Checked.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("ImagePath");
            element.InnerText = image_path.Text;
            controls.AppendChild(element);

            element = document.CreateElement("ImageRatio");
            element.InnerText = image_ratio.Checked.ToString();
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

                    XmlNode node = original_doc.SelectSingleNode("Boss/Overlay/Bounds");
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
            bool ignore, dualMonitor, ratio;
            int opacity;

            if (!File.Exists(workingFile))
                return;

            XmlDocument document = new XmlDocument();
            document.Load(workingFile);

            XmlNode singleNode = document.SelectSingleNode("Boss/Controls/Ignore");
            if (singleNode != null)
            if (bool.TryParse(singleNode.InnerText, out ignore))
                image_ignore.Checked = ignore;

            singleNode = document.SelectSingleNode("Boss/Controls/DualMonitor");
            if (singleNode != null)
            if (bool.TryParse(singleNode.InnerText, out dualMonitor))
                image_dualMonitor.Checked = dualMonitor;

            singleNode = document.SelectSingleNode("Boss/Controls/Opacity");
            if (singleNode != null)
            if (int.TryParse(singleNode.InnerText, out opacity))
                bar_value = opacity;

            singleNode = document.SelectSingleNode("Boss/Controls/ImagePath");
            if (singleNode != null)
            if (File.Exists(singleNode.InnerText))
                image_path.Text = singleNode.InnerText;

            singleNode = document.SelectSingleNode("Boss/Controls/ImageRatio");
            if (singleNode != null)
                if (bool.TryParse(singleNode.InnerText, out ratio))
                    image_ratio.Checked = ratio;

        }

        public Rectangle getOverlaySettings()
        {
            Rectangle bounds = new Rectangle(0, 0, 500, 500);
            
            if (File.Exists(workingFile))
            {
                XmlDocument document = new XmlDocument();
                document.Load(workingFile);

                XmlNode singleNode = document.SelectSingleNode("Boss/Overlay/Bounds");
                if (singleNode != null)
                    bounds = (Rectangle)new RectangleConverter().ConvertFromString(singleNode.InnerText);

            }

            return bounds;
        }


        private void addHoverTooltip()
        {
            label_imgDual.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "보조 모니터에 표시";
                toolTip.SetToolTip(label_imgDual, "모니터를 2개 이상 사용중인 경우, 두번째 모니터에 표시할 수 있도록 하는 기능입니다.\r\n저에게 모니터가 1개밖에 없어 실제로 테스트해보지 못한 기능입니다.");
            };
            label_imgIgnore.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "클릭 불가";
                toolTip.SetToolTip(label_imgIgnore, "화면에 표시된 이미지의 UI를 숨기고, 게임에 방해되지 않도록 클릭 불가능하도록 변경합니다.");
            };

            label_image.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "표시";
                toolTip.SetToolTip(label_image, "오버레이를 켜거나 끕니다.");
            };

            label_imgTran.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "불투명도 조절";
                toolTip.SetToolTip(label_imgTran, "화면에 표시되는 이미지의 불투명도를 조절합니다.");
            };


            label_imgRatio.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "원본 크기로 불러오기";
                toolTip.SetToolTip(label_imgRatio, "화면에 이미지를 원본 크기 그대로 가져와 오버레이합니다.\r\n이 기능을 끌 경우 어떤 이미지를 가져와도 항상 이미지를 같은 크기로 조절하여 표시합니다.");
            };







            label_imgPath.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "이미지 경로";
                toolTip.SetToolTip(label_imgPath, "화면에 오버레이시킬 컨닝페이퍼 이미지 파일의 경로를 입력하세요.\r\n\r\n\"찾아보기\" 버튼을 클릭하여 탐색기에서 파일을 선택할 수 있습니다.\r\n\"적용\"버튼을 클릭하여 오버레이를 껐다 켜지 않고 바로 이미지를 변경할 수 있습니다.");
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
            label_imgTran.Text = "불투명도 (" + bar_value.ToString() + "%)";

            if (Screen.AllScreens.Length == 1)
            {
                image_dualMonitor.Checked = false;
                image_dualMonitor.Enabled = false;

                label_imgDual.Enabled = false;
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

                    label_imgTran.Text = "불투명도 (" + bar_value.ToString() + "%)";


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

                    label_imgTran.Text = "불투명도 (" + bar_value.ToString() + "%)";


                    if (overlayForm.IsHandleCreated)
                        overlayForm.Opacity = (float)bar_value / 100;
                }
            }
        }

        private void scrollBar_back_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }





        private void image_Click(object sender, EventArgs e)
        {
            if (image.Checked 
                && !overlayForm.IsHandleCreated)
            {
                overlayForm = new overlayForm_boss();

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

                    showMsgbox("마지막 이미지 창의 위치가 그 어떤 화면에도 온전히 속해있지 않습니다.\r\n\r\n창 위치를 초기화합니다.", "알림", 375, 225, false);
                }

                else
                    overlayForm.Bounds = formRect;

                overlayForm.imgPath = image_path.Text;
                overlayForm.load_by_originalSize = image_ratio.Checked;
                overlayForm.Show();
                overlayForm.setTransparent(image_ignore.Checked);

                opened = true;
            }

            else
            {
                saveSettings();

                overlayForm.Dispose();
                overlayForm.Close();

                GC.Collect();
            }
        }

        private void image_ignore_Click(object sender, EventArgs e)
        {
            if (image.Checked)
            {
                if (image_ignore.Checked)
                    overlayForm.setTransparent(true);

                else
                    overlayForm.setTransparent(false);
            }
        }

        private void image_ratio_Click(object sender, EventArgs e)
        {
            if (image_ratio.Checked)
                overlayForm.load_by_originalSize = true;

            else
                overlayForm.load_by_originalSize = false;
        }


        #endregion


        #region Event Handlers - Image
        private void apply_image_Click(object sender, EventArgs e)
        {
            if (image.Checked)
            {
                overlayForm.imgPath = image_path.Text;
                overlayForm.load_by_originalSize = image_ratio.Checked;
                overlayForm.updateImage();
            }
        }

        private void browse_image_Click(object sender, EventArgs e)
        {
            openDialog.Title = "컨닝페이퍼 이미지 불러오기";
            openDialog.InitialDirectory = Application.StartupPath;
            openDialog.Filter = "이미지 파일 (*.png, *.jpg, *.bmp)|*.png;*.jpg;*.bmp";
            openDialog.CheckFileExists = true;
            openDialog.CheckPathExists = true;

            DialogResult result = openDialog.ShowDialog();

            if (result == DialogResult.Cancel)
                return;


            if (!File.Exists(openDialog.FileName))
            {
                showMsgbox("존재하지 않는 파일입니다.", "실패", 350, 175, false);
                return;
            }

            image_path.Text = openDialog.FileName;
            overlayForm.imgPath = openDialog.FileName;
        }




        #endregion

        #region Event Handlers - Label Click
        private void label_image_Click(object sender, EventArgs e)
        {
            image.Checked = !image.Checked;
            image_Click(image, new EventArgs());
        }

        private void label_imgRatio_Click(object sender, EventArgs e)
        {
            image_ratio.Checked = !image_ratio.Checked;
            image_ratio_Click(image_ratio, new EventArgs());
        }


        private void label_imgIgnore_Click(object sender, EventArgs e)
        {
            image_ignore.Checked = !image_ignore.Checked;
            image_ignore_Click(image_ignore, new EventArgs());
        }

        private void label_imgDual_Click(object sender, EventArgs e)
        {
            image_dualMonitor.Checked = !image_dualMonitor.Checked;
        }
        #endregion


    }
}
