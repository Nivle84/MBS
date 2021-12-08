using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System;

namespace SplashScreenTest02.Droid
{
	[Activity(
		Label = "SplashScreenTest02",
		Icon = "@drawable/mbs_logo",
		NoHistory = true,
		Theme = "@style/MainTheme.Splash",
		MainLauncher = true,
		ConfigurationChanges =
		ConfigChanges.ScreenSize |
		ConfigChanges.Orientation |
		ConfigChanges.UiMode |
		ConfigChanges.ScreenLayout |
		ConfigChanges.SmallestScreenSize
		)]
	public class SplashActivity : Activity, Android.Animation.Animator.IAnimatorListener
	{
		//https://www.serkanseker.com/animated-splash-screen/
		public void OnAnimationCancel(Animator animation)
		{
			throw new NotImplementedException();
			//TODO If startup task is complete, cancel animation
			//StartActivity(new Intent(Application.Context, typeof(MainActivity)));
		}

		public void OnAnimationEnd(Animator animation)
		{
			//throw new NotImplementedException();
			StartActivity(new Intent(Application.Context, typeof(MainActivity)));
		}

		public void OnAnimationRepeat(Animator animation)
		{
			//throw new NotImplementedException();
		}

		public void OnAnimationStart(Animator animation)
		{
			//throw new NotImplementedException();
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			//StartActivity(typeof(MainActivity));

			SetContentView(Resource.Layout.SplashLayout);
			var loading_animation = FindViewById<Com.Airbnb.Lottie.LottieAnimationView>(Resource.Id.lottieAnimationView1);
			loading_animation.AddAnimatorListener(this);

			// Create your application here
		}
	}
}