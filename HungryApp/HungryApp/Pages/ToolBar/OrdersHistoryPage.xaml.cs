using HungryApp.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HungryApp.Pages.ToolBar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrdersHistoryPage : ContentPage
	{
		public OrdersHistoryPage (IEnumerable<SlimOrderViewModel> orders)
		{
			InitializeComponent ();
            OrderHistoryList.ItemsSource = orders;
		}
	}
}
