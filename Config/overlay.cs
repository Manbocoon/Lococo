using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using Lococo.Forms.overlay;



namespace Lococo.Config
{
    /// <summary>
    /// 브라우저 오버레이의 설정을 관리하는 객체입니다.
    /// </summary>
    class overlay : IDisposable
    {
        #region Global Variables
        private Form Owner_value = null;
        public Form Owner
        {
            get
            {
                return Owner_value;
            }

            set
            {
                if (value == null)
                    return;

                Owner_value = value;

                defaultConfigPath = _public.configDir + "\\overlay_" + Owner.GetType().Name + ".xml";
                configDir = _public.configDir;
                favDir = _public.configDir + "\\favorites\\" + Owner.GetType().Name;
            }
        }

        /// <summary>
        /// 브라우저 오버레이의 설정을 담는 변수입니다.
        /// </summary>

        public Dictionary<string, object> Configs = new Dictionary<string, object>() 
        {
            {"URL", null}, {"clickable", null}, {"zoom", null }, {"opacity", null}, {"Bounds", null},
            {"keepRatio", null }, {"imgPath", null}, {"useOriginalSize", null}
        };

        /// <summary>
        /// 오버레이 설정 즐겨찾기 목록입니다.
        /// </summary>
        public List<string> favorites = new List<string>();
        #endregion


        #region Private Variables
        /// <summary>
        /// 자동으로 저장되고 불러와지는 설정파일의 경로입니다. 부모 오버레이 창(Owner)의 유형에 따라 파일 경로가 자동 변경됩니다.
        /// </summary>
        public string defaultConfigPath = null;

        /// <summary>
        /// 설정파일의 폴더경로입니다. 부모 오버레이 창(Owner)의 유형에 따라 파일 경로가 자동 변경됩니다.
        /// </summary>
        public string configDir = null;

        /// <summary>
        /// 즐겨찾기 설정파일의 폴더경로입니다. 부모 오버레이 창(Owner)의 유형에 따라 파일 경로가 자동 변경됩니다.
        /// </summary>
        public string favDir = null;
        #endregion

        public void Dispose()
        {

        }



        #region Settings
        /// <summary>
        /// 켜져 있는 오버레이의 설정을 그대로 불러옵니다.
        /// </summary>
        private void GetActiveSettings()
        {
            if (!Program.IsActivated(Owner))
            {
                Program.ShowMsgbox("오버레이 창의 현재 설정을 읽지 못했습니다.\r\n\r\n오버레이 창이 활성화되지 않았습니다.", "저장 실패");
                return;
            }

            foreach (var item in Configs.ToList())
            {
                if (!Program.IsValidProperty(Owner, item.Key))
                    continue;

                Configs[item.Key] = Program.GetProperty(Owner, item.Key);
            }
        }

        /// <summary>
        /// 오버레이 창의 기본 초기설정을 불러옵니다.
        /// </summary>
        private void LoadDefaultSettings()
        {
            Configs["Bounds"] = new Rectangle(0, 30, 500, 500);
            Configs["clickable"] = true;
            Configs["zoom"] = 100;
            Configs["opacity"] = 80;
            Configs["URL"] = "https://lostark.inven.co.kr/dataninfo/world/?code=10201";
            Configs["keepRatio"] = true;
            Configs["imgPath"] = null;
            Configs["useOriginalSize"] = false;
        }

        /// <summary>
        /// 현재 브라우저 오버레이 설정을 자동으로 관리될 기본 파일로 저장합니다.
        /// </summary>
        public void SaveSettings()
        {
            SaveSettings(defaultConfigPath);
        }

        /// <summary>
        /// 현재 브라우저 오버레이 설정을 특정 파일로 저장합니다.
        /// </summary>
        /// <param name="file_path">저장할 파일의 경로입니다.</param>
        public void SaveSettings(string file_path)
        {
            if (!_File.IsValidFileName(Path.GetFileName(file_path)))
            {
                Program.ShowMsgbox("설정 혹은 즐겨찾기를 저장하지 못했습니다.\r\n\r\n" + Path.GetFileName(file_path) + " 는 윈도우에서 사용 불가능한 파일명입니다.", "실패");
                return;
            }

            GetActiveSettings();

            // 기본 속성 저장
            XmlDocument document = new XmlDocument();
            document.LoadXml("<OverlayConfig></OverlayConfig>");

            foreach (var item in Configs.ToList())
            {
                string key = item.Key;
                object value = item.Value;
                string config_value = null;

                if (!Program.IsValidProperty(Owner, key))
                    continue;


                if (value is Rectangle)
                    config_value = new RectangleConverter().ConvertToString(value);

                else
                {
                    if (value == null)
                        value = "";

                    config_value = value.ToString();
                }


                XmlElement node = document.CreateElement(key);
                node.InnerText = config_value;
                document.DocumentElement.AppendChild(node);
            }

            // .NET 자체에서 지원하는 Encoding.UTF8 사용 시, 인코딩 및 인디언 확인을 위한 3 Byte 크기의 BOM(Byte Order Mark)가 붙어버리므로
            // new UTF8Encoding(false)를 통해 범용성 높은 진짜 UTF8 인코딩으로 작성
            _public.CreateDirectories();
            using (XmlTextWriter writer = new XmlTextWriter(file_path, new UTF8Encoding(false)))
            {
                writer.Formatting = Formatting.Indented;
                document.Save(writer);
            }

        }

        /// <summary>
        /// 자동 저장된 파일로부터 브라우저 오버레이 설정을 읽어들입니다.
        /// </summary>
        public void ReadSettings()
        {
            ReadSettings(defaultConfigPath);
        }

        /// <summary>
        /// 특정 파일로부터 브라우저 오버레이 설정을 읽어들입니다.
        /// </summary>
        /// <param name="file_path">읽을 파일의 경로입니다.</param>
        public void ReadSettings(string file_path)
        {
            LoadDefaultSettings();

            if (!File.Exists(file_path))
            {
                Program.ShowMsgbox("설정 파일이 존재하지 않아 오버레이에 불러오지 못했습니다.\r\n\r\n" + file_path.Replace(Program.Path, "프로그램 폴더"), "실패");
                return;
            }

            if (!IsValidConfig(file_path))
            {
                try { File.Delete(file_path); }
                catch (Exception) { }

                SaveSettings(file_path);
                GetActiveSettings();
                Program.ShowMsgbox("불러오고자 하는 설정파일이 유효하지 않아 초기화했습니다.\r\n\r\n" + file_path.Replace(Program.Path, "프로그램 폴더"), "실패");
                return;
            }

            XmlDocument document = new XmlDocument();
            document.Load(file_path); 

            foreach (var item in Configs.ToList())
            {
                string key = item.Key;
                object value = item.Value;

                if (!Program.IsValidProperty(Owner, key))
                    continue;


                XmlNode node = document.SelectSingleNode("OverlayConfig/" + key);
                if (node == null || String.IsNullOrEmpty(node.InnerText))
                    continue;

                if (key == "Bounds")
                    Configs[key] = new RectangleConverter().ConvertFromString(node.InnerText);
                
                else
                    Configs[key] = node.InnerText;               
            }
        }

        /// <summary>
        /// 읽어들인 설정/즐겨찾기를 현재 켜져있는 브라우저 오버레이에 즉시 적용시킵니다.
        /// </summary>
        public void ApplySettings()
        {
            if (!Program.IsActivated(Owner))
            {
                Program.ShowMsgbox("오버레이 설정을 불러오지 못했습니다.\r\n\r\n오버레이 창이 활성화되지 않았습니다.", "불러오기 실패");
                return;
            }

            foreach (var item in Configs.ToList())
            {
                string key = item.Key;
                object value = item.Value;
                object config_value = value;

                if (!Program.IsValidProperty(Owner, key))
                    continue;

                Program.SetProperty(Owner, key, config_value);
            }
        }

        /// <summary>
        /// 특정 설정/즐겨찾기 파일이 불러올 수 있는 유효한 파일인지 확인합니다.
        /// </summary>
        /// <param name="filePath">확인할 설정파일의 경로입니다.</param>
        public bool IsValidConfig(string filePath)
        {
            bool is_valid = true;

            if (!File.Exists(filePath))
                is_valid = false;
            

            XmlDocument document = new XmlDocument();

            try { document.Load(filePath); }

            catch (XmlException)
            { is_valid = false; }

            foreach (var item in Configs.ToList())
            {
                string key = item.Key;

                if (!Program.IsValidProperty(Owner, key))
                    continue;

                var node = document.SelectSingleNode("OverlayConfig/" + key);
                if (node == null)
                {
                    is_valid = false;
                    break;
                }
            }
  
            return is_valid;
        }
        #endregion


        #region Favorites
        /// <summary>
        /// 즐겨찾기 리스트에 파일로 저장된 모든 즐겨찾기를 불러오는 함수입니다.
        /// </summary>
        public void ReadFavorites()
        {
            favorites.Clear();

            if (!Directory.Exists(favDir))         
                return;
            

            string[] fav_files = Directory.GetFiles(favDir, "*.xml", SearchOption.TopDirectoryOnly);
            foreach (string filePath in fav_files)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                favorites.Add(fileName);
            }

        }

        /// <summary>
        /// 단일 즐겨찾기 파일로부터 브라우저 오버레이 설정을 읽어옵니다.
        /// </summary>
        /// <param name="fav_name">읽어올 즐겨찾기 파일의 이름입니다.</param>
        public void ReadFavorite(string fav_name)
        {
            ReadSettings(favDir + "\\" + fav_name + ".xml");
        }


        /// <summary>
        /// 현재 브라우저 오버레이의 설정을 단일 즐겨찾기 파일로 저장합니다.
        /// </summary>
        /// <param name="fav_name">저장할 즐겨찾기 파일의 이름입니다.</param>
        public void SaveFavorite(string fav_name)
        {
            SaveSettings(favDir + "\\" + fav_name + ".xml");
        }

        #endregion
    }
}
