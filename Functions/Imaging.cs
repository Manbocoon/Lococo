using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;



namespace Lococo
{
    static class Imaging
    {
        public static bool IsSupportedImage(string file_path)
        {
            if (!File.Exists(file_path))
            {
                return false;
            }

            bool result = false;

            using (var imgStream = File.OpenRead(file_path))
            {
                try
                {
                    BitmapDecoder.Create(imgStream, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);

                    result = true;
                }

                catch (NotSupportedException)
                {
                    result = false;
                }
            }

            return result;
        }

        public static Size GetImageSize(string file_path)
        {
            if (!File.Exists(file_path))
                return Size.Empty;

            Size result = new Size(0, 0);

            using (var imageStream = File.OpenRead(file_path))
            {
                try
                {
                    var decoder = BitmapDecoder.Create(imageStream, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                    result.Width = decoder.Frames[0].PixelWidth;
                    result.Height = decoder.Frames[0].PixelHeight;
                }

                catch (NotSupportedException) { }
            }

            return result;
        }

        public static Point GetImageRatio(Size image)
        {
            int gcd = _Math.GetGCD(image.Width, image.Height);
            Point result = new Point(image.Width / gcd, image.Height / gcd);

            return result;
        }
    }
}
