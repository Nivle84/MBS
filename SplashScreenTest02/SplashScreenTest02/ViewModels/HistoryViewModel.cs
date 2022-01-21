using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SplashScreenTest02.ViewModels
{
	public class HistoryViewModel : BaseViewModel
	{
		public Command GoToMyStreamCommand{ get; }

		public HistoryViewModel()
		{
			GoToMyStreamCommand = new Command(GoToMyStream);
		}

		public async void GoToMyStream(object obj)
		{
			await Shell.Current.GoToAsync("///MyStreamPage");
		}
	}
}
