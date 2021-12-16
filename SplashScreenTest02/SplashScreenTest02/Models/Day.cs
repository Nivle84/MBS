using System;

namespace MBStest01.Models
{
	public class Day
	{
		public int DayID { get; set; }
		public int UserID { get; set; }
		public User User { get; set; }
		public int MoodID { get; set; }
		public Mood Mood { get; set; }
		public int InfluenceID { get; set; }
		public Influence Influence { get; set; }
		public DateTime Date { get; set; }
		public bool HasNote { get; set; } = false;
		public virtual Note Note { get; set; }  //Virtual = lazy loading, ja?
												//      [Required]
												//public int UserID { get; set; }
												//      [Required]
												//public int MoodID { get; set; }
												//      [Required]
												//public int InfluenceID { get; set; }
												////public int? NoteID { get; set; }
	}
}
