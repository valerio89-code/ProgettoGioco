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
        public Random rnd = new Random();
        public StartGameOne()
        {
            InitializeComponent();
        }
        private void btn_Start_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_CliccaImmagine_Clicked(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

            Miss++;
            lbl_tempoStart.Text = Miss.ToString();
        }
    }
}