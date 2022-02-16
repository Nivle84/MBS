using MBStest01.Models;
using MBStest03.ViewModels;
using Rg.Plugins.Popup.Services;
using SplashScreenTest02.Services;
using SplashScreenTest02.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace SplashScreenTest02.ViewModels
{
	public class HistoryViewModel : BaseViewModel
	{
		private ObservableCollection<Day> _daysSource;
		public ObservableCollection<Day> DaysSource
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

		public HistoryDayPopup historyDayPopup {get; set;}
		//public object dayObjFromView { get; set; }
		public DataFiller MyFiller { get; set; }
		public Command OpenPopupCommand { get; set; }
		public HistoryViewModel()
		{
			MyFiller = new DataFiller();
			FillDaysList();
			OpenPopupCommand = new Command(OpenPopupClicked);
			//Skal finde en måde at instantiere popup'en her og overføre instansen til popup kaldet.
		}

		public async void FillDaysList()
		{
			DaysSource = await MyFiller.GetUsersDays();
		}

		public async void OpenPopupClicked(object obj)
		{

			historyDayPopup = new HistoryDayPopup((Day)obj, this);
			await PopupNavigation.PushAsync(historyDayPopup);

		}
	}
}
