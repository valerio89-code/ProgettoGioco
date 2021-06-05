using ProgettoGioco.Gioco2;
using System;
using Xamarin.Forms;

namespace ProgettoGioco
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //da modificare dal gruppo 1
            //Navigation.PushAsync(new  )
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //da modificare dal gruppo 2
            int level = 1,
                lifes = 3;

            await Navigation.PushAsync(new GiocoSequenza(level, lifes));
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            //da modificare dal gruppo 3
            //Navigation.PushAsync(new  )
        }
    }
}
