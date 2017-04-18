using HungryApp.Contratos;
using HungryApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HungryApp.ViewModels
{
    public class BuiltInMenuViewModel
    {
        public IEnumerable<DetailedBuiltInMenuViewModel> MenusCollection { get; set; }


    }
}
