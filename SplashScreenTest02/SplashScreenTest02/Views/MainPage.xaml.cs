using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MBStest03.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        //MainPageVM mpVM = new MainPageVM();
        public MainPage()
        {
            InitializeComponent();
        }

        //private void GoodMood_Clicked(object sender, EventArgs e)
        //{
        //    mpVM_CB.ThisMood = mpVM_CB.goodMood;
        //}

        //private void OkMood_Clicked(object sender, EventArgs e)
        //{
        //    mpVM_CB.ThisMood = mpVM_CB.okMood;
        //}

        //private void BadMood_Clicked(object sender, EventArgs e)
        //{
        //    mpVM_CB.ThisMood = mpVM_CB.badMood;
        //}
    }
}