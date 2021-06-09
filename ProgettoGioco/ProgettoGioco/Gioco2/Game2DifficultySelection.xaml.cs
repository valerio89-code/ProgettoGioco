using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoGioco.Gioco2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game2DifficultySelection : ContentPage
    {
        public Game2DifficultySelection()
        {
            InitializeComponent();
        }

        private async void btn_difficultySelection_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var difficulty = btn.Text;
            int level = 1,
                lifes = difficulty == "Hard" ? 2 : 3;

            if (difficulty == "Impossible") lifes = 1;

            await Navigation.PushAsync(new Gioco2(level, lifes, difficulty));
        }
    }
}