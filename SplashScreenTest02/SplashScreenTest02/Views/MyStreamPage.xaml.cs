
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MBStest03.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /*
     * Brug de erfaringer du har gjort undervejs i projektet til at lave 'Min Å' korrekt!
     * Brug selve denne side som bund for forskellige views (grafen er ét view med sin egen viewmodel og kan
     * derfor fungere uafhængigt og genbruges andre steder, og ligeledes er "største påvirkninger" sit eget).
     * Disse bliver så bare komponenter på siden 'Min Å', og deklareret/brugt sådan i xaml.
     */
    public partial class MyStreamPage : ContentPage
    {
        public MyStreamPage()
        {
            InitializeComponent();
        }
    }
}