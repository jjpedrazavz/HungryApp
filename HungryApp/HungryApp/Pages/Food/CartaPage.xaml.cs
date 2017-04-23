using CoreService.Models;
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
	public partial class CartaPage : ContentPage
	{
        ClientOrdersViewModel _viewModel;

        public CartaPage (ClientOrdersViewModel viewModel)
		{
			InitializeComponent();
            _viewModel = viewModel;
        }

        private IEnumerable<Alimentos> CreateListByCategory(string tipo)
        {

            return _viewModel.AlimentosList.Where(p => p.TipoId == int.Parse(tipo)).ToList();

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            Navigation.PushAsync(new CategoriaCartaPage(CreateListByCategory((sender as Image).StyleId), (sender as Image).StyleId));

        }
    }
}
