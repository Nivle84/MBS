using MBStest01.Models;
using SplashScreenTest02.Models;
using SplashScreenTest02.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplashScreenTest02.ViewModels
{
	public class MyStreamInfluencesViewModel : BaseViewModel
	{
		//public string TestText { get; set; }
		//public string YANTestText { get; set; }
		public string PositiveInfluence { get; set; }
		public string NegativeInfluence { get; set; }
		private ObservableCollection<Influence> GreatestInfluences { get; set; }
		private List<Influence> Influences = new List<Influence>();
		private ObservableCollection<GraphDay> GraphDays = new ObservableCollection<GraphDay>();
		private DataFiller MyFiller = new DataFiller();
		private static Dictionary<int, int> GoodInfluenceDictionary = new Dictionary<int, int>()
		{
			{1, 0},
			{2, 0},
			{3, 0},
			{4, 0},
			{5, 0},
			{6, 0},
			{7, 0},
			{8, 0},
			{9, 0},
			{10, 0},
			{11, 0},
			{12, 0}
		};

		private static Dictionary<int, int> BadInfluenceDictionary = new Dictionary<int, int>()
		{
			{1, 0},
			{2, 0},
			{3, 0},
			{4, 0},
			{5, 0},
			{6, 0},
			{7, 0},
			{8, 0},
			{9, 0},
			{10, 0},
			{11, 0},
			{12, 0}
		};

		public MyStreamInfluencesViewModel(ObservableCollection<GraphDay> graphDays)
		{
			GraphDays = graphDays;
			GreatestInfluences = new ObservableCollection<Influence>();
			Influences = MyFiller.GetInfluences();//Newtonsoft.Json.JsonConvert.DeserializeObject<List<Influence>>(Xamarin.Essentials.Preferences.Get(Constants.StoredInfluences, null));
			AnalyseDays();
			PositiveInfluence = GreatestInfluences[0].InfluenceName;
			NegativeInfluence = GreatestInfluences[1].InfluenceName;
		}

		public async void AnalyseDays()
		{
			var groupDaysByMood = GraphDays //Inddeler i tre grupper, med en key-værdi for hver gruppe værende MoodID
				.GroupBy(d => d.MoodID)     //(altså én gruppe med alle objekter med MoodID 1, én gruppe med alle objekter med MoodID 2, osv.)
				.OrderBy(k => k.Key)
				.ToList();

			foreach (var moodGroup in groupDaysByMood)	//Løber gennem hver gruppe skabt ovenover
			{
				foreach (var day in moodGroup)			//Løber gennem hver objekt i hver gruppe
				{
					AddInfluenceToDictionary(day.InfluenceID, moodGroup.Key);	//Forekomster af Influences i hver gruppe tælles og tilføjes til en dictionary.
				}
			}

			Influence GreatestPositiveInfluence = FindGreatestInfluences(GoodInfluenceDictionary);
			Influence GreatestNegativeInfluence = FindGreatestInfluences(BadInfluenceDictionary);

			GreatestInfluences = new ObservableCollection<Influence>()
			{
				GreatestPositiveInfluence,
				GreatestNegativeInfluence
			};
		}

		public void AddInfluenceToDictionary(int influenceIDToAdd, int moodID)
		{
			int counter = 0;
			switch (moodID)	//En case per gruppe
			{
				case 1:
					GoodInfluenceDictionary.TryGetValue(influenceIDToAdd, out counter);	//Output'er value'en associeret med key'en for det pågældende InfluenceID til counter variablen.
					GoodInfluenceDictionary[influenceIDToAdd] = ++counter;				//Forøger værdien med 1 og indsætter den på den samme plads i dictionary'en.
					break;
				case 3:
					BadInfluenceDictionary.TryGetValue(influenceIDToAdd, out counter);
					BadInfluenceDictionary[influenceIDToAdd] = ++counter;
					break;
				default:
					break;
			}
		}

		private Influence FindGreatestInfluences(Dictionary<int, int> influenceDictionary)
		{																		//hvis largest er størst ? behold largest : ellers set value til next, vælg key tilhørende value
			int thisInfluenceID = influenceDictionary.Aggregate((largest, next) => largest.Value > next.Value ? largest : next).Key;	//Løber gennem dictionary'en og sammenligner værdierne. Key'en associeret med den højeste værdi udvælges.
			Influence greatestInfluence = Influences.Where(i => i.InfluenceID == thisInfluenceID).FirstOrDefault();	//Influence'en med ID'et fundet ovenover udvælges og returneres.
			return greatestInfluence;
		}
	}
}
