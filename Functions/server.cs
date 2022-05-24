using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lococo.Functions
{
    class server : IDisposable
    {
        public void Dispose()
        {

        }



        public string DownloadString(string fileName)
        {
            string URL = "http://gleak.dothome.co.kr/Lococo/" + fileName;
            string result = null;

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                
                try { result = client.DownloadString(URL);  }
                catch (Exception) { result = "ERROR: CONNECTION FAILED"; }
            }

            return result;
        }

        public void DownloadFile(string fileName, string destinationPath)
        {
            string URL = "http://gleak.dothome.co.kr/Lococo/user_backup/" + fileName;

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(URL, destinationPath);

                // 파일 마지막 수정시간을 서버에서 받아와 동일하게 적용
                var last_modified = client.ResponseHeaders["Last-Modified"];
                if (DateTime.TryParse(last_modified, out DateTime date))
                    System.IO.File.SetLastWriteTime(destinationPath, date);
            }
        }

        public string UploadFile(string localFilePath)
        {
            string URL = "http://gleak.dothome.co.kr/Lococo/upload.php";

            using (WebClient Client = new WebClient())
            {
                Client.Headers.Add("Content-Type", "binary/octet-stream");
                byte[] result_byte = Client.UploadFile(URL, "POST", localFilePath);

                return Encoding.UTF8.GetString(result_byte, 0, result_byte.Length);
            }

        }


        public bool checkFileExists(string fileName)
        {
            string URL = "http://gleak.dothome.co.kr/Lococo/user_backup/" + fileName;

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                string result = client.DownloadString(URL);

                if (result.Contains("Error 404"))              
                    return false;
                
            }

            return true;
        }

        public bool getServerState()
        {
            string URL = "http://gleak.dothome.co.kr/Lococo/state.txt";
            string data = null;
            bool result = false;

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                try { data = client.DownloadString(URL); }
                catch (Exception) { data = "ERROR: CONNECTION FAILED"; }

                if (data.Contains("정상"))
                    result = true;
            }

            return result;
        }







    }
}
