using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MBStest01.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPassword { get; set; }
		//public ICollection<Note> Notes { get; set; }
		//public ICollection<Day> Days { get; set; }
	}
}
