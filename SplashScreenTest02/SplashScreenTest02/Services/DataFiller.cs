using MBStest01.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SplashScreenTest02.Services
{
	public class DataFiller
	{
		public ApiHelper ApiHelper { get; set; }
		public DataFiller()
		{
			ApiHelper = new ApiHelper();
		}

		public List<Mood> GetMoods()
		{
			var receivedJson = Preferences.Get(Constants.StoredMoods, string.Empty);
			//await ApiHelper.ApiGetter("moods");

			List<Mood> moods = new List<Mood>();
			moods = JsonConvert.DeserializeObject<List<Mood>>(receivedJson);
			return moods;
		}

		public List<Influence> GetInfluences()
		{
			var receivedJson = Preferences.Get(Constants.StoredInfluences, string.Empty);
			//await ApiHelper.ApiGetter("influences");

			List<Influence> influences = new List<Influence>();
			influences = JsonConvert.DeserializeObject<List<Influence>>(receivedJson);
			return influences;
		}

		public async Task<List<Day>> GetUsersDays(int userID)
		{
			var receivedJson = await ApiHelper.ApiGetter("users/" + userID.ToString() + "/days");

			List<Day> days = new List<Day>();
			days = JsonConvert.DeserializeObject<List<Day>>(receivedJson);
			return days;
		}
	}
}
