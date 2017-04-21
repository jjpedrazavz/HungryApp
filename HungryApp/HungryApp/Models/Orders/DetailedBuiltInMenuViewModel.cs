using System;
using System.Collections.Generic;
using System.Text;

namespace HungryApp.ViewModels
{
    public class DetailedBuiltInMenuViewModel
    {
        public int BundleId { get; set; }

        public string NameMenu { get; set; }

        public string MenuCategory { get; set; }

        public double Precio { get; set; }

        public IEnumerable<string> Seleccionados { get; set; }

    }
}
