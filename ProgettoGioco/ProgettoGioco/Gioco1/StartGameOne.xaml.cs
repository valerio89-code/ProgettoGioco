using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Media;
using System.Reflection;
using Stream = System.IO.Stream;

namespace ProgettoGioco.Gioco1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartGameOne : ContentPage
    {
        public int punteggio = 0;
        public int uscita = 0;
        int difficoltàSelezionata;
        public Plugin.SimpleAudioPlayer.ISimpleAudioPlayer Player { get; set; }

        public Random rnd = new Random();
        public MediaPlayer player;
        public StartGameOne(int difficoltà)
        {
            InitializeComponent();
            BindingContext = new StartGameOneViewModel();
            difficoltàSelezionata = difficoltà;
            Player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            Player.Load(GetStream("canzone 2 app.mp3"));
            Player.Play();
        }

        private void btn_CliccaImmagine_Clicked(object sender, EventArgs e)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(GetStream("hit.mp3"));
            player.Play();
            punteggio++;
            lbl_punteggioGame.Text = $"Punteggio: {punteggio}";
            btn_CliccaImmagine.IsVisible = false;
        }
        private Stream GetStream(string fileName)
        {
            var assembry = typeof(App).GetTypeInfo().Assembly;
            var stream = assembry.GetManifestResourceStream($"ProgettoGioco.Gioco1.Canzoni.{fileName}");
            return stream;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(GetStream("miss.mp3"));
            player.Play();
            punteggio--;
            if (punteggio < 0)
            {
                punteggio = 0;
            }
            lbl_punteggioGame.Text = $"Punteggio: {punteggio}";
        }

        private void lbl_tempoStart_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (lbl_tempoStart.Text == "20" && uscita == 0)
            {
                Navigation.PushAsync(new EndGame(punteggio,difficoltàSelezionata));
                uscita = 1;
                //Player.Stop();
            }
        }
        private void lbl_Timer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void lbl_facile_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (difficoltàSelezionata == 0)
            {
                btn_CliccaImmagine.IsVisible = true;
                btn_CliccaImmagine.TranslationY = rnd.Next(-190, 190);
                btn_CliccaImmagine.TranslationX = rnd.Next(-190, 190);
            }
        }

        private void lbl_normale_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (difficoltàSelezionata == 1)
            {
                btn_CliccaImmagine.IsVisible = true;
                btn_CliccaImmagine.TranslationY = rnd.Next(-190, 190);
                btn_CliccaImmagine.TranslationX = rnd.Next(-190, 190);
            }
        }

        private void lbl_difficile_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (difficoltàSelezionata == 2)
            {
                btn_CliccaImmagine.IsVisible = true;
                btn_CliccaImmagine.TranslationY = rnd.Next(-190, 190);
                btn_CliccaImmagine.TranslationX = rnd.Next(-190, 190);
            }
        }

        private void lbl_impossibile_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (difficoltàSelezionata == 3)
            {
                btn_CliccaImmagine.IsVisible = true;
                btn_CliccaImmagine.TranslationY = rnd.Next(-190, 190);
                btn_CliccaImmagine.TranslationX = rnd.Next(-190, 190);
            }
        }
    }
}