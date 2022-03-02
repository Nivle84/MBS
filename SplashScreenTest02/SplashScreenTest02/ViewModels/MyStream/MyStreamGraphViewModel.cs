using MBStest01.Models;
using SplashScreenTest02.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SplashScreenTest02.ViewModels
{
	public class MyStreamGraphViewModel : BaseViewModel
	{
		public Label LabelTest { get; set; }
		public MyStreamGraphViewModel(ObservableCollection<GraphDay> graphDaysCollection)
		{
			LabelTest.Text = "Test tekst fra MyStreamGraphViewModel"; 
		}
		public MyStreamGraphViewModel()
		{
			LabelTest.Text = "Test tekst fra MyStreamGraphViewModel";
		}
	}
}