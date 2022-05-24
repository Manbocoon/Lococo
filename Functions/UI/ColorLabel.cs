using Lococo.Functions.UI.ColorPicker;
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
    class ColorLabel : Label
    {
        private Color checkBoxBackColor = Color.FromArgb(22, 22, 22);


        public ColorLabel()
        {
            Size = new Size(100, 30);
            AutoSize = false;
            ForeColor = Color.LightGray;
            Cursor = Cursors.Hand;
        }


        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);

            BackColor = Color.FromArgb(45, 45, 45);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);

            BackColor = Color.FromArgb(22, 22, 22);
            Invalidate();
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            Color starting_color = Color.Black;
            try { starting_color = ColorTranslator.FromHtml(Text); }
            catch (Exception) { }

            frmColorPicker colorPicker = new frmColorPicker(starting_color);
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                Text = ColorTranslator.ToHtml(colorPicker.PrimaryColor);
                this.Invalidate();
            }

            colorPicker.Dispose();
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            Rectangle checkBoxRectangle = new Rectangle(4, 4, 20, 20);

            base.OnPaint(pevent);
            pevent.Graphics.Clear(BackColor);


            Color boxColor = Color.Black;
            try { boxColor = ColorTranslator.FromHtml(Text); }
            catch (Exception) { }

            using (SolidBrush brush = new SolidBrush(ForeColor))
                pevent.Graphics.DrawString(Text, Font, brush, 30, 8);
            using (SolidBrush rect_fillBrush = new SolidBrush(boxColor))
                pevent.Graphics.FillRectangle(rect_fillBrush, checkBoxRectangle);
           

            pevent.Graphics.DrawRectangle(Pens.LightGray, checkBoxRectangle);
            pevent.Graphics.DrawRectangle(Pens.DimGray, new Rectangle(1, 1, Width - 2, Height - 4));
        }

    }
}
