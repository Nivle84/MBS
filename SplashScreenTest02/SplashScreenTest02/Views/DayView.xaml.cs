using Android.Widget;
using MBStest01.Models;
using MBStest03.ViewModels;
using System;
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
   //     protected override bool OnBackButtonPressed()
   //     {
   //         if (BindingContext != null && BindingContext is DayViewVM)
			//{
   //             if (noteEditor.IsVisible)
   //             {
   //                 influenceCollectionView.IsVisible = true;
   //                 SelectedInfluence.IsVisible = false;
   //                 noteEditor.IsVisible = false;
   //             }
			//}
   //     }

        public DayView()
        {
            vm = new DayViewVM();
            this.BindingContext = vm;// new DayViewVM();
                                     //collectionViewInfluences.ItemsSource = vm.influenceList;
                                     //collectionViewInfluences.SelectedItem = vm.influenceClickedCommand;

            MoodClickedCommand = new Command(MoodClicked);
            InfluenceClickedCommand = new Command(InfluenceClicked);
            //SequenceIncreaseCommand = new Command(SequenceIncrease);
            SaveThisDayCommand = new Command(SaveDayClicked);
            GoBackCommand = new Command(GoBackClicked);
            InitializeComponent();
        }

        //public static readonly BindableProperty TextProperty = BindableProperty.Create(
        //	nameof(Text),
        //	typeof(string),
        //	typeof(DayView),
        //	propertyChanging: (bindable, oldValue, newValue) =>
        //	{
        //		var control = bindable as Label;
        //		var changingFrom = oldValue as string;
        //		var changingTo = newValue as string;
        //	});
        //public string Text
        //{
        //	get { return (string)GetValue(TextProperty); }
        //	set { SetValue(TextProperty, value); }
        //}

        //public static readonly BindableProperty ThisDayDVProperty = BindableProperty.Create(nameof(ThisDayDV), typeof(Day), typeof(DayView)
        //				, propertyChanging: (bindable, oldValue, newValue) =>
        //				{
        //					var control = bindable as Label;
        //					var changingFrom = oldValue as string;
        //					var changingTo = newValue as string;
        //				});
        //public Day ThisDayDV
        //{
        //	get
        //	{ return (Day)GetValue(ThisDayDVProperty); }
        //	set { SetValue(ThisDayDVProperty, value); }
        //}

        //public static readonly BindableProperty ThisMoodDVProperty = BindableProperty.Create(nameof(ThisMoodDV), typeof(Mood), typeof(DayView));
        //public Mood ThisMoodDV
        //{
        //	get { return (Mood)GetValue(ThisMoodDVProperty); }
        //	set { SetValue(ThisMoodDVProperty, value); }
        //}

        //public static readonly BindableProperty ThisInfluenceDVProperty = BindableProperty.Create(nameof(ThisInfluenceDV), typeof(Influence), typeof(DayView));
        //public Influence ThisInfluenceDV
        //{
        //	get { return (Influence)GetValue(ThisInfluenceDVProperty); }
        //	set { SetValue(ThisInfluenceDVProperty, value); }
        //}

        //public static readonly BindableProperty ThisNoteDVProperty = BindableProperty.Create(nameof(ThisNoteDV), typeof(Note), typeof(DayView));
        //public Note ThisNoteDV
        //{
        //	get { return (Note)GetValue(ThisNoteDVProperty); }
        //	set { SetValue(ThisNoteDVProperty, value); }
        //}

        //public static readonly BindableProperty ThisUserDVProperty = BindableProperty.Create(nameof(ThisUserDV), typeof(User), typeof(DayView));
        //public User ThisUserDV
        //{
        //	get { return (User)GetValue(ThisUserDVProperty); }
        //	set { SetValue(ThisUserDVProperty, value); }
        //}

        public void MoodClicked(object obj)
        {
            //vm.ThisMood = vm.moodList.FirstOrDefault(m => m.MoodID.ToString() == obj.ToString()); //Kan åbenbart ikke sammenligne ints. Virker lidt fjollet med ToString(), men det virker ¯\_(ツ)_/¯
            vm.ThisMood = (Mood)obj;

            if (vm.ThisInfluence.InfluenceName != null)
            {
                influenceCollectionView.IsVisible = false;
                SelectedInfluence.IsVisible = true;
                noteEditor.IsVisible = true;
                GoBackButton.IsVisible = true;
            }
        }

        public void InfluenceClicked(object obj)
        {
            //Command og metode formentlig overflødig grundet måden CollectionView.SelectedItem fungerer.
            //Kan måske bruges ifm at skulle holde styr på hvor i processen af at registere/ændre en dag man er.

            //vm.ThisInfluence = vm.influenceList.Cast<Influence>().SingleOrDefault(i => i.InfluenceName == obj.ToString());
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
            vm.SaveThisDay();
            if (vm.DayHasBeenSaved)
            {
                await Shell.Current.GoToAsync("///MyStreamPage");
            }
        }

        //public void SequenceIncrease(object obj)
        //{
        //    vm.sequenceStep++;
        //}

        //public void ChangeElementsVisibility()
        //{
        //    switch (vm.sequenceStep)    //SequenceStep++ ved valg af mood og influence. Tilbage til 0 ved gemt dag. Denne metode skulle kaldes ved ændringer i View.
        //    {
        //        case 0: //Intet valgt endnu
        //            moodCollectionView.IsVisible = true;
        //            influenceCollectionView.IsVisible = true;
        //            noteEditor.IsVisible = false;
        //            break;
        //        case 1: //Mood || Influence valgt
        //            moodCollectionView.IsVisible = true;
        //            influenceCollectionView.IsVisible = true;
        //            noteEditor.IsVisible = false;
        //            break;
        //        case 2: //Mood && Influence valgt
        //            moodCollectionView.IsVisible = true;
        //            influenceCollectionView.IsVisible = false;
        //            noteEditor.IsVisible = true;
        //            break;
        //    }
        //}
    }
}