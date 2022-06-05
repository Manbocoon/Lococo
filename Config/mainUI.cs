using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;



namespace Lococo.Config
{
    /// <summary>
    /// 오버레이 메뉴의 설정을 관리하는 객체입니다.
    /// </summary>
    class mainUI : IDisposable
    {
        #region Global Variables
        public Forms.menus.menu_overlay ParentForm { get; set; }

        public Settings globalSettings = new Settings();
        public struct Settings
        {
            public bool Overlay_Toggle;
            public bool Relying_On_Game;

            public byte UI_Opacity;
        };
        #endregion

        #region Private Variables
        private readonly string filePath = Program.Path + "\\db\\settings\\overlay_mainUI.xml";
        #endregion

        public void Dispose()
        {

        }



        private void GetDefaultSettings()
        {
            globalSettings.Overlay_Toggle = false;
            globalSettings.Relying_On_Game = false;

            globalSettings.UI_Opacity = 80;
        }

        public void SaveSettings()
        {
            if (ParentForm != null)
            {
                globalSettings.Overlay_Toggle = ParentForm.Overlay_Toggle;
                globalSettings.Relying_On_Game = ParentForm.Relying_On_Game;
                globalSettings.UI_Opacity = ParentForm.UI_Opacity;
            }

            // 기본 속성 저장
            XmlDocument document = new XmlDocument();
            document.LoadXml("<MainUI></MainUI>");

            XmlElement controls = document.CreateElement("Controls");

            XmlElement element = document.CreateElement("Overlay_Toggle");
            element.InnerText = globalSettings.Overlay_Toggle.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("Relying_On_Game");
            element.InnerText = globalSettings.Relying_On_Game.ToString();
            controls.AppendChild(element);

            element = document.CreateElement("UI_Opacity");
            element.InnerText = globalSettings.UI_Opacity.ToString();
            controls.AppendChild(element);

            document.DocumentElement.AppendChild(controls);


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
            GetDefaultSettings();

            if (!File.Exists(filePath))
                return;

            XmlDocument document = new XmlDocument();
            document.Load(filePath);

            XmlNode singleNode = document.SelectSingleNode("MainUI/Controls/Overlay_Toggle");
            if (singleNode != null)
                bool.TryParse(singleNode.InnerText, out globalSettings.Overlay_Toggle);

            singleNode = document.SelectSingleNode("MainUI/Controls/Relying_On_Game");
            if (singleNode != null)
                bool.TryParse(singleNode.InnerText, out globalSettings.Relying_On_Game);

            singleNode = document.SelectSingleNode("MainUI/Controls/UI_Opacity");
            if (singleNode != null)
                byte.TryParse(singleNode.InnerText, out globalSettings.UI_Opacity);
        }

    }
}
