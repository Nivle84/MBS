using Xamarin.Forms;	//Jeg har på fornemmelsen at dette er bad practice ift at overholde MVVM... Xamarin.Forms er vel strengt forbeholdt View'et?

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
		public string MoodName { get; set; }
		public string MoodImagePath { get; set; }
		//public int DayID { get; set; }
		//public Day Day { get; set; }
		//public MoodEnum MoodName { get; set; }
	}
}
