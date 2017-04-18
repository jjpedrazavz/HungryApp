using HungryApp.Navigation;
using HungryApp.Pages.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HungryApp.Contratos;
using HungryApp.Services;
using HungryApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data.Common;
using HungryApp.Pages.Orders;

namespace HungryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{

        public MainViewModel _viewModelMain;

        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModelMain = viewModel;
            BindingContext = viewModel;
            viewModel._BuiltInMenus = new BuiltInMenuViewModel();
            LoadMenusCollection(viewModel._BuiltInMenus);

        }

        private  async void LoadMenusCollection(BuiltInMenuViewModel viewModel)
        {

            viewModel.MenusCollection = await _viewModelMain._menuFoodService.GetBuiltInMenus();

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
        }

        private async void GetListClicked(object sender, EventArgs e)
        {

            switch((sender as Button).StyleId)
            {
                case "1":
                    await Navigation.PushAsync(new ComidasDiaPage(GetSpecificBuiltMenu("Comidas")));

                    break;
                case "2":

                    await Navigation.PushAsync(new ComidasDiaPage(GetSpecificBuiltMenu("Cenas")));

                    break;
                case "3":
                    await Navigation.PushAsync(new ComidasDiaPage(GetSpecificBuiltMenu("Desayunos")));
                    break;

                case "4":

                    _viewModelMain._MenuCarta = await _viewModelMain._menuFoodService.GetMenuElements();

                    await Navigation.PushAsync(new CartaPage(_viewModelMain._MenuCarta));

                    break;
                default:
                    break;
            }


        }

        private List<DetailedBuiltInMenuViewModel> GetSpecificBuiltMenu(string category)
        {

            return (from element in _viewModelMain._BuiltInMenus.MenusCollection
                    where element.MenuCategory.Equals(category)
                    select element).ToList();
        }

        private async void MenuSettings_Clicked(object sender, EventArgs e)
        {
            switch((sender as ToolbarItem).StyleId)
            {
                case "5":
                    await Navigation.PushAsync(new BasketPage(_viewModelMain._MainBasket));
                    break;
                case "666":
                    await Navigation.PushAsync(new SuperTestPage());
                    break;
                default:
                    break;

            }
           
        }
    }
}
