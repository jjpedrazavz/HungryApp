using HungryApp.Contratos;
using HungryApp.enums;
using HungryApp.Models.Basket;
using HungryApp.Pages.Orders;
using HungryApp.Services;
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
	public partial class ComidasDiaPage : ContentPage
	{
        

        public ComidasDiaPage(List<DetailedBuiltInMenuViewModel> Comidas, Menus tipo)
		{
            

            InitializeComponent();

            switch (tipo)
            {
                case Menus.Cenas:
                    imgHeader.Style = (Style)Resources["CenasS"];
                    break;
                case Menus.Comidas:
                    imgHeader.Style = (Style)Resources["ComidasS"];
                    break;
                case Menus.Desayunos:
                    imgHeader.Style = (Style)Resources["DesayunosS"];
                    break;
                default:
                    break;
            }


            listContainer.ItemsSource = Comidas;

        }


        private void OnListItemMenuSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new DetailedBuiltInMenuOrderPage(e.SelectedItem as DetailedBuiltInMenuViewModel));
        }

        private void Basket_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BasketPage(Ioc.Ioc.Resolve<Basket>()));
        }
    }
}
