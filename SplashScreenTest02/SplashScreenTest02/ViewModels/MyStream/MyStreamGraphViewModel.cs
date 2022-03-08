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
		public Label LabelTest { get; set; }
		public string YANlabelTest { get; set; }
		public ObservableCollection<GraphDay> daysForChart { get; set; }
		public ObservableCollection<ChartDataPoint> pointsForChart { get; set; }
		public SfChart daysChart = new SfChart();
		public ColumnSeries daysSeries { get; set; }
		//public ObservableCollection<chartmodel>
		public MyStreamGraphViewModel(ObservableCollection<GraphDay> graphDaysCollection)
		{
			Debug.WriteLine("Start of MyStreamGraphViewModel ctor.");
			Debug.WriteLine("Parameter graphDaysCollection.Count = " + graphDaysCollection.Count);
			CreateChartDataPoints(graphDaysCollection);

			daysForChart = graphDaysCollection;

			CategoryAxis primaryAxis = new CategoryAxis();
			primaryAxis.Title.Text = "Date";
			primaryAxis.Name = "Date";
			NumericalAxis secondaryAxis = new NumericalAxis();
			secondaryAxis.Title.Text = "Mood";

			//daysChart.PrimaryAxis = new CategoryAxis();
			//daysChart.SecondaryAxis = new NumericalAxis();

			daysChart.PrimaryAxis = primaryAxis;
			daysChart.SecondaryAxis = secondaryAxis;

			daysSeries = new ColumnSeries();
			//daysSeries.ItemsSource = pointsForChart;
			//daysChart.Series.Add(daysSeries);


			//daysForChart = graphDaysCollection;
			//LabelTest.Text = "Test tekst fra MyStreamGraphViewModel";
			YANlabelTest = "Test tekst fra MyStreamGraphViewModel";

		}

		public void CreateChartDataPoints(ObservableCollection<GraphDay> dataPointsSource)
		{
			foreach (GraphDay graphDay in dataPointsSource)
			{
				Debug.WriteLine("CreateChartDataPoints GraphDay.Date: " + graphDay.Date.ToShortDateString());
				pointsForChart.Add(new ChartDataPoint(graphDay.Date, graphDay.MoodID));
			}
		}
		//public MyStreamGraphViewModel()
		//{
		//	LabelTest.Text = "Test tekst fra MyStreamGraphViewModel";
		//}
	}
}