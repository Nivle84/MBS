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
		private User _currentUser;

		public User CurrentUser
		{
			get
			{
				//_currentUser = Preferences.Set("CurrentUser", JsonConvert.SerializeObject(value));
				_currentUser = JsonConvert.DeserializeObject<User>(Preferences.Get("CurrentUser", null));
				return _currentUser;
			}
			set
			{
				_currentUser = value;
			}
		}

		public UserState()
		{
			CurrentUser = new User();
		}
	}
}
