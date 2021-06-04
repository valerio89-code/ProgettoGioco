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
        private int numVite;
        public int NumVite
        {
            get
            {
                return numVite;
            }
            set
            {
                if (numVite != value)
                {
                    numVite = value;
                    OnPropertyChanged();
                }
            }
        }

        private int maxLevel = 5;
        private int livello;
        public int Livello
        {
            get { return livello; }
            set
            {
                if (livello != value)
                {
                    livello = value;
                    OnPropertyChanged();
                }
            }
        }
        public GiocoSequenza(int livello, int vite)
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);

            InitializeValues(livello, vite);

            BindingContext = this;
        }

        private void btn_start_Clicked(object sender, EventArgs e)
        {
            btn_start.IsVisible = false;
            gridBottoni.IsVisible = true;

            var buttons = ListaBottoni();

            ShowSequence(buttons);
        }

        private async void btn_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var verifica = VerificaInput(int.Parse(btn.Text), Sequenza[IndiceSequenza]);

            btn.BorderColor = btn.BackgroundColor = verifica ? Color.Green : Color.Red;

            await Task.Delay(250);

            btn.BorderColor = btn.BackgroundColor = Color.White;

            GestioneClick(verifica, btn.Text);
        }

        private async void btn_exit_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Uscita", "Vuoi uscire?", "Si", "No"))
            {
                Exit();
            }
        }

        private void GestioneClick(bool verifica, string numeroInserito)
        {
            var ultimoIndice = CifreSequenza - 1;

            if (verifica)
            {
                if (IndiceSequenza < ultimoIndice)
                    IndiceSequenza++;
                else if (IndiceSequenza == ultimoIndice)
                {
                    lbl_result.Text = string.Empty;
                    lbl_result.Text = "Livello completato";

                    NewLevel();
                }

                lbl_inputNumber.Text += $"{numeroInserito}";
            }
            else
            {
                NumVite--;
                if (NumVite == 0)
                {
                    lbl_result.Text = string.Empty;
                    lbl_result.Text = "Hai perso";

                    RestartGame();
                }
            }
        }

        private void InitializeValues(int livello, int vite)
        {
            NumVite = vite;
            Livello = livello;

            var cifre = new int[] { 4, 5, 6, 7, 8 };

            CifreSequenza = cifre[livello - 1];

            Sequenza = new int[CifreSequenza];
            for (int i = 0; i < CifreSequenza; i++)
            {
                Random rnd = new Random();
                Sequenza[i] = rnd.Next(0, 9);
            }
        }
        private bool VerificaInput(int numInserito, int numSequenza)
        {
            return numInserito == numSequenza;
        }

        private async void NewLevel()
        {
            if (Livello == maxLevel)
            {
                //await Navigation.PushAsync(new WinPage());
                Exit();
            }
            Livello++;

            await Navigation.PushAsync(new GiocoSequenza(Livello, NumVite));
        }

        private void Exit()
        {
            Navigation.PopToRootAsync();
        }

        private async void BackToLevelOne()
        {
            for (var counter = 1; counter < Livello + 1; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }

            await Navigation.PopAsync();
        }
        private async void RestartGame()
        {
            if (await DisplayAlert("Hai perso", "Vuoi ricominciare la partita?", "Si", "No"))
            {
                BackToLevelOne();

                await Navigation.PushAsync(new GiocoSequenza(1, 3));
            }
            else
            {
                Exit();
            }
        }
        private async void ShowSequence(List<Button> buttons)
        {
            foreach (var randomNumber in Sequenza)
            {
                var btn = buttons.First(x => x.Text == randomNumber.ToString());
                btn.BorderColor = Color.Green;

                await Task.Delay(1000);

                btn.BorderColor = Color.White;

                await Task.Delay(1000);
            }

            EnableButtons(buttons);
        }

        private static void EnableButtons(List<Button> buttons)
        {
            foreach (var button in buttons)
            {
                button.IsEnabled = true;
            }
        }

        private List<Button> ListaBottoni()
        {
            List<Button> buttons = new List<Button>
            {
                btn_zero,
                btn_uno,
                btn_due,
                btn_tre,
                btn_quattro,
                btn_cinque,
                btn_sei,
                btn_sette,
                btn_otto,
                btn_nove
            };

            return buttons;
        }
    }
}