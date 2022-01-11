using MBStest01.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SplashScreenTest02.Services
{
	public class MoodHelper
	{
		public static readonly List<Mood> moods = JsonConvert.DeserializeObject<List<Mood>>(Preferences.Get(Constants.StoredMoods, null));


	}
}
