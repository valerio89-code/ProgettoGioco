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
        
        public Gioco1()
        {
            InitializeComponent();
        }
        private async void btn_EnterGame_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartGameOne());
        }
    }
}