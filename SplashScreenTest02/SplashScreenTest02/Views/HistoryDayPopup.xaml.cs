using MBStest01.Models;
using MBStest03.ViewModels;
using SplashScreenTest02.Services;
using SplashScreenTest02.ViewModels;
using System;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SplashScreenTest02.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryDayPopup : Rg.Plugins.Popup.Pages.PopupPage
	{
		public DayViewVM dayViewVM;
		public HistoryViewModel historyVM { get; set; }
		public DayView popupDayView { get; set; }
		public Day selectedDay { get; set; }
		public Command DeleteDayCommand { get; set; }
		public Day EditedDay { get; set; }
		public Day DeletedDay { get; set; }

		public HistoryDayPopup(Day dayFromHistoryPage, HistoryViewModel hpVM)
		{
			Debug.WriteLine("HistoryDayPopup constructor called.");
			selectedDay = dayFromHistoryPage;
			dayViewVM = new DayViewVM(selectedDay);
			historyVM = hpVM;
			popupDayView = new DayView(dayViewVM);

			DeleteDayCommand = new Command(DeleteDay);
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			//Det her blev godt nok en snørklet og grim implementering... -_-
			//Men fordi jeg ikke var mere forudseende må det være fyldestgørende.
			//Og det er vist ikke sådan helt rigtig tilladt ifm MVVM, men jeg synes godt
			//at kunne forsvare det da det trods alt er relateret til view'et...
			try
			{
				//Den dag som er blevet redigeret og set'et i DayViewVM hentes.
				var jsonEditedDay = Xamarin.Essentials.Preferences.Get(Constants.EditedDay, null);
				if (jsonEditedDay != null)
					EditedDay = Newtonsoft.Json.JsonConvert.DeserializeObject<Day>(jsonEditedDay);
				//Det samme gør sig gældende for ID'et af dagen som (potentielt) er blevet slettet.

				var jsonDeletedDay = Xamarin.Essentials.Preferences.Get(Constants.DeletedDay, null);
				if (jsonDeletedDay != null)
					DeletedDay = Newtonsoft.Json.JsonConvert.DeserializeObject<Day>(jsonDeletedDay);

				//Hvis dagen som er blevet åbnet i popup'en er den samme som den dag der er blevet slettet, fjernes den fra historiklisten
				if (DeletedDay != null && selectedDay.DayID == DeletedDay.DayID)
				{
					//deletedDay = historyVM.DaysSource.Find(d => d.DayID == deletedDay.DayID);
					int dayIndex = historyVM.DaysSource.IndexOf(selectedDay);
					historyVM.DaysSource.Remove(selectedDay);
				}
				//Hvis der er blevet gemt en redigeret dag i Preferences, og den dag som er blevet åbnet i popup'en har det samme ID som den dag der er blevet redigeret,
				//erstattes den givne dag i listen.
				else if (EditedDay != null && selectedDay.DayID == EditedDay.DayID)
				{
					//int dayIndex = historyVM.DaysSource.FindIndex(d => d.DayID == editedDay.DayID);
					int dayIndex = historyVM.DaysSource.IndexOf(selectedDay);

					if (dayIndex != -1)
						historyVM.DaysSource[dayIndex] = EditedDay;
				}
				//Den redigerede dag nulstilles for en sikkerheds skyld, for at minimere sandsynligheden for fejl.
				Xamarin.Essentials.Preferences.Set(Constants.EditedDay, null);
				EditedDay = null;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}

			base.OnDisappearing();
		}

		protected override bool OnBackButtonPressed()
		{
			return base.OnBackButtonPressed();
		}

		protected override bool OnBackgroundClicked()
		{
			return base.OnBackgroundClicked();
		}

		public async void DeleteDay(object obj)
		{
			dayViewVM.DeleteDay(selectedDay);
		}

		public async void EditDay(object obj)
		{

		}
	}
}