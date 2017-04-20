using HungryApp.Contratos;
using HungryApp.Models.Basket;
using HungryApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryApp.ViewModels
{
    public class MainViewModel
    {
        public int clientID = 1;

        public Basket _MainBasket { get; set; }

        public BuiltInMenuViewModel _BuiltInMenus { get; set; }

        public ClientOrdersViewModel _MenuCarta { get; set; }

        public IServiceOrders _ServiceOrdersService { get; set; }

        public IServiceMenuFood _menuFoodService { get; set; }

        


        public MainViewModel(IServiceOrders ServiceOrdersService, IServiceMenuFood MenuFoodService, ClientOrdersViewModel MenuCarta, BuiltInMenuViewModel BuiltInMenus, Basket MainBasket)
        {
            _MainBasket = MainBasket;
            _MenuCarta = MenuCarta;
            _BuiltInMenus = BuiltInMenus;
            _ServiceOrdersService = ServiceOrdersService;
            _menuFoodService = MenuFoodService;
        }


        
        public MainViewModel()
        {
            _MainBasket =  Ioc.Ioc.Resolve< Basket>();
            _ServiceOrdersService = Ioc.Ioc.Resolve<IServiceOrders>();
            _menuFoodService = Ioc.Ioc.Resolve<IServiceMenuFood>();

        }
        
    }
}
