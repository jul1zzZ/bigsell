using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumperApplication
{
    static class Captcha
    {
        static public string CreateCaptcha(string fileName = "captcha.png")
        {
            Random rnd = new Random();

            int height = 100;
            int width = 200;
            string abc = "qwertyuiopasdfghjklzxcvbnm1234567890";
            string captcha = "";
            for (int i = 0; i < 5; i++)
            {
                captcha = captcha + abc[rnd.Next(0, abc.Length)];
            }

            Bitmap image = new Bitmap(width, height);

            Graphics graphics = Graphics.FromImage(image);

            for (int i = 0; i < 100; i += 10)
            {
                graphics.DrawLine(Pens.Black, new Point(i, i),
                  new Point(width - i, height - i));
            }
            graphics.DrawString(captcha, new Font("Arial", 15, FontStyle.Italic), Brushes.Black, new PointF(width / 2 - 42, height / 2 - 13));

            image.Save(Directory.GetCurrentDirectory() + "\\Images\\" + captcha+".png", System.Drawing.Imaging.ImageFormat.Png);

            return captcha;
        }
    }
}
