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
using System.Windows.Media.Imaging;
using System.Xml;





namespace Lococo.Forms.menus
{
    public partial class menu_image : UserControl
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
        private overlayForm_image overlayForm = new overlayForm_image();

        private string workingFile = Application.StartupPath + "\\db\\settings\\menu_image.xml";

        public bool opened { get; set; } = false;
        #endregion



        public menu_image()
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
        public void saveSettings()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml("<Image></Image>");

            XmlElement controls = document.CreateElement("Controls");

            XmlElement element = document.CreateElement("Ignore");
            element.InnerText = ignore.Checked.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("Opacity");
            element.InnerText = opacity.Value.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("Width");
            element.InnerText = width.Value.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("Height");
            element.InnerText = height.Value.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("ImagePath");
            element.InnerText = file_path.Text;
            controls.AppendChild(element);

            document.DocumentElement.AppendChild(controls);



            if (opened)
            {
                XmlElement overlay = document.CreateElement("Overlay");

                element = document.CreateElement("Location");
                element.InnerText = new PointConverter().ConvertToString(overlayForm.Location);
                overlay.AppendChild(element);

                document.DocumentElement.AppendChild(overlay);
            }

            else
            {
                Point location = new Point(0, 0);

                if (File.Exists(workingFile))
                {
                    XmlDocument original_doc = new XmlDocument();
                    original_doc.Load(workingFile);

                    XmlNode node = original_doc.SelectSingleNode("Image/Overlay/Location");
                    if (node != null)
                        location = (Point)new PointConverter().ConvertFromString(node.InnerText);

                }

                XmlElement overlay = document.CreateElement("Overlay");

                element = document.CreateElement("Location");
                element.InnerText = new PointConverter().ConvertToString(overlayForm.Location);
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

            if (!File.Exists(workingFile))
                return;

            XmlDocument document = new XmlDocument();
            document.Load(workingFile);

            XmlNode singleNode = document.SelectSingleNode("Image/Controls/Ignore");
            if (singleNode != null)
            if (bool.TryParse(singleNode.InnerText, out bool ignore_value))
                ignore.Checked = ignore_value;

            singleNode = document.SelectSingleNode("Image/Controls/Opacity");
            if (singleNode != null)
            if (int.TryParse(singleNode.InnerText, out int opacity_value))
                opacity.Value = opacity_value;

            singleNode = document.SelectSingleNode("Image/Controls/Width");
            if (singleNode != null)
            if (int.TryParse(singleNode.InnerText, out int width_value))
                width.Value = width_value;

            singleNode = document.SelectSingleNode("Image/Controls/Height");
            if (singleNode != null)
                if (int.TryParse(singleNode.InnerText, out int height_value))
                    height.Value = height_value;

            singleNode = document.SelectSingleNode("Image/Controls/ImagePath");
            if (singleNode != null)
            if (File.Exists(singleNode.InnerText))
                file_path.Text = singleNode.InnerText;

        }

        public Point getOverlaySettings()
        {
            Point location = new Point(0, 0);
            
            if (File.Exists(workingFile))
            {
                XmlDocument document = new XmlDocument();
                document.Load(workingFile);

                XmlNode singleNode = document.SelectSingleNode("Image/Overlay/Location");
                if (singleNode != null)
                    location = (Point)new PointConverter().ConvertFromString(singleNode.InnerText);

            }

            return location;
        }

        private Size getImageSize(string file_path)
        {
            Size result = new Size(0, 0);

            using (var imageStream = File.OpenRead(file_path))
            {
                try
                {
                    BitmapDecoder decoder = BitmapDecoder.Create(imageStream, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                    result.Width = decoder.Frames[0].PixelWidth;
                    result.Height = decoder.Frames[0].PixelHeight;
                }

                catch (NotSupportedException) { }
            }

            return result;
        }

   
        #endregion




        private void menu_mococo_Load(object sender, EventArgs e)
        {
            width.Maximum = Screen.PrimaryScreen.Bounds.Width;
            height.Maximum = Screen.PrimaryScreen.Bounds.Height;

            loadMenuSettings();

            opacity_label.Text = opacity.Value.ToString() + " %";
            width_label.Text = width.Value.ToString() + " 픽셀";
            height_label.Text = height.Value.ToString() + " 픽셀";
        }


        #region Event Handlers - About Map



        private void ignore_Click(object sender, EventArgs e)
        {
            if (image.Checked)
            {            
                if (ignore.Checked)
                    overlayForm.setTransparent(true);

                else
                    overlayForm.setTransparent(false);
            
            }
        }


        #endregion


        #region Event Handlers - Image
        private void image_Click(object sender, EventArgs e)
        {
            if (image.Checked
    && !overlayForm.IsHandleCreated)
            {
                overlayForm = new overlayForm_image();

                Point form_loc = getOverlaySettings();

                bool areaCorrect = false;
                for (byte index = 0; index < Screen.AllScreens.Length; ++index)
                {
                    Rectangle screenBounds = Screen.AllScreens[index].Bounds;

                    if (form_loc.X > screenBounds.Left - 50
                        && form_loc.X < screenBounds.Right
                        && form_loc.Y > screenBounds.Top - 50
                        && form_loc.Y < screenBounds.Bottom)
                    {
                        areaCorrect = true;
                        break;
                    }

                }

                if (!areaCorrect)
                {
                    overlayForm.form_loc = new Point(0, 0);

                    showMsgbox("마지막 이미지 창의 위치가 그 어떤 화면에도 온전히 속해있지 않습니다.\r\n\r\n창 위치를 초기화합니다.", "알림", 375, 225, false);
                }

                else
                    overlayForm.form_loc = form_loc;

                overlayForm.Show();
                overlayForm.updateImage(file_path.Text, (float)opacity.Value / 100, width.Value, height.Value);
                overlayForm.setTransparent(ignore.Checked);

                Size img_size = getImageSize(file_path.Text);
                label_imgSize.Text = "현재 이미지 원본 크기: " + img_size.Width.ToString() + "x" + img_size.Height.ToString();

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


        private void browse_file_Click(object sender, EventArgs e)
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

            file_path.Text = openDialog.FileName;

            Size img_size = getImageSize(file_path.Text);
            label_imgSize.Text = "현재 이미지 원본 크기: " + img_size.Width.ToString() + "x" + img_size.Height.ToString();
        }




        #endregion

        #region Event Handlers - Label Click
        private void label_image_Click(object sender, EventArgs e)
        {
            image.Checked = !image.Checked;
            image_Click(image, new EventArgs());
        }


        private void label_ignore_Click(object sender, EventArgs e)
        {
            ignore.Checked = !ignore.Checked;
            ignore_Click(ignore, new EventArgs());
        }
        #endregion


        #region Event Handlers - ScrollBars
        private void opacity_MouseUp(object sender, MouseEventArgs e)
        {
            opacity_label.Text = opacity.Value.ToString() + "%";

            if (image.Checked)
                overlayForm.updateImage(file_path.Text, (float)opacity.Value / 100, width.Value, height.Value);
        }

        private void width_MouseUp(object sender, MouseEventArgs e)
        {


            width_label.Text = width.Value.ToString() + " 픽셀";

            if (image.Checked)
                overlayForm.updateImage(file_path.Text, (float)opacity.Value / 100, width.Value, height.Value);
        }

        private void height_MouseUp(object sender, MouseEventArgs e)
        {
            height_label.Text = height.Value.ToString() + " 픽셀";

            if (image.Checked)
                overlayForm.updateImage(file_path.Text, (float)opacity.Value / 100, width.Value, height.Value);
        }



        private void opacity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                if (e.KeyCode == Keys.Left)
                    opacity_label.Text = (opacity.Value - 1).ToString() + "%";

                else
                    opacity_label.Text = (opacity.Value + 1).ToString() + "%";

                if (image.Checked)               
                    overlayForm.updateImage(file_path.Text, (float)opacity.Value / 100, width.Value, height.Value);
                
            }
        }


        private void width_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                if (e.KeyCode == Keys.Left)
                    width_label.Text = (width.Value - 5).ToString() + " 픽셀";

                else
                    width_label.Text = (width.Value + 5).ToString() + " 픽셀";


                if (image.Checked)
                    overlayForm.updateImage(file_path.Text, (float)opacity.Value / 100, width.Value, height.Value);

            }
        }
        

        private void height_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                if (e.KeyCode == Keys.Left)
                    height_label.Text = (height.Value - 5).ToString() + " 픽셀";

                else
                    height_label.Text = (height.Value + 5).ToString() + " 픽셀";


                if (image.Checked)
                    overlayForm.updateImage(file_path.Text, (float)opacity.Value / 100, width.Value, height.Value);
            }
        }
        #endregion


        private void update_file_Click(object sender, EventArgs e)
        {
            Size img_size = getImageSize(file_path.Text);
            label_imgSize.Text = "현재 이미지 원본 크기: " + img_size.Width.ToString() + "x" + img_size.Height.ToString();

            if (image.Checked)
                overlayForm.updateImage(file_path.Text, (float)opacity.Value / 100, width.Value, height.Value);
            
        }

        private void width_ValueChanged(object sender, EventArgs e)
        {
            if (width.Value % 5 > 0)
                width.Value = width.Value - width.Value % 5;
        }

        private void height_ValueChanged(object sender, EventArgs e)
        {
            if (height.Value % 5 > 0)
                height.Value = height.Value - height.Value % 5;
        }
    }
}
