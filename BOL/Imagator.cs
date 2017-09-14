using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public static class Imgator
    {
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        public static Bitmap ByteToBitmap(byte[] byteImg)
        {
            using (var ms = new MemoryStream(byteImg))
            {
                return new Bitmap(ms);
            }
        }
        public static Bitmap getDefaultProfilePicture()
        {
            var request = WebRequest.Create("http://i.imgur.com/pKjRJxC.jpg");
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                return new Bitmap(stream);
            }
        }
        public static Bitmap getImgFromUrl(string Url)
        {
            var request = WebRequest.Create(Url);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                return new Bitmap(stream);
            }
        }
    }
}
