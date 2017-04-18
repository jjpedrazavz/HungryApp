using HungryApp.Contratos;
using System;
using System.Collections.Generic;
using System.Text;
using HungryApp.ViewModels;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace HungryApp.Services
{
    public class ServicesMenuFoodImp : IServiceMenuFood
    {

        private HttpClient _client;

        public ServicesMenuFoodImp()
        {
            _client = Ioc.Ioc.Resolve<HttpClient>();
        }
       
        public async Task<IEnumerable<DetailedBuiltInMenuViewModel>> GetBuiltInMenus()
        {
                _client.BaseAddress = new Uri(Constants.GetBuiltInMenu);
                HttpResponseMessage response = await _client.GetAsync(Constants.GetBuiltInMenu);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    List<DetailedBuiltInMenuViewModel> collection = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DetailedBuiltInMenuViewModel>>(data);

                    return collection;
                }
            

                return null;
            
        }

        public async Task<ClientOrdersViewModel> GetMenuElements()
        {

            _client.BaseAddress = new Uri(Constants.GetOrderMenu);

            HttpResponseMessage response = await _client.GetAsync(Constants.GetOrderMenu);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Devuelto el objeto con exito");
                var data = await response.Content.ReadAsStringAsync();
                ClientOrdersViewModel viewModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ClientOrdersViewModel>(data);

                return viewModel;

            }


            return null;



        }
    }
}
