using MBStest01.Models;
using SplashScreenTest02.ViewModels;
using System;
using Xamarin.Essentials;
using SplashScreenTest02.Services;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Globalization;
using System.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Drawing;
using Android.Widget;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MBStest03.ViewModels
{
	public class DayViewVM : BaseViewModel
	{
		//private User _user;
		//public User ThisUser
		//{
		//	get { return _user; }
		//	set
		//	{
		//		_user = value;
		//		//ThisDay.User = ThisUser;
		//	}
		//}

		private Day _day;
		public Day ThisDay
		{
			get { return _day; }
			set
			{
				_day = value;
				OnPropertyChanged();
			}
		}

		private Mood _mood;
		public Mood ThisMood
		{
			get { return _mood; }
			set
			{
				_mood = value;
				OnPropertyChanged();
			}
		}

		private Influence _influence;
		public Influence ThisInfluence
		{
			get { return _influence; }
			set
			{
				_influence = value;
				OnPropertyChanged();
			}
		}

		private Note _note;
		public Note ThisNote
		{
			get { return _note; }
			set
			{
				_note = value;
				OnPropertyChanged();
			}
		}

		public string ShortDate 
		{
			get
			{
				var culture = CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("da-DK");
				var date = ThisDay.Date.ToString("dddd dd/MM/yy", culture).ToUpperInvariant();
				return date;
			}
		}
		//public Command SaveThisDayCommand { get; }
		public IEnumerable<Influence> influenceList { get; set; }
		public List<Mood> moodList { get; set; }
		DataFiller myFiller { get; set; }
		public ApiHelper apiHelper { get; }
		int dayViewVMNoParamCallTimes = 0;

		public DayViewVM()
		{
			dayViewVMNoParamCallTimes++;
			Debug.WriteLine($"DayViewVM() called {dayViewVMNoParamCallTimes} times from {ToString()}.");
			ThisMood = new Mood();
			ThisInfluence = new Influence();
			ThisNote = new Note();
			ThisDay = new Day()
			{
				Date = DateTime.Now.Date,
				UserID = Preferences.Get(Constants.StoredUserID, 0)
			};
			//ThisUser = new User()
			//{
			//	UserID = Preferences.Get(Constants.StoredUserID, 0)
			//};

			myFiller = new DataFiller();
			influenceList = myFiller.GetInfluences();
			moodList = myFiller.GetMoods();
			apiHelper = new ApiHelper();
		}

		int dayViewVMParamCallTimes = 0;
		public DayViewVM(Day selectedDay)
		{
			dayViewVMParamCallTimes++;
			Debug.WriteLine($"DayViewVM(Day selectedDay) called {dayViewVMParamCallTimes} times.");
			myFiller = new DataFiller();
			apiHelper = new ApiHelper();
			//ThisDay = new Day();
			//ThisMood = new Mood();
			//ThisInfluence = new Influence();
			//ThisNote = new Note();
			influenceList = myFiller.GetInfluences();
			moodList = myFiller.GetMoods();
			ThisDay = selectedDay;
			ThisMood = selectedDay.Mood;
			ThisInfluence = selectedDay.Influence;
			ThisNote = selectedDay.Note;
			//ThisUser.UserID = selectedDay.UserID;
			Debug.WriteLine("DayViewVM(Day selectedDay) constructor end.");
		}

		public bool DayHasBeenSaved = false;

		internal async void SaveThisDay()
        {
			//ThisDay.UserID		= ThisUser.UserID;	//Denne fungerer ikke ordentligt i popupvinduet. Går bare ud af metoden.
			ThisDay.MoodID		= ThisMood.MoodID;
			ThisDay.InfluenceID = ThisInfluence.InfluenceID;
			if (!String.IsNullOrEmpty(ThisNote.NoteString))
			{
				ThisDay.HasNote = true;
				ThisDay.Note = ThisNote;	//Dette er det eneste "child object" der postes med, da det er
			}								//det eneste som skal oprettes selvstændigt i sin egen tabel i DB.

			var response = await apiHelper.ApiPoster("days/", ThisDay);
			
			if (response == System.Net.HttpStatusCode.OK)
			{
				Toast.MakeText(Android.App.Application.Context, "Dag gemt!", ToastLength.Short).Show();
				ThisDay.Mood = null;
				ThisDay.Influence = null;
				ThisDay.Note = null;
				DayHasBeenSaved = true;
			}
			else
			{
				Toast.MakeText(Android.App.Application.Context, "Der skete en fejl. Error: " + response.ToString(), ToastLength.Long).Show();
				DayHasBeenSaved = false;
			}
		}

		public observableobject
    }
}
