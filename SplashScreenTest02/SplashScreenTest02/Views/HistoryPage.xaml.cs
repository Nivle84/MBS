
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MBStest03.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        //public Command GoToMyStreamCommand { get; }
        public HistoryPage()
        {
            InitializeComponent();
            //GoToMyStreamCommand = new Command(GoToMyStream);
        }

  //      public async void GoToMyStream(object obj)
		//{
  //          await Shell.Current.GoToAsync("MyStreamPage");
		//}
    }
}