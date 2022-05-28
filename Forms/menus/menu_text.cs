using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
    public partial class menu_text : UserControl
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
        private overlay.o_text overlayForm = new overlay.o_text();

        private string appPath = Application.StartupPath;
        private string workingFile = Application.StartupPath + @"\db\settings\menu_text.xml";

        public bool opened { get; set; } = false;
        #endregion



        public menu_text()
        {
            InitializeComponent();
        }







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

        private bool checkURLValid(string source)
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

            document.DocumentElement.AppendChild(controls);



            if (opened)
            {
                XmlElement overlay = document.CreateElement("Overlay");

                XmlElement element = document.CreateElement("Bounds");
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

                XmlElement element = document.CreateElement("Bounds");
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


            XmlNode singleNode = document.SelectSingleNode("Browser/Controls/URL");
            if (singleNode != null)
            if (singleNode.InnerText.Length > 9)
                content.Text = singleNode.InnerText;

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



        #region Drawing Text to Image File

        public struct TextElements
        {
            public string text;
            public Font font;

            public Color foreColor;
            public Color backColor;

            public Color outlineColor;
            public float outlineWidth;

            public float gradientAngle;
            public Color gradientColor1;
            public Color gradientColor2;

            public Color shadowColor;
            public byte shadowDistance;
        }
        
        public TextElements textElement = new TextElements();
        private Bitmap DrawTextLine(TextElements textInfo)
        {
            if (string.IsNullOrWhiteSpace(textInfo.text))
            {
                Bitmap emptyBmp = new Bitmap(1, 1);
                emptyBmp.MakeTransparent();

                return emptyBmp;
            }

            Bitmap dummy_bmp = new Bitmap(1, 1);
            Graphics graphic = Graphics.FromImage(dummy_bmp);
            SizeF textSize = graphic.MeasureString(textInfo.text, textInfo.font);
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            dummy_bmp.Dispose();

            // 그림파일이 화면크기보다 커지지 않도록 제한
            if (textSize.Width > screenSize.Width || textSize.Height > screenSize.Height)
            {
                float reduceRatio = (float)screenSize.Width / textSize.Width;

                textInfo.font = new Font(textInfo.font.Name, ((float)textInfo.font.Size * reduceRatio), textInfo.font.Style);
            }


            using (Bitmap bmp = new Bitmap((int)textSize.Width, (int)textSize.Height))
            {
                graphic = Graphics.FromImage(bmp);
                graphic.Clear(textInfo.backColor);

                // 텍스트 가운데 정렬
                StringFormat str_format = new StringFormat();
                str_format.Alignment = StringAlignment.Near;
                str_format.LineAlignment = StringAlignment.Far;

                Pen pen_outline = new Pen(textInfo.outlineColor, textInfo.outlineWidth);
                pen_outline.LineJoin = LineJoin.Round;


                // 그라데이션
                Rectangle gradient_rect = new Rectangle(0, bmp.Height - textInfo.font.Height, bmp.Width, textInfo.font.Height);
                LinearGradientBrush gradient_brush = new LinearGradientBrush(gradient_rect, textInfo.gradientColor1, textInfo.gradientColor2, textInfo.gradientAngle);


                // 텍스트 그림자 그리기
                Rectangle rect = new Rectangle(textInfo.shadowDistance, textInfo.shadowDistance, bmp.Width, bmp.Height);
                GraphicsPath g_path = new GraphicsPath();
                g_path.AddString(textInfo.text, textInfo.font.FontFamily, (int)textInfo.font.Style, (float)textInfo.font.Size, rect, str_format);
                using (Pen shadowPen = new Pen(textInfo.shadowColor))
                    graphic.DrawPath(shadowPen, g_path);
                using (SolidBrush shadowBrush = new SolidBrush(textInfo.shadowColor))
                    graphic.FillPath(shadowBrush, g_path);


                // 텍스트 윤곽 부드럽게 그리기
                rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                g_path.Reset();
                g_path.AddString(textInfo.text, textInfo.font.FontFamily, (int)textInfo.font.Style, (float)textInfo.font.Size, rect, str_format);

                graphic.SmoothingMode = SmoothingMode.AntiAlias;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphic.DrawPath(pen_outline, g_path);
                graphic.FillPath(gradient_brush, g_path);


                g_path.Dispose();
                gradient_brush.Dispose();
                pen_outline.Dispose();
                str_format.Dispose();
                graphic.Dispose();

                return new Bitmap(bmp);
            }


        }
        
        private Bitmap DrawTextAll(TextElements[] textInfo, float char_space)
        {
            Bitmap[] text_images = new Bitmap[textInfo.Length];
            Bitmap dummy_bmp;
            Graphics graphic;
            SizeF textSize;
            float maxWidth=0, sumHeight=0;


            for (int i=0; i<textInfo.Length; ++i)
            {
                dummy_bmp = new Bitmap(1, 1);
                graphic = Graphics.FromImage(dummy_bmp);
                textSize = graphic.MeasureString(textInfo[i].text, textInfo[i].font);


                if (textSize.Width > maxWidth)
                    maxWidth = textSize.Width;
                sumHeight += textSize.Height;
                dummy_bmp.Dispose();
            }


            using (Bitmap bmp = new Bitmap((int)maxWidth, (int)(sumHeight * char_space * 1.5f)))
            {
                for (int i=0; i<textInfo.Length; ++i)
                {
                    text_images[i] = DrawTextLine(textInfo[i]);
                }

                graphic = Graphics.FromImage(bmp);
                graphic.Clear(Color.Transparent);

                float sum_height = 0;
                for (int i=0; i<textInfo.Length; ++i)
                {
                    graphic.DrawImage(text_images[i], 0, sum_height);
                    sum_height += text_images[i].Height * (char_space * 0.85f);
                    text_images[i].Dispose();
                }

                graphic.Dispose();

                return new Bitmap(bmp);
            }

        }


        #endregion


        #region Functions - Text StylePack
        private List<TextElements> textStyles = new List<TextElements>();

        #region Functions

        #endregion


        #endregion


        private void menu_browser_Load(object sender, EventArgs e)
        {
            // 저장된 설정이 있다면 불러오기
            loadMenuSettings();
        }


        #region Event Handlers - About Map

        private void open_overlay_Click(object sender, EventArgs e)
        {
            string[] text_line = content.Text.Split('\n');
            TextElements[] texts = new TextElements[text_line.Length];

            for (int i=0; i<text_line.Length; ++i)
            {
                texts[i].text = text_line[i];
                texts[i].font = new Font("맑은 고딕", 50, FontStyle.Bold);
                texts[i].backColor = Color.Transparent;
                texts[i].foreColor = Color.FromArgb(200, 200, 200);
                texts[i].outlineColor = Color.White;
                texts[i].outlineWidth = 5;
                texts[i].gradientAngle = 90;
                texts[i].gradientColor1 = Color.Red;
                texts[i].gradientColor2 = Color.Black;
            }

            using (Bitmap text_image = DrawTextAll(texts, 1.0f))
            {
                text_image.Save(appPath + @"\db\lococo_target_text.png", ImageFormat.Png);
            }
            File.SetAttributes(appPath + @"\db\lococo_target_text.png", FileAttributes.Hidden);

            if (open_overlay.Checked 
                && !overlayForm.IsHandleCreated)
            {
                overlayForm = new overlay.o_text();

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

                    Program.ShowMsgbox("마지막 지도 창의 위치가 그 어떤 화면에도 온전히 속해있지 않습니다.\r\n\r\n지도 위치를 초기화합니다.", "알림", false);
                }

                else
                    overlayForm.Bounds = formRect;

                
                overlayForm.Show();
                overlayForm.updateImage(appPath + @"\db\lococo_target_text.png", (float)1);

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

        private void map_ignore_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #region Event Handlers - Label Click
        private void label_map_Click(object sender, EventArgs e)
        {
            open_overlay.Checked = !open_overlay.Checked;
            open_overlay_Click(open_overlay, new EventArgs());
        }

        #endregion

        #region Event Handlers - About URL
        private void URL_map_Click(object sender, EventArgs e)
        {
        }



        #endregion

        #region Event Handlers - About Opacity

        #endregion



        private void setFont_Click(object sender, EventArgs e)
        {
            using (FontDialog font_dialog = new FontDialog())
            {
                font_dialog.ShowEffects = false;

                string lastFont_str = setFont_title.Text.Remove(0, setFont_title.Text.IndexOf('▷') + 1);
                lastFont_str = lastFont_str.TrimStart();

                string[] font_data = lastFont_str.Split(',');
                for (byte i = 0; i < font_data.Length; ++i)
                    font_data[i] = font_data[i].Trim();

                string font_name = font_data[0];
                float font_size = float.Parse(font_data[1].Replace("pt", null));
                FontStyle font_style = (FontStyle)Enum.Parse(typeof(FontStyle), font_data[2], true);
                if (font_data.Length > 3)
                    font_style |= FontStyle.Italic;

                font_dialog.Font = new Font(font_name, font_size, font_style);


                if (font_dialog.ShowDialog() == DialogResult.OK)
                {
                    Font font = font_dialog.Font;

                    setFont_title.Text = "폰트        ▷  " + font.Name + ", " + font.Size + "pt, " + font.Style;
                }
            }
        }

    }
}
