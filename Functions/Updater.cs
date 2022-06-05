using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lococo.Functions
{
    /// <summary>
    /// Lococo 프로그램의 업데이트를 관리하는 객체입니다.
    /// </summary>
    class Updater : IDisposable
    {
        public readonly string Release_Url = "https://github.com/bumju08/Lococo/releases";


        public void Dispose()
        {

        }

        /// <summary>
        /// 웹으로부터 얻은 최신버전의 정보를 저장할 구조체입니다.
        /// </summary>
        public struct AppINFO
        {
            public string Name;
            public string Version;

            public StringBuilder Patch_Note;
            public string Download_URL;
        }


        private DateTime GetLastCheckedDate()
        {
            DateTime last_time = DateTime.Now.AddDays(-1);
            DateTime saved_time = Properties.Settings.Default.LastUpdateCheckedTime;

            // 파일 조작을 통해 업데이트 자동확인을 막는 행위 방지
            if (DateTime.Compare(saved_time, DateTime.Now) > 0)
            {
                saved_time = last_time;
            }
            last_time = saved_time;

            return last_time;
        }

        private void SetLastCheckedDate()
        {
            Properties.Settings.Default.LastUpdateCheckedTime = DateTime.Now;
            Properties.Settings.Default.Save();
        }


        /// <summary>
        /// 웹으로부터 최신버전에 대한 정보를 불러옵니다.
        /// </summary>
        public AppINFO GetRecentInfo()
        {
            AppINFO AppInfo = new AppINFO();
            string name_and_version = null;
            //string web_data = null;
            //string download_url = null;

            DateTime lastCheckedDate = GetLastCheckedDate();
            DateTime now = DateTime.Now;
            TimeSpan date_span = (now - lastCheckedDate);

            // Github 악의적인 트래픽 부하 방지, 각 유저당 30초의 쿨타임
            if (date_span.TotalSeconds < 30)
            {
                AppInfo.Name = "WAITING: " + (30 - (int)date_span.TotalSeconds).ToString();

                return AppInfo;
            }

            using (WebClient web_client = new WebClient())
            {
                web_client.Encoding = Encoding.UTF8;
                web_client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                try
                {
                    Stream webData = web_client.OpenRead(Release_Url + "/latest");
                    StreamReader webDataReader = new StreamReader(webData);

                    while (!webDataReader.EndOfStream)
                    {
                        string webDataLine = webDataReader.ReadLine();

                        if (webDataLine.Contains("<title>Release"))
                        {
                            name_and_version = webDataLine.Trim();
                            break;
                        }
                    }

                    webDataReader.Dispose();
                    webData.Dispose();
                }

                catch (Exception)
                {
                    AppInfo.Name = "SERVER NOT AVAILABLE";
                    return AppInfo;
                }
            }

            /*
            AppInfo.Patch_Note = new StringBuilder(null);
            int block_count = 0;
            foreach (string data_line in web_data.Split('\n'))
            {
                if (data_line.Contains("<title>Release"))
                {
                    name_and_version = data_line.Trim();
                    break;
                }

                
                else if (data_line.Contains("<p>"))
                {
                    string patchNoteData = data_line;
                    patchNoteData = patchNoteData.Remove(0, patchNoteData.IndexOf("<p>") + 3);
                    patchNoteData = patchNoteData.Remove(patchNoteData.IndexOf("</p>"), 4);

                    if (patchNoteData.IndexOf('■') != -1)
                    {
                        if (block_count > 0)
                        {
                            AppInfo.Patch_Note.AppendLine();
                        }
                    }

                    else
                    {
                        AppInfo.Patch_Note.Append("  ");
                    }
                    ++block_count;

                    AppInfo.Patch_Note.AppendLine(patchNoteData);
                }

                
                else if (data_line.Contains("download/"))
                {
                    download_url = data_line;
                    download_url = download_url.Remove(0, download_url.IndexOf("\"") + 1);
                    download_url = download_url.Remove(download_url.IndexOf("\""));

                    AppInfo.Download_URL = "https://github.com" + download_url;
                }
            }*/

            // Trim된 결과물 = <title>Release 버전명 · 아이디/Repository명 · GitHub</title>
            string version = name_and_version;
            version = version.Remove(0, version.IndexOf(' ') + 1);
            version = version.Remove(version.IndexOf('·') - 1);

            string name = name_and_version;
            name = name.Remove(0, name.IndexOf("bumju08/") + 8);
            name = name.Remove(name.IndexOf("·") - 1);

            AppInfo.Version = version;
            AppInfo.Name = name;

            SetLastCheckedDate();

            return AppInfo;
        }







    }
}
