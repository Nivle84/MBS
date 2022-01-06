using MBStest03.Views;
using SplashScreenTest02;
using SplashScreenTest02.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using BCrypt.Net;
using MBStest01.Models;
using SplashScreenTest02.Services;
using Newtonsoft.Json;
using Android.Widget;
using Android.Content;
using System.Threading.Tasks;

namespace MBStest03.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
		PasswordHasher hasher = new PasswordHasher();

        //public User currentUser = new User();
		private User _currentUser;
		public User CurrentUser
		{
			get { return _currentUser; }
			set { _currentUser = value; OnPropertyChanged(); }
		}

		public Command LoginCommand { get; }
		public Command GoToCreateUserCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
			GoToCreateUserCommand = new Command(GoToCreateUserClicked);
			CurrentUser = new User();
			//{
			//	UserID = 69,
   //             UserEmail = "placeholder_email",
   //             UserPassword = "placeholder_password"
			//};
		}

		private async void GoToCreateUserClicked(object obj)
		{
			await Shell.Current.GoToAsync($"//CreateAccountPage");
		}

		public async void OnLoginClicked(object obj)
        {
			Console.WriteLine(CurrentUser.UserEmail.ToString());
			Console.WriteLine(CurrentUser.UserPassword.ToString());

			CurrentUser.UserPassword = hasher.Hasher(CurrentUser.UserPassword);
			if (await UserIsVerified(CurrentUser))
			{
				Application.Current.MainPage = new AppShell();
				await Shell.Current.GoToAsync("//main");
			}
			else
				Toast.MakeText(Android.App.Application.Context, "Forkert email eller kodeord!", ToastLength.Long).Show();

			// Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
			//await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
			//await Shell.Current.GoToAsync("//MainPage");

			//TODO Login logik.
		}

		ApiHelper apiHelper = new ApiHelper();
		private async Task<bool> UserIsVerified(User user)
		{
			var receivedResponse = await apiHelper.ApiGetter("users/username/" + user.UserEmail);
			var receivedUser = JsonConvert.DeserializeObject<User>(receivedResponse);
			
			user.UserID = receivedUser.UserID;
			if (user.UserPassword == receivedUser.UserPassword)
				return true;
			else
				return false;
		}
	}
}
