using MBStest01.Models;
using SplashScreenTest02.Models;
using SplashScreenTest02.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SplashScreenTest02.ViewModels
{
	//https://entityframework.net/knowledge-base/6730974/select-most-frequent-value-using-linq
	public class MyStreamViewModel : BaseViewModel
	{
		public MyStreamGraphViewModel MsGraphVM { get; set; }
		public MyStreamInfluencesViewModel MsInfVM { get; set; }
		public ObservableCollection<GraphDay> GraphDays = new ObservableCollection<GraphDay>();
		//private ObservableCollection<Influence> GreatestInfluences { get; set; }
		//private List<Influence> Influences = new List<Influence>();
		//private static Dictionary<int, int> GoodInfluenceDictionary = new Dictionary<int, int>()
		//{
		//	{1, 0},
		//	{2, 0},
		//	{3, 0},
		//	{4, 0},
		//	{5, 0},
		//	{6, 0},
		//	{7, 0},
		//	{8, 0},
		//	{9, 0},
		//	{10, 0},
		//	{11, 0},
		//	{12, 0}
		//};

		//private static Dictionary<int, int> BadInfluenceDictionary = new Dictionary<int, int>()
		//{
		//	{1, 0},
		//	{2, 0},
		//	{3, 0},
		//	{4, 0},
		//	{5, 0},
		//	{6, 0},
		//	{7, 0},
		//	{8, 0},
		//	{9, 0},
		//	{10, 0},
		//	{11, 0},
		//	{12, 0}
		//};
		private DataFiller MyFiller { get; set; }
		public MyStreamViewModel()
		{
			Debug.WriteLine("MyStreamViewModel() ctor.");
			MyFiller = new DataFiller();
			//GreatestInfluences = new ObservableCollection<Influence>();
			//Influences = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Influence>>(Xamarin.Essentials.Preferences.Get(Constants.StoredInfluences, null));
			//{
			//	new Influence()
			//	{
			//		InfluenceID = 1,
			//		InfluenceName = "Family"
			//	},
			//	new Influence()
			//	{
			//		InfluenceID = 3,
			//		InfluenceName = "Friends"
			//	}
			//};

			#region GraphDays test data
			/*
			{
				new GraphDay()
				{
					Date = DateTime.Now,
					InfluenceID = 1,
					MoodID = 1
				},
				new GraphDay()
				{
					Date = new DateTime(2022, 03, 08),
					InfluenceID = 2,
					MoodID = 1
				},
				new GraphDay()
				{
					Date = new DateTime(2022, 03, 07),
					InfluenceID = 6,
					MoodID = 3
				},
				new GraphDay()
				{
					Date = new DateTime(2022, 03, 06),
					InfluenceID = 9,
					MoodID = 2
				},
				new GraphDay()
				{
					Date = new DateTime(2022, 03, 03),
					InfluenceID = 4,
					MoodID = 1
				},
				new GraphDay()
				{
					Date = new DateTime(2022, 03, 01),
					InfluenceID = 4,
					MoodID = 3
				},
				new GraphDay()
				{
					Date = new DateTime(2022, 02, 27),
					InfluenceID = 11,
					MoodID = 1
				}
			};
			*/
			#endregion
			Task GetGraphDaysTask = Task.Run(async () => GraphDays = await MyFiller.FillGraphDays());
			GetGraphDaysTask.Wait();
			//AnalyseDays();

			MsGraphVM = new MyStreamGraphViewModel(GraphDays);
			MsInfVM = new MyStreamInfluencesViewModel(GraphDays);
		}

		//Skab to lister af gode og dårlige dage
		//Tæl hver Influence, tilføj de to Influence objekter til ObsColl
		//public async void AnalyseDays()
		//{
		//	//GraphDaysTestList = new List<GraphDay>();
		//	Task GetGraphDaysTask = Task.Run(async () => GraphDays = await MyFiller.FillGraphDays());
		//	GetGraphDaysTask.Wait();

		//	var groupDaysByMood = GraphDays //Inddeler i tre grupper, med en key-værdi for hver gruppe værende MoodID
		//		.GroupBy(d => d.MoodID)     //(altså én gruppe med alle objekter med MoodID 1, én gruppe med alle objekter med MoodID 2, osv.)
		//		.OrderBy(k => k.Key)
		//		.ToList();

		//	foreach (var moodGroup in groupDaysByMood)
		//	{
		//		foreach (var day in moodGroup)
		//		{
		//			AddInfluenceToDictionary(day.InfluenceID, moodGroup.Key);
		//		}
		//	}

		//	Influence GreatestPositiveInfluence = FindGreatestInfluences(GoodInfluenceDictionary);
		//	Influence GreatestNegativeInfluence = FindGreatestInfluences(BadInfluenceDictionary);

		//	GreatestInfluences = new ObservableCollection<Influence>()
		//	{
		//		GreatestPositiveInfluence,
		//		GreatestNegativeInfluence
		//	};
		//}

		//public void AddInfluenceToDictionary(int influenceIDToAdd, int moodID)
		//{
		//	int counter = 0;
		//	switch (moodID)
		//	{
		//		case 1:
		//			GoodInfluenceDictionary.TryGetValue(influenceIDToAdd, out counter);
		//			GoodInfluenceDictionary[influenceIDToAdd] = ++counter;
		//			break;
		//		case 3:
		//			BadInfluenceDictionary.TryGetValue(influenceIDToAdd, out counter);
		//			BadInfluenceDictionary[influenceIDToAdd] = ++counter;
		//			break;
		//		default:
		//			break;
		//	}
		//}

		//private Influence FindGreatestInfluences(Dictionary<int, int> influenceDictionary)
		//{
		//	int thisInfluenceID = influenceDictionary.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
		//	Influence greatestInfluence = Influences.Where(i => i.InfluenceID == thisInfluenceID).FirstOrDefault();
		//	return greatestInfluence;
		//}
	}
}
