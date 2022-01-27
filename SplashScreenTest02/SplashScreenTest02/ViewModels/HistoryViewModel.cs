using MBStest01.Models;
using MBStest03.ViewModels;
using SplashScreenTest02.Services;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace SplashScreenTest02.ViewModels
{
	public class HistoryViewModel : BaseViewModel
	{
		//https://www.xamarinexpert.it/how-to-change-listview-using-templates/
		public Command GoToMyStreamCommand { get; }
		public DataTemplate DayTemplate { get; set; }
		public IEnumerable<Day> _daysSource;
		public IEnumerable<Day> DaysSource
		{
			get { return _daysSource; }
			set { _daysSource = value; OnPropertyChanged(); }
		}
		public DataFiller MyFiller { get; set; }
		public DayViewVM dayViewVM { get; set; }
		public HistoryViewModel()
		{
			MyFiller = new DataFiller();
			FillDaysList();
			//DaysSource = await MyFiller.GetUsersDays();
			//DayTemplate = new DataTemplate(typeof(DayCell));

			dayViewVM = new DayViewVM();
			GoToMyStreamCommand = new Command(GoToMyStream);
		}

		public async void GoToMyStream(object obj)
		{
			await Shell.Current.GoToAsync("///MyStreamPage");
		}

		//public DataTemplate GetTemplate(Day dayObj)
		//{
		//	//Vi bestemmer hvilket layout hver linje i collectionview skal have alt efter om
		//	//bool værdien er sand eller falsk (om der skal vises et note-ikon eller ej).
		//	switch (dayObj.HasNote)
		//	{
		//		case true:
		//			return new DataTemplate(typeof(DayCell));
		//		case false:
		//			return new DataTemplate(typeof(CellWithoutNote));
		//	}
		//	return null;
		//}

		public void CreateTemplate()
		{
			DayTemplate = new DataTemplate(typeof(DayCell));
			//return new DataTemplate(typeof(DayCell));
		}

		public async void FillDaysList()
		{
			DaysSource = await MyFiller.GetUsersDays();
			foreach (var day in DaysSource)
			{
				//Det her er grimt og rodet, men det må virke.
				day.Mood.MoodImagePath = "mood" + $"{day.Mood.MoodName}".ToLower() + ".png";
				//Debug.WriteLine("DaysSource MoodName: " + day.Mood.MoodName);
			}
		}

		//private DataTemplate _cellWithNote;

		//public DataTemplate CellWithNote
		//{
		//	get { return _cellWithNote; }
		//	set { _cellWithNote = value; }
		//}
		//private DataTemplate _cellWithoutNote;
		//public DataTemplate CellWithoutNote
		//{
		//	get { return _cellWithoutNote; }
		//	set { _cellWithoutNote = value; }
		//}
	}

	public class DayCell
	{
	//	public DayCell(object obj)
	//	{
	//		Label historyWeekdayLabel = new Label()
	//		{
	//			Text = obj.Date.DayOfWeek.ToString(),
	//			HorizontalTextAlignment = TextAlignment.Start
	//		};
	//		Label historyDateLabel = new Label()
	//		{
	//			Text = obj.Date.ToShortDateString(),
	//			HorizontalTextAlignment = TextAlignment.Start
	//		};
	//		Image historyHasNoteIcon = new Image()
	//		{
	//			Source = "historynote.png",
	//			IsVisible = false
	//		};
	//		Image historyMoodIcon = new Image()
	//		{
	//			Source = obj.Mood.MoodImagePath
	//		};

	//		Grid historyDayGrid = new Grid();
	//		historyDayGrid.BackgroundColor = (Color)Application.Current.Resources["PrimaryAccent1"];
	//		RowDefinition row1 = new RowDefinition()
	//		{
	//			Height = new GridLength(30)
	//		};
	//		ColumnDefinition column1 = new ColumnDefinition()
	//		{
	//			Width = GridLength.Star
	//		};
	//		ColumnDefinition column2 = new ColumnDefinition()
	//		{
	//			Width = GridLength.Star
	//		};
	//		ColumnDefinition column3 = new ColumnDefinition()
	//		{
	//			Width = GridLength.Star
	//		};
	//		ColumnDefinition column4 = new ColumnDefinition()
	//		{
	//			Width = GridLength.Star
	//		};
	//		historyDayGrid.RowDefinitions.Add(row1);
	//		historyDayGrid.ColumnDefinitions.Add(column1);
	//		historyDayGrid.ColumnDefinitions.Add(column2);
	//		historyDayGrid.ColumnDefinitions.Add(column3);
	//		historyDayGrid.ColumnDefinitions.Add(column4);

	//		Grid.SetRow(historyWeekdayLabel, 0);
	//		Grid.SetColumn(historyWeekdayLabel, 0);
	//		Grid.SetRow(historyDateLabel, 0);
	//		Grid.SetColumn(historyDateLabel, 1);
	//		Grid.SetRow(historyHasNoteIcon, 0);
	//		Grid.SetColumn(historyHasNoteIcon, 2);
	//		Grid.SetRow(historyMoodIcon, 0);
	//		Grid.SetColumn(historyMoodIcon, 3);

	//		if (obj.HasNote)
	//			historyHasNoteIcon.IsVisible = true;
	//	}
	//}

	//public class CellWithoutNote
	//{
	//	public CellWithoutNote(Day dayForCurrentRow)
	//	{
	//		Label historyWeekdayLabel = new Label()
	//		{
	//			Text = dayForCurrentRow.Date.DayOfWeek.ToString(),

	//		};
	//		Label historyDateLabel = new Label()
	//		{
	//			Text = dayForCurrentRow.Date.ToShortDateString()
	//		};
	//		Image historyHasNote = new Image()
	//		{
	//			Source = "historynote.png"
	//		};
	//		Image historyMood = new Image()
	//		{
	//			Source = dayForCurrentRow.Mood.MoodImagePath
	//		};

	//		Grid historyDayGrid = new Grid();
	//		historyDayGrid.BackgroundColor = (Color)Application.Current.Resources["PrimaryAccent1"];
	//		RowDefinition row1 = new RowDefinition()
	//		{
	//			Height = new GridLength(30)
	//		};
	//		ColumnDefinition column1 = new ColumnDefinition()
	//		{
	//			Width = GridLength.Star
	//		};
	//		ColumnDefinition column2 = new ColumnDefinition()
	//		{
	//			Width = GridLength.Star
	//		};
	//		ColumnDefinition column3 = new ColumnDefinition()
	//		{
	//			Width = GridLength.Star
	//		};
	//		ColumnDefinition column4 = new ColumnDefinition()
	//		{
	//			Width = GridLength.Star
	//		};
	//		historyDayGrid.RowDefinitions.Add(row1);
	//		historyDayGrid.ColumnDefinitions.Add(column1);
	//		historyDayGrid.ColumnDefinitions.Add(column2);
	//		historyDayGrid.ColumnDefinitions.Add(column3);
	//		historyDayGrid.ColumnDefinitions.Add(column4);

	//		Grid.SetRow(historyWeekdayLabel, 0);
	//		Grid.SetColumn(historyWeekdayLabel, 0);
	//		Grid.SetRow(historyDateLabel, 0);
	//		Grid.SetColumn(historyDateLabel, 1);
	//		Grid.SetRow(historyHasNote, 0);
	//		Grid.SetColumn(historyHasNote, 2);
	//		Grid.SetRow(historyMood, 0);
	//		Grid.SetColumn(historyMood, 3);
	//	}
	//}
	}
}
