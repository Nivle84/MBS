using MBStest01.Models;
using MBStest03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public DayView()
		{
			InitializeComponent();
			vm = new DayViewVM();
			this.BindingContext = vm;// new DayViewVM();
			//collectionViewInfluences.ItemsSource = vm.influenceList;
			//collectionViewInfluences.SelectedItem = vm.influenceClickedCommand;

			MoodClickedCommand = new Command(MoodClicked);
			InfluenceClickedCommand = new Command(InfluenceClicked);
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
			vm.ThisMood = vm.moodList.FirstOrDefault(m => m.MoodID.ToString() == obj.ToString()); //Kan åbenbart ikke sammenligne ints. Virker lidt fjollet med ToString(), men det virker ¯\_(ツ)_/¯
		}

		public void InfluenceClicked(object obj)
		{
			//Command og metode formentlig overflødig grundet måden CollectionView.SelectedItem fungerer.
			//Kan måske bruges ifm at skulle holde styr på hvor i processen af at registere/ændre en dag man er.

			vm.ThisInfluence = vm.influenceList.Cast<Influence>().SingleOrDefault(i => i.InfluenceName == obj.ToString());
		}

		public void ChangeElementsVisibility()
		{
			switch (vm.sequenceStep)
			{
				//case 0:

			}
		}
}
}