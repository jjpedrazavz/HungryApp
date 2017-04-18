using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryApp.ViewModels
{
    public class ClientOrdersViewModel
    {
        public int ComensalID { get; set; }

        public int EstadoID { get; set; }

        public IList<MenuViewModel> menuSeleccionado { get; set; }

        public IEnumerable<Alimentos> AlimentosList { get; set; }

    }
}
