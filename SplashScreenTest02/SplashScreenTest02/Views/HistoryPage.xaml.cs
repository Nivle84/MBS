using MBStest01.Models;
using MBStest03.ViewModels;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using SplashScreenTest02.ViewModels;
using SplashScreenTest02.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MBStest03.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        //public Command GoToMyStreamCommand { get; }
        public Command OpenPopupCommand { get; }
        //public DayViewVM dayViewVM;
        public HistoryPage()
        {

            //GoToMyStreamCommand = new Command(GoToMyStream);
            //HistoryCV.ItemsSource = hpVM_CB.DaysSource;
            //HistoryCV.ItemTemplate = hpVM_CB.DayTemplate;
            Label labelCV = new Label();
            InitializeComponent();
            OpenPopupCommand = new Command(OpenPopupClicked);
        }

        //https://devlinduldulao.pro/xamarin-forms-101-how-to-create-a-popup-form-in-xamarin-forms/
        private async void OpenPopupClicked(object obj)
		{
            //dayViewVM = new DayViewVM((Day)obj);
            //await PopupNavigation.PushAsync(new HistoryDayPopup(dayViewVM));
            await PopupNavigation.PushAsync(new HistoryDayPopup((Day)obj));

            Debug.WriteLine("OpenPopupClicked() called!");
		}
		//private void HistoryCV_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		//{
  //          hpVM_CB.DaysSource = hpVM_CB.DaysSource;
		//}

		//ImageSource historyNote = "historynote.png";

		//      public async void GoToMyStream(object obj)
		//{
		//          await Shell.Current.GoToAsync("MyStreamPage");
		//}
	}
}