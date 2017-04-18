using HungryApp.Models.Basket;
using HungryApp.Models.Orders;
using HungryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HungryApp.Pages.Orders
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasketPage : ContentPage
	{  
        
		public BasketPage (Basket basket)
		{
			InitializeComponent ();
            MainLayout.BindingContext = basket;

		}

        protected override void OnAppearing()
        {
            
            var basket = (MainLayout.BindingContext as Basket);

            basket.MenuSeleccionadoSize = basket.MenuSeleccionado.Count;
            basket.BuiltInMenuSeleccionadoSize = basket.BuiltInMenuSeleccionado.Count;


            LayoutDayMenuCollection.IsVisible = basket.BuiltInMenuSeleccionadoSize != 0;  
            LayoutCartaMenuCollection.IsVisible = basket.MenuSeleccionadoSize != 0;


            if(!LayoutDayMenuCollection.IsVisible && !LayoutCartaMenuCollection.IsVisible)
            {
                LayoutSummary.IsVisible = false;
            }
            else
            {
                LayoutSummary.IsVisible = true;
            }

            basket.IsVisibleSummaryLayout = LayoutSummary.IsVisible;


            base.OnAppearing();

        }


    }
}
