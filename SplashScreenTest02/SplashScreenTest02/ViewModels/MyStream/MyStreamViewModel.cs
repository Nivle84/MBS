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
		private DataFiller MyFiller { get; set; }
		public MyStreamViewModel()
		{
			Debug.WriteLine("MyStreamViewModel() ctor.");
			MyFiller = new DataFiller();

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

					//TODO TODO TODO TODO
					//Lav standard constructors så view'et i det mindste ikke crasher ved ingen GraphDays
			MsGraphVM = new MyStreamGraphViewModel(GraphDays);
			MsInfVM = new MyStreamInfluencesViewModel(GraphDays);
		}
	}
}
