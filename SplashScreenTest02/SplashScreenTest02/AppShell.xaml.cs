using SplashScreenTest02.ViewModels;
using SplashScreenTest02.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MBStest03.Views;

namespace SplashScreenTest02
{
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public AppShell()
		{
			InitializeComponent();
			//Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
			//Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
			//Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
			Routing.RegisterRoute("createUser", typeof(CreateUserPage));
		}

	}
}
