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
        public static readonly Size screen = Screen.PrimaryScreen.Bounds.Size;

        public static readonly string Path = Application.StartupPath;
        public static readonly string EXE_PATH = Application.ExecutablePath;

        public static readonly string APP_NAME = "Lococo";
        public static readonly string VERSION = "2022 05 28";
        #endregion

        #region Static Functions
        public static void ShowMsgbox(string message)
        {
            ShowMsgbox(message, APP_NAME, false);
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
            Mutex mutex = new Mutex(true, APP_NAME, out bool isNotDuplicated);
            bool isDuplicated = !isNotDuplicated;

            if (isDuplicated)
            {
                MessageBox.Show("프로그램이 이미 실행중입니다.", APP_NAME, 0, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.mainUI.MainForm());

            mutex.ReleaseMutex();
        }

    }
}
