using MSA.Library.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MSA.Library.Program
{
    public class Logic : ILogic
    {
        public void TakeScreenShot(int screenWidth, int screenHeight, string fileName, ImageFormat imageFormat)
        {
            Bitmap bitmap = new Bitmap(screenWidth, screenHeight);

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            try
            {
                bitmap.Save(fileName, imageFormat);
            }
            catch (ExternalException)
            {
                throw new InvalidFilenameException();
            }
        }
    }
}
