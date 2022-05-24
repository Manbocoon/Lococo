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
        public bool yesNo { get; set; } = false;

        public byte dialogResult { get; set; }

        private bool dragging = false;
        private POINT startPoint, currentPoint;
        private int form_left, form_top;
        // 0 = No
        // 1 = Yes, OK
        #endregion


        #region UI
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


        private int white_space = 25;
        private void messageForm_Load(object sender, EventArgs e)
        {
            Size screen = Program.screen;

            Caption.Text = cap;
            message.Text = msg;
            message.MaximumSize = new Size(screen.Width/2 - (white_space*2), (int)((float)screen.Height*0.9) - (white_space*4));
            
            MinimumSize = new Size(350, 200);
            Width = message.Width + (white_space * 2);
            Height = message.Top + message.Height + okButton.Height + (white_space * 3);

            Left = (screen.Width - Width) / 2;
            Top = (screen.Height - Height) / 2;

            if (yesNo)
            {
                int buttons_total_width = okButton.Width + noButton.Width + white_space;

                okButton.Location = new Point((Width - buttons_total_width) / 2, message.Bottom + (white_space * 2));
                noButton.Location = new Point(okButton.Right + white_space, okButton.Top);
            }

            else
            {
                noButton.Visible = false;

                okButton.Location = new Point((Width -okButton.Width) / 2, message.Bottom + (white_space*2));
            }

            title_panel.Width = Width;
            close_top.Left = Width - 35;

            using (var shadowClass = new Functions.UI.dropShadow())
            {
                shadowClass.ApplyShadows(this, 0, 0, 1, 0);
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
