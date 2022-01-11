using Android.Widget;
using MBStest01.Models;
using MBStest03.Views;
using SplashScreenTest02.Services;
using SplashScreenTest02.ViewModels;
using Xamarin.Forms;
using BC = BCrypt.Net.BCrypt;

namespace MBStest03.ViewModels
{
	class CreateUserViewModel : BaseViewModel
	{
		ApiHelper apiHelper = new ApiHelper();
		public Command CreateUserCommand { get; }
		private User _currentUser;
		public User CurrentUser
		{
			get { return _currentUser; }
			set { _currentUser = value; }
		}

		public CreateUserViewModel()
		{
			CurrentUser = new User();
			CreateUserCommand = new Command(CreateUserClicked);
		}

		public async void CreateUserClicked(object obj)
		{
			CurrentUser.UserPassword = BC.HashPassword(CurrentUser.UserPassword);
			var apiResponse = await apiHelper.ApiPoster("users", CurrentUser);
			if (apiResponse == "Post ok!")
			{
				Toast.MakeText(Android.App.Application.Context, "Bruger oprettet!", ToastLength.Long).Show();
				await Shell.Current.GoToAsync(nameof(LoginPage));
			}
			else
				Toast.MakeText(Android.App.Application.Context, "Der skete en fejl. Prøv igen", ToastLength.Short).Show();
		}
	}
}
