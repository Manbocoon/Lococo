using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Lococo.Functions
{
    class loadImage : IDisposable
    {
        public void Dispose()
        {

        }



        public Image loadImageFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new Bitmap(1, 1);

            using (var tempBmp = new Bitmap(filePath))
                return new Bitmap(tempBmp);
        }
    }
}
