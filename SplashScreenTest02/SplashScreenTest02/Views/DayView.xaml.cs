using Android.Widget;
using MBStest01.Models;
using MBStest03.ViewModels;
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

        public DayView()
        {
            Debug.WriteLine("DayView() called.");
            vm = new DayViewVM();
            this.BindingContext = vm;// new DayViewVM();

            MoodClickedCommand = new Command(MoodClicked);
            InfluenceClickedCommand = new Command(InfluenceClicked);
            SaveThisDayCommand = new Command(SaveDayClicked);
            GoBackCommand = new Command(GoBackClicked);
            InitializeComponent();
        }

        public DayView(DayViewVM dayViewVM)
		{
            Debug.WriteLine("DayView(DayViewVM dayViewVM) called.");
            vm = dayViewVM;
            this.BindingContext= vm;
            MoodClickedCommand = new Command(MoodClicked);
            InfluenceClickedCommand = new Command(InfluenceClicked);
            SaveThisDayCommand = new Command(SaveDayClicked);
            GoBackCommand = new Command(GoBackClicked);
            InitializeComponent();
        }

        public void MoodClicked(object obj) //Parameteren stammer fra CommandParameter fra view'et.
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

        public void InfluenceClicked(object obj)
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

        public void GoBackClicked(object obj)
		{
            if (noteEditor.IsVisible == true)
			{
                influenceCollectionView.IsVisible = true;
                SelectedInfluence.IsVisible = false;
                noteEditor.IsVisible = false;
                GoBackButton.IsVisible = false;
            }
		}

        public async void SaveDayClicked(object obj)
        {
			try
			{
                vm.SaveThisDay();
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