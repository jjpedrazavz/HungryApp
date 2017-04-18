using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryApp.Ioc
{
    public interface IModule
    {
        void RegisterModule(ContainerBuilder builder);
    }
}
