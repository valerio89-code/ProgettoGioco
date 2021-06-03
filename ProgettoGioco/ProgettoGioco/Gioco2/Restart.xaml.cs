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
    public partial class Restart : ContentPage
    {
        public Restart()
        {
            InitializeComponent();
        }

        private async void btn_no_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void btn_yes_Clicked(object sender, EventArgs e)
        {

        }
    }
}