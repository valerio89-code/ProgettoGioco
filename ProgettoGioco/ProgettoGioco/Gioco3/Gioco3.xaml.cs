using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoGioco.Gioco3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gioco3 : ContentPage
    {
        //livelli
        static readonly Livello Livello1 = new Livello(1, 10);
        static readonly Livello Livello2 = new Livello(2, 20);
        static readonly Livello Livello3 = new Livello(3, 30);
        static readonly Livello Livello4 = new Livello(4, 45);
        static readonly Livello Livello5 = new Livello(5, 60);

        //lista livelli
        readonly List<Livello> Livelli = new List<Livello>() { Livello1, Livello2, Livello3, Livello4, Livello5 };

        //field necessari per ciclare i livelli
        int position = 0;
        int levelsCompleted = 0;
        Livello livello;

        //field necessari per singoli livelli
        int clickCounter;
        static readonly Stopwatch timerLivello = new Stopwatch();
        static readonly Stopwatch timerGioco = new Stopwatch();

        public Gioco3()
        {
            InitializeComponent();
            ShowLevel();
            NavigationPage.SetHasBackButton(this, false);
            new ToolbarItem() { IconImageSource = "home.png" };
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Reset();
            await Navigation.PushAsync(new MainPageGioco3());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            clickCounter++;
            if (clickCounter == 1)
            {
                timerLivello.Start();
                timerGioco.Start();
            }

            lbl_clickCounter.Text = clickCounter.ToString();

            if (clickCounter == livello.CondizioneVittoria)
            {
                btnClicca.IsEnabled = false;
                timerLivello.Stop();

                if (timerLivello.Elapsed.TotalSeconds <= 5)
                {
                    if (levelsCompleted == Livelli.Count - 1)
                        HaiFinitoIlGioco();
                    else
                        HaiVinto();
                }
                else
                    HaiPerso();
            }
        }

        private async void HaiVinto()
        {
            PlaySound("VincitaLivello.wav");
            await ShowMessage("Vittoria!", $"Hai superato il livello in {timerLivello.Elapsed.Seconds},{timerLivello.Elapsed.Milliseconds} secondi", "Vai al livello successivo", " ");
            NextLevel();
            ShowLevel();
        }

        private async void HaiPerso()
        {
            PlaySound("Perso.wav");
            await ShowMessage("", "Troppo lento!", "Riprova", " ");
            Reset();
            ShowLevel();
        }

        private async void HaiFinitoIlGioco()
        {
            PlaySound("VincitaFinale.wav");
            timerGioco.Stop();
            await ShowMessage("Hai Vinto!", $"Hai superato l'ultimo livello in {timerLivello.Elapsed.Seconds},{timerLivello.Elapsed.Milliseconds} secondi", "Continua", " ");
            ShowFinalPageLayout();
        }

        private async Task ShowMessage(string title, string message, string accept, string cancel)
        {
            var result = await DisplayAlert(title, message, accept, cancel);
            while (!result)
                result = await DisplayAlert(title, message, accept, cancel);
        }

        private void btnRigioca_Clicked(object sender, EventArgs e)
        {
            ShowGameLayout();

            Reset();
            ShowLevel();
        }

        private async void Exit_Clicked(object sender, EventArgs e)
        {
            Reset();
            await Navigation.PushAsync(new MainPage());
        }

        private async void btnMenuPrincipale_Clicked(object sender, EventArgs e)
        {
            Reset();
            await Navigation.PushAsync(new MainPageGioco3());
        }

        private void ShowGameLayout()
        {
            lbl_clickCounter.IsVisible = true;
            btnClicca.IsVisible = true;
            messaggioFinale.IsVisible = false;
            lbl_Sottotitolo.IsVisible = true;
            lbl_PunteggioFinale.IsVisible = false;
            imageTrophy.IsVisible = false;
        }

        private void ShowFinalPageLayout()
        {
            lbl_clickCounter.IsVisible = false;
            btnClicca.IsVisible = false;
            messaggioFinale.IsVisible = true;
            lbl_Sottotitolo.IsVisible = false;
            lbl_PunteggioFinale.IsVisible = true;
            imageTrophy.IsVisible = true;
            lbl_Livello.Text = $"Vittoria!";
            lbl_PunteggioFinale.Text = $"Hai completato il gioco in \n {timerGioco.Elapsed.Seconds}.{timerGioco.Elapsed.Milliseconds} secondi";
        }

        void ShowLevel()
        {
            livello = Livelli[position];
            lbl_Livello.Text = livello.NumeroLivello;
            lbl_Sottotitolo.Text = livello.Descrizione;
            lbl_clickCounter.Text = "0";
            btnClicca.IsEnabled = true;
        }

        void NextLevel()
        {
            timerLivello.Reset();
            levelsCompleted++;
            clickCounter = 0;
            position++;
        }

        void Reset()
        {
            timerLivello.Reset();
            timerGioco.Reset();
            levelsCompleted = 0;
            clickCounter = 0;
            position = 0;
        }

        private void PlaySound(string nomeFile)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(GetStream(nomeFile));
            player.Play();
        }

        private Stream GetStream(string fileName)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"ProgettoGioco.Gioco3.{fileName}");
            return stream;
        }
    }
}
