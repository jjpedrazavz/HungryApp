using CoreService.Models;
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
        Task GetSummaryOrders();
    }
}
