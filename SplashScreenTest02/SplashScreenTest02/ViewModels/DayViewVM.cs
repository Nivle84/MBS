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

namespace MBStest03.ViewModels
{
	public class DayViewVM : BaseViewModel
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
				//if (ThisMood.MoodID != 0)
				//{
					//ThisDay.Mood = value;
					//ThisDay.MoodID = value.MoodID;
				//}
				OnPropertyChanged();
				//OnPropertyChanged("ThisDay");
			}
		}

		private Influence _influence;
		public Influence ThisInfluence
		{
			get { return _influence; }
			set
			{
				_influence = value;
				//if (value.InfluenceID != 0)
				//	ThisDay.Influence = value;
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
				//if (ThisNote.DayID != 0)
				//	ThisDay.Note = value;
				OnPropertyChanged();
				//OnPropertyChanged("ThisDay");
			}
		}

		//private string _shortDate;
		public string ShortDate 
		{
			get
			{
				//return _shortDate;
				//var date = DateTime.ParseExact(ThisDay.Date.ToString(), $"MM/dd/yy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString();
				var kultur = CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("da-DK");
				var date = ThisDay.Date.ToString("dddd dd/MM/yy", kultur).ToUpperInvariant();
				return date; //.ToString("dd/MM/yy");

				//return ThisDay.Date.ToShortDateString();
			}
			//set
			//{
			//	_shortDate = ThisDay.Date.ToShortDateString();
			//}
		}
		//private string _currentMoodName { get; set; }
		//public string currentMoodName
		//{
		//	get
		//	{
		//		return _currentMoodName;
		//	}
		//	set
		//	{
		//		_currentMoodName = ThisMood.MoodName;
		//		OnPropertyChanged();
		//	}
		//}
		//public Command goodMoodClickedCommand { get; }
		//public Command okMoodClickedCommand { get; }
		//public Command badMoodClickedCommand { get; }
		//public Command moodClickedCommand { get; }
		//public Command influenceClickedCommand { get; }
		public IEnumerable<Influence> influenceList { get; set; }
		public List<Mood> moodList { get; set; }
		DataFiller myFiller { get; set; }
		public int sequenceStep
		{
			//Sekvensen:
			//0		Ny-åbnet, ingenting valgt endnu
			//1		Mood valgt
			//2		Influence valgt
			//3		Klar til at gemme, evt er en note skrevet
			get { return sequenceStep; }
			set	{ sequenceStep = value; }
		}
		//public ObservableCollection<Influence> influenceCollection { get; set; }
		//public IEnumerable<Influence> influenceListToBind { get; set; }
		public DayViewVM()
		{
			ThisMood = new Mood();
			ThisInfluence = new Influence();
			ThisNote = new Note();
			ThisDay = new Day()
			{
				Date = DateTime.Now
			};
			ThisUser = new User()
			{
				UserID = Preferences.Get(Constants.StoredUserID, 0)
			};
			//ThisDay.User = ThisUser;    //Kan jeg undgå at have HELE objektet og nøjes med ID??
			//ThisDay.Date = DateTime.Now;
			//goodMoodClickedCommand = new Command(GoodMoodClicked);
			//okMoodClickedCommand = new Command(OkMoodClicked);
			//badMoodClickedCommand = new Command(BadMoodClicked);
			//moodClickedCommand = new Command(MoodClicked);
			//influenceClickedCommand = new Command(InfluenceClicked);

			myFiller = new DataFiller();
			influenceList = myFiller.GetInfluences();
			moodList = myFiller.GetMoods();

			//influenceListToBind = influenceList as IEnumerable<Influence>;


			//influenceCollection = new ObservableCollection<Influence>();	//Det her virker mærkeligt. Hvorfor først lave en liste for at putte ting i ObsColl??
			//foreach (var item in influenceList)
			//{
			//	influenceCollection.Add(item);
			//}
		}

		//public void MoodClicked(object obj)
		//{
		//	ThisMood = moodList.FirstOrDefault(m => m.MoodID.ToString() == obj.ToString()); //Kan åbenbart ikke sammenligne ints. Virker lidt fjollet med ToString(), men det virker ¯\_(ツ)_/¯
		//}

		//public void InfluenceClicked(object obj)
		//{
		//	//Command og metode formentlig overflødig grundet måden CollectionView.SelectedItem fungerer.
		//	//Kan måske bruges ifm at skulle holde styr på hvor i processen af at registere/ændre en dag man er.

		//	ThisInfluence = influenceList.Cast<Influence>().SingleOrDefault(i => i.InfluenceName == obj.ToString());
		//}
		//public void GoodMoodClicked(object obj)
		//{
		//	//var click = obj as ImageButton;
		//	//var cP = click.CommandParameter.ToString();
		//	var click = obj.ToString();

		//	ThisMood = moodList.Find(m => m.MoodName == "Good");
		//	//Hvordan gør jeg det her? Vil gerne associere de tre imagebuttons med deres respektive mood, som så kan udledes gennem obj parameteren, og føres igennem
		//	//en switch statement som så får udvalgt og sendt mood'et videre i det rigtige format. Eller som minimum sendt 1-3 med som tilsvarer de forskellige moods.
		//	//Kunne jo sagtens lave tre forskellige commands, men det virker lidt fjollet og overholder ikke DRY princippet.
		//}
		//public void OkMoodClicked(object obj)
		//{
		//	ThisMood = moodList.Find(m => m.MoodName == "Ok");
		//}
		//public void BadMoodClicked(object obj)
		//{
		//	ThisMood = moodList.Find(m => m.MoodName == "Bad");
		//}

		//private string moodName = ThisDay.Mood.MoodName;

		//public event PropertyChangedEventHandler PropertyChanged;

		//private void OnPropertyChanged([CallerMemberName] string propertyname = null)
		//{
		//    if (PropertyChanged != null)
		//        PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
		//}
	}
}
