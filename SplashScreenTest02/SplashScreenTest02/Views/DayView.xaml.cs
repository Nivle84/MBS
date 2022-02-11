using Android.Widget;
using MBStest01.Models;
using MBStest03.ViewModels;
using SplashScreenTest02.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SplashScreenTest02.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayView : Grid
    {
        DayViewVM vm { get; set; }
        public Command MoodClickedCommand { get; }
        public Command InfluenceClickedCommand { get; }
        public Command SaveDayClickedCommand { get; }
        public Command SequenceIncreaseCommand { get; }
        public Command SaveThisDayCommand { get; }
        public Command GoBackCommand { get; }
		public GridLength rowHeight { get; set; }
        public GridLength influenceRowHeight { get; set; }
		public double moodImageScale { get; set; }
		public DayView()
        {
            rowHeight = GridLength.Star;
            influenceRowHeight = GridLength.Auto;

            Debug.WriteLine("DayView() called.");
            vm = new DayViewVM();
            this.BindingContext = vm;// new DayViewVM();

            moodImageScale = 1.5;

   //         Label shortdateLabel = new Label()
   //         {
			//	Text = vm.ShortDate.ToString(),
			//	HorizontalOptions = LayoutOptions.CenterAndExpand,
			//	VerticalTextAlignment = TextAlignment.End,
			//	FontSize = (Double)NamedSize.Title,
			//	TextColor = (Color)Application.Current.Resources["Primary"]
			//};

            MoodClickedCommand = new Command(MoodClicked);
            InfluenceClickedCommand = new Command(InfluenceClicked);
            SaveThisDayCommand = new Command(SaveDayClicked);
            GoBackCommand = new Command(GoBackClicked);
            InitializeComponent();
            //dvMainGrid.Children.Add(shortdateLabel, 1, 5, 1, 2);
        }

        public DayView(DayViewVM dayViewVM)
		{
			//dvMainGrid.HeightRequest = 800;
			rowHeight = GridLength.Star;
            influenceRowHeight = 17;
            //Image collectionviewMoodImage_CB = (Image)collectionviewMoodList.FindByName("collectionviewMoodImage");
            //collectionviewMoodImage_CB.Scale = 1;
            moodImageScale = 3;

            Debug.WriteLine("DayView(DayViewVM dayViewVM) called.");
            vm = dayViewVM;
            this.BindingContext = vm;
			//row1.Height = 
   //         row2.Height = GridLength.Auto;
   //         row3.Height = GridLength.Auto;
   //         row4.Height = GridLength.Auto;
   //         row5.Height = GridLength.Auto;
   //         row6.Height = GridLength.Auto;
   //         row7.Height = GridLength.Auto;
   //         row8.Height = GridLength.Auto;
   //         row9.Height = GridLength.Auto;
            //dvMainGrid.VerticalOptions = LayoutOptions.End;
			/*
            Grid mainGrid = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(20)},
                    new RowDefinition { Height = new GridLength((Double)GridUnitType.Star) },   //7 rækker
                    new RowDefinition { Height = new GridLength((Double)GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength((Double)GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength((Double)GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength((Double)GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength((Double)GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength((Double)GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(20)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(20)},
                    new ColumnDefinition { Width = new GridLength((Double)GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength((Double)GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength((Double)GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(20)}
                }

            };
            */
			MoodClickedCommand = new Command(MoodClicked);
            InfluenceClickedCommand = new Command(InfluenceClicked);
            SaveThisDayCommand = new Command(SaveDayClicked);
            GoBackCommand = new Command(GoBackClicked);

            InitializeComponent();

            int rownumber = 0;
			foreach (var row in dvMainGrid.RowDefinitions)
			{
                rownumber++;
                Debug.WriteLine(row.ToString() + rownumber);
			}

			dvMainGrid.RowDefinitions.Remove(row1);
			dvMainGrid.RowDefinitions.Remove(row2);
			dvMainGrid.RowDefinitions.Remove(row3);
			dvMainGrid.RowDefinitions.Remove(row4);
			//dvMainGrid.RowDefinitions.Remove(row5);
			//dvMainGrid.RowDefinitions.Remove(row7);
			//dvMainGrid.RowDefinitions.Remove(row8);
			//dvMainGrid.RowDefinitions.Remove(row9);
			Debug.WriteLine("Rows removed.");
            rownumber = 0;
            foreach (var row in dvMainGrid.RowDefinitions)
            {
                rownumber++;
                Debug.WriteLine(row.ToString() + rownumber);
            }

			BoxView testBox = new BoxView()
			{
				BackgroundColor = Color.HotPink
			};

            row9.Height = GridLength.Auto;

            //Column, Column + ColumnSpan, Row, Row + RowSpan
            //Det er til starten af kolonne/række nummer whatever, og ikke span over X kolonner/rækker.
            //dvMainGrid.Children.Add(testBox, 0, 5, 6, 7);
            //dvMainGrid.Children.Add(new BoxView() { BackgroundColor = Color.LawnGreen, Opacity = 50 },            0, 5, 1, 2);
            //dvMainGrid.Children.Add(new BoxView() { BackgroundColor = Color.LightGoldenrodYellow, Opacity = 50 }, 0, 5, 2, 3);
            //dvMainGrid.Children.Add(new BoxView() { BackgroundColor = Color.Indigo, Opacity = 50 },               0, 5, 3, 4);
            //dvMainGrid.Children.Add(new BoxView() { BackgroundColor = Color.DimGray, Opacity = 50 },              0, 5, 4, 5);
            //dvMainGrid.Children.Add(new BoxView() { BackgroundColor = Color.Blue, Opacity = 50 },                 0, 5, 5, 6);
            //dvMainGrid.Children.Add(new BoxView() { BackgroundColor = Color.SteelBlue, Opacity = 50 },            0, 5, 6, 7);
            //dvMainGrid.Children.Add(new BoxView() { BackgroundColor = Color.Firebrick, Opacity = 50 },            0, 5, 7, 8);
            //dvMainGrid.Children.Add(new BoxView() { BackgroundColor = Color.Tomato, Opacity = 50 },               0, 5, 8, 9);
            //Label infLabels_CB = (Label)influenceCollectionView.FindByName("infLabels");
            //infLabels_CB.

            Label dayIDLabel = new Label()
            {
                Text = vm.ThisDay.DayID.ToString(),
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 20,
                TextColor = Color.Red
            };
            labelShortDate.FontSize = 14;
            dvMainGrid.Children.Add(labelShortDate,          0, 5, 0, 1);
			dvMainGrid.Children.Add(collectionviewMoodList,  0, 5, 1, 2);
			dvMainGrid.Children.Add(influenceCollectionView, 1, 4, 2, 5);
			dvMainGrid.Children.Add(SelectedInfluence,       1, 4, 2, 3);
			dvMainGrid.Children.Add(noteEditor,              1, 4, 3, 5);
			dvMainGrid.Children.Add(SaveDayButton,           3, 4, 5, 6);
			dvMainGrid.Children.Add(GoBackButton,            1, 2, 5, 6);
            dvMainGrid.Children.Add(dayIDLabel,              2, 3, 5, 6);

		}

		private void MoodClicked(object obj) //Parameteren stammer fra CommandParameter fra view'et.
        {
            Debug.WriteLine("MoodClicked() called.");
            vm.ThisMood = (Mood)obj;

            if (vm.ThisInfluence.InfluenceName != null)     //Visse elementer af view'et skjules.
            {                                               //Var dette implementeret mere "korrekt", havde de
                influenceCollectionView.IsVisible = false;  //forskellige elementer været deres egne respektive views,
                SelectedInfluence.IsVisible = true;         //således at de ikke bare skjules men "unloades" fra hukommelsen.
                noteEditor.IsVisible = true;                //I og med at programmet ikke er større end det er,
                GoBackButton.IsVisible = true;              //synes jeg dog at det er acceptabelt
            }                                               //(load-tid stadig inden for kravspec).
        }

        private void InfluenceClicked(object obj)
        {
            vm.ThisInfluence = (Influence)obj;

            if (vm.ThisMood.MoodName != null)
			{
			    influenceCollectionView.IsVisible = false;
                SelectedInfluence.IsVisible = true;
                noteEditor.IsVisible = true;
                GoBackButton.IsVisible = true;
			}
        }

        private void GoBackClicked(object obj)
		{
            if (noteEditor.IsVisible == true)
			{
                influenceCollectionView.IsVisible = true;
                SelectedInfluence.IsVisible = false;
                noteEditor.IsVisible = false;
                GoBackButton.IsVisible = false;
            }
		}

		public HistoryViewModel historyVM { get; set; }
		private async void SaveDayClicked(object obj)
        {
			try
			{
                vm.SaveThisDay();
                //historyVM.EditDay();
			}
            catch (Exception ex)
			{

            }
            if (vm.DayHasBeenSaved)
            {
                await Shell.Current.GoToAsync("///MyStreamPage");
                //TODO
                //Det her fungerer ikke. DayHasBeenSaved bliver af uvisse årsager ikke set i første omgang.
            }
        }
    }
}