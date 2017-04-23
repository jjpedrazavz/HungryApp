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
using HungryApp.Pages.ToolBar;
using HungryApp.enums;
using HungryApp.Pages.Account;

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
            LoadingData.IsRunning = true;

            viewModel.MenusCollection = await _viewModelMain._menuFoodService.GetBuiltInMenus();
            _viewModelMain._MenuCarta = await _viewModelMain._menuFoodService.GetMenuElements();

            await Task.Delay(4000);

            LoadingData.IsRunning = false;
            LayoutMenus.IsVisible = true;
            LayoutMenus.IsEnabled = true;

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
        }

        private async void GetListClicked(object sender, EventArgs e)
        {

            switch((sender as Image).StyleId)
            {
                case "1":
                    await Navigation.PushAsync(new ComidasDiaPage(GetSpecificBuiltMenu("Comidas"),Menus.Comidas));

                    break;
                case "2":

                    await Navigation.PushAsync(new ComidasDiaPage(GetSpecificBuiltMenu("Cenas"), Menus.Cenas));

                    break;
                case "3":
                    await Navigation.PushAsync(new ComidasDiaPage(GetSpecificBuiltMenu("Desayunos"), Menus.Desayunos));
                    break;

                case "4":

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
                case "T1":
                    break;
                case "T2":
                    break;
                case "T3":
                    await Navigation.PushAsync(new OrdersHistoryPage(await _viewModelMain._ServiceOrdersService.GetSummaryOrders(_viewModelMain.clientID)));
                    break;
                case "T4":
                    await Navigation.PushAsync(new LoginPage());
                    break;
                case "T5":
                    await Navigation.PushAsync(new BasketPage(_viewModelMain._MainBasket));
                    break;
                default:
                    break;

            }
           
        }

    }
}
