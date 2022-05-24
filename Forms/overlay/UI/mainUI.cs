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





namespace Lococo.Forms.overlay
{
    public partial class mainUI : Form
    {
        #region Global Variables

        public bool relying { get; set; } = true;

        public byte opacity
        {
            get
            {
                return (byte)(Opacity * 100);
            }

            set
            {
                Opacity = (float)value / 100;

                if (Program.IsActivated(overlayForm_browser))
                {
                    overlayForm_browser.opacityUI = opacity;
                }

                if (Program.IsActivated(overlayForm_image))
                {
                    overlayForm_image.SizerForm.opacityUI = opacity;
                }
            }
        }

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

        #region Form - Make Borderless Form Movable
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CAPTION = 0x2;

        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);

            if (msg.Msg == WM_NCHITTEST)
                msg.Result = (IntPtr)(HT_CAPTION);
        }
        #endregion


        private void SetOverlayOpacity(byte opacity_value)
        {
            float opacity_valueF = (float)opacity_value / 100;

            if (Program.IsActivated(overlayForm_browser))
            {
                if (Program.IsActivated(overlayForm_browser.ChildBar))
                {
                    overlayForm_browser.ChildBar.Opacity = opacity_valueF;
                }

                if (Program.IsActivated(overlayForm_browser.ChildForm))
                {
                    overlayForm_browser.ChildForm.Opacity = opacity_valueF;
                }

                if (Program.IsActivated(overlayForm_browser.SliderForm))
                {
                    overlayForm_browser.SliderForm.Opacity = opacity_valueF;
                }
            }


        }

        private void SetOverlayVisible(bool visible_value)
        {
            if (Program.IsActivated(overlayForm_browser))
            {
                Invoke((MethodInvoker)delegate 
                {
                    overlayForm_browser.Visible = visible_value; 
                });

            }

            if (Program.IsActivated(overlayForm_image))
            {
                Invoke((MethodInvoker)delegate
                {
                    overlayForm_image.Visible = visible_value;
                });


                if (Program.IsActivated(overlayForm_image.SizerForm))
                {
                    Invoke((MethodInvoker)delegate
                    {
                        overlayForm_image.SizerForm.Visible = visible_value;
                    });
                }
            }

            if (Program.IsActivated(overlayForm_text))
            {
                Invoke((MethodInvoker)delegate
                {
                    overlayForm_text.Visible = visible_value;
                });
            }

            if (Program.IsActivated(this))
            {
                Invoke((MethodInvoker)delegate
                {
                    Visible = visible_value;
                });
            }
        }

        public Thread _watcherThread;
        private void overlayForm_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;

            this.WindowState = FormWindowState.Normal;

            using (var shadowClass = new Functions.UI.dropShadow())
            {
                shadowClass.ApplyShadows(this, 5, 5, 5, 5);
            }

            Game.ScreenOption screen_option = Game.GetScreenOption();
            if (screen_option.Read_Success)
            {
                if (screen_option.FullScreen)
                {
                    Program.ShowMsgbox("로스트아크의 화면 설정이 \"전체 화면\"으로 설정되어 있습니다.\r\n\r\n오버레이는 \"전체 화면\"에서 작동하지 않으니, \"전체 창 모드\"로 사용하시길 권장합니다.", "알림");
                }
            }

            _watcherThread = new Thread(() =>
           {
               while (true)
               {
                   if (!Program.IsActivated(this))
                   {
                       return;
                   }

                   bool visible_value = false;

                   if (relying)
                   {
                       if (Game.IsRunning())
                       {
                           visible_value = true;
                       }

                       SetOverlayVisible(visible_value);
                   }

                   else
                   {
                       SetOverlayVisible(true);
                   }

                   Thread.Sleep(500);
               }
           });
            _watcherThread.IsBackground = true;
            _watcherThread.Start();
        }





        #region Event Handlers - Buttons For Overlay
        private readonly Color Button_DefaultBackColor = Color.FromArgb(22, 22, 22);
        private readonly Color Button_ActivatedBackColor = Color.FromArgb(75, 75, 75);
        public o_browser overlayForm_browser;
        public o_image overlayForm_image;
        public o_text overlayForm_text;

        public bool IsButtonActivated(Button button, bool change_state)
        {
            bool result = false;

            if (button.BackColor.R > Button_DefaultBackColor.R)
            {
                result = true;
            }

            if (change_state)
            {
                if (result)
                {
                    button.BackColor = Button_DefaultBackColor;
                }

                else
                {
                    button.BackColor = Button_ActivatedBackColor;
                }
            }

            return result;
        }

        private void ActivateButton(Button thisButton)
        {
            IsButtonActivated(thisButton, true);

            SwitchOverlayForm(thisButton);
        }

        private void SwitchOverlayForm(Button thisButton)
        {
            bool activated = false;
            if (thisButton.BackColor.R > 22)
            {
                activated = true;
            }

            else
            {
                activated = false; 
            }




            switch (thisButton.Name)
            {
                case "open_browser":

                    if (activated)
                    {
                        overlayForm_browser = new o_browser();
                        overlayForm_browser.Show();
                        overlayForm_browser.opacityUI = opacity;
                    }

                    else
                    {
                        if (Program.IsActivated(overlayForm_browser))
                        {
                            overlayForm_browser.SaveSettings();

                            overlayForm_browser.DisposeChilds();
                            overlayForm_browser.Dispose();
                            overlayForm_browser.Close();

                            GC.Collect();
                        }
                    }

                    break;


                case "open_image":

                    if (activated)
                    {
                        overlayForm_image = new o_image();
                        overlayForm_image.Show();
                        overlayForm_image.SizerForm.opacityUI = opacity;
                    }

                    else
                    {
                        if (Program.IsActivated(overlayForm_image))
                        {
                            overlayForm_image.SaveSettings();

                            overlayForm_image.DisposeChilds();
                            overlayForm_image.Dispose();
                            overlayForm_image.Close();

                            GC.Collect();
                        }
                    }

                    break;

                case "open_text":
                    break;
            }
        }
        
        private void menu_image_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
        }

        private void menu_text_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
        }

        private void menu_browser_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
        }

        #endregion
    }
}
