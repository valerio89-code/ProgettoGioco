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

        private void Button_Clicked(object sender, EventArgs e)
        {
            //da modificare dal gruppo 1
            //Navigation.PushAsync(new  )
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //da modificare dal gruppo 2
            await Navigation.PushAsync(new Gioco2());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            //da modificare dal gruppo 3
            //Navigation.PushAsync(new  )
        }
    }
}
