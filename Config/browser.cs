using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace Lococo.Config
{
    class browser : IDisposable
    {

        #region Global Variables
        public Forms.overlay.o_browser ParentForm { get; set; }


        public Settings globalSettings = new Settings();
        public struct Settings 
        {
            public string URL;
            public bool clickable;
            public ushort zoom;
            public byte opacity;

            public Rectangle bounds;
        };

        public List<Settings> favorites = new List<Settings>();
        #endregion


        #region Private Variables
        private readonly string filePath = Program.Path + "\\db\\settings\\overlay_browser.xml";
        private readonly string rootPath = Program.Path + "\\db\\settings";
        #endregion

        public void Dispose()
        {

        }




        private void ResetSettings()
        {
            globalSettings.bounds = new Rectangle(0, 30, 500, 500);

            globalSettings.clickable = true;
            globalSettings.zoom = 100;
            globalSettings.opacity = 80;
            globalSettings.URL = "https://lostark.inven.co.kr/dataninfo/world/?code=10201";
        }

        public void SaveSettings()
        {
            if (ParentForm != null)
            {
                globalSettings.bounds = ParentForm.Bounds;

                globalSettings.opacity = ParentForm.opacity;
                globalSettings.clickable = ParentForm.clickable;
                globalSettings.zoom = ParentForm.zoom;
                globalSettings.URL = ParentForm.URL;
            }

            // 기본 속성 저장
            XmlDocument document = new XmlDocument();
            document.LoadXml("<Browser></Browser>");

            XmlElement controls = document.CreateElement("Controls");

            XmlElement element = document.CreateElement("Clickable");
            element.InnerText = globalSettings.clickable.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("Opacity");
            element.InnerText = globalSettings.opacity.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("Zoom");
            element.InnerText = globalSettings.zoom.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("URL");
            element.InnerText = globalSettings.URL;
            controls.AppendChild(element);

            document.DocumentElement.AppendChild(controls);


            // 폼의 Bounds 저장
            XmlElement overlay = document.CreateElement("Overlay");

            element = document.CreateElement("Bounds");
            element.InnerText = new RectangleConverter().ConvertToString(globalSettings.bounds);
            overlay.AppendChild(element);


            document.DocumentElement.AppendChild(overlay);


            // .NET 자체에서 지원하는 Encoding.UTF8 사용 시, 인코딩 및 인디언 확인을 위한 3 Byte 크기의 BOM(Byte Order Mark)가 붙어버리므로
            // new UTF8Encoding(false)를 통해 범용성 높은 진짜 UTF8 인코딩으로 작성
            _public.CreateDirectories();
            using (XmlTextWriter writer = new XmlTextWriter(filePath, new UTF8Encoding(false)))
            {
                writer.Formatting = Formatting.Indented;
                document.Save(writer);
            }

        }

        public void LoadSettings()
        {
            ResetSettings();

            if (!File.Exists(filePath))
                return;

            XmlDocument document = new XmlDocument();
            document.Load(filePath);
 
            XmlNode singleNode = document.SelectSingleNode("Browser/Controls/Clickable");
            if (singleNode != null)
                bool.TryParse(singleNode.InnerText, out globalSettings.clickable);

            singleNode = document.SelectSingleNode("Browser/Controls/Opacity");
            if (singleNode != null)
                byte.TryParse(singleNode.InnerText, out globalSettings.opacity);

            singleNode = document.SelectSingleNode("Browser/Controls/Zoom");
            if (singleNode != null)
                ushort.TryParse(singleNode.InnerText, out globalSettings.zoom);

            singleNode = document.SelectSingleNode("Browser/Controls/URL");
            if (singleNode != null)
                if (singleNode.InnerText.Length > 9)
                    globalSettings.URL = singleNode.InnerText;

            singleNode = document.SelectSingleNode("Browser/Overlay/Bounds");
            if (singleNode != null)
                globalSettings.bounds = (Rectangle)new RectangleConverter().ConvertFromString(singleNode.InnerText);
        }
    }
}
