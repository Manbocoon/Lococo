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
    public partial class mainUI : Form
    {

        #region Global Variables
        public Form ParentForm { get; set; }
        public object SettingsForm { get; set; }
        public slider SliderForm { get; set; }

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

        #region Private Variables
        private messageForm messageForm = new messageForm();

        private readonly string appPath = Application.StartupPath;
        #endregion



        public mainUI()
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



        #region Functions - Overlay
        private void SetClickable(bool clickable)
        {
            if (ParentForm is o_browser)
            {
                ((o_browser)ParentForm).clickable = clickable;
            }

            else if (ParentForm is o_image_sizer)
            {
                ((o_image_sizer)ParentForm).clickable = clickable;
            }
        }

        private bool Clickable()
        {
            bool clickable = true;

            if (ParentForm is o_browser)
            {
                clickable = ((o_browser)ParentForm).clickable;
            }

            else if (ParentForm is o_image_sizer)
            {
                clickable = ((o_image_sizer)ParentForm).clickable;
            }

            return clickable;
        }

        private byte GetOpacity()
        {
            byte opacity = 80;

            if (ParentForm is o_browser)
            {
                opacity = ((o_browser)ParentForm).opacity;
            }

            else if (ParentForm is o_image_sizer)
            {
                opacity = ((o_image_sizer)ParentForm).ParentForm.opacity;
            }

            return opacity;
        }
        #endregion




        #region Event Handlers - Buttons
        private readonly Color Button_DefaultBackColor = Color.FromArgb(22, 22, 22);
        private readonly Color Button_ActivatedBackColor = Color.FromArgb(255, 81, 36);
        private void lockButton_Click(object sender, EventArgs e)
        {
            if (lockButton.Image == null)
            {
                lockButton.Image = Properties.Resources.unlock;
                return;
            }

            bool clickable = true;
            if (lockButton.BackColor.R > 22)
            {
                clickable = false;
            }



            lockButton.Image.Dispose();

            if (clickable)
            {
                lockButton.Image = Properties.Resources._lock;
                lockButton.BackColor = Button_ActivatedBackColor;
            }

            else
            {
                lockButton.Image = Properties.Resources.unlock;
                lockButton.BackColor = Button_DefaultBackColor;
            }

            SetClickable(!clickable);
        }

        private void opacityButton_Click(object sender, EventArgs e)
        {
            bool opened = false;
            if (opacityButton.BackColor.R > 22)
            {
                opened = true;
            }

            opened = !opened;         
            if (opened)
            {
                SliderForm = new slider();
                SliderForm.start_value = GetOpacity();
                SliderForm.ParentForm = ParentForm;
                SliderForm.Location = new Point(this.Right + 5, this.Top);
                SliderForm.Opacity = Opacity;
                SliderForm.Show();

                if (ParentForm is o_browser)
                {
                    ((o_browser)ParentForm).SliderForm = SliderForm;
                }

                else if (ParentForm is o_image_sizer)
                {
                    ((o_image_sizer)ParentForm).SliderForm = SliderForm;
                }

                opacityButton.BackColor = Button_ActivatedBackColor;
            }

            else
            {
                if (SliderForm != null && SliderForm.IsHandleCreated)
                {
                    SliderForm.Dispose();
                    SliderForm.Close();

                    opacityButton.BackColor = Button_DefaultBackColor;
                }
            }
        }



        private void settingsButton_Click(object sender, EventArgs e)
        {
            bool opened = false;
            if (settingsButton.BackColor.R > 22)
            {
                opened = true;
            }

            opened = !opened;

            if (opened)
            {
                if (ParentForm is o_browser)
                {
                    SettingsForm = new s_browser();
                    ((s_browser)SettingsForm).ParentForm = (o_browser)ParentForm;
                    ((s_browser)SettingsForm).Location = new Point(ParentForm.Right + 5, ParentForm.Top);
                    ((s_browser)SettingsForm).Opacity = Opacity;
                    ((s_browser)SettingsForm).Show();

                }

                else if (ParentForm is o_image_sizer)
                {
                    SettingsForm = new s_image();
                    ((s_image)SettingsForm).ParentForm = ((o_image_sizer)ParentForm).ParentForm;
                    ((s_image)SettingsForm).Location = new Point(ParentForm.Right + 5, ParentForm.Top);
                    ((s_image)SettingsForm).Opacity = Opacity;
                    ((s_image)SettingsForm).Show();
                }

                settingsButton.BackColor = Button_ActivatedBackColor;
            }

            else
            {
                if (SettingsForm != null && ((Form)SettingsForm).IsHandleCreated)
                {
                    ((Form)SettingsForm).Dispose();
                    ((Form)SettingsForm).Close();
                }

                settingsButton.BackColor = Button_DefaultBackColor;
            }


        }

        private void favoritesButton_Click(object sender, EventArgs e)
        {
            bool opened = false;
            if (favoritesButton.BackColor.R > 22)
            {
                opened = true;
            }

            opened = !opened;

            if (opened)
            {
                fav_menu.Renderer = new ToolStripProfessionalRenderer(new Functions.UI.MenuColorTable());
                fav_menu.ForeColor = Color.White;
                fav_menu.Show(favoritesButton, new Point(favoritesButton.Width, 0));

                favoritesButton.BackColor = Button_ActivatedBackColor;
            }

            else
            {


                favoritesButton.BackColor = Button_DefaultBackColor;
            }



        }
        #endregion



        #region Event Handlers - Form

        private void mainUI_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;

            this.WindowState = FormWindowState.Normal;

            if (!Clickable())
            {
                lockButton.Image = Properties.Resources._lock;
                lockButton.BackColor = Button_ActivatedBackColor;
            }

            else
            {
                lockButton.Image = Properties.Resources.unlock;
                lockButton.BackColor = Button_DefaultBackColor;
            }
        }


        #endregion
    }


}
