namespace MBStest01.Models
{
	public class Note
	{
		//public int NoteID { get; set; }
		//      [Required]
		//[ForeignKey("User")]
		//public int UserID { get; set; }
		public int DayID { get; set; }
		public string NoteString { get; set; }
		//Jeg bliver vel nødt til at have en dag med her??
		//Ellers kan jeg ikke definere et 1-1 forhold i contexten.
		//public virtual Day Day { get; set; }
		//public User User { get; set; }
	}
}
