using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HungryApp.InitModulos;

namespace HungryApp.Droid
{
	[Activity (Label = "HungryApp", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

            InitIOC();


            LoadApplication (new HungryApp.App ());
		}

        private void InitIOC()
        {
            Ioc.Ioc.CreateContainer();
            Ioc.Ioc.RegisterModule(new Initialize());
            Ioc.Ioc.StartContainer();
        }
	}
}

