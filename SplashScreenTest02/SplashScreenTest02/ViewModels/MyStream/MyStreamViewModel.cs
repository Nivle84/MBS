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
		public List<GraphDay> GraphDaysTestList { get; set; }
		public ObservableCollection<Influence> GreatestInfluences { get; set; }
		public Influence GoodInfluence { get; set; }
		public Influence BadInfluence { get; set; }
		public DataFiller MyFiller { get; set; }
		public static string WhoIsThere([CallerMemberName] string memberName = "")
		{
			return memberName;
		}
		public MyStreamViewModel()
		{
			//var whoDat = WhoIsThere();
			//Debug.WriteLine("MyStreamViewModel() ctor called from: " + this.ToString() + whoDat);
			Debug.WriteLine("MyStreamViewModel() ctor.");
			//apiHelper = new ApiHelper();
			MyFiller = new DataFiller();
			//GraphDays = new ObservableCollection<GraphDay>();
			GreatestInfluences = new ObservableCollection<Influence>()//;
			{
				new Influence()
				{
					InfluenceID = 1,
					InfluenceName = "Family"
				},
				new Influence()
				{
					InfluenceID = 3,
					InfluenceName = "Friends"
				}
			};

			//GraphDays = new ObservableCollection<GraphDay>();
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
			//bool getDaysSucces;
			AnalyseDays();      //TODO - Der er et eller andet helt galt her. Den henter ikke noget.

			//for (int i = 1; i < 3; i++)
			//{
			//	GraphDays.Add(
			//		new GraphDay
			//		{
			//			Date = new DateTime(2022, 3, i),
			//			InfluenceID = i,
			//			MoodID = i,
			//		});
			//}

			MsGraphVM = new MyStreamGraphViewModel(GraphDays);
			MsInfVM = new MyStreamInfluencesViewModel(GreatestInfluences);

		}

		//Skab to lister af gode og dårlige dage
		//Tæl hver Influence, tilføj de to Influence objekter til ObsColl
		public async void AnalyseDays()
		{
			//GraphDaysTestList = new List<GraphDay>();
			Task GetGraphDaysTask = Task.Run(async () => GraphDays = await MyFiller.FillGraphDays());
			GetGraphDaysTask.Wait();

			//GraphDaysTestList = await MyFiller.FillGraphDays();
			//GraphDays = new ObservableCollection<GraphDay>();
			//GraphDays = await MyFiller.FillGraphDays();
			//DetermineGreatestInfluences();

			//if (GraphDaysTestList.Count > 0)
			//	return true;
			//else
			//	return false;

		}

		public async void DetermineGreatestInfluences()
		{
			//https://mtaulty.com/2007/09/28/m_9836/

			var queryGoodDays = GraphDays
				.GroupBy(d => d.MoodID)
				.Where(m => m.Key == 1)	//Find alle elementer fra GraphDays hvor MoodID = 1 (alle good days)
				.ToList();

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
