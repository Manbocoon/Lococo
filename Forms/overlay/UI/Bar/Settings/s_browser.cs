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
    public partial class s_browser : Form
    {

        #region Global Variables
        public o_browser ParentForm { get; set; }

        public ushort zoomValue
        {
            get
            {
                return (ushort)zoom.Value;
            }

            set
            {
                if (this.IsHandleCreated)
                {
                    changedByParent = true;
                    zoom.Value = value;
                    changedByParent = false;
                }
            }
        }

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





        public s_browser()
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


        private bool checkURLValid(string source)
        {
            bool result = false;

            if (!source.StartsWith("http://") || !source.StartsWith("https://"))
                source = "https://" + source;

            if (source.IndexOf('.') > -1)
                result = true;

            return result;
        }


        private void LoadSettings()
        {
            zoom.Value = ParentForm.zoom;
        }


        private void s_browser_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;

            this.WindowState = FormWindowState.Normal;

            if (Program.IsActivated(ParentForm))
            {
                ParentForm.ChildForm = this;

                LoadSettings();
            }
        }




        #region Event Handlers - Buttons

        private void URL_map_Click(object sender, EventArgs e)
        {
            if (ParentForm == null || !ParentForm.IsHandleCreated)
            {
                return;
            }

            ParentForm.URL = "https://lostark.inven.co.kr/dataninfo/world/?code=10201";
        }

        private void URL_bingpago_Click(object sender, EventArgs e)
        {
            if (ParentForm == null || !ParentForm.IsHandleCreated)
            {
                return;
            }

            ParentForm.URL = "https://ialy1595.me/kouku/";
        }

        private void URL_youtube_Click(object sender, EventArgs e)
        {
            if (ParentForm == null || !ParentForm.IsHandleCreated)
            {
                return;
            }

            ParentForm.URL = "https://www.youtube.com";
        }

        private void URL_input_Click(object sender, EventArgs e)
        {
            if (ParentForm == null || !ParentForm.IsHandleCreated)
            {
                return;
            }

            string input_url = Microsoft.VisualBasic.Interaction.InputBox("오버레이에 표시할 웹사이트의 URL이나 로컬 HTML파일의 경로를 입력하세요.\r\n\r\n(예시) 네이버라면 https://www.naver.com 입력", "브라우저 오버레이 링크 입력", null);

            if (input_url.Length < 1)
                return;

            if (!checkURLValid(input_url))
            {
                Program.ShowMsgbox("유효한 링크(URL)이 아닙니다.", "실패", false);
                return;
            } 
            
            ParentForm.URL = input_url;
        }
        #endregion


        private bool changedByParent = false;
        private void zoom_ValueChanged(object sender, EventArgs e)
        {
            if (ParentForm == null || !ParentForm.IsHandleCreated)
            {
                return;
            }

            zoom_value.Text = zoom.Value.ToString() + "%";

            if (!changedByParent)
            {
                ParentForm.zoom = (ushort)zoom.Value;
            }
        }

    }
}
