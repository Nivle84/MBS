using MBStest01.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SplashScreenTest02.ViewModels
{
	public class MyStreamInfluencesViewModel : BaseViewModel
	{
		public string TestText { get; set; }
		public string YANTestText { get; set; }
		public MyStreamInfluencesViewModel(ObservableCollection<Influence> greatestInfluences)
		{
			ObservableCollection<Influence> testInfluences = greatestInfluences;
			YANTestText = testInfluences[0].InfluenceName;
			TestText = "Test tekst fra MyStreamInfluencesViewModel";
		}
	}
}
