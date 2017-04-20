using CoreService.Models;
using HungryApp.Models.Basket;
using HungryApp.Models.Orders;
using HungryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HungryApp.Pages.Food
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailedFoodPage : ContentPage
	{
        private decimal total=0;
        private int cantidad=1;

		public DetailedFoodPage (Alimentos alimento)
		{
			InitializeComponent();
            BindingContext = alimento;
            total = alimento.Precio;
            lblQuantity.Text = cantidad.ToString();
            lblPrecioFinal.Text = string.Format("{0} MXN", total);
        }

        private void btnQuantity_Clicked(object sender, EventArgs e)
        {
            if ((sender as Button).StyleId.Equals("b+"))
            {
                cantidad++;
                lblQuantity.Text = cantidad.ToString();
                total += (BindingContext as Alimentos).Precio;
                lblPrecioFinal.Text = string.Format("{0} MXN", total);
            }
            else
            {
                if (cantidad > 1)
                {
                    cantidad--;
                    lblQuantity.Text = cantidad.ToString();
                    total -= (BindingContext as Alimentos).Precio;
                    lblPrecioFinal.Text = string.Format("{0} MXN", total);
                }

            }

        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            DetailedMenuCartaViewModel menuViewModel = new DetailedMenuCartaViewModel();
            menuViewModel.AlimentoID = (BindingContext as Alimentos).Id;
            menuViewModel.Nombre = (BindingContext as Alimentos).Nombre;
            menuViewModel.Cantidad = cantidad;
            menuViewModel.Precio = (BindingContext as Alimentos).Precio;
            menuViewModel.Total = (decimal)total;

            var basket = Ioc.Ioc.Resolve<Basket>();

            basket.MenuSeleccionado.Add(menuViewModel);
            basket.TotalFinalOrden += (double)menuViewModel.Total;

            await Navigation.PopAsync();

        }
    }
}
