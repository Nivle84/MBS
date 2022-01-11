using MBStest03.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MBStest03.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateUserPage : ContentPage
	{
		public CreateUserPage()
		{
			InitializeComponent();

			imgDisp.Source = "splash.jpg";
			this.BindingContext = new CreateUserViewModel();
		}
	}
}