using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MBStest01.Models
{
    public class Mood
    {
        //public enum MoodEnum
        //{
        //    Good,
        //    Ok,
        //    Bad
        //}
        public int MoodID { get; set; }
        [Required]
        public string MoodName { get; set; }
        //public int DayID { get; set; }
        //public Day Day { get; set; }
        //public MoodEnum MoodName { get; set; }
    }
}
