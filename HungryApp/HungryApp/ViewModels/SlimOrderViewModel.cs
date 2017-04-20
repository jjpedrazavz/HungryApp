using System;
using System.Collections.Generic;
using System.Text;

namespace HungryApp.Models.Orders
{
    public class SlimOrderViewModel
    {
        public int OrdenID { get; set; }

        public int ComensalID { get; set; }

        public DateTime OrdenFecha { get; set; }

        public string EstadoDescripcion { get; set; }


    }
}
