using Android.Widget;
using MBStest01.Models;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using SplashScreenTest02.Services;
using SplashScreenTest02.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using Xamarin.Essentials;

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
		public IEnumerable<Influence> influenceList { get; set; }
		public IEnumerable<Mood> moodList { get; set; }
		DataFiller myFiller { get; set; }
		public ApiHelper apiHelper { get; }

		public DayViewVM()
		{
			Debug.WriteLine("DayViewVM() constructor called.");
			ThisMood = new Mood();
			ThisInfluence = new Influence();
			ThisNote = new Note();
			ThisDay = new Day()
			{
				Date = DateTime.Now.Date,
				UserID = Preferences.Get(Constants.StoredUserID, 0)
			};

			myFiller = new DataFiller();
			influenceList = myFiller.GetInfluences();
			moodList = myFiller.GetMoods();
			apiHelper = new ApiHelper();
		}

		public DayViewVM(Day selectedDay)
		{
			Debug.WriteLine($"DayViewVM(Day selectedDay) constructor called.");
			myFiller = new DataFiller();
			apiHelper = new ApiHelper();
			influenceList = myFiller.GetInfluences();
			moodList = myFiller.GetMoods();
			ThisDay = selectedDay;
			ThisMood = moodList.Single(m => m.MoodID == selectedDay.MoodID);
			ThisInfluence = influenceList.Single(i => i.InfluenceID == selectedDay.InfluenceID);
			ThisNote = selectedDay.Note;
		}

		//public bool DayHasBeenSaved = false;
		//public HistoryViewModel hpVM { get; set; }
		internal async void SaveThisDay()
		{
			ThisDay.Mood = ThisMood;
			ThisDay.MoodID = ThisMood.MoodID;

			ThisDay.Influence = ThisInfluence;
			ThisDay.InfluenceID = ThisInfluence.InfluenceID;

			ThisDay.Note = ThisNote;

			var json = JsonConvert.SerializeObject(ThisDay, Formatting.Indented);
			Preferences.Set(Constants.EditedDay, json);
			
			ThisDay = PrepareDay(ThisDay);
			var response = new HttpStatusCode();

			if (ThisDay.DayID != 0)
			{
				response = await apiHelper.ApiPutter("days/" + ThisDay.DayID.ToString(), ThisDay);
			}

			else
				response = await apiHelper.ApiPoster("days/", ThisDay);

			if (response == HttpStatusCode.Created || response == HttpStatusCode.NoContent)
			{
				Toast.MakeText(Android.App.Application.Context, "Dag gemt!", ToastLength.Short).Show();
				ThisDay.Note = null;
				//DayHasBeenSaved = true;
			}
			else
			{
				Toast.MakeText(Android.App.Application.Context, "Der skete en fejl. Error: " + response.ToString(), ToastLength.Long).Show();
				//DayHasBeenSaved = false;
			}

			try
			{
				//Er stadig ikke helt sikker på om det er good practice at
				//forvente en exception.
				await PopupNavigation.PopAsync();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message.ToString());
			}
		}

		private Day PrepareDay(Day dayToPrepare)
		{	//Child objekter sættes for en sikkerheds skyld til null. Lidt overflødigt.
			dayToPrepare.Influence = null;
			dayToPrepare.Mood = null;
			dayToPrepare.User = null;

			dayToPrepare.InfluenceID = ThisInfluence.InfluenceID;
			dayToPrepare.MoodID = ThisMood.MoodID;
			if (!string.IsNullOrEmpty(ThisNote.NoteString))
			{
				dayToPrepare.HasNote = true;
				dayToPrepare.Note = ThisNote;   //Dette er det eneste "child object" der postes med, da det er
			}                                   //det eneste som skal oprettes selvstændigt i sin egen tabel i DB.

			return dayToPrepare;
		}

		public async void DeleteDay(Day dayToDelete)
		{
			var responseStatusCode = new HttpStatusCode();
			try
			{
				responseStatusCode = await apiHelper.ApiDeleter("days/" + dayToDelete.DayID.ToString());
			}
			catch (Exception ex)
			{
				Toast.MakeText(Android.App.Application.Context, "Der skete en fejl. Error: " + ex.Message.ToString(), ToastLength.Long);
			}

			if (responseStatusCode == HttpStatusCode.NoContent)
			{
				Xamarin.Essentials.Preferences.Set(Constants.DeletedDay, Newtonsoft.Json.JsonConvert.SerializeObject(dayToDelete, Formatting.Indented));
				Toast.MakeText(Android.App.Application.Context, "Dag slettet!", ToastLength.Long);

			}
			else
				Toast.MakeText(Android.App.Application.Context, "Der skete en fejl! Http error: " + responseStatusCode.ToString(), ToastLength.Long);

			await PopupNavigation.PopAsync();
		}
	}
}
