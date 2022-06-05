using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using Microsoft.Win32;
using System.Security;





namespace Lococo.Forms.overlay.UI.Bar
{
    /// <summary>
    /// 모든 오버레이의 불투명도 설정 창
    /// </summary>
    public partial class favorites : Form
    {
        #region Windows API
        [DllImport("user32")]
        public static extern Int32 SetWindowLong(IntPtr hWnd, Int32 nIndex, Int32 dwNewLong);
        [DllImport("user32")]
        public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 nIndex);
        #endregion


        #region Global Variables
        public Form ParentForm { get; set; }

        private byte opacityUI_value = 80;
        public byte opacityUI
        {
            get
            {
                Invoke((MethodInvoker)delegate
                {
                    opacityUI_value = (byte)(this.Opacity * 100);
                });

                return opacityUI_value;
            }

            set
            {
                opacityUI_value = value;

                if (IsHandleCreated)
                {
                    Opacity = (double)value / 100;
                }
            }
        }
        #endregion

    

        public favorites()
        {
            InitializeComponent();
        }

        #region Form - Hide from Alt+Tab Switcher / Show Shadow
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;
                Params.ExStyle |= 0x80;

                return Params;
            }
        }
        #endregion



        private void overlayForm_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;

            this.WindowState = FormWindowState.Normal;

            
            if (ParentForm != null)
            {
                Program.ShowMsgbox(ParentForm.GetType().Name);
            }


        }

    }
}
