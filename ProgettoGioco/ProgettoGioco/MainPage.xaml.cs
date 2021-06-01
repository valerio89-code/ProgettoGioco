using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoGioco
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Gioco1.Gioco1());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //da modificare dal gruppo 2
            //Navigation.PushAsync(new  )
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            //da modificare dal gruppo 3
            //Navigation.PushAsync(new  )
        }
    }
}
