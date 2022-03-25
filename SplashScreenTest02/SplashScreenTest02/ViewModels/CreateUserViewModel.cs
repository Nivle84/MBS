using Android.Widget;
using MBStest01.Models;
using MBStest03.Views;
using SplashScreenTest02.Services;
using SplashScreenTest02.ViewModels;
using System.Net;
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

        private string repeatPassword;

        public string RepeatPassword
        {
            get { return repeatPassword; }
            set { repeatPassword = value; }
        }


        public CreateUserViewModel()
		{
			CurrentUser = new User();
			CreateUserCommand = new Command(CreateUserClicked);
			RepeatPassword = string.Empty;
		}

		public async void CreateUserClicked(object obj)
		{
			if (CurrentUser.UserEmail == CurrentUser.UserPassword)				//Tjek om email er brugt som kodeord.
				Toast.MakeText(Android.App.Application.Context, "Email er ikke gyldigt som kodeord! Prøv igen.", ToastLength.Short).Show();
			else if (CurrentUser.UserPassword == RepeatPassword)				//Tjek om de to kodeod er ens.
			{
				switch (await apiHelper.DoesUserExist(CurrentUser.UserEmail))	//Tjek om brugeren findes i forvejen i DB.
				{
					case true:	//Brugeren findes i forvejen
						Toast.MakeText(Android.App.Application.Context, "Bruger findes allerede!", ToastLength.Short).Show();
						break;
					
					case false:	//Brugeren findes ikke i forvejen
						CurrentUser.UserPassword = BC.HashPassword(CurrentUser.UserPassword);				//Hash kodeord med salt.
						var apiResponseStatusCode = await apiHelper.ApiPoster("users/", CurrentUser);		//Post bruger til API.
						switch (apiResponseStatusCode)
						{
							case HttpStatusCode.Created:						//Bruger blev oprettet, programmet navigerer tilbage til LoginPage.
								Toast.MakeText(Android.App.Application.Context, "Bruger oprettet!", ToastLength.Long).Show();
								await Shell.Current.GoToAsync(nameof(LoginPage));
								break;
							default:
								Toast.MakeText(Android.App.Application.Context, "Der skete en fejl. Fejlkode: " + apiResponseStatusCode, ToastLength.Long).Show();
								break;
						}
						break;
				}
			}
			else
				Toast.MakeText(Android.App.Application.Context, "Kodeord matcher ikke! Prøv igen.", ToastLength.Long).Show();

		}
	}
}
