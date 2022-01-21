using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace SplashScreenTest02.Services
{
	public static class ExtensionMethods
	{
		public static ImageSource GetImageSourceFromBase64String(this string base64)
		{
			if (base64 == null)
			{
				return null;
			}
			byte[] Base64Stream = Convert.FromBase64String(base64);

			return ImageSource.FromStream(() => new MemoryStream(Base64Stream));
		}
	}
}
