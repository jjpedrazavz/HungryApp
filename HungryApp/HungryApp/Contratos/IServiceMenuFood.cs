using HungryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace HungryApp.Contratos
{
    public interface IServiceMenuFood
    {
        Task<IEnumerable<DetailedBuiltInMenuViewModel>> GetBuiltInMenus();

        Task<ClientOrdersViewModel> GetMenuElements();

    }
}
