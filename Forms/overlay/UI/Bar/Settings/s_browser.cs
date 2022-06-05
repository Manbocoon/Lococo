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


        private bool IsValidURL(string source)
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
            zoom.Value = ((o_browser)Owner).zoom;
        }


        private void s_browser_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;

            this.WindowState = FormWindowState.Normal;

            if (Program.IsActivated(Owner))
            {
                ((o_browser)Owner).SettingsForm = this;

                LoadSettings();
            }
        }




        #region Event Handlers - Buttons

        private void URL_map_Click(object sender, EventArgs e)
        {
            if (!Program.IsActivated(Owner))
                return;

            ((o_browser)Owner).URL = "https://lostark.inven.co.kr/dataninfo/world/?code=10201";
        }

        private void URL_bingpago_Click(object sender, EventArgs e)
        {
            if (!Program.IsActivated(Owner))
                return;

            ((o_browser)Owner).URL = "https://ialy1595.me/kouku/";
        }

        private void URL_youtube_Click(object sender, EventArgs e)
        {
            if (!Program.IsActivated(Owner))
                return;

            ((o_browser)Owner).URL = "https://www.youtube.com";
        }

        private void URL_input_Click(object sender, EventArgs e)
        {
            if (!Program.IsActivated(Owner))
                return;

            if (file_path.TextLength < 1)
                return;

            if (!File.Exists(file_path.Text))            
                if (!file_path.Text.Contains("https://") && !file_path.Text.Contains("http://"))            
                    file_path.Text = "https://" + file_path.Text;
                   
            ((o_browser)Owner).URL = file_path.Text;
        }
        #endregion

        private void file_path_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                URL_input_Click(URL_input, new EventArgs());
           
        }




        private bool changedByParent = false;
        private void zoom_ValueChanged(object sender, EventArgs e)
        {
            if (!Program.IsActivated(Owner))
                return;

            zoom_value.Text = zoom.Value.ToString() + "%";

            if (!changedByParent)
                ((o_browser)Owner).zoom = (ushort)zoom.Value;

        }
    }
}
