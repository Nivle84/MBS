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
		public Day dayToEdit { get; set; }
		public Command DeleteDayCommand { get; set; }
		//public HistoryDayPopup(DayViewVM dayViewVMFromHistoryPage)
		//{
		//	dayViewVM = dayViewVMFromHistoryPage;
		//	//BindingContext = dayViewVM;
		//	//popDayView_CB.BindingContext = dayViewVM;	//Der sker noget her det gør at den hopper ud, så InitializeComponent() slet ikke bliver kaldt. Men det er jo heller ikke selve popupvinduet som skal have den binding.
		//	InitializeComponent();
		//	//Debug.WriteLine(this.BindingContext.ToString());
		//}

		public HistoryDayPopup(Day selectedDay, HistoryViewModel hpVM)
		{
			dayToEdit = selectedDay;
			dayViewVM = new DayViewVM(dayToEdit);   //Lader til at blive kaldt og constructet fint nok.
			historyVM = hpVM;
			Debug.WriteLine("HistoryDayPopup constructor called.");
			popupDayView = new DayView(dayViewVM);
			//popupDayView.VerticalOptions = LayoutOptions.Center;
			//popupDayView.HeightRequest = 800;


			DeleteDayCommand = new Command(DeleteDay);
			//this.Content = popupDayView;
			//this.Content.VerticalOptions = LayoutOptions.End;
			//this.HasSystemPadding = true;

			//this.SystemPaddingSides = 50;
			//this.Padding = 50;
			//this.Content.HeightRequest = 800;
			//this.HeightRequest = 800;
			//popupFrame_CB.Content = popupDayView;	//Der går noget galt her. Den hopper ud.
			//popupDayView_CB.BindingContext = new DayViewVM(selectedDay);
			Debug.WriteLine("popupDayView.BindingContext set.");
			InitializeComponent();
			Debug.WriteLine("HistoryDayPopup initialized.");
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			//Det her blev godt nok en snørklet og grim implementering... -_-
			//Men fordi jeg ikke var mere forudseende må det være fyldestgørende.
			try
			{
				//Den dag som er blevet redigeret og set'et i DayViewVM hentes.
				Day editedDay = Newtonsoft.Json.JsonConvert.DeserializeObject<Day>(Xamarin.Essentials.Preferences.Get(Constants.EditedDay, null));
				//Det samme gør sig gældende for ID'et af dagen som (potentielt) er blevet slettet.
				Day deletedDay = Newtonsoft.Json.JsonConvert.DeserializeObject<Day>(Xamarin.Essentials.Preferences.Get(Constants.DeletedDay, null));

				//Hvis dagen som er blevet åbnet i popup'en er den samme som den dag der er blevet slettet, fjernes den fra historiklisten
				if (dayToEdit.DayID == deletedDay.DayID)
					historyVM.DaysSource.Remove(deletedDay);
				//Hvis der er blevet gemt en redigeret dag i Preferences, og den dag som er blevet åbnet i popup'en har det samme ID som den dag der er blevet redigeret,
				//erstattes den givne dag i listen.
				else if (editedDay != null && dayToEdit.DayID == editedDay.DayID)
				{
					int dayIndex = historyVM.DaysSource.FindIndex(d => d.DayID == editedDay.DayID);

					if (dayIndex != -1)
						historyVM.DaysSource[dayIndex] = editedDay;
				}
				//Den redigerede dag nulstilles for en sikkerheds skyld, så der ikke opstår fejl.
				editedDay = null;
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
			dayViewVM.DeleteDay(dayToEdit);
		}

		public async void EditDay(object obj)
		{

		}
	}
}