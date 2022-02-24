using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SplashScreenTest02.Views;
using MBStest03.ViewModels;
using Syncfusion.SfChart.XForms.Droid;

namespace SplashScreenTest02.Droid
{
    [Activity(
        Label = "Mange Bække Små",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = false,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            new SfChartRenderer();

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

		public override void OnBackPressed()
		{
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
                //TODO
                //Luk popup hvis der er en i "stacken"
                base.OnBackPressed();
            else
			    base.OnBackPressed();
		}
		//protected override bool OnBackPressed()
		//{
		//	if (BindingContext != null && BindingContext is DayViewVM)
		//		if (noteEditor.IsVisible)
		//		{
		//			influenceCollectionView.IsVisible = true;
		//			SelectedInfluence.IsVisible = false;
		//			noteEditor.IsVisible = false;
		//		}
		//}
	}
}