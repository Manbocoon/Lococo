using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Lococo.Functions.UI
{
    public class MenuColorTable : ProfessionalColorTable
    {
        private Color dark_orange = Color.FromArgb(255, 81, 36);
        private Color darker_orange = Color.FromArgb(100, 30, 5);
        private Color lococo_backColor = Color.FromArgb(22, 22, 22);




        public override Color MenuItemSelected => darker_orange;

        public override Color MenuItemBorder => dark_orange;

        public override Color MenuBorder => dark_orange;


        public override Color ImageMarginGradientBegin => lococo_backColor;
        public override Color ImageMarginGradientMiddle => lococo_backColor;
        public override Color ImageMarginGradientEnd => lococo_backColor;
        public override Color ToolStripDropDownBackground => lococo_backColor;


    }
}
