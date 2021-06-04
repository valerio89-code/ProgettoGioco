using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoGioco.Gioco1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gioco1 : ContentPage
    {
       public static int Hit { get; set; }
       public static int Miss { get; set; }
        





        public Gioco1()
        {
            InitializeComponent();
            lbl_hit.Text = $"Hit: {hit}";
            lbl_miss.Text = $"Miss: { miss}";
            lbl_punteggio.Text = $"Punteggio: {hit-miss}";
        }
        private async void btn_EnterGame_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartGameOne());
        }
    }
}