using Lococo.Forms.menus;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.NetworkInformation;

namespace Lococo.Forms.mainUI
{
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
        private Forms.messageForm messageForm = new Forms.messageForm();

        private menu_browser mococo;
        private menu_image boss;
        private menu_chatOption chatOption;

        private readonly string appPath = Application.StartupPath;
        private readonly string app_version = "2022 01 04";

        private bool form_dragging = false;
        private POINT firstPoint;
        private int form_left, form_top;
        #endregion








        #region App Functions
        private void preventDoubleExcuting()
        {
            Process[] proc1 = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);

            if (proc1.Length > 1)
            {
                for (byte index = 0; index < proc1.Count(); ++index)
                {
                    if (proc1[index].MainWindowHandle != this.Handle)
                    {
                        SetForegroundWindow(this.Handle);

                        showMsgbox("이미 실행중입니다!", "추가실행 불가", 300, 175, false);
                        break;
                    }
                }

                Environment.Exit(0);
            }

            for (byte index = 0; index < proc1.Length; ++index)
                proc1[index].Dispose();
        }

        private bool showMsgbox(string message, string caption, int width, int height, bool yesNo)
        {
            messageForm.Dispose();
            messageForm = new messageForm();

            bool result = false;

            messageForm.msg = message;
            messageForm.cap = caption;
            messageForm.width = width;
            messageForm.height = height;
            messageForm.yesNo = yesNo;

            messageForm.ShowDialog();

            if (messageForm.dialogResult == 1)
                result = true;

            return result;
        }


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


 
        #region Event Handlers - Form
        // 폼이 보이기 전
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            preventDoubleExcuting();

            File.Open(Application.ExecutablePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            if (!Directory.Exists(appPath + "\\db\\settings"))
                Directory.CreateDirectory(appPath + "\\db\\settings");

            this.Size = new Size(900, 750);

            try
            {
                using (var img = new Functions.loadImage())
                {
                    menu_browser.Image = img.loadImageFromFile(appPath + "\\db\\images\\menu_mococo.db");
                    menu_image.Image = img.loadImageFromFile(appPath + "\\db\\images\\menu_boss.db");
                    menu_chatOption.Image = img.loadImageFromFile(appPath + "\\db\\images\\menu_chatOption.db");

                    top_logo.Image = img.loadImageFromFile(appPath + "\\db\\images\\top_logo.db");
                    top_text.Image = img.loadImageFromFile(appPath + "\\db\\images\\lococo_text.db");
                    minimize_top.Image = img.loadImageFromFile(appPath + "\\db\\images\\minimize_top.db");
                    close_top.Image = img.loadImageFromFile(appPath + "\\db\\images\\close_top.db");
                }
            }

            catch (Exception)
            {
                showMsgbox("리소스를 불러오던 도중 오류가 발생했습니다.\r\ndb 폴더를 재설치해주세요.", "오류", 375, 200, false);
                Environment.Exit(0);
            }
            

            layoutForm();
            resizeControls();

            this.Resize += (sen, evt) =>
            { resizeControls(); };


            using (var shadowClass = new Functions.UI.dropShadow())
            {
                shadowClass.top = 1;

                shadowClass.ApplyShadows(this);
            }

            ((ToolStripMenuItem)Menu.Items[0]).Checked = true;
            menu_browser_Click(menu_browser, new EventArgs());
        }



        private void resizeControls()
        {
            panel_browser.Size = new Size(this.Width - panel_browser.Left - 5, this.Height - panel_browser.Top - 5);
            panel_image.Size = new Size(panel_browser.Width, panel_browser.Height);
            panel_chatOption.Size = new Size(panel_browser.Width, panel_browser.Height);


            close_top.Left = this.Width - 27;
            minimize_top.Left = this.Width - 52;
        }

        private void layoutForm()
        {
            mococo = new menu_browser();
            boss = new menu_image();
            chatOption = new menu_chatOption();

            panel_browser.Controls.Add(mococo);
            panel_image.Controls.Add(boss);
            panel_chatOption.Controls.Add(chatOption);

            panel_browser.Location = new Point(201, 33);
            panel_image.Location = new Point(201, 33);
            panel_chatOption.Location = new Point(201, 33);
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
            mococo.saveSettings();
            boss.saveSettings();

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


        #region Check Version
        private void check_version_Click(object sender, EventArgs e)
        {
            string data = null;

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                data = client.DownloadString("https://github.com//bumju08/Lococo/releases/latest");
            }

            string[] data_lines = data.Split('\n');
            for (uint index=0; index<data_lines.Length; ++index)
            {
                if (data_lines[index].Contains("<title>Release"))
                {
                    data = data_lines[index];
                    break;
                }
            }
            data = data.Remove(0, data.IndexOf('<') + 1);
            data = data.Remove(0, data.IndexOf(' ') + 1);
            data = data.Remove(data.IndexOf('·') - 1, data.Length - data.IndexOf('·') + 1);

            MessageBox.Show("현재 사용중인 앱 버전: " + app_version + "\r\n최신 버전: " + data, "알림", 0, (MessageBoxIcon)64);
            Process.Start("https://github.com/bumju08/Lococo/releases");
        }
        #endregion
    }
}
