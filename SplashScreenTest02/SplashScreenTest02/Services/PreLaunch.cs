using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MBStest01.Models;
using Newtonsoft.Json;

namespace SplashScreenTest02.Services
{
	public class PreLaunch
	{
		public static IList<Mood> moods;
		public static IList<Influence> influences;
		private static Uri baseUri = new Uri(string.Format ("https://localhost:44314/api/", string.Empty));
		private static HttpClient client;
		private static async void GetInfluencesAsync()
		{
			HttpResponseMessage response = await client.GetAsync (baseUri + "influences");
			if (response.IsSuccessStatusCode)
			{
				string receivedInfluences = await response.Content.ReadAsStringAsync();
				influences = JsonConvert.DeserializeObject<List<Influence>>(receivedInfluences);
			}

			//TODO Skal sikkert have en bedre statuskode på her.
			//return null;
		}

		private static async void GetMoodsAsync()
		{
			HttpResponseMessage response = await client.GetAsync(baseUri + "moods");
			if (response.IsSuccessStatusCode)
			{
				string receivedMoods = await response.Content.ReadAsStringAsync();
				moods = JsonConvert.DeserializeObject<List<Mood>>(receivedMoods);
				//return Task<TResult>.CompletedTask;
			}

			//TODO Skal sikkert have en bedre statuskode på her.
			//return null;
		}

		public PreLaunch()
		{
			//influences = (IList<Influence>)GetInfluencesAsync();
			//moods = (IList<Mood>)GetMoodsAsync();
		}

		static Task moodTask =		new Task(GetMoodsAsync);
		static Task influenceTask = new Task(GetInfluencesAsync);

		public List<Task> preLaunchTasks = new List<Task>()
		{
			moodTask,
			influenceTask
		};

	}
}
