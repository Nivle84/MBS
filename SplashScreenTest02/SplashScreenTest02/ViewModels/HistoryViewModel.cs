using MBStest01.Models;
using MBStest03.ViewModels;
using SplashScreenTest02.Services;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace SplashScreenTest02.ViewModels
{
	public class HistoryViewModel : BaseViewModel
	{
		public IEnumerable<Day> _daysSource;
		public IEnumerable<Day> DaysSource
		{
			get { return _daysSource; }
			set { _daysSource = value; OnPropertyChanged(); }
		}
		public DataFiller MyFiller { get; set; }
		public HistoryViewModel()
		{
			MyFiller = new DataFiller();
			FillDaysList();
		}

		public async void FillDaysList()
		{
			DaysSource = await MyFiller.GetUsersDays();
			foreach (var day in DaysSource)
			{
				//Det her er grimt og rodet, men det virker.
				day.Mood.MoodImagePath = "mood" + $"{day.Mood.MoodName}".ToLower() + ".png";
				//Debug.WriteLine("DaysSource MoodName: " + day.Mood.MoodName);
			}
		}
	}
}
