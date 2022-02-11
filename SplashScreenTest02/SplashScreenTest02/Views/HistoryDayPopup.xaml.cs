using MBStest01.Models;
using MBStest03.ViewModels;
using SplashScreenTest02.Services;
using SplashScreenTest02.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public HistoryDayPopup(Day selectedDay)
		{
			dayToEdit = selectedDay;
			dayViewVM = new DayViewVM(dayToEdit);	//Lader til at blive kaldt og constructet fint nok.
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
			//historyVM.EditDay(dayToEdit);
			//foreach (var day in historyVM.DaysSource.Where(d => d.DayID == dayToEdit.DayID))
			//{
			//	dayToEdit = day;
			//}
			//Der tjekkes her om en dag er blevet slettet eller ændret.
			//Det her blev godt nok en snørklet og grim implementering... -_-
			//Men fordi jeg ikke var mere forudseende må det være som det er.
			try
			{
				Day dayToInsert = Newtonsoft.Json.JsonConvert.DeserializeObject<Day>(Xamarin.Essentials.Preferences.Get(Constants.EditedDay, null));

				if (Xamarin.Essentials.Preferences.Get(Constants.DeletedDayID, 0) != 0)
					historyVM.DaysSource.Remove(dayToEdit);
				else if (dayToInsert != null)
				{
					foreach (var day in historyVM.DaysSource.Where(d => d.DayID == dayToInsert.DayID))
					{
						dayToInsert = day;
					}
				}
			}
			catch (Exception ex)
			{

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