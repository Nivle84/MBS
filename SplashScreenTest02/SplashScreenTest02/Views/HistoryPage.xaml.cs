
using SplashScreenTest02.ViewModels;
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
        public HistoryPage()
        {

            //GoToMyStreamCommand = new Command(GoToMyStream);
            //HistoryCV.ItemsSource = hpVM_CB.DaysSource;
            //HistoryCV.ItemTemplate = hpVM_CB.DayTemplate;
            Label labelCV = new Label();
            OpenPopupCommand = new Command(OpenPopupClicked);
            
            InitializeComponent();
        }

        private async void OpenPopupClicked(object obj)
		{
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