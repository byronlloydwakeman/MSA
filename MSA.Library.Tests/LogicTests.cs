using Autofac;
using MSA.Library.AutoFac;
using MSA.Library.Program;
using MSA.Library.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MSA.Library.Tests
{
    public class LogicTests
    {
        private readonly ILogic _logic;

        public LogicTests()
        {
            using (ILifetimeScope scope = ContainerConfig.Configure().BeginLifetimeScope())
            {
                _logic = scope.Resolve<ILogic>();
            }
        }

        public void DelegateForTakingScreenShots(int width, int height, string fileName, ImageFormat format)
        {
            _logic.TakeScreenShot(width, height, fileName, format);
        }

        [Fact]
        public void TakeScreenShotNoFileExtensionThrowException()
        {
            Action action = () => DelegateForTakingScreenShots(1920, 1080, @"C:\Users\44785\Documents\Dream\Finance\Gold\ExampleCandleStickCharts", ImageFormat.Png);

            Assert.Throws<InvalidFilenameException>(action);
        }

    }
}