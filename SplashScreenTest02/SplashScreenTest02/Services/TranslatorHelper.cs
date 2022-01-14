namespace MBStest03.Helpers
{
    public class TranslatorHelper
    {
        public string InfluenceTranslator(int influenceID)
        {
            string transInfluenceName = "Placeholder";

            switch (influenceID)
            {
                case 1:
                    transInfluenceName = "Familie";
                    break;
                case 2:
                    transInfluenceName = "Forhold";
                    break;
                case 3:
                    transInfluenceName = "Venner";
                    break;
                case 4:
                    transInfluenceName = "Mad";
                    break;
                case 5:
                    transInfluenceName = "Helbred";
                    break;
                case 6:
                    transInfluenceName = "Motion";
                    break;
                case 7:
                    transInfluenceName = "Spiritualitet";
                    break;
                case 8:
                    transInfluenceName = "Karriere";
                    break;
                case 9:
                    transInfluenceName = "Uddannelse";
                    break;
                case 10:
                    transInfluenceName = "Rejser";
                    break;
                case 11:
                    transInfluenceName = "Søvn";
                    break;
                case 12:
                    transInfluenceName = "Økonomi";
                    break;
                default:
                    break;
            }

            return transInfluenceName;
        }

        public string MoodTranslator(int moodID)
        {
            string transMoodName = "Placeholder";

            switch (moodID)
            {
                case 1:
                    transMoodName = "God";
                    break;
                case 2:
                    transMoodName = "Ok";
                    break;
                case 3:
                    transMoodName = "Skidt";
                    break;
                default:
                    break;
            }

            return transMoodName;
        }
    }
}
