using System;
using System.Collections.Generic;
using System.Text;

namespace HungryApp.Models.Orders
{
    public class AlimentosViewModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string NameSource { get; set; }
    }
}
