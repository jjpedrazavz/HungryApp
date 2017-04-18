using HungryApp.Pages.Food;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HungryApp.Navigation
{
    public class NavigationService
    {
        public INavigation _navigate { get; set; }

        public ICommand ComidasCommand { get; set; }

        public ICommand CenasCommand { get; set; }

        public ICommand CartaCommand { get; set; }

        public ICommand DesayunosCommand { get; set; }


        public NavigationService(INavigation navigate)
        {
          

        }
         


    }
}
