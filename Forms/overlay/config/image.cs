using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace Lococo.Forms.overlay.config
{
    class image : IDisposable
    {

        #region Global Variables
        public overlay.o_image ParentForm { get; set; }
        public overlay.o_image_sizer SizerForm { get; set; }

        public Settings globalSettings = new Settings();
        public struct Settings 
        {
            public string imgPath;
            public byte opacity;

            public bool clickable;
            public bool useOriginalSize;
            public bool keepRatio;

            public Rectangle bounds;
        };
        #endregion

        #region Private Variables
        private readonly string filePath = Program.path + "\\db\\settings\\overlay_image.xml";
        #endregion

        public void Dispose()
        {

        }



        public void ResetSettings()
        {
            globalSettings.bounds = new Rectangle(0, 0, 500, 500);

            globalSettings.opacity = 80;
            globalSettings.clickable = true;
            globalSettings.useOriginalSize = false;
            globalSettings.keepRatio = true;
        }


        public void SaveSettings()
        {
            if (Program.IsActivated(ParentForm) && Program.IsActivated(SizerForm))
            {
                globalSettings.bounds = ParentForm.bounds;

                globalSettings.opacity = ParentForm.opacity;
                globalSettings.imgPath = ParentForm.imgPath;
                globalSettings.clickable = SizerForm.clickable;
                globalSettings.useOriginalSize = ParentForm.useOriginalSize;
                globalSettings.keepRatio = SizerForm.keepRatio;
            }

            // 기본 속성 저장
            XmlDocument document = new XmlDocument();
            document.LoadXml("<Image></Image>");

            XmlElement controls = document.CreateElement("Controls");

            XmlElement element = document.CreateElement("Opacity");
            element.InnerText = globalSettings.opacity.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("Clickable");
            element.InnerText = globalSettings.clickable.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("UseOriginalSize");
            element.InnerText = globalSettings.useOriginalSize.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("KeepRatio");
            element.InnerText = globalSettings.keepRatio.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("imgPath");
            element.InnerText = globalSettings.imgPath;
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
            using (XmlTextWriter writer = new XmlTextWriter(filePath, new UTF8Encoding(false)))
            {
                writer.Formatting = Formatting.Indented;
                document.Save(writer);
            }


        }

        public void LoadSettings()
        {
            if (!File.Exists(filePath))
                return;

            XmlDocument document = new XmlDocument();
            document.Load(filePath);

            XmlNode singleNode = document.SelectSingleNode("Image/Controls/Opacity");
            if (singleNode != null)
                byte.TryParse(singleNode.InnerText, out globalSettings.opacity);

            singleNode = document.SelectSingleNode("Image/Controls/Clickable");
            if (singleNode != null)
                bool.TryParse(singleNode.InnerText, out globalSettings.clickable);

            singleNode = document.SelectSingleNode("Image/Controls/UseOriginalSize");
            if (singleNode != null)
                bool.TryParse(singleNode.InnerText, out globalSettings.useOriginalSize);

            singleNode = document.SelectSingleNode("Image/Controls/KeepRatio");
            if (singleNode != null)
                bool.TryParse(singleNode.InnerText, out globalSettings.keepRatio);

            singleNode = document.SelectSingleNode("Image/Controls/imgPath");
            if (singleNode != null)
                if (singleNode.InnerText.Length > 4)
                    globalSettings.imgPath = singleNode.InnerText;

            singleNode = document.SelectSingleNode("Image/Overlay/Bounds");
            if (singleNode != null)
                globalSettings.bounds = (Rectangle)new RectangleConverter().ConvertFromString(singleNode.InnerText);
        }
    }
}
