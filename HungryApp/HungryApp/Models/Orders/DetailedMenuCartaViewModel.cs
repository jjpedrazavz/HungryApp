using System;
using System.Collections.Generic;
using System.Text;

namespace HungryApp.Models.Orders
{
    public class DetailedMenuCartaViewModel
    {
        public int AlimentoID { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public decimal Total { get; set; }

        public int Cantidad { get; set; }
    }
}
