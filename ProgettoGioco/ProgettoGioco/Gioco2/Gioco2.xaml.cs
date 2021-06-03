using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoGioco.Gioco2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GiocoSequenza : ContentPage
    {
        public int IndiceSequenza { get; set; } = 0;
        public int[] Sequenza { get; set; }
        public int CifreSequenza { get; set; }
        public int NumVite { get; set; }
        public int Livello { get; set; }
        public GiocoSequenza(int livello, int vite)
        {
            InitializeComponent();

            NumVite = vite;
            Livello = livello;
            switch (livello)
            {
                case 1:
                    CifreSequenza = 4;
                    break;
                case 2:
                    CifreSequenza = 5;
                    break;
                case 3:
                    CifreSequenza = 6;
                    break;
                case 4:
                    CifreSequenza = 7;
                    break;
                case 5:
                    CifreSequenza = 8;
                    break;

                default:
                    CifreSequenza = 9;
                    break;
            }
            Sequenza = new int[CifreSequenza];
            for (int i = 0; i < CifreSequenza; i++)
            {
                Random rnd = new Random();
                Sequenza[i] = rnd.Next(0, 9);
            }
            foreach (var item in Sequenza)
            {
                lbl_randomNumber.Text += $"{item}";
            }
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var verifica = VerificaInput(int.Parse(btn.Text), Sequenza[IndiceSequenza]);

            btn.BackgroundColor = verifica ? Color.Green : Color.Red;

            var timer = new Timer(1000);
            timer.Enabled = true;

            btn.BackgroundColor = Color.Default;

            CasiBottone(verifica);
        }

        private async void btn_exit_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Uscita", "Vuoi uscire?", "Si", "No"))
            {
                ResetStack(Livello);
            }
        }

        private void CasiBottone(bool verifica)
        {
            var ultimoIndice = CifreSequenza - 1;

            if (verifica && IndiceSequenza < ultimoIndice)
                IndiceSequenza++;
            else if (verifica && IndiceSequenza == ultimoIndice)
            {
                lbl_randomNumber.Text = "";
                lbl_randomNumber.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                lbl_randomNumber.Text = "Livello completato";

                NewLevel();
            }
            else
            {
                NumVite--;
                if (NumVite == 0)
                {
                    lbl_randomNumber.Text = "";
                    lbl_randomNumber.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                    lbl_randomNumber.Text = "Hai perso";

                    RestartGame();
                }
            }
        }
        private bool VerificaInput(int numInserito, int numSequenza)
        {
            return numInserito == numSequenza;
        }

        private async void NewLevel()
        {
            Livello++;

            await Navigation.PushAsync(new GiocoSequenza(Livello, NumVite));
        }
        private async void RestartGame()
        {
            if (await DisplayAlert("Ricomincia", "Vuoi ricominciare la partita?", "Si", "No"))
            {
                ResetStack(Livello + 1);
                await Navigation.PushAsync(new GiocoSequenza(1, 3));
            }
            else
                ResetStack(Livello);
        }

        private async void ResetStack(int numPagine)
        {
            for (var counter = 1; counter < numPagine; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            await Navigation.PopAsync();
        }
    }
}