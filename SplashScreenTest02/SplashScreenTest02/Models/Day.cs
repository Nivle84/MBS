using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MBStest01.Models
{
	public class Day
	{
		public int DayID { get; set; }
		[Required]
		[ForeignKey("Users")]
		public int UserID { get; set; }
		public User User { get; set; }
		[Required]
		[ForeignKey("Moods")]
		public int MoodID { get; set; }
		public Mood Mood { get; set; }
		[Required]
		[ForeignKey("Influences")]
		public int InfluenceID { get; set; }
		public Influence Influence { get; set; }
		[Required]
		public DateTime Date { get; set; }
		public bool HasNote { get; set; } = false;
		public virtual Note Note { get; set; }	//Virtual = lazy loading, ja?
		//      [Required]
		//public int UserID { get; set; }
		//      [Required]
		//public int MoodID { get; set; }
		//      [Required]
		//public int InfluenceID { get; set; }
		////public int? NoteID { get; set; }
	}
}
