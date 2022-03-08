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
		public MyStreamInfluencesViewModel(ObservableCollection<Influence> greatestInfluences)
		{
			TestText = "Test tekst fra MyStreamInfluencesViewModel";
		}
	}
}
