using HungryApp.Pages.Food;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HungryApp.ViewModels
{
    public class SummaryBuiltInMenuViewModel : BaseViewModel
    {
        private int bundleId;
        private string nameMenu;
        private int quantity = 1;
        private double _totalprice;
        private int clientID;

        public int BundleId { get => bundleId; set => bundleId = value; }
        public string NameMenu { get => nameMenu; set => nameMenu = value; }
        public int Quantity { get => quantity; set => SetProperty(ref quantity, value); }
        public double Totalprice { get => _totalprice; set => SetProperty(ref _totalprice, value); }
        public int ClientID { get => clientID; set => clientID = value; }
    }
}
