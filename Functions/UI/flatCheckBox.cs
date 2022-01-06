using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lococo.Functions.UI
{
    class flatCheckBox : CheckBox
    {
        private Color checkBoxBackColor = Color.FromArgb(22, 22, 22);


        public flatCheckBox()
        {
            Size = new Size(35, 30);
        }


        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);

            checkBoxBackColor = Color.FromArgb(50, 50, 50);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);

            checkBoxBackColor = Color.FromArgb(22, 22, 22);
            Invalidate();
        }



        protected override void OnPaint(PaintEventArgs pevent)
        {
            Rectangle checkBoxRectangle = new Rectangle(4, 4, 20, 20);

            base.OnPaint(pevent);
            pevent.Graphics.Clear(BackColor);

            using (SolidBrush brush = new SolidBrush(ForeColor))
                pevent.Graphics.DrawString(Text, Font, brush, 30, 8);
            using (SolidBrush rect_fillBrush = new SolidBrush(checkBoxBackColor))
                pevent.Graphics.FillRectangle(rect_fillBrush, checkBoxRectangle);
            
            if (Checked)
            {
                using (SolidBrush check_brush = new SolidBrush(Color.FromArgb(255, 81, 36)))
                using (Font wing = new Font("굴림", 13))
                    pevent.Graphics.DrawString("✔", wing, check_brush, 3, 4);
            }

            pevent.Graphics.DrawRectangle(Pens.LightGray, checkBoxRectangle);
        }

    }
}
