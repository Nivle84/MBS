using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System;
using SplashScreenTest02.Services;
using System.Threading.Tasks;

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
		//Splash skal tjekke om der er en bruger logget ind, og om moods og influences listerne har værdier.
		//Moods og influences bliver vel hentet af sig selv hvis vi henter dage med lazy loading?
		//Hvis ikke fører den til login/registrér.
		//Notes på historik skærmen kan hentes via lazy loading.

		public Intent mainAct;
		public void OnAnimationCancel(Animator animation)
		{
			//TODO Pass data fra prelaunch.cs til mainAct
			//StartActivity(mainAct);
		}

		public void OnAnimationEnd(Animator animation)
		{
			//throw new NotImplementedException();
			//StartActivity(new Intent(Application.Context, typeof(MainActivity)));
			//mainAct = new Intent(this, typeof(MainActivity));
			//mainAct.PutExtra();

		}

		public void OnAnimationRepeat(Animator animation)
		{
		}

		public void OnAnimationStart(Animator animation)
		{
			PreLaunch preLaunch = new PreLaunch();
			if (Task.Run(() => preLaunch.preLaunchTasks).IsCompletedSuccessfully)
			{
				animation.Cancel();
			}


			//Tjek lister for influence og mood
			//Tjek om der er en bruger logget ind
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