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
			//GraphDayDummyData();

			//TODO TODO TODO TODO
			//Lav standard constructors så view'et i det mindste ikke crasher ved ingen GraphDays
			MsGraphVM = new MyStreamGraphViewModel(GraphDays);
			MsInfVM = new MyStreamInfluencesViewModel(GraphDays);
		}

		private void GraphDayDummyData()
		{
			string jsonDummyData = "[{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":10,\"Influence\":null,\"Date\":\"2022-02-03T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":3,\"Influence\":null,\"Date\":\"2022-02-04T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":9,\"Influence\":null,\"Date\":\"2022-02-05T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":1,\"Influence\":null,\"Date\":\"2022-02-06T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":12,\"Influence\":null,\"Date\":\"2022-02-07T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":6,\"Influence\":null,\"Date\":\"2022-02-08T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":1,\"Influence\":null,\"Date\":\"2022-02-09T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":2,\"Influence\":null,\"Date\":\"2022-02-10T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":8,\"Influence\":null,\"Date\":\"2022-02-11T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":8,\"Influence\":null,\"Date\":\"2022-02-12T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":5,\"Influence\":null,\"Date\":\"2022-02-13T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":9,\"Influence\":null,\"Date\":\"2022-02-14T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":2,\"Influence\":null,\"Date\":\"2022-02-15T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":2,\"Influence\":null,\"Date\":\"2022-02-16T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":10,\"Influence\":null,\"Date\":\"2022-02-17T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":11,\"Influence\":null,\"Date\":\"2022-02-18T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":5,\"Influence\":null,\"Date\":\"2022-02-19T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":11,\"Influence\":null,\"Date\":\"2022-02-20T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":2,\"Influence\":null,\"Date\":\"2022-02-21T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":1,\"Influence\":null,\"Date\":\"2022-02-22T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":9,\"Influence\":null,\"Date\":\"2022-02-23T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":5,\"Influence\":null,\"Date\":\"2022-02-24T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":4,\"Influence\":null,\"Date\":\"2022-02-25T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":6,\"Influence\":null,\"Date\":\"2022-02-26T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":4,\"Influence\":null,\"Date\":\"2022-02-27T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":9,\"Influence\":null,\"Date\":\"2022-02-28T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":5,\"Influence\":null,\"Date\":\"2022-03-01T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":10,\"Influence\":null,\"Date\":\"2022-03-02T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":7,\"Influence\":null,\"Date\":\"2022-03-03T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":1,\"Influence\":null,\"Date\":\"2022-03-04T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":9,\"Influence\":null,\"Date\":\"2022-03-05T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":11,\"Influence\":null,\"Date\":\"2022-03-06T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":7,\"Influence\":null,\"Date\":\"2022-03-07T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":6,\"Influence\":null,\"Date\":\"2022-03-08T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":11,\"Influence\":null,\"Date\":\"2022-03-09T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":1,\"Influence\":null,\"Date\":\"2022-03-10T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":5,\"Influence\":null,\"Date\":\"2022-03-11T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":7,\"Influence\":null,\"Date\":\"2022-03-12T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":12,\"Influence\":null,\"Date\":\"2022-03-13T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":2,\"Influence\":null,\"Date\":\"2022-03-14T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":3,\"Influence\":null,\"Date\":\"2022-03-15T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":5,\"Influence\":null,\"Date\":\"2022-03-16T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":5,\"Influence\":null,\"Date\":\"2022-03-17T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":1,\"Influence\":null,\"Date\":\"2022-03-18T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":7,\"Influence\":null,\"Date\":\"2022-03-19T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":11,\"Influence\":null,\"Date\":\"2022-03-20T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":8,\"Influence\":null,\"Date\":\"2022-03-21T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":2,\"Influence\":null,\"Date\":\"2022-03-22T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":12,\"Influence\":null,\"Date\":\"2022-03-23T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":3,\"Influence\":null,\"Date\":\"2022-03-24T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":6,\"Influence\":null,\"Date\":\"2022-03-25T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":3,\"Influence\":null,\"Date\":\"2022-03-26T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":7,\"Influence\":null,\"Date\":\"2022-03-27T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":3,\"Influence\":null,\"Date\":\"2022-03-28T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":11,\"Influence\":null,\"Date\":\"2022-03-29T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":1,\"Mood\":null,\"InfluenceID\":5,\"Influence\":null,\"Date\":\"2022-03-30T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":8,\"Influence\":null,\"Date\":\"2022-03-31T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":3,\"Mood\":null,\"InfluenceID\":11,\"Influence\":null,\"Date\":\"2022-04-01T00:00:00\",\"HasNote\":false,\"Note\":null},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":12,\"Influence\":null,\"Date\":\"2022-04-02T00:00:00\",\"HasNote\":true,\"Note\":{\"DayID\":0,\"NoteString\":\"DummyDay NoteString.\"}},{\"DayID\":0,\"UserID\":1,\"User\":null,\"MoodID\":2,\"Mood\":null,\"InfluenceID\":7,\"Influence\":null,\"Date\":\"2022-04-03T00:00:00\",\"HasNote\":false,\"Note\":null}]";

			GraphDays = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<GraphDay>>(jsonDummyData);
		}
	}
}
