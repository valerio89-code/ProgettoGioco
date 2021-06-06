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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            grid_difficulties.IsVisible = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //da modificare dal gruppo 1
            //Navigation.PushAsync(new  )
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //da modificare dal gruppo 2
            grid_difficulties.IsVisible = !grid_difficulties.IsVisible;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            //da modificare dal gruppo 3
            //Navigation.PushAsync(new  )
        }

        private async void btn_gioco2_difficulty_Clicked(object sender, EventArgs e)
        {
            int level = 1,
                lifes = 3;

            var btn = (Button)sender;

            await Navigation.PushAsync(new GiocoSequenza(level, lifes, btn.Text));
        }
    }
}
