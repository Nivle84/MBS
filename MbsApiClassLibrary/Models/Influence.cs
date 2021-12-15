namespace MBStest03.Models
{
    public class Influence
    {
        public int InfluenceID { get; set; }
        public string InfluenceName { get; set; }
		//public InfluenceEnumID InfluenceEnumID { get; set; }

		//public InfluenceEnum Influence { get; set; }

		public int DayID { get; set; }
		public Day Day { get; set; }
	}

    //public enum InfluenceEnum : int
    //{
    //    Family = 0,
    //    Relationships = 1,
    //    Friends = 2,
    //    Food = 3,
    //    Health = 4,
    //    Exercise = 5,
    //    Spiritual = 6,
    //    Career = 7,
    //    Education = 8,
    //    Travel = 9,
    //    Sleep = 10,
    //    Financial = 11
    //}
}
