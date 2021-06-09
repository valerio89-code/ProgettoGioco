using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoGioco.Gioco1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndGame : ContentPage
    {
        public int difficoltà;
        public EndGame(int punteggio, int difficoltàSeleionata)
        {
            InitializeComponent();
            lbl_punteggio.Text = punteggio.ToString();
            if (difficoltàSeleionata == 0)
            {
                if (punteggio >= 15)
                {
                    img_win.IsVisible = true;

                }
                else if (punteggio < 15)
                    img_lose.IsVisible = true;

            }
            else if (difficoltàSeleionata == 1)
            {
                if (punteggio >= 10)
                {
                    img_win.IsVisible = true;

                }
                else if (punteggio < 10)
                    img_lose.IsVisible = true;
            }
            else if (difficoltàSeleionata == 2)
            {
                if (punteggio >= 7)
                {
                    img_win.IsVisible = true;

                }
                else if (punteggio < 7)
                    img_lose.IsVisible = true;
            }
            else if (difficoltàSeleionata == 3)
            {
                if (punteggio >= 4)
                {
                    img_win.IsVisible = true;

                }
                else if (punteggio < 4)
                {
                    img_lose.IsVisible = true;

                }                
            }
            if (img_win.IsVisible == true)
            {
                var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                player.Load(GetStream("Win.mp3"));
                player.Play();
            }
            else
            {
                var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                player.Load(GetStream("Lose.mp3"));
                player.Play();
            }
        }
        private Stream GetStream(string fileName)
        {
            var assembry = typeof(App).GetTypeInfo().Assembly;
            var stream = assembry.GetManifestResourceStream($"ProgettoGioco.Gioco1.Canzoni.{fileName}");
            return stream;
        }

        private void btn_rigioca_Clicked(object sender, EventArgs e)
        {
            lbl_punteggio.Text = "0";
            Navigation.PopAsync();
        }

        private void btn_esci_Clicked(object sender, EventArgs e)
        {
            lbl_punteggio.Text = "0";
            Navigation.PopAsync();
            Navigation.PopAsync();
        }
    }
}