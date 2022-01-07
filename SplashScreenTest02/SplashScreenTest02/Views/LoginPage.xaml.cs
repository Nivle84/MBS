using MBStest03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MBStest03.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public Command GoToCreateUserCommand { get; }
        public LoginPage()
        {
            InitializeComponent();
            //GoToCreateUserCommand = new Command(GoToCreateUserPage);
            imgDisp.Source = "splash.jpg";
            this.BindingContext = new LoginViewModel();
        }

  //      private async void GoToCreateUserPage(object obj)
		//{
  //          await Navigation.PopAsync();
  //          await Navigation.PushModalAsync(new CreateUserPage());
		//}
    }
}