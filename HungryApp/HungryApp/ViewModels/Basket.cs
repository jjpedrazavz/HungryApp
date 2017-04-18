using CoreService.Models;
using HungryApp.Contratos;
using HungryApp.Models.Orders;
using HungryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HungryApp.Models.Basket
{
    public class Basket : BaseViewModel
    {
        public int basketID;

        public int ClientID;

        private double totalFinalOrden=0;

        public int _menuSeleccionadoSize;

        public int _builtInMenuSeleccionadoSize;

        private string titleBasket;

        private bool isVisibleDayMenuCollection;

        private bool isVisibleCartaMenuCollection;

        private bool isVisibleSummaryLayout;




        public ICommand RemoveDetailedMenuCartaCommand { get; set; }

        public ICommand RemoveSummaryBuiltInMenuCommand { get; set; }

        public ICommand CreateOrderCommand { get; set; }





        public ObservableCollection<DetailedMenuCartaViewModel> MenuSeleccionado { get; set; }

        public ObservableCollection<SummaryBuiltInMenuViewModel> BuiltInMenuSeleccionado { get; set; }

        public Basket()
        {
            MenuSeleccionado = new ObservableCollection<DetailedMenuCartaViewModel>();
            BuiltInMenuSeleccionado = new ObservableCollection<SummaryBuiltInMenuViewModel>();


            RemoveDetailedMenuCartaCommand = new Command<DetailedMenuCartaViewModel>(
                execute: (parameter) =>
                {
                    if(parameter != null)
                       RemoveMenuSeleccionadoElement(parameter);
                       RefreshCommand();
                });

            RemoveSummaryBuiltInMenuCommand = new Command<SummaryBuiltInMenuViewModel>(

                execute: (parameter) =>
                 {
                     if(parameter != null)
                        RemoveBuiltInMenuElement(parameter);
                        RefreshCommand();
                 });



            CreateOrderCommand = new Command(

                execute: () =>
                {
                    GenerateMenuOrder();

                },

                canExecute: () =>
                {
                    bool respuesta = TotalFinalOrden == 0 ? false : true;
                    VerifyTitleBasket(respuesta);
                    return respuesta;
                }
                
                );


        }

        private void VerifyTitleBasket(bool respuesta)
        {
            TitleBasket = respuesta ? "Resumen de la Orden" : "Empty Basket";
        }

        private void GenerateMenuOrder()
        {
            ClientOrdersViewModel viewModel = new ClientOrdersViewModel();
            viewModel.menuSeleccionado = new List<MenuViewModel>();
            viewModel.ComensalID = 1;

            foreach (var item in MenuSeleccionado)
            {
                viewModel.menuSeleccionado.Add(new MenuViewModel { AlimentoID = item.AlimentoID, Cantidad = item.Cantidad });
            }


            foreach (var item in BuiltInMenuSeleccionado)
            {
                viewModel.menuSeleccionado.Add(new MenuViewModel { BundleId = item.BundleId, Cantidad = item.Quantity });
            }


            var _ServiceOrdersService = Ioc.Ioc.Resolve<IServiceOrders>();


            _ServiceOrdersService.CreateOrder(viewModel);





        }

        public int MenuSeleccionadoSize{ get => _menuSeleccionadoSize; set => SetProperty(ref _menuSeleccionadoSize, value); }

        public int BuiltInMenuSeleccionadoSize { get => _builtInMenuSeleccionadoSize; set => SetProperty(ref _builtInMenuSeleccionadoSize, value); }

       
        public void RemoveMenuSeleccionadoElement(DetailedMenuCartaViewModel menu)
        {
            MenuSeleccionado.Remove(menu);
            TotalFinalOrden -= (double)menu.Total;
            MenuSeleccionadoSize = MenuSeleccionado.Count;
            IsVisibleCartaMenuCollection = MenuSeleccionadoSize != 0;
            IsEmptyBasket();


        }

        private void IsEmptyBasket()
        {
            if(!IsVisibleCartaMenuCollection && !IsVisibleDaymenuCollection)
            {
                IsVisibleSummaryLayout = false;
            }
        }

        public void RemoveBuiltInMenuElement(SummaryBuiltInMenuViewModel menu)
        {
            BuiltInMenuSeleccionado.Remove(menu);
            TotalFinalOrden -= menu.Totalprice;
            BuiltInMenuSeleccionadoSize = BuiltInMenuSeleccionado.Count;
            IsVisibleDaymenuCollection = BuiltInMenuSeleccionadoSize != 0;
            IsEmptyBasket();

        }


        public double TotalFinalOrden { get => totalFinalOrden; set => SetProperty(ref totalFinalOrden, value); }
        public string TitleBasket { get => titleBasket; set => SetProperty(ref titleBasket, value); }
        public bool IsVisibleDaymenuCollection { get => isVisibleDayMenuCollection; set => SetProperty(ref isVisibleDayMenuCollection, value); }

        public bool IsVisibleCartaMenuCollection { get => isVisibleCartaMenuCollection; set => SetProperty(ref isVisibleCartaMenuCollection, value); }
        public bool IsVisibleSummaryLayout { get => isVisibleSummaryLayout; set => SetProperty(ref isVisibleSummaryLayout, value); }

        public void RefreshCommand()
        {
            ((Command)CreateOrderCommand).ChangeCanExecute();
        }


    }
}
