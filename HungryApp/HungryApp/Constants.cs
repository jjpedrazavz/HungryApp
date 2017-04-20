using System;
using System.Collections.Generic;
using System.Text;

namespace HungryApp
{
    public static class Constants
    {
        public static string GetBuiltInMenu = "http://192.168.15.5:5000/api/ClientMenu/GetBuildInMenus";
        public static string GetOrderMenu = "http://192.168.15.5:5000/api/ClientMenu/GetCreateOrder";
        public static string CreateOrder = "http://192.168.15.5:5000/api/ClientMenu/CreateOrder";
        public static string GetClientOrders = "http://192.168.15.5:5000/api/ClientMenu/GetClientOrders/{0}";
        
    }
}
