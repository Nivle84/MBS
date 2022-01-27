using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SplashScreenTest02.Services
{
	public class DateTimeCultureConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var incVal = (DateTime)value;
			var localCulture = CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("da-DK");
			
			TextInfo textInfo = localCulture.TextInfo;
			return textInfo.ToTitleCase(incVal.ToString("dddd", localCulture));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
