using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.OS;
using MBStest01.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace SplashScreenTest02.Services
{
	public class PreLaunch
	{
		//public static IList<Mood> moods;
		//public static IList<Influence> influences;
		private static Uri baseUri = new Uri(string.Format ("https://localhost:44314/api/", string.Empty));
		private static HttpClient client = new HttpClient();
		private readonly UserState userState;
		public static string storedInfluences;
		public static string storedMoods;
		private static async Task GetInfluencesAsync()
		{
			storedInfluences = (string)JsonConvert.DeserializeObject(Preferences.Get("StoredInfluences", "default_value"));
			if (storedInfluences == null)
			{
				HttpResponseMessage response = await client.GetAsync (baseUri + "influences");
				if (response.IsSuccessStatusCode)
				{
					Preferences.Set("StoredInfluences", await response.Content.ReadAsStringAsync());

					//string receivedInfluences = await response.Content.ReadAsStringAsync();
					//influences = JsonConvert.DeserializeObject<List<Influence>>(receivedInfluences);
				}
			}


			//TODO Skal sikkert have en bedre statuskode på her.
			//return null;
		}

		private static async Task GetMoodsAsync()
		{
			//var storedMoods;
			storedMoods = (string)JsonConvert.DeserializeObject(Preferences.Get("StoredMoods", "default_value"));
			if ( storedMoods == null)
			{
				HttpResponseMessage response = await client.GetAsync(baseUri + "moods");
				if (response.IsSuccessStatusCode)
				{
					Preferences.Set("StoredMoods", await response.Content.ReadAsStringAsync());

					//string receivedMoods = await response.Content.ReadAsStringAsync();
					//moods = JsonConvert.DeserializeObject<List<Mood>>(receivedMoods);
					//return Task<TResult>.CompletedTask;
				}
			}

			//TODO Skal sikkert have en bedre statuskode på her.
			//return null;
		}

		public Bundle GatherBundle()
		{
			Bundle launchBundle = new Bundle();
			launchBundle.PutString("StoredMoods", storedMoods);
			launchBundle.PutString("StoredInfluences", storedInfluences);
			launchBundle.PutInt("LoggedInUserID", userState.CurrentUser.UserID);
			return launchBundle;
		}

		//public async void LoggedInUserExists()
		//{
		//	//var storedUser = JsonConvert.DeserializeObject(Preferences.Get("StoredUser", "default_value"));

		//}

		public PreLaunch()
		{
			//preLaunchTasks.ForEach(task => task.Start());
			//influences = (IList<Influence>)GetInfluencesAsync();
			//moods = (IList<Mood>)GetMoodsAsync();
		}

		static Task moodTask = new Task(new Action(GetMoodsAsync));
		static Task influenceTask = GetInfluencesAsync();
		//static Task userTask = new Task(LoggedInUserExists);

		//public List<Task> preLaunchTasks = new List<Task>()
		//{
		//	moodTask,
		//	influenceTask
		//	//userTask
		//};


		//Kig efter om der er en bruger i secure storage


	}
}
