namespace MBStest03.Models
{
    public class Note
    {
        public int NoteID { get; set; }
        public string NoteString { get; set; }
		public int DayID { get; set; }
		public Day Day { get; set; }
	}
}
