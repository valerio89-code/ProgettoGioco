using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoGioco.Gioco3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageGioco3 : ContentPage
    {
        public MainPageGioco3()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Gioco3());
        }
    }
}