using HungryApp.Contratos;
using System;
using System.Collections.Generic;
using System.Text;
using CoreService.Models;
using System.Threading.Tasks;
using HungryApp.ViewModels;
using System.Net.Http;
using System.Diagnostics;
using HungryApp.Models.Orders;

namespace HungryApp.Services
{
    public class ServiceOrdersImp : IServiceOrders
    {
        private HttpClient _client;

        public ServiceOrdersImp()
        {
            _client = Ioc.Ioc.Resolve<HttpClient>();

        }

        public async Task<bool> CreateOrder(ClientOrdersViewModel viewModel)
        {
            _client.BaseAddress = new Uri(Constants.CreateOrder);


            HttpResponseMessage response = await _client.PostAsync(Constants.CreateOrder,
                new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json"));


            return response.StatusCode == System.Net.HttpStatusCode.Conflict ? false : true;


        }

        public async Task<IEnumerable<SlimOrderViewModel>> GetSummaryOrders(int clientId)
        {

            _client.BaseAddress = new Uri(string.Format(Constants.GetClientOrders, clientId));

            HttpResponseMessage response = await _client.GetAsync(string.Format(Constants.GetClientOrders, clientId));

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var collection = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<SlimOrderViewModel>>(data);

                return collection;

            }

            return null;


        }
    }
}
