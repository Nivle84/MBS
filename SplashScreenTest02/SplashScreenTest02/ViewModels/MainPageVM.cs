using MBStest01.Models;
using SplashScreenTest02.ViewModels;
using System;

namespace MBStest03.ViewModels
{
	//public class MainPageVM : INotifyPropertyChanged
	public class MainPageVM : BaseViewModel
	{
		private User _user;
		public User ThisUser
		{
			get { return _user; }
			set
			{
				_user = value;
				ThisDay.User = ThisUser;
			}
		}

		private Day _day;
		public Day ThisDay
		{
			get { return _day; }
			set
			{
				//Er det her jeg skal indsætte værdierne for mood, influence m.m. i day? Nej vel??
				//ThisDay.Mood = ThisMood;
				//ThisDay.Influence = ThisInfluence;
				//ThisDay.Note = ThisNote;
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
				if (ThisMood.MoodID != 0)
				{
					ThisDay.Mood = ThisMood;
					currentMoodName = ThisMood.MoodName;
				}
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
				if (ThisInfluence.InfluenceID != 0)
					ThisDay.Influence = ThisInfluence;
				OnPropertyChanged();
				//OnPropertyChanged("ThisDay");
			}
		}

		private Note _note;
		public Note ThisNote
		{
			get { return _note; }
			set
			{
				_note = value;
				if (ThisNote.DayID != 0)
					ThisDay.Note = ThisNote;
				OnPropertyChanged();
				//OnPropertyChanged("ThisDay");
			}
		}
		private string _currentMoodName { get; set; }
		public string currentMoodName
		{
			get
			{
				return _currentMoodName;
			}
			set
			{
				_currentMoodName = ThisMood.MoodName;
				OnPropertyChanged();
			}
		}

		public MainPageVM()
		{
			ThisMood = new Mood();
			ThisInfluence = new Influence();
			ThisNote = new Note();
			ThisDay = new Day();
			//ThisDay.User = ThisUser;    //Kan jeg undgå at have HELE objektet og nøjes med ID??
			ThisDay.Date = DateTime.Now;
		}

		public Mood goodMood = new Mood
		{
			MoodID = 1,
			MoodName = "Good"
		};
		public Mood okMood = new Mood
		{
			MoodID = 2,
			MoodName = "Ok"
		};
		public Mood badMood = new Mood
		{
			MoodID = 3,
			MoodName = "Bad"
		};

		//private string moodName = ThisDay.Mood.MoodName;

		//public event PropertyChangedEventHandler PropertyChanged;

		//private void OnPropertyChanged([CallerMemberName] string propertyname = null)
		//{
		//    if (PropertyChanged != null)
		//        PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
		//}
	}
}
