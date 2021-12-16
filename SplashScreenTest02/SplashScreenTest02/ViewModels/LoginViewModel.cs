using MBStest03.Views;
using SplashScreenTest02.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace MBStest03.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            //Image loginpageImage = new Image
            //{
            //    Source = ImageSource.FromFile("Assets/Splash_screen.jpg"),
            //    Aspect = Aspect.AspectFit
            //};

            //if (loginpageImage == null)
            //    Debug.Write("Image not set!");

            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            //await Shell.Current.GoToAsync("//MainPage");

            //TODO Login logik.
        }
    }
}
