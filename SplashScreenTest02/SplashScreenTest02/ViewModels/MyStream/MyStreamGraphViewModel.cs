using MBStest01.Models;
using SplashScreenTest02.Models;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace SplashScreenTest02.ViewModels
{
	public class MyStreamGraphViewModel : BaseViewModel
	{
		public ObservableCollection<ChartDataPoint> pointsForChart { get; set; }
		public MyStreamGraphViewModel(ObservableCollection<GraphDay> graphDaysCollection)
		{
			//Debug.WriteLine("Start of MyStreamGraphViewModel ctor.");
			//if (graphDaysCollection.Count > 0)
			//	Debug.WriteLine("Parameter graphDaysCollection.Count = " + graphDaysCollection.Count);

			pointsForChart = new ObservableCollection<ChartDataPoint>();
			CreateChartDataPoints(graphDaysCollection);
		}

		public void CreateChartDataPoints(ObservableCollection<GraphDay> dataPointsSource)
		{
			foreach (GraphDay graphDay in dataPointsSource)
			{
				Debug.WriteLine("CreateChartDataPoints GraphDay.Date: " + graphDay.Date.ToShortDateString());
				pointsForChart.Add(new ChartDataPoint(graphDay.Date, (double)graphDay.MoodID));
			}
		}
	}
}