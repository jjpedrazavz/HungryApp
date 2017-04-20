using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HungryApp.InitModulos;
using Xamarin.Forms;
using Android.Content.Res;

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


        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);


            switch (newConfig.Orientation)
            {
                case Android.Content.Res.Orientation.Landscape:
                    switch (Device.Idiom)
                    {
                        case TargetIdiom.Phone:
                            LockRotation(Android.Content.Res.Orientation.Portrait);
                            break;
                        case TargetIdiom.Tablet:
                            LockRotation(Android.Content.Res.Orientation.Landscape);
                            break;
                    }
                    break;
                case Android.Content.Res.Orientation.Portrait:
                    switch (Device.Idiom)
                    {
                        case TargetIdiom.Phone:
                            LockRotation(Android.Content.Res.Orientation.Portrait);
                            break;
                        case TargetIdiom.Tablet:
                            LockRotation(Android.Content.Res.Orientation.Landscape);
                            break;
                    }
                    break;
            }



        }


        private void LockRotation(Android.Content.Res.Orientation orientation)
        {
            switch (orientation)
            {
                case Android.Content.Res.Orientation.Portrait:
                    RequestedOrientation = ScreenOrientation.Portrait;
                    break;
                case Android.Content.Res.Orientation.Landscape:
                    RequestedOrientation = ScreenOrientation.Landscape;
                    break;
            }
        }


        private void InitIOC()
        {
            Ioc.Ioc.CreateContainer();
            Ioc.Ioc.RegisterModule(new Initialize());
            Ioc.Ioc.StartContainer();
        }
	}
}

