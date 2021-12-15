using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MBStest01.Models
{
    public class Note
    {
        //public int NoteID { get; set; }
  //      [Required]
		//[ForeignKey("User")]
		//public int UserID { get; set; }
        [Key, ForeignKey("Day")]
		public int DayID { get; set; }
        public string NoteString { get; set; }
		//Jeg bliver vel nødt til at have en dag med her??
		//Ellers kan jeg ikke definere et 1-1 forhold i contexten.
		//public virtual Day Day { get; set; }
		//public User User { get; set; }
	}
}
