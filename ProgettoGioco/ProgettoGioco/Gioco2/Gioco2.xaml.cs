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
        public int SequenceIndex { get; set; } = 0;
        public int[] Sequence { get; set; }
        public int SequenceDigits { get; set; }
        private int lifes;
        public int Lifes
        {
            get => lifes;
            set
            {
                if (Lifes != value)
                {
                    Lifes = value;
                    OnPropertyChanged();
                }
            }
        }
        private int maxLevel = 5;
        private int level;
        public int Level
        {
            get => level;
            set
            {
                if (level != value)
                {
                    level = value;
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

            ButtonsManager.ShowSequence(GetButtons(), Sequence);
        }

        private async void btn_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var verifica = VerifyInput(int.Parse(btn.Text), Sequence[SequenceIndex]);

            await ButtonsManager.ColorButton(btn, verifica);

            ClickManager(verifica, btn.Text);
        }

        private async void btn_exit_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Uscita", "Vuoi uscire?", "Si", "No")) await Exit();
        }

        private void InitializeValues(int level, int lifes)
        {
            Lifes = lifes;
            Level = level;

            var digits = new int[] { 4, 5, 6, 7, 8 };

            SequenceDigits = digits[level - 1];

            Sequence = new int[SequenceDigits];
            for (int i = 0; i < SequenceDigits; i++)
            {
                Random rnd = new Random();
                Sequence[i] = rnd.Next(0, 9);
            }
        }

        private async void ClickManager(bool verifica, string enteredNumber)
        {
            if (verifica)
            {
                lbl_inputNumber.Text += enteredNumber;
                RightChoiceHandler();
            }
            else
            {
                Lifes--;
                if (Lifes == 0)
                {
                    await Defeat();
                }
            }
        }

        private void RightChoiceHandler()
        {
            var lastIndex = SequenceDigits - 1;

            if (SequenceIndex < lastIndex)
                SequenceIndex++;
            else if (SequenceIndex == lastIndex)
            {
                lbl_result.Text = "Livello completato";

                LevelCompletedHandler();
            }
        }

        private async Task Defeat()
        {
            lbl_result.Text = "Hai perso";

            if (await DisplayAlert("Hai perso", "Vuoi ricominciare la partita?", "Si", "No"))
                await RestartGame("lost");
            else await Exit();
        }

        private bool VerifyInput(int enteredNumber, int sequenceNumber)
        {
            return enteredNumber == sequenceNumber;
        }

        private async void LevelCompletedHandler()
        {
            if (Level == maxLevel) await Win();

            await NewLevel();
        }

        private async Task NewLevel()
        {
            if (await DisplayAlert($"Livello {Level} completato", "Vuoi proseguire al livello successivo?", "Si", "No"))
            {
                Level++;

                await Navigation.PushAsync(new GiocoSequenza(Level, Lifes));
            }
            else await Exit();
        }

        private async Task Win()
        {
            if (await DisplayAlert("Vittoria", $"Hai completato il gioco,{Environment.NewLine} Vuoi ricominciare?", "Si", "No"))
                await RestartGame("won");
            else await Exit();
        }

        private async Task Exit()
        {
            await Navigation.PopToRootAsync();
        }

        private async Task RestartGame(string winLose)
        {
            var pagesToRemove = winLose == "won" ? Level : Level + 1;
            for (var counter = 1; counter < pagesToRemove; counter++)
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

            await Navigation.PopAsync();

            await Navigation.PushAsync(new GiocoSequenza(1, 3));
        }

        private List<Button> GetButtons()
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