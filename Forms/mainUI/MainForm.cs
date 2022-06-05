using Lococo.Forms.menus;

using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Threading;



namespace Lococo.Forms.mainUI
{
    /// <summary>
    /// Lococo 프로그램의 메인 UI 폼입니다.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Windows API
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32")]
        public static extern Int32 GetCursorPos(out POINT pt);

        public struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        #endregion

        #region Private Variables
        private bool form_dragging = false;
        private POINT firstPoint;
        private int form_left, form_top;
        #endregion








        public MainForm()
        {
            InitializeComponent();
        }

        
        #region Form - Make Shadow
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams crp = base.CreateParams;
                crp.ClassStyle = 0x00020000;
                return crp;
            }
        }
        #endregion

        #region Form - Make Borderless Form as Resizable
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13 ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12 ;
                            else
                                m.Result = (IntPtr)14 ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10 ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2 ;
                            else
                                m.Result = (IntPtr)11 ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16 ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15 ;
                            else
                                m.Result = (IntPtr)17 ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }
        #endregion





        private void CheckUpdateAndAsk()
        {
            Color dark_orange = Color.FromArgb(255, 81, 36);
            var AppInfo = new Functions.Updater.AppINFO();

            Thread _webThread = new Thread(() => 
            {
                var updater = new Functions.Updater();

                AppInfo = updater.GetRecentInfo();

                if (AppInfo.Name == "SERVER NOT AVAILABLE")
                {
                    Invoke((MethodInvoker)delegate
                    {
                        version_state.LinkColor = dark_orange;
                        version_state.Text = "업데이트 확인 실패: 서버 오류";
                    });
                }

                else if (AppInfo.Name.StartsWith("WAITING"))
                {
                    string second_str = AppInfo.Name.Remove(0, 9);
                    byte.TryParse(second_str, out byte second);
                    ++second;

                    for (; second > 0; --second)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            version_state.LinkColor = dark_orange;
                            version_state.Text = "부하 방지: " + second + "초 남음";
                        });

                        Thread.Sleep(1000);
                    }

                    Invoke((MethodInvoker)delegate
                    {
                        version_state.LinkColor = Color.LightSeaGreen;
                        version_state.Text = "업데이트 확인 중";
                    });

                    CheckUpdateAndAsk();
                }


                else
                {
                    if (AppInfo.Version != Program.VERSION)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            version_state.LinkColor = dark_orange;
                            version_state.Text = "업데이트 필요 / " + AppInfo.Version;
                        });

                    }

                    else
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            version_state.LinkColor = Color.LightSeaGreen;
                            version_state.Text = "✔ 최신 버전입니다.";
                        });
                    }
                }
  
                updater.Dispose();
            });
            _webThread.IsBackground = true;
            _webThread.Start();
        }


        #region Event Handlers - Form
        // 폼이 보이기 전
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Lock
            File.Open(Application.ExecutablePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            this.Size = new Size(825, 450);

            layoutForm();
            resizeControls();

            this.Resize += (sen, evt) =>
            { resizeControls(); };


            using (var shadowClass = new Functions.UI.dropShadow())
            { 
                shadowClass.ApplyShadows(this, 0, 0, 1, 0);
            }

            ((ToolStripMenuItem)Menu.Items[0]).Checked = true;
            menu_browser_Click(menu_overlay, new EventArgs());

            CheckUpdateAndAsk();

        }


        private void resizeControls()
        {
            Size panel_size = new Size(this.Width - (panel_default_loc.X+5), this.Height - (panel_default_loc.Y+5));

            panel_chatOption.Size = panel_size;

            close_top.Left = this.Width - 27;
            minimize_top.Left = this.Width - 52;
        }



        public menu_overlay m_overlay;
        public menu_chatOption m_chatOption;
        public menu_text m_text;

        private Panel panel_overlay, panel_text;
        private Panel panel_chatOption;
        private Point panel_default_loc = new Point(201, 33);
        private Color panel_default_backColor = Color.FromArgb(22, 22, 22);
        private void layoutForm()
        {
            m_overlay = new menu_overlay();
            m_chatOption = new menu_chatOption();
            m_text = new menu_text();

            panel_overlay = new Panel
            {
                Name = "panel_overlay",
                BackColor = panel_default_backColor,
                Location = panel_default_loc,
                Width = this.Width - 210,
                Height = this.Height - 50
            };

            panel_text = new Panel
            {
                Name = "panel_text",
                BackColor = panel_default_backColor,
                Location = panel_default_loc,
                Width = this.Width - 210,
                Height = this.Height - 50
            };

            panel_chatOption = new Panel
            {
                Name = "panel_chatOption",
                BackColor = panel_default_backColor,
                Location = panel_default_loc,
                Width = this.Width - 210,
                Height = this.Height - 50
            };

            panel_overlay.Controls.Add(m_overlay);
            panel_chatOption.Controls.Add(m_chatOption);
            panel_text.Controls.Add(m_text);

            this.Controls.Add(panel_overlay);
            this.Controls.Add(panel_chatOption);
            this.Controls.Add(panel_text);
        }
        #endregion

        #region Event Handlers - Title Bar Panel Controls
        private void minimize_top_MouseEnter(object sender, EventArgs e)
        {
            minimize_top.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void minimize_top_MouseLeave(object sender, EventArgs e)
        {
            minimize_top.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void minimize_top_Click(object sender, EventArgs e)
        {
            minimize_top.BackColor = Color.FromArgb(60, 60, 60);
            this.WindowState = FormWindowState.Minimized;
        }


        private void close_top_MouseEnter(object sender, EventArgs e)
        {
            close_top.BackColor = Color.FromArgb(180, 35, 35);
        }

        private void close_top_MouseLeave(object sender, EventArgs e)
        {
            close_top.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void close_top_Click(object sender, EventArgs e)
        {
            close_top.BackColor = Color.FromArgb(255, 15, 15);

            // 설정 저장
            using (var config_ui = new Config.mainUI())
            {
                config_ui.ParentForm = m_overlay;

                config_ui.SaveSettings();
            }

            if (Program.IsActivated(m_overlay.overlayUIForm))
            {
                if (Program.IsActivated(m_overlay.overlayUIForm.overlayForm_browser))
                {
                    overlay.o_browser overlay_browser = m_overlay.overlayUIForm.overlayForm_browser;

                    overlay_browser.SaveSettings();

                    overlay_browser.DisposeChilds();
                    overlay_browser.Dispose();
                    overlay_browser.Close();
                }

                if (Program.IsActivated(m_overlay.overlayUIForm.overlayForm_image))
                {
                    overlay.o_image overlay_image = m_overlay.overlayUIForm.overlayForm_image;

                    overlay_image.SaveSettings();

                    overlay_image.DisposeChilds();
                    overlay_image.Dispose();
                    overlay_image.Close();
                }
            }

            // 종료
            Environment.Exit(0);
        }

        private void top_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!form_dragging)
            {
                form_dragging = true;
                form_left = this.Left;
                form_top = this.Top;

                GetCursorPos(out firstPoint);
            }
        }



        private void top_panel_MouseMove(object sender, MouseEventArgs e)
        {
            POINT secondPoint;

            if (form_dragging)
            {
                GetCursorPos(out secondPoint);

                this.Left = form_left + secondPoint.x - firstPoint.x;
                this.Top = form_top + secondPoint.y - firstPoint.y;
            }
        }


        private void top_panel_MouseUp(object sender, MouseEventArgs e)
        {
            form_dragging = false;
        }
        #endregion

        #region Event Handlers - Menus
        private void menu_browser_Click(object sender, EventArgs e)
        {
            highlightMenu((Button)sender);
        }

        private void menu_image_Click(object sender, EventArgs e)
        {
            highlightMenu((Button)sender);
        }


        private void menu_chatOption_Click(object sender, EventArgs e)
        {
            highlightMenu((Button)sender);
        }

        private void menu_text_Click(object sender, EventArgs e)
        {
            highlightMenu((Button)sender);
        }


        private void highlightMenu(Button current_menu)
        {
            string menu_name = current_menu.Name.Remove(0, 5);


            for (ushort index=0; index<this.Controls.Count; ++index)
            {
                Control current_control = this.Controls[index];

                if (current_control is Panel)
                {
                    if (current_control.Size == menu_panel_1.Size)
                    {
                        if (current_control.Top == current_menu.Top)
                            current_control.BackColor = Color.FromArgb(255, 81, 36);

                        else
                            current_control.BackColor = Color.FromArgb(17, 17, 17);

                    }


                    else if (current_control.Name == "panel_" + menu_name)
                    {
                        current_control.BringToFront();
                    }

                }

            }

            GC.Collect();
            GC.WaitForFullGCComplete();
        }

        private void version_state_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var updater = new Functions.Updater())
            {
                Process.Start(updater.Release_Url);
            }
        }


        #endregion

        #region Tray Menu
        private void 폼보이기ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (((ToolStripMenuItem)Menu.Items[0]).Checked)
            {
                this.ShowInTaskbar = false;
                this.Visible = false;
                ((ToolStripMenuItem)Menu.Items[0]).Checked = false;
            }

            else
            {
                this.ShowInTaskbar = true;
                this.Visible = true;
                ((ToolStripMenuItem)Menu.Items[0]).Checked = true;

                SetForegroundWindow(this.Handle);
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            close_top_Click(new object(), new EventArgs());
        }
        #endregion



    }
}
