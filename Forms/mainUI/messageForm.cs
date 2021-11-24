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
using System.Media;





namespace Lococo.Forms
{
    public partial class messageForm : Form
    {
        #region API
        [DllImport("winmm.dll", SetLastError = true)] private static extern int waveOutSetVolume(IntPtr device, uint volume);

        [DllImport("user32")]
        public static extern Int32 GetCursorPos(out POINT pt);

        public struct POINT
        {
            public Int32 x;
            public Int32 y;
        }
        #endregion

        #region Global Variables
        public string msg { get; set; } = null;
        public string cap { get; set; } = null;
        public int width { get; set; } = 350;
        public int height { get; set; } = 200;
        public bool yesNo { get; set; } = false;

        public byte dialogResult { get; set; }

        private bool dragging = false;
        private POINT startPoint, currentPoint;
        private int form_left, form_top;
        // 0 = No
        // 1 = Yes, OK
        #endregion


        #region UI/Sound
        public messageForm()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams crp = base.CreateParams;
                crp.ClassStyle = 0x00020000;
                return crp;
            }
        }


        private void messageForm_Load(object sender, EventArgs e)
        {
            using (var img = new Functions.loadImage())
            {
                close_top.Image = img.loadImageFromFile(Application.StartupPath + "\\db\\images\\close_top.db");
                top_logo.Image = img.loadImageFromFile(Application.StartupPath + "\\db\\images\\top_logo.db");
            }
            

            this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - (width/2);
            this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - (height/2);
            
            this.Width = width;
            this.Height = height;

            Caption.Text = cap;

            message.Text = msg;
            message.MaximumSize = new Size(this.Width - message.Left - 25, this.Height - message.Top - 80);

            if (yesNo)
            {
                okButton.MaximumSize = new Size(this.Width - 54, okButton.Height);
                okButton.Location = new Point((this.Width / 2 - 96 > 27 ? this.Width / 2 - 96 : 28), this.Height - 60);
                noButton.Location = new Point(this.Width / 2 + 10, this.Height - 60);
            }

            else
            {
                noButton.Visible = false;
                okButton.Location = new Point (27, this.Height - 60);
                okButton.Width = this.Width - 54;
            }

            title_panel.Width = this.width;
            close_top.Left = this.width - 35;


            waveOutSetVolume(IntPtr.Zero, (uint)0x69786978);

            if (System.IO.File.Exists(Application.StartupPath + "\\db\\sounds\\Messagebox.db"))
            {
                SoundPlayer sound = new SoundPlayer(Application.StartupPath + "\\db\\sounds\\Messagebox.db");
                sound.Play();
                sound.Dispose();
            }

            using (var shadowClass = new Functions.UI.dropShadow())
            {
                shadowClass.top = 1;

                shadowClass.ApplyShadows(this);
            }
        }

        private void close_top_MouseEnter(object sender, EventArgs e)
        {
            close_top.BackColor = Color.FromArgb(180, 35, 35);
        }

        private void close_top_MouseLeave(object sender, EventArgs e)
        {
            close_top.BackColor = Color.FromArgb(25, 25, 25);
        }
        #endregion


        #region move Form with Dragging
        private void title_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dragging)
            {
                dragging = true;

                GetCursorPos(out startPoint);

                form_left = this.Left;
                form_top = this.Top;
            }
        }

        private void title_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                GetCursorPos(out currentPoint);

                this.Left = form_left + currentPoint.x - startPoint.x;
                this.Top = form_top + currentPoint.y - startPoint.y;
            }
        }

        private void title_panel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion



        #region Pressed No/Closed
        private void noButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close_top_Click(object sender, EventArgs e)
        {
            if (!noButton.Visible)
                dialogResult = 1;

            this.Close();
        }
        #endregion

        #region Pressed OK
        private void okButton_Click(object sender, EventArgs e)
        {
            dialogResult = 1;
            this.Close();
        }



        #endregion
    }
}
