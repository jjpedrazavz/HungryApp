using System;
using System.Collections.Generic;
using System.Text;

namespace HungryApp
{
    public static class Constants
    {
        public static string WebPath = "http://hungryweb20170419090103.azurewebsites.net/Content/ImagenesProducto/{0}";
        public static string GetBuiltInMenu = "http://coreserviceapi.azurewebsites.net/api/ClientMenu/GetBuildInMenus";
        public static string GetOrderMenu = "http://coreserviceapi.azurewebsites.net/api/ClientMenu/GetCreateOrder";
        public static string CreateOrder = "http://coreserviceapi.azurewebsites.net/api/ClientMenu/CreateOrder";
        public static string GetClientOrders = "http://coreserviceapi.azurewebsites.net/api/ClientMenu/GetClientOrders/{0}";

    }
}
