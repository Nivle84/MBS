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

			//if (Preferences.Get(Constants.StoredUserID, 0) != 0)    //Hvis der findes et ID, gå til AppShell. Ellers gå til Login.
			//	MainPage = new AppShell();
			//else
				MainPage = new NavigationPage(new LoginPage());
			//ContentPage = new CreateUserPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
