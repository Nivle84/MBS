using MBStest01.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SplashScreenTest02.Services
{
	public class UserState
	{
		public User CurrentUser
		{
			get
			{
				var currentUser = JsonConvert.DeserializeObject<User>(Preferences.Get("LoggedInUserKey", "default_value"));
				return currentUser;
			}
			set
			{
				Preferences.Set("LoggedInUserKey", JsonConvert.SerializeObject(value));
			}
		}

		public UserState()
		{
			CurrentUser = new User();
		}
	}
}
