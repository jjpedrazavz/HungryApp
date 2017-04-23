using HungryApp.Models.Basket;
using HungryApp.Pages.Orders;
using HungryApp.ViewModels;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HungryApp.Pages.Food
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailedBuiltInMenuOrderPage : ContentPage
	{
        SummaryBuiltInMenuViewModel viewModelSummary = new SummaryBuiltInMenuViewModel();

        public DetailedBuiltInMenuOrderPage(DetailedBuiltInMenuViewModel viewModel)
		{
			InitializeComponent();
            MenuLayout.BindingContext = viewModel;
            layoutCountOrders.BindingContext = viewModelSummary;
            
            viewModelSummary.Totalprice = viewModel.Precio;

        }


        private async void ProcessClickEvent(object sender, EventArgs e)
        {
            viewModelSummary.BundleId = (MenuLayout.BindingContext as DetailedBuiltInMenuViewModel).BundleId;
            viewModelSummary.NameMenu = (MenuLayout.BindingContext as DetailedBuiltInMenuViewModel).NameMenu;

            AddOrder(viewModelSummary);

            await Navigation.PopAsync();
  
        }


        private void btnQuantity_Clicked(object sender, EventArgs e)
        {
            if((sender as Button).Text.Equals("+"))
            {
                viewModelSummary.Quantity++;
                viewModelSummary.Totalprice += (MenuLayout.BindingContext as DetailedBuiltInMenuViewModel).Precio;
            }
            else
            {
                if (viewModelSummary.Quantity > 1)
                {
                    viewModelSummary.Quantity--;
                    viewModelSummary.Totalprice -= (MenuLayout.BindingContext as DetailedBuiltInMenuViewModel).Precio;
                    
                    
                }
                
            }

        }


        private void AddOrder(SummaryBuiltInMenuViewModel viewModelSummary)
        {
            var context = Ioc.Ioc.Resolve<Basket>();

            bool containts = false;

            foreach (var item in context.BuiltInMenuSeleccionado)
            {
                if (item.NameMenu.Equals(viewModelSummary.NameMenu))
                {
                    item.Quantity += viewModelSummary.Quantity;
                    item.Totalprice += viewModelSummary.Totalprice;
                    containts = true;
                }
            }
            if (!containts)
            {
                context.BuiltInMenuSeleccionado.Add(viewModelSummary);
            }

            context.TotalFinalOrden += viewModelSummary.Totalprice;

        }



    }

}
