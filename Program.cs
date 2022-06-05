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
        public static readonly string VERSION = "2022 06 05";
        #endregion

        #region Static Functions
        /// <summary>
        /// Lococo의 커스텀 메세지박스를 띄웁니다.
        /// </summary>
        /// <param name="message">내용입니다.</param>
        public static void ShowMsgbox(string message)
        {
            ShowMsgbox(message, APP_NAME, false);
        }

        /// <summary>
        /// Lococo의 커스텀 메세지박스를 띄웁니다.
        /// </summary>
        /// <param name="message">내용입니다.</param>
        /// <param name="caption">재목입니다.</param>
        public static void ShowMsgbox(string message, string caption)
        {
            ShowMsgbox(message, caption, false);
        }

        /// <summary>
        /// Lococo의 커스텀 메세지박스를 띄웁니다.
        /// </summary>
        /// <param name="message">내용입니다.</param>
        /// <param name="caption">재목입니다.</param>
        /// <param name="use_YesNo">"예/아니오" 버튼을 사용할지의 여부입니다. 이 옵션을 사용한다면 사용자의 선택을 반환합니다.</param>
        public static bool ShowMsgbox(string message, string caption, bool use_YesNo)
        {
            using (var msgForm = new Forms.messageForm())
            {
                bool result = false;

                msgForm.msg = message;
                msgForm.cap = caption;
                msgForm.yesNo = use_YesNo;

                msgForm.ShowDialog();

                if (msgForm.dialogResult == 1)
                    result = true;

                return result;
            }
        }

        /// <summary>
        /// 알 수 없는 객체에서 특정 이름의 속성 값을 가져옵니다.
        /// </summary>
        public static object GetProperty(object _object, string property_name)
        {
            var propertyInfo = _object.GetType().GetProperty(property_name);

            if (propertyInfo == null)
                return null;

            var property_value = propertyInfo.GetValue(_object, null);

            return property_value;
        }

        /// <summary>
        /// 알 수 없는 객체에서 특정 이름의 속성 값을 설정합니다.
        /// </summary>
        public static void SetProperty(object _object, string property_name, object value)
        {
            var propertyInfo = _object.GetType().GetProperty(property_name);

            propertyInfo.SetValue(_object, Convert.ChangeType(value, propertyInfo.PropertyType), null);
        }


        /// <summary>
        /// 알 수 없는 객체에서 같은 이름의 메서드가 존재하는지 확인하는 함수입니다.
        /// </summary>
        public static bool IsValidProperty(object _object, string method_name)
        {
            if (_object == null) 
                return false;

            if (_object is IDictionary<string, object> dict)           
                return dict.ContainsKey(method_name);
            
            return _object.GetType().GetProperty(method_name) != null;
        }

        /// <summary>
        /// 특정 객체가 활성화되어 있는지 확인할 함수입니다.
        /// </summary>
        /// <param name="_object">확인할 객체입니다.</param>
        /// <returns></returns>
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
                    is_activated = true;
            }

            else if (_object is Thread)
            {
                if (((Thread)_object).IsAlive)                
                    is_activated = true;
                
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
