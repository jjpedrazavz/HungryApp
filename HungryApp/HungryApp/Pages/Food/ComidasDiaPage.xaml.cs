using HungryApp.Contratos;
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
        

        public ComidasDiaPage(List<DetailedBuiltInMenuViewModel> Comidas)
		{
            

            InitializeComponent();
            listContainer.ItemsSource = Comidas;

        }

        protected override void OnAppearing()
        {

            base.OnAppearing();
        }



        private void OnListItemMenuSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new DetailedBuiltInMenuOrderPage(e.SelectedItem as DetailedBuiltInMenuViewModel));
        }
    }
}
