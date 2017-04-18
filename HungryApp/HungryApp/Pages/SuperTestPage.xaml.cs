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
	public partial class SuperTestPage : ContentPage
	{
		public SuperTestPage ()
		{
			InitializeComponent ();

            List<Button> myButtons = new List<Button>();

            for (int i = 0; i < 50; i++)
            {
                myButtons.Add(new Button { Text = i.ToString() });
            }

            testListView.ItemsSource = myButtons;



		}
	}
}
