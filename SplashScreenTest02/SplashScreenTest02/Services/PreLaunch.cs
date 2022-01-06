using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.OS;
using Android.Widget;
using MBStest01.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace SplashScreenTest02.Services
{
	public class PreLaunch
	{
		//private static Uri baseUri = new Uri(string.Format ("https://10.0.2.2:44314/api/", string.Empty));
		//private static HttpClient client; // = new HttpClient();
		//public static HttpClient Client
		//{
		//	get
		//	{
		//		client = client ?? new HttpClient
		//		(
		//			new HttpClientHandler()
		//			{
		//				ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
		//			},
		//			false
		//		)
		//		{
		//			BaseAddress = baseUri
		//		};
		//		return client;
		//	}
		//}
		private readonly UserState userState = new UserState();
		public static string storedInfluences;
		public static string storedMoods;
		public static ApiHelper apiHelper = new ApiHelper();

		private static Task GetInfluencesAsync()
		{
			return Task.Run(async () =>
			{
				storedInfluences = Preferences.Get(Constants.StoredInfluences, String.Empty);
				if (storedInfluences == null)
				{
					//HttpResponseMessage response = await apiHelper.ApiGetter("influences");
					var response = await apiHelper.ApiGetter("influences");
					//if (response.IsSuccessStatusCode)
					//{
						Preferences.Set(Constants.StoredInfluences, response);
						storedInfluences = Preferences.Get(Constants.StoredInfluences, String.Empty);
					//}
				}
			});
		}

		private static Task GetMoodsAsync()
		{
			return Task.Run(async () =>
			{
				storedMoods = Preferences.Get(Constants.StoredMoods, String.Empty);
				if (storedMoods == null)
				{
					//HttpResponseMessage response = await apiHelper.ApiGetter("moods");
					var response = await apiHelper.ApiGetter("moods");
					//if (response.IsSuccessStatusCode)
					//{
						Preferences.Set(Constants.StoredMoods, response);
						storedMoods = Preferences.Get(Constants.StoredMoods, String.Empty);
					//}
				}
			});
		}

		private static Task GetLoggedInUser()	//Bruges ikke pt., tjekkes andetsteds... ikke??
		{
			return Task.Run(() =>
			{
				//UserState userState = new UserState();
				//var storedUser = Preferences.Get("StoredUser", String.Empty);
			});
		}

		public PreLaunch()
		{
			Task mooTask = GetMoodsAsync();
			Task infTask = GetInfluencesAsync();
			Task useTask = GetLoggedInUser();
			//Task bunTask = GatherBundle();

			Task.WaitAll(mooTask, infTask, useTask);
		}

		public Bundle GatherBundle()
		{
			Bundle launchBundle = new Bundle();
			launchBundle.PutString(Constants.StoredMoods, storedMoods);
			launchBundle.PutString(Constants.StoredInfluences, storedInfluences);
			if (userState.CurrentUser.UserID != 0)
				launchBundle.PutInt(Constants.StoredUserID, userState.CurrentUser.UserID);
			return launchBundle;
		}
	}
}
