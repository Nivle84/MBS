﻿using MBStest01.Models;
using MBStest03.ViewModels;
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
			dayViewVM = new DayViewVM(selectedDay);	//Lader til at blive kaldt og constructet fint nok.
			Debug.WriteLine("HistoryDayPopup constructor called.");
			DayView popupDayView = new DayView(dayViewVM);
			//popupDayView.VerticalOptions = LayoutOptions.Center;
			//popupDayView.HeightRequest = 800;

			this.Content = popupDayView;
			this.Content.VerticalOptions = LayoutOptions.EndAndExpand;
			this.HasSystemPadding = true;
			
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
	}
}