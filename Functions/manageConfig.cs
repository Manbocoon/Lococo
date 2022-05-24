using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;





namespace Lococo.Functions
{
    class manageConfig : IDisposable
    {
        #region Windows API
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string sAppName, string sKeyName, string sDefault, StringBuilder sReturnedString, int nSize, string sFileName);

        [DllImport("kernel32")]
        public static extern int WritePrivateProfileString(string sAppName, string sKeyName, string sValue, string sFileName);
        #endregion

        private StringBuilder str = new StringBuilder(null);




        public void Dispose()
        {

        }



        public void writeConfig(string treeName, string contentName, string value, string filePath)
        {
            WritePrivateProfileString(treeName, contentName, value, filePath);
        }

        public string readConfig(string treeName, string contentName, string filePath)
        {
            str.Clear();
            GetPrivateProfileString(treeName, contentName, null, str, 1024, filePath);

            return str.ToString();
        }

    }
}
