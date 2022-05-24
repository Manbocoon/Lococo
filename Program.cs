using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lococo
{
    static class Program
    {

        #region Static Variables
        public static Size screen = Screen.PrimaryScreen.Bounds.Size;

        public static string path = Application.StartupPath;
        public static string exePath = Application.ExecutablePath;
        #endregion

        #region Static Functions
        public static void ShowMsgbox(string message)
        {
            ShowMsgbox(message, "", false);
        }

        public static void ShowMsgbox(string message, string caption)
        {
            ShowMsgbox(message, caption, false);
        }

        public static bool ShowMsgbox(string message, string caption, bool yesNo)
        {
            using (Forms.messageForm msgForm = new Forms.messageForm())
            {
                bool result = false;

                msgForm.msg = message;
                msgForm.cap = caption;
                msgForm.yesNo = yesNo;

                msgForm.ShowDialog();

                if (msgForm.dialogResult == 1)
                    result = true;

                return result;
            }
        }

        public static bool IsActivated(object _object)
        {
            bool is_activated = false;

            if (_object == null)
            {
                return false;
            }


            if (_object is Form)
            {
                if (((Form)_object).IsHandleCreated && !((Form)_object).IsDisposed)
                {
                    is_activated = true;
                }
            }

            else if (_object is Thread)
            {
                if (((Thread)_object).IsAlive)
                {
                    is_activated = true;
                }
            }

            return is_activated;
        }
        #endregion




        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex mutex = new Mutex(true, "Lococo", out bool isNotDuplicated);
            bool isDuplicated = !isNotDuplicated;

            if (isDuplicated)
            {
                MessageBox.Show("프로그램이 이미 실행중입니다.", "Lococo", 0, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.mainUI.MainForm());

            mutex.ReleaseMutex();
        }

    }
}
