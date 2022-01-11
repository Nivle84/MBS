using MBStest03.Views;
using SplashScreenTest02.Services;
using SplashScreenTest02.Views;
using System;
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
			//Preferences.Set(Constants.StoredUserID, 0);
			if (Preferences.Get(Constants.StoredUserID, 0) != 0)    //Hvis der findes et ID, naviger til Login, ellers naviger til main.
				await Shell.Current.GoToAsync("///main");
			else
				await Shell.Current.GoToAsync("LoginPage");
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
