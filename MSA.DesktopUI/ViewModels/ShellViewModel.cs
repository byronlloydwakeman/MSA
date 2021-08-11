using Autofac;
using Caliburn.Micro;
using MSA.Library.AutoFac;
using MSA.Library.Exceptions;
using MSA.Library.Program;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MSA.DesktopUI.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly ILogic _logic;
        public ShellViewModel()
        {
            using (ILifetimeScope scope = ContainerConfig.Configure().BeginLifetimeScope())
            {
                _logic = scope.Resolve<ILogic>();
            }
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanTakeScreenShot);
            }
        }

        private string _location = @"";
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                NotifyOfPropertyChange(() => Location);
                NotifyOfPropertyChange(() => CanTakeScreenShot);
            }
        }

        private ImageFormat _imageFormat;
        public ImageFormat ImageFormat
        {
            get { return _imageFormat; }
            set
            { 
                _imageFormat = value;
                NotifyOfPropertyChange(() => ImageFormat);
                NotifyOfPropertyChange(() => CanTakeScreenShot);
            }
        }

        private int _delay;
        public int Delay
        {
            get { return _delay; }
            set 
            { 
                _delay = value;
                NotifyOfPropertyChange(() => Delay);
                NotifyOfPropertyChange(() => CanTakeScreenShot);
            }
        }

        private int _screenWidth;
        public int ScreenWidth
        {
            get { return _screenWidth; }
            set 
            {
                _screenWidth = value;
                NotifyOfPropertyChange(() => ScreenWidth);
                NotifyOfPropertyChange(() => CanTakeScreenShot);
            }
        }

        private int screenHeight;
        public int ScreenHeight
        {
            get { return screenHeight; }
            set 
            {
                screenHeight = value;
                NotifyOfPropertyChange(() => ScreenHeight);
                NotifyOfPropertyChange(() => CanTakeScreenShot);
            }
        }

        private string _messageBox;

        public string MessageBox
        {
            get { return _messageBox; }
            set 
            {
                _messageBox = value;
                NotifyOfPropertyChange(() => MessageBox);
            }
        }


        public bool CanTakeScreenShot
        {
            get 
            {
                if (Name == null || Location == "" || ImageFormat == null || ScreenWidth == 0 || ScreenHeight == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        public void TakeScreenShot()
        {
            Thread.Sleep(Delay);

            try
            {
                MessageBox = "";
                _logic.TakeScreenShot(ScreenWidth, ScreenHeight, $@"{Location}\{Name}.{ImageFormat}", ImageFormat);
                MessageBox = $"Screenshot for {Name} Taken";
            }
            catch (InvalidFilenameException)
            {
                MessageBox = "Invalid location";
            }
            
        }
    }
}
