using SplashScreenTest02.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SplashScreenTest02.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyStreamGraphView : ContentView
	{
		public MyStreamGraphView()
		{
			//thisBindingContext = (MyStreamGraphViewModel)this.BindingContext;	//null
			InitializeComponent();
		}
	}
}