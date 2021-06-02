using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoGioco.Gioco1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartGameOne : ContentPage
    {
        public Stopwatch Tempo { get; set; } = new Stopwatch();
        public int Hit = 0;
        public int Miss = 0;
        public int contTemp = 0;
        public Stopwatch TempoAcceso { get; set; } = new Stopwatch();
        public Random rnd = new Random();
        public StartGameOne()
        {
            InitializeComponent();
            BindingContext = new StartGameOneViewModel();
            
        } 

        private void btn_CliccaImmagine_Clicked(object sender, EventArgs e)
        {
            Hit++;
            btn_CliccaImmagine.TranslationY = rnd.Next(-190, 190);
            btn_CliccaImmagine.TranslationX = rnd.Next(-190, 190);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Miss++;
            lbl_tempoStart.Text = Miss.ToString();
        }

        private void lbl_tempoStart_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (lbl_tempoStart.Text == "10")
            {
                Navigation.PopAsync();
            }
        }
    }
}