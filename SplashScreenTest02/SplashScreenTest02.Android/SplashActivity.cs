using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System;
using SplashScreenTest02.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;

namespace SplashScreenTest02.Droid
{
	[Activity(
		Label = "Mange Bække Små",
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
		//private readonly UserState UserState = new UserState();
		public void OnAnimationCancel(Animator animation)
		{
			StartActivity(mainAct);
		}

		public void OnAnimationEnd(Animator animation)
		{
			//throw new NotImplementedException();
			//StartActivity(new Intent(Application.Context, typeof(MainActivity)));
			//mainAct = new Intent(this, typeof(MainActivity));
			//mainAct.PutExtra();
			animation.Cancel();
		}

		public void OnAnimationRepeat(Animator animation)
		{
		}

		public void OnAnimationStart(Animator animation)
		{
			PreLaunch preLaunch = new PreLaunch();
			Bundle bundle = preLaunch.GatherBundle();
			mainAct = new Intent(this, typeof(MainActivity));
			//mainAct.Extras.PutBundle("preLaunchBundle", bundle);
			mainAct.PutExtra("preLaunchBundle", bundle);
			//List<Task> preLaunchTasks = preLaunch.GatherTasks();
			//Task.WaitAll(PreLaunch.moodTask, PreLaunch.influenceTask, PreLaunch.userTask);
			//await Task.WhenAll(preLaunch.GatherTasks());
			//animation.Cancel();	//Man når desværre ikke at se den fine loadingskærm hvis cancel sker hernede.

			//Tjek lister for influence og mood
			//Tjek om der er en bruger logget ind
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			//ServicePointManager
			//	.ServerCertificateValidationCallback +=
			//	(sender, cert, chain, sslPolicyErrors) => true;

			base.OnCreate(savedInstanceState);
			//StartActivity(typeof(MainActivity));

			SetContentView(Resource.Layout.SplashLayout);	//Vi sørger for at View'et der tilhører activity'en er vores minimalistiske layout.
			var loading_animation = FindViewById<Com.Airbnb.Lottie.LottieAnimationView>(Resource.Id.lottieAnimationView1);
			loading_animation.AddAnimatorListener(this);

			// Create your application here
		}
	}
}