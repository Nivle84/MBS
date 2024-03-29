﻿using MBStest01.Models;
using MBStest03.ViewModels;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using SplashScreenTest02.Services;
using SplashScreenTest02.ViewModels;
using SplashScreenTest02.Views;
using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MBStest03.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
		//public Command GoToMyStreamCommand { get; }
		//public Command OpenPopupCommand { get; }
		//public DayViewVM dayViewVM;
		public Day NewDay { get; set; }
		public HistoryPage()
        {

            //GoToMyStreamCommand = new Command(GoToMyStream);
            //HistoryCV.ItemsSource = hpVM_CB.DaysSource;
            //HistoryCV.ItemTemplate = hpVM_CB.DayTemplate;
            Label labelCV = new Label();
			
            InitializeComponent();
            //OpenPopupCommand = new Command(OpenPopupClicked);
        }

		protected override void OnAppearing()	//Tiltænkt til efter popupvinduet lukkes
		{
			if (hpVM_CB.DaysSource != null)	//Sikrer at koden kun kører hvis viewmodel har været initialiseret.
			{
				var json = Xamarin.Essentials.Preferences.Get(Constants.EditedDay, null);
				if (json != null)
				{
					NewDay = Newtonsoft.Json.JsonConvert.DeserializeObject<Day>(json);
					if (NewDay != null && NewDay.DayID == 0)	//Der sikres at der findes data i NewDay, samt at det ikke blot er et tomt objekt,
						hpVM_CB.DaysSource.Add(NewDay);			//som så tilføjes til den ObservableCollection som udgør historiksiden.
				}
				Preferences.Set(Constants.EditedDay, null);
			}
			base.OnAppearing();
		}

		//https://devlinduldulao.pro/xamarin-forms-101-how-to-create-a-popup-form-in-xamarin-forms/
		//      private async void OpenPopupClicked(object obj)
		//{
		//          //dayViewVM = new DayViewVM((Day)obj);
		//          hpVM_CB.dayObjFromView = obj;
		//          //await PopupNavigation.PushAsync(new HistoryDayPopup(dayViewVM));
		//          await PopupNavigation.PushAsync(hpVM_CB.historyDayPopup);

		//          Debug.WriteLine("OpenPopupClicked() called!");
		//}

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