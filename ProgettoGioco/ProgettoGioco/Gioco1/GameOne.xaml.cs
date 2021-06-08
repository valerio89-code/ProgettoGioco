using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoGioco.Gioco1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gioco1 : ContentPage
    {
        public int difficoltà = 0;
        public Gioco1()
        {
            InitializeComponent();
        }
        private async void btn_EnterGame_Clicked(object sender, EventArgs e)
        {
            if (rdbn_normale.IsChecked)
            {
                difficoltà = 1;
            }
            else if (rdbn_difficile.IsChecked)
            {
                difficoltà = 2;
            }
            else if (rdbn_impossibile.IsChecked)
            {
                difficoltà = 3;
            }
            await Navigation.PushAsync(new StartGameOne(difficoltà));
        }
    }
}