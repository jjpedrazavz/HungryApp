using CoreService.Models;
using HungryApp.Models.Orders;
using HungryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryApp.Contratos
{
    public interface IServiceOrders
    {
        Task<bool> CreateOrder(ClientOrdersViewModel viewModel);
        Task<IEnumerable<SlimOrderViewModel>> GetSummaryOrders(int clientID);
    }
}
