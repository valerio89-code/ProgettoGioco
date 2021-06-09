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


        public Gioco1()
        {
            InitializeComponent();            
        }

        private void btn_EnterGame_Clicked(object sender, EventArgs e)
        {
           var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(GetStream("Start.mp3"));
            player.Play();
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
            Navigation.PushAsync(new StartGameOne(difficoltà));

        }
        private Stream GetStream(string fileName)
        {
            var assembry = typeof(App).GetTypeInfo().Assembly;
            var stream = assembry.GetManifestResourceStream($"ProgettoGioco.Gioco1.Canzoni.{fileName}");
            return stream;
        }
    }
}