using MBStest01.Models;
using MBStest03.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
//using SplashScreenTest02.Resources.Images;

namespace SplashScreenTest02.Services
{
	public class DataFiller
	{
		public ApiHelper ApiHelper { get; set; }
		public TranslatorHelper Translator {get; set;}
		public DataFiller()
		{
			ApiHelper = new ApiHelper();
			Translator = new TranslatorHelper();
		}

		public List<Mood> GetMoods()
		{
			var receivedJson = Preferences.Get(Constants.StoredMoods, string.Empty);
			//await ApiHelper.ApiGetter("moods");

			List<Mood> moods = new List<Mood>();
			moods = JsonConvert.DeserializeObject<List<Mood>>(receivedJson);
            //Bryder mig ikke om denne her hardcoded implementering... Men kan godt forsvare den fordi der med al sandsynlighed ikke kommer flere moods til.

            foreach (var mood in moods)
            {
				mood.MoodImagePath = "mood" + $"{mood.MoodName}".ToLower() + ".png";
			}

            return moods;
		}

		public List<Influence> GetInfluences()
		{
			var receivedJson = Preferences.Get(Constants.StoredInfluences, string.Empty);
			//await ApiHelper.ApiGetter("influences");

			List<Influence> influences = new List<Influence>();
			influences = JsonConvert.DeserializeObject<List<Influence>>(receivedJson);

            foreach (var influence in influences)
            {
				influence.InfluenceName = Translator.InfluenceTranslator(influence.InfluenceID);
            }

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
