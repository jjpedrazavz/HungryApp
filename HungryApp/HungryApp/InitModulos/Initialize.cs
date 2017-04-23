using HungryApp.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using HungryApp.Services;
using HungryApp.Contratos;
using Xamarin.Forms;
using System.Windows.Input;
using HungryApp.Pages.Food;
using System.Net.Http;
using HungryApp.ViewModels;
using HungryApp.Models.Basket;
using HungryApp.Pages;

namespace HungryApp.InitModulos
{
    public class Initialize : IModule
    {
        public void RegisterModule(ContainerBuilder builder)
        {
            builder.RegisterType<MainPage>().SingleInstance();
            builder.Register(x => new NavigationPage(x.Resolve<MainPage>())
            { BarBackgroundColor = Color.Orange,
              BarTextColor=Color.White}).AsSelf().SingleInstance();

            builder.RegisterType<HttpClient>().SingleInstance();
            builder.RegisterType<Basket>().SingleInstance();
            builder.RegisterType<ServicesMenuFoodImp>().As<IServiceMenuFood>().SingleInstance();
            builder.RegisterType<ServiceOrdersImp>().As<IServiceOrders>().SingleInstance();

            builder.RegisterType<MainViewModel>().SingleInstance();
        }
    }
}
