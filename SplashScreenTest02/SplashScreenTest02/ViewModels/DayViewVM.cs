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
				//ThisDay.User = ThisUser;
			}
		}

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
				var kultur = CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("da-DK");
				var date = ThisDay.Date.ToString("dddd dd/MM/yy", kultur).ToUpperInvariant();
				return date;
			}
		}
		//public Command goodMoodClickedCommand { get; }
		//public Command okMoodClickedCommand { get; }
		//public Command badMoodClickedCommand { get; }
		//public Command moodClickedCommand { get; }
		//public Command influenceClickedCommand { get; }
		public Command SaveThisDayCommand { get; }
		public IEnumerable<Influence> influenceList { get; set; }
		public List<Mood> moodList { get; set; }
		DataFiller myFiller { get; set; }
		public ApiHelper apiHelper { get; }
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
		public Image moodImagePath(Mood mood)
		{
			string imagePath = "mood" + $"{mood.MoodName}".ToLower() + ".png";

			var image = new Image
			{
				Source = ImageSource.FromFile(imagePath)
			};

			return image;
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
				Date = DateTime.Now.Date
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
			//SaveThisDayCommand = new Command(SaveThisDay);

			myFiller = new DataFiller();
			influenceList = myFiller.GetInfluences();
			moodList = myFiller.GetMoods();
			apiHelper = new ApiHelper();
		}

		public bool DayHasBeenSaved = false;

        internal async void SaveThisDay()
        {
			ThisDay.UserID		= ThisUser.UserID;
			ThisDay.MoodID		= ThisMood.MoodID;
			ThisDay.InfluenceID = ThisInfluence.InfluenceID;
			if (ThisNote.NoteString != String.Empty)
			{
				ThisDay.HasNote = true;
				ThisDay.Note = ThisNote;
			}

			var response = await apiHelper.ApiPoster("days/", ThisDay);
			
			switch (response.StatusCode)
			{
				case 200:
					Toast.MakeText(Android.App.Application.Context, "Dag gemt!", ToastLength.Short).Show();
					//sequenceStep = 0;
					ThisDay = null;
					DayHasBeenSaved = true;
					break;
			}
			if (response == "Post ok!")
            {
				Toast.MakeText(Android.App.Application.Context, "Dag gemt!", ToastLength.Short).Show();
				//sequenceStep = 0;
				ThisDay = null;
				DayHasBeenSaved = true;
            }
			else
			{
				Toast.MakeText(Android.App.Application.Context, response.ToString(), ToastLength.Short).Show();
				DayHasBeenSaved = false;
			}
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
