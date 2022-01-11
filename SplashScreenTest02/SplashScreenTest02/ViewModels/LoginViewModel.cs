using Android.Widget;
using MBStest01.Models;
using MBStest03.Views;
using Newtonsoft.Json;
using SplashScreenTest02;
using SplashScreenTest02.Services;
using SplashScreenTest02.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using BC = BCrypt.Net.BCrypt;

namespace MBStest03.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		//PasswordHasher hasher = new PasswordHasher();
		//LoginPage loginPage;
		//CreateUserPage cuPage = new CreateUserPage();

		//public User currentUser = new User();
		private User _currentUser;
		public User CurrentUser
		{
			get { return _currentUser; }
			set { _currentUser = value; }
		}

		public Command LoginCommand { get; }
		public Command GoToCreateUserCommand { get; }

		public LoginViewModel()
		{
			//loginPage = new LoginPage();
			LoginCommand = new Command(OnLoginClicked);
			GoToCreateUserCommand = new Command(GoToCreateUserClicked);
			CurrentUser = new User();
			//{
			//	UserID = 69,
			//	UserEmail = "placeholder_email",
			//	UserPassword = "placeholder_password"
			//};
		}

		private async void GoToCreateUserClicked(object obj)
		{
			//await loginPage.Navigation.PushModalAsync(new CreateUserPage());
			await Shell.Current.GoToAsync(nameof(CreateUserPage));
			//Application.Current.MainPage = new CreateUserPage();
			//await Shell.Current.GoToAsync($"//createUser");
		}

		public async void OnLoginClicked(object obj)
		{
			//Console.WriteLine(CurrentUser.UserEmail.ToString());
			//Console.WriteLine(CurrentUser.UserPassword.ToString());

			//CurrentUser.UserPassword = hasher.Hasher(CurrentUser.UserPassword);
			if (await UserIsVerified(CurrentUser))
			{
				Preferences.Set(Constants.StoredUserID, CurrentUser.UserID);
				Application.Current.MainPage = new AppShell();
				await Shell.Current.GoToAsync("//main");
			}
			else
				Toast.MakeText(Android.App.Application.Context, "Forkert email eller kodeord!", ToastLength.Long).Show();

			// Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
			//await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
			//await Shell.Current.GoToAsync("//MainPage");
		}

		ApiHelper apiHelper = new ApiHelper();
		private async Task<bool> UserIsVerified(User user)
		{
			var receivedResponse = await apiHelper.ApiGetter("users/username/" + user.UserEmail);   //Henter brugeren med den matchende email.
			var receivedUser = JsonConvert.DeserializeObject<User>(receivedResponse);               //Konverterer den hentede bruger til et User objekt.

			if (receivedUser != null && BC.Verify(user.UserPassword, receivedUser.UserPassword))    //Stemmer de hashede passwords overens har vi fat i den rigtige bruger og set'er dens ID.
			{                                                   //Brugeren er verificeret som værende en eksisterende bruger.
				CurrentUser.UserID = receivedUser.UserID;
				return true;
			}
			else
				return false;
		}
	}
}
