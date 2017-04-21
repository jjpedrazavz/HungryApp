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

            var context = Ioc.Ioc.Resolve<Basket>();

            context.BuiltInMenuSeleccionado.Add(viewModelSummary);
            context.TotalFinalOrden += viewModelSummary.Totalprice;

            Debug.WriteLine("Grabado Bundle: "+viewModelSummary.BundleId);


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
    }
}
