using SplashScreenTest02.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SplashScreenTest02.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}