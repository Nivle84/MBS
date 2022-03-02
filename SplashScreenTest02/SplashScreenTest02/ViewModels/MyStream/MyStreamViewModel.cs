using MBStest01.Models;
using SplashScreenTest02.Models;
using SplashScreenTest02.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using System.Linq;

namespace SplashScreenTest02.ViewModels
{
	//https://entityframework.net/knowledge-base/6730974/select-most-frequent-value-using-linq
	internal class MyStreamViewModel : BaseViewModel
	{
		public MyStreamGraphViewModel MsGraphVM { get; set; }
		public MyStreamInfluencesViewModel MsInfVM { get; set; }
		public ObservableCollection<GraphDay> GraphDays { get; set; }
		public ObservableCollection<Influence> GreatestInfluences { get; set; }
		public Influence GoodInfluence { get; set; }
		public Influence BadInfluence { get; set; }
		public DataFiller MyFiller { get; set; }
		public MyStreamViewModel()
		{
			//apiHelper = new ApiHelper();
			MyFiller = new DataFiller();
			AnalyseDays();
			MsGraphVM = new MyStreamGraphViewModel(GraphDays);
			MsInfVM = new MyStreamInfluencesViewModel(GreatestInfluences);

		}

		//Skab to lister af gode og dårlige dage
		//Tæl hver Influence, tilføj de to Influence objekter til ObsColl
		public async void AnalyseDays()
		{
			GraphDays = await MyFiller.FillGraphDays();
			DetermineGreatestInfluences();
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

			var queryGoodInfluence = queryGoodDays
				//.GroupBy(i => i.Key)
				.OrderBy(m => m.Key)
				.Select()

			var query = GraphDays
				.GroupBy(x => x.InfluenceID)
				.Where(g => g.Count() > 1)
				.Select(y => y.Key)
				.ToList();
		}
	}
}
