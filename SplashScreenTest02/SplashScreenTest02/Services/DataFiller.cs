using MBStest01.Models;
using MBStest03.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		public async Task<ObservableCollection<Day>> GetUsersDays()
		{
			var receivedJson = await ApiHelper.GetDaysByUserID(Preferences.Get(Constants.StoredUserID, 0));

			ObservableCollection<Day> days = new ObservableCollection<Day>();
			days = JsonConvert.DeserializeObject<ObservableCollection<Day>>(receivedJson);
			return days;
		}
	}
}
