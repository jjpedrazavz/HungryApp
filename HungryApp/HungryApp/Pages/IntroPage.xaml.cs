using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HungryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IntroPage : ContentPage
	{
		public IntroPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            await Task.Delay(4000);

            App.Current.MainPage = Ioc.Ioc.Resolve<NavigationPage>();

        }

    }
}
