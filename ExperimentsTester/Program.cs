using MBStest01.Models;
using Newtonsoft.Json;
using SplashScreenTest02.Models;
using SplashScreenTest02.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ExperimentsTester
{
	public class Program
	{
		public static ObservableCollection<GraphDay> GraphDays { get; set; }// = new ObservableCollection<GraphDay>();
		//public static List<GraphDay> TestList { get; set; }
		public static DataFiller anotherFiller = new DataFiller();
		public static ApiHelper apiHelper = new ApiHelper();

		static void Main(string[] args)
		{
			//GraphDays = new ObservableCollection<GraphDay>();
			//var moods = anotherFiller.GetUsersDays();
			//var testDays = TestGet();
			//GetThoseDamnGraphDays();
			AnalyseDays();
			//Task createData = Task.Run(async () => await CreateDummyData(1, DateTime.Now));
			//CreateDummyData(1, DateTime.Now);
		}

		public static async Task<bool> CreateDummyData(int userID, DateTime startDate)
		{
			Random random = new Random();
			Note dummyNote = new Note() { NoteString = "DummyDay NoteString."};
			List<Day> dummyDayList = new List<Day>();
			DateTime dummyDate = startDate;

			for (int i = 0; i < 40; i++)
			{
				Day dummyDay = new Day() { UserID = userID};
				dummyDay.MoodID = random.Next(1, 4);
				dummyDay.InfluenceID = random.Next(1, 13);

				dummyDate = dummyDate.AddDays(1);
				dummyDay.Date = dummyDate;

				if (dummyDay.InfluenceID % 2 == 0)
				{
					dummyDay.HasNote = true;
					dummyDay.Note = dummyNote;
				}
				else
				{
					dummyDay.HasNote = false;
					dummyDay.Note = null;
				}
				dummyDayList.Add(dummyDay);
			}

			var json = JsonConvert.SerializeObject(dummyDayList, Formatting.None);
			Console.WriteLine(json);

			await apiHelper.ApiPoster("days/postmultiple", dummyDayList);
			return true;
		}

		public static async Task<string> TestGet()
		{
			return await apiHelper.GetDaysByUserID(1);
		}

		public static async Task<ObservableCollection<GraphDay>> GetThoseDamnGraphDays()
		{
			//List<GraphDay> newlist = new List<GraphDay>();
			//GraphDays = new ObservableCollection<GraphDay>();


			Task testTask = Task.Run(async () => GraphDays = await anotherFiller.FillGraphDays());
			testTask.Wait();
			//newlist = await anotherFiller.FillGraphDays();
			//return newlist;

			//GraphDays = await anotherFiller.FillGraphDays();

			return GraphDays;
		}

		public static async void AnalyseDays()
		{
			//https://mtaulty.com/2007/09/28/m_9836/
			//DataFiller fill = new DataFiller();

			//GraphDays = await fill.FillGraphDays();

			var json = "[{\"moodID\":2,\"influenceID\":8,\"date\":\"2022-04-24T10:50:13.1323132\"},{\"moodID\":1,\"influenceID\":2,\"date\":\"2022-04-23T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":8,\"date\":\"2022-04-22T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":4,\"date\":\"2022-04-21T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":10,\"date\":\"2022-04-20T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":9,\"date\":\"2022-04-19T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":8,\"date\":\"2022-04-18T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":10,\"date\":\"2022-04-17T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":2,\"date\":\"2022-04-16T10:50:13.1323132\"},{\"moodID\":1,\"influenceID\":6,\"date\":\"2022-04-15T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":2,\"date\":\"2022-04-14T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":7,\"date\":\"2022-04-13T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":11,\"date\":\"2022-04-12T10:50:13.1323132\"},{\"moodID\":2,\"influenceID\":3,\"date\":\"2022-04-11T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":10,\"date\":\"2022-04-10T10:50:13.1323132\"},{\"moodID\":1,\"influenceID\":12,\"date\":\"2022-04-09T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":7,\"date\":\"2022-04-08T10:50:13.1323132\"},{\"moodID\":1,\"influenceID\":6,\"date\":\"2022-04-07T10:50:13.1323132\"},{\"moodID\":1,\"influenceID\":10,\"date\":\"2022-04-06T10:50:13.1323132\"},{\"moodID\":1,\"influenceID\":6,\"date\":\"2022-04-05T10:50:13.1323132\"},{\"moodID\":1,\"influenceID\":3,\"date\":\"2022-04-04T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":1,\"date\":\"2022-04-03T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":10,\"date\":\"2022-04-02T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":2,\"date\":\"2022-04-01T10:50:13.1323132\"},{\"moodID\":2,\"influenceID\":2,\"date\":\"2022-03-31T10:50:13.1323132\"},{\"moodID\":1,\"influenceID\":9,\"date\":\"2022-03-30T10:50:13.1323132\"},{\"moodID\":1,\"influenceID\":11,\"date\":\"2022-03-29T10:50:13.1323132\"},{\"moodID\":1,\"influenceID\":6,\"date\":\"2022-03-28T10:50:13.1323132\"},{\"moodID\":3,\"influenceID\":8,\"date\":\"2022-03-27T10:50:13.1323132\"},{\"moodID\":1,\"influenceID\":5,\"date\":\"2022-03-26T10:50:13.1323132\"}]"

			//GraphDays = JsonConvert.DeserializeObject<ObservableCollection<GraphDay>>(json);

			var groupDaysByMood = GraphDays	//Inddeler i tre grupper, med en key-værdi for hver gruppe værende MoodID
				.GroupBy(d => d.MoodID)     //(altså én gruppe med alle objekter med MoodID 1, én gruppe med alle objekter med MoodID 2, osv.)
				.OrderBy(k => k.Key)
				.ToList();

			//var altGroupDaysByMood = GraphDays
			//	.GroupBy(d => d.MoodID)
			//	.OrderBy(k => k.Key)
			//	//.OrderBy(grp => grp.Key)
			//	.ThenBy(d => d.Count(i => i.InfluenceID).Select(i => i.InfluenceID).Count())
			//	.ToList();
				//.Select(grp => grp.Where(k => k.MoodID == 1)
				//.Select(grp => grp.Select(grp.InfluenceID => grp.c)
				//.OrderBy(d => d.)
				//.ThenBy(grp => grp.Key)
				//.Select(grp => grp.Key)
				//.First();
			/*
			 * Det er noget med at køre dagene igennem to, måske flere løkker.
			 * Første løkke kører på elementer med key x (1, 2, 3).
			 * Anden løkke gennemgår disse elementer, tilføjer alle influenceID til et array.
			 * Dette array kan så gennemgås for hvilken værdi der opstår oftest.
			 */

			Influence BestInfluence = new Influence();
			Influence WorstInfluence = new Influence();
			int[] goodInfluences = new int[groupDaysByMood[0].Count()];
			int[] badInfluences = new int[groupDaysByMood[2].Count()];

			//var testInfluences = groupDaysByMood.Select(group => group.Select(d => d.InfluenceID)).ToArray();	//Giver ikke noget brugbart.
			var testInfluences = groupDaysByMood.Select(group => group.Select(d => d.InfluenceID)).ToList();

			foreach (var grpKey in groupDaysByMood
								   .GroupBy(grp => grp
								   .Select(gDay => gDay.InfluenceID)))
			{
				Console.WriteLine();
			}

			//foreach (var grp in GraphDays
			//					.GroupBy(d => d.MoodID)
			//					.OrderBy(g => g.Key)
			//					.Select(k => k.Select(i => i.InfluenceID))
			//					.OrderBy(x => x.Count())
			//					.First())
			//{
			//	Console.WriteLine(grp.ToString());
			//}

			var testSort = GraphDays
							.GroupBy(d => d.MoodID)
							.OrderBy(g => g.Key)
							.GroupBy(k => k.Select(d => d.InfluenceID))
							//.Select(k => k.Select(i => i.InfluenceID))
							.OrderBy(x => x.Count())
							.First();

			var testAgain = GraphDays
				.GroupBy(d => d.MoodID)
				.OrderBy(g => g.Key)
				.ThenBy(k => k.Select(gDay => gDay.InfluenceID).Count())
				.ToList();

			var dicTest = GraphDays
				.GroupBy(d => d.MoodID)
				.OrderBy(g => g.Key)
				.ToLookup(x => x.Select(x => x.InfluenceID));
				//.ToDictionary(d => d.Key, d => d.Select(x => x.InfluenceID).Count());

			List<GraphDay> goodGraphDays = new List<GraphDay>();
			ObservableCollection<Influence> mostOccuringInfluences = new ObservableCollection<Influence>();
			List<GraphDay> badGraphDays = new List<GraphDay>();
			int count = 0;

			foreach (var keyGroup in groupDaysByMood)	//Denne fremgangsmåde fungerer (!), men virker lidt grim og klodset.
			{											//Tænker at der er en hurtigere, smartere måde at gøre det på med LINQ.
				foreach (var gDay in keyGroup)
				{
					switch (keyGroup.Key)
					{
						case 1:
							//goodGraphDays.Add(gDay);
							goodInfluences.SetValue(gDay.InfluenceID, count++);
							goodGraphDays.Add(gDay);
							break;
						case 3:
							badInfluences.SetValue(gDay.InfluenceID, count++);
							badGraphDays.Add(gDay);
							break;
						default:
							break;
					}
				}
				count = 0;
			}

			//goodGraphDays.

			foreach (var item in goodGraphDays)
			{

			}

			//var infGoodMood = (from d in testInfluences
			//				   group d by d into grp
			//				   orderby grp.Count() descending
			//				   select grp.Key).First();
			//IEnumerable<int>[] selectInfluencesTest;

			//Console.WriteLine(testInfluences[0].Select(d => d.);

			//for (int i = 0; i <= 12; i++)
			//{
			//	selectInfluencesTest = testInfluences.Where(m => m.Contains(i)).ToArray();
			//}

			//IGrouping<System.Reflection.MemberTypes, System.Reflection.MemberInfo> group =
			//	typeof(String)
			//	.GetMembers()
			//	.GroupBy(member => member.MemberType)
			//	.First();


			//foreach (System.Reflection.MemberInfo moodKey in sortedDaysByMood)
			//{
			//	//Console.WriteLine("Outer item keys are: " + moodKey.Key.ToString());

			//	foreach (var graphDay in moodKey)
			//	{

			//		Console.WriteLine("Day.MoodID is: " + graphDay.MoodID);
			//		Console.WriteLine("Day.InfluenceID is: " + graphDay.InfluenceID);
			//		Console.WriteLine("Day.Date is: " + graphDay.Date.ToShortDateString() + "\n");
			//	}
			//}

			//for (int i = 0; i < sortedDaysByMood.Count; i++)
			//{
			//	Console.WriteLine(sortedDaysByMood.ElementAt(i).ToString());
			//}

			var queryBadDays = GraphDays
				.GroupBy(d => d.MoodID)
				.Where(m => m.Key == 3)
				.ToList();

			//Influence queryGoodInfluence = queryGoodDays
			//	.Select(i => i.Key == 1)
			//	//.GroupBy(i => i.Key)
			//	.OrderBy(m => m.Key)
			//	.Select()



			var query = GraphDays
				.GroupBy(x => x.InfluenceID)
				.Where(g => g.Count() > 1)
				.Select(y => y.Key)
				.ToList();
		}
	}
}
