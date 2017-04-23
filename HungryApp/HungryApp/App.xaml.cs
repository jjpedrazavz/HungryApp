using HungryApp.Pages;
using HungryApp.Pages.Food;
using HungryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HungryApp
{
	public partial class App : Application
	{

		public App ()
		{
			InitializeComponent();

            MainPage = new IntroPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
