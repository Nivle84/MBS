using MBStest01.Models;
using MBStest03.ViewModels;
using SplashScreenTest02.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace SplashScreenTest02.ViewModels
{
	public class HistoryViewModel : BaseViewModel
	{
		private IList<Day> _daysSource;
		public IList<Day> DaysSource
		{
			get 
			{
				return _daysSource;
			}
			set
			{
				if (value != null)
				{
					foreach (var day in value)
					{
						day.Mood.MoodImagePath = "mood" + $"{day.Mood.MoodName}".ToLower() + ".png";
					}
				}
				_daysSource = value;
				OnPropertyChanged();
			}
		}

		private Day _thisDay;

		public Day ThisDay
		{
			get { return _thisDay; }
			set { _thisDay = value; }
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
		}

		//public void EditDay(Day dayToEdit)
		//{
		//	foreach (var day in DaysSource.Where(d => d.DayID == dayToEdit.DayID))
		//	{
		//		dayToEdit = day;
		//	}
		//}
	}
}
