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
                if(numVite != value)
                {
                    numVite = value;
                    OnPropertyChanged();
                }
            }
        }

        private int livello;
        public int Livello
        {
            get { return livello; }
            set {
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

            InitializationValues(livello, vite);

            BindingContext = this;
        }

        private void btn_start_Clicked(object sender, EventArgs e)
        {
            btn_start.IsVisible = false;
            gridBottoni.IsVisible = true;

            ShowSequence();
        }

        private async void btn_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var verifica = VerificaInput(int.Parse(btn.Text), Sequenza[IndiceSequenza]);

            btn.BackgroundColor = verifica ? Color.Green : Color.Red;

            await Task.Delay(250);

            btn.BackgroundColor = Color.White;

            lbl_inputNumber.Text += $"{btn.Text}";

            CasiBottone(verifica);
        }

        private async void btn_exit_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Uscita", "Vuoi uscire?", "Si", "No"))
            {
                var dimStack = Navigation.NavigationStack.Count;
                ResetStack(dimStack);
            }
        }

        private void CasiBottone(bool verifica)
        {
            var ultimoIndice = CifreSequenza - 1;

            if (verifica && IndiceSequenza < ultimoIndice)
                IndiceSequenza++;
            else if (verifica && IndiceSequenza == ultimoIndice)
            {
                lbl_result.Text = "";
                lbl_result.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                lbl_result.Text = "Livello completato";

                NewLevel();
            }
            else
            {
                NumVite--;
                if (NumVite == 0)
                {
                    lbl_result.Text = "";
                    lbl_result.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                    lbl_result.Text = "Hai perso";

                    RestartGame();
                }
            }
        }

        private void InitializationValues(int livello, int vite)
        {
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
        private async void ResetStack(int numPagine)
        {
            for (var counter = 1; counter < numPagine; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
            }
            await Navigation.PopAsync();
        }
        private async void RestartGame()
        {
            if (await DisplayAlert("Hai perso", "Vuoi ricominciare la partita?", "Si", "No"))
            {
                ResetStack(Livello + 1);
                await Navigation.PushAsync(new GiocoSequenza(1, 3));
            }
            else
            {
                ResetStack(Livello);
            }
        }
        private async void ShowSequence()
        {
            var buttons = ListaBottoni();

            foreach (var randomNumber in Sequenza)
            {
                var btn = buttons.First(x => x.Text == randomNumber.ToString());
                btn.BorderColor = Color.Green;

                await Task.Delay(1000);

                btn.BorderColor = Color.White;

                await Task.Delay(1000);
            }

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