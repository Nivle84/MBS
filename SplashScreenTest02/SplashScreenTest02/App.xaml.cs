using MBStest03.Views;
using SplashScreenTest02.Services;
using SplashScreenTest02.Views;
using System;
using System.Globalization;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SplashScreenTest02
{
	public partial class App : Application
	{
		public CreateUserPage ContentPage { get; }

		public App()
		{
			InitializeComponent();

			//DependencyService.Register<MockDataStore>();
			

			MainPage = new AppShell();
		}

		protected async override void OnStart()
		{
			var culture = CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("da-DK");
			SetLocale(culture);
			//Preferences.Set(Constants.StoredUserID, 0);
			if (Preferences.Get(Constants.StoredUserID, 0) != 0)    //Hvis der ikkr findes et ID, naviger til Login, ellers naviger til main.
				await Shell.Current.GoToAsync("///main");
			else
				await Shell.Current.GoToAsync("LoginPage");
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
			var culture = CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("da-DK");
			SetLocale(culture);
		}

		public void SetLocale(CultureInfo culture)
		{
			Thread.CurrentThread.CurrentCulture = culture;
			Thread.CurrentThread.CurrentUICulture = culture;
		}
	}
}
