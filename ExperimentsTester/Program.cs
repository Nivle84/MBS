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
		//public ObservableCollection<GraphDay> GraphDays { get; set; }
		public static ObservableCollection<GraphDay> GraphDays { get; set; }// = new ObservableCollection<GraphDay>();
		public static List<GraphDay> TestList { get; set; }

		static void Main(string[] args)
		{
			//GraphDays = new ObservableCollection<GraphDay>();
			//AnalyseDays();
			GetThoseDamnGraphDays();
		}

		public static async Task<List<GraphDay>> GetThoseDamnGraphDays()
		{
			DataFiller anotherFiller = new DataFiller();
			List<GraphDay> newlist = new List<GraphDay>();

			Task testTask = Task.Run(async () => newlist = await anotherFiller.FillGraphDays());
			testTask.Wait();
			//newlist = await anotherFiller.FillGraphDays();
			return newlist;
		}

		public static async void AnalyseDays()
		{
			//https://mtaulty.com/2007/09/28/m_9836/
			//DataFiller fill = new DataFiller();

			//GraphDays = await fill.FillGraphDays();

			var json = "[{\"moodID\":2,\"influenceID\":8,\"date\":\"2022-03-02T00:00:00\"},{\"moodID\":1,\"influenceID\":8,\"date\":\"2022-02-16T00:00:00\"},{\"moodID\":2,\"influenceID\":8,\"date\":\"2022-02-16T00:00:00\"},{\"moodID\":3,\"influenceID\":3,\"date\":\"2022-02-01T00:00:00\"},{\"moodID\":1,\"influenceID\":1,\"date\":\"2022-01-27T00:00:00\"},{\"moodID\":3,\"influenceID\":7,\"date\":\"2022-01-25T00:00:00\"},{\"moodID\":2,\"influenceID\":6,\"date\":\"2022-01-21T09:19:12.4499\"}]";

			GraphDays = JsonConvert.DeserializeObject<ObservableCollection<GraphDay>>(json);

			var sortedDaysByMood = GraphDays
				.GroupBy(d => d.MoodID)
				.OrderBy(k => k.Key)
				//.Where(m => m.Key == 1 && m.Key == 3) //Find alle elementer fra GraphDays hvor MoodID = 1 (alle good days)
				.ToList();
			/*
			 * Det er noget med at køre dagene igennem to, måske flere løkker.
			 * Første løkke kører på elementer med key x (1, 2, 3).
			 * Anden løkke gennemgår disse elementer, tilføjer alle influenceID til et array.
			 * Dette array kan så gennemgås for hvilken værdi der opstår oftest.
			 */

			Influence BestInfluence = new Influence();
			Influence WorstInfluence = new Influence();

			foreach (var moodKey in sortedDaysByMood)
			{
				//Console.WriteLine("Outer item keys are: " + moodKey.Key.ToString());

				foreach (var graphDay in moodKey)
				{

					Console.WriteLine("Day.MoodID is: " + graphDay.MoodID);
					Console.WriteLine("Day.InfluenceID is: " + graphDay.InfluenceID);
					Console.WriteLine("Day.Date is: " + graphDay.Date.ToShortDateString() + "\n");
				}
			}

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
