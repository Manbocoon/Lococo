using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lococo
{
    static class Game
    {
        #region Win32 API
        [DllImport("user32")]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(int parent, int childAfter, string className, string windowName);
        [DllImport("user32")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);


        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool QueryFullProcessImageName(IntPtr hProcess, int dwFlags, StringBuilder lpExeName, ref int lpdwSize);

        private const int QueryLimitedInformation = 0x00001000;
        #endregion


        // 프로세스의 실행파일 경로를 가져오는 함수
        public static string GetProcessPath(Process process)
        {
            int size = 1024;
            StringBuilder exeName = new StringBuilder(size);
            IntPtr handle = OpenProcess(QueryLimitedInformation, false, process.Id);

            if (handle == IntPtr.Zero)
                return null;

            bool success = QueryFullProcessImageName(handle, 0, exeName, ref size);
            CloseHandle(handle);

            if (!success)
                return null;

            return exeName.ToString();
        }

        // 레지스트리에서 로스트아크 경로를 가져오는 함수
        public static string GetDirectoryPath()
        {
            string gamePath = null;

            // 기본 경로: C:\Program Files (x86)\Smilegate\Games\LOSTARK
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\SGUP\Apps\45", false);

            if (key != null)
            {
                gamePath = (string)key.GetValue("GamePath", null);
                key.Close();
                key.Dispose();
            }

            return gamePath;
        }

        // 로스트아크 실행파일 경로를 가져오는 함수
        public static string GetExecutablePath()
        {
            string gamePath = GetDirectoryPath();
            string exePath = gamePath + "\\Binaries\\Win64\\LOSTARK.exe";

            if (!File.Exists(exePath))
            {
                exePath = null;
            }

            return exePath;
        }

        // 로스트아크가 설치되어있는지 확인하는 함수
        public static bool IsInstalled()
        {
            bool result = false;
            string gamePath = GetDirectoryPath();

            string lostark_exe = gamePath + @"\Binaries\Win64\LOSTARK.exe";
            if (File.Exists(lostark_exe))
            {
                result = true;
            }

            return result;
        }

        // 로스트아크가 구동중인지 확인하는 함수
        public static bool IsRunning()
        {
            if (!IsInstalled())
            {
                return false;
            }

            bool result = false;
            StringBuilder appTitle = new StringBuilder(null, 100);
            IntPtr lostarkHwnd = FindWindow("EFLaunchUnrealUWindowsClient", null);
            GetWindowText(lostarkHwnd, appTitle, 100);

            if (appTitle.ToString().StartsWith("LOST ARK"))
            {
                Process[] procs = Process.GetProcessesByName("LOSTARK");
                for (int i=0; i<procs.Length; ++i)
                {
                    if (GetProcessPath(procs[i]) == GetExecutablePath())
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }



        // 로스트아크 실시간 화면 설정을 가져오는 함수
        public static ScreenOption GetScreenOption()
        {
            ScreenOption screen_option = new ScreenOption();
            screen_option.Read_Success = false;

            string root_path = GetDirectoryPath();
            string config_path = root_path + "\\EFGame\\Config\\UserOption.xml"; 
            if (!File.Exists(config_path))
            {
                return screen_option;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(config_path);

            XmlNode resolution = doc.SelectSingleNode("UserOption/GraphicOptionData/CurrentResolutionData");
            if (resolution != null)
            {
                screen_option.Read_Success = true;

                XmlNode node = resolution.SelectSingleNode("FullScreen");
                if (node != null)
                {
                    byte.TryParse(node.InnerText, out byte bool_num);

                    screen_option.FullScreen = Convert.ToBoolean(bool_num);
                }

                node = resolution.SelectSingleNode("Borderless");
                if (node != null)
                {
                    byte.TryParse(node.InnerText, out byte bool_num);

                    screen_option.Borderless = Convert.ToBoolean(bool_num);
                }
            }

            return screen_option;
        }
        public struct ScreenOption
        {
            public bool FullScreen;
            public bool Borderless;

            public bool Read_Success;
        };
    }
}
