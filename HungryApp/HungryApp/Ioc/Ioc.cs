using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryApp.Ioc
{
    public static class Ioc
    {
        public static IContainer Container { get; private set; }

        private static ContainerBuilder builder;



        //se crea el subcontenedor  que mantiene las instancias registras
        public static void CreateContainer()
        {
            builder = new ContainerBuilder();
        }

        //Se crean las instancias especificas contenidas dentro de cada modulo
        public static void RegisterModule(IModule module)
        {
            module.RegisterModule(builder);
        }

        public static void RegisterModules(IEnumerable<IModule> modules)
        {
            foreach (var item in modules)
            {
                item.RegisterModule(builder);
            }
        }

        //se Asocia y contruye el contenedor principal
        public static void StartContainer()
        {
            Container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

    }
}
