using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public Plugin.SimpleAudioPlayer.ISimpleAudioPlayer Player { get; set; }
        public Gioco1()
        {
            InitializeComponent();
            Player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            Player.Load(GetStream("canzone 3 appù.mp3"));
            Player.Play();
        }
        private Stream GetStream(string fileName)
        {
            var assembry = typeof(App).GetTypeInfo().Assembly;
            var stream = assembry.GetManifestResourceStream($"ProgettoGioco.Gioco1.Canzoni.{fileName}");
            return stream;
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
            Player.Stop();
            await Navigation.PushAsync(new StartGameOne(difficoltà));
            
        }
    }
}