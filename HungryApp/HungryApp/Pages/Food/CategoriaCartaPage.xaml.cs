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

namespace HungryApp.Pages.Food
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoriaCartaPage : ContentPage
	{

        public CategoriaCartaPage(IEnumerable<Alimentos> alimentos)
		{
            
            InitializeComponent();
            FoodList.ItemsSource = alimentos;

        }


        private void TappedElement_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Navigation.PushAsync(new DetailedFoodPage(e.SelectedItem as Alimentos));

        }

    }
}
