using Autofac;
using MSA.Library.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSA.Library.AutoFac
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Logic>().As<ILogic>();

            return builder.Build();
        }
    }
}
