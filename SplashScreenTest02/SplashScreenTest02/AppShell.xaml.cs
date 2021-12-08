using SplashScreenTest02.ViewModels;
using SplashScreenTest02.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SplashScreenTest02
{
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
			Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
		}

	}
}
