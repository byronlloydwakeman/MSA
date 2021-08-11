using System.Drawing.Imaging;

namespace MSA.Library.Program
{
    public interface ILogic
    {
        void TakeScreenShot(int screenWidth, int screenHeight, string fileName, ImageFormat imageFormat);
    }
}