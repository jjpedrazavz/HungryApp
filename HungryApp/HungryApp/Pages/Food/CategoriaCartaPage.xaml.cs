using CoreService.Models;
using HungryApp.Contratos;
using HungryApp.Services;
using HungryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq.Expressions;
using HungryApp.enums;
using HungryApp.Pages.Orders;
using HungryApp.Models.Basket;

namespace HungryApp.Pages.Food
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoriaCartaPage : ContentPage
	{

        public CategoriaCartaPage(IEnumerable<Alimentos> alimentos, string tipo)
		{
            Debug.WriteLine("valor recibido: " + tipo);
            
            InitializeComponent();

            switch (tipo)
            {
                case "1":
                    imgHeader.Style = (Style)Resources["MSopas"];
                    break;
                case "2":
                    imgHeader.Style = (Style)Resources["MBebidas"];
                    break;
                case "3":
                    imgHeader.Style = (Style)Resources["MPlatosFuertes"];
                    break;
                case "4":
                    imgHeader.Style = (Style)Resources["MPostres"];
                    break;
                case "5":
                    imgHeader.Style = (Style)Resources["MComplementos"];
                    break;
                case "6":
                    imgHeader.Style = (Style)Resources["MBocadillos"];
                    break;
            }


            FoodList.ItemsSource = alimentos;

        }


        private void TappedElement_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Navigation.PushAsync(new DetailedFoodPage(e.SelectedItem as Alimentos));

        }

        private void Basket_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BasketPage(Ioc.Ioc.Resolve<Basket>()));
        }
    }
}
