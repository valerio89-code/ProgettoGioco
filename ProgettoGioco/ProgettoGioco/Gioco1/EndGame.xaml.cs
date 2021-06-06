using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoGioco.Gioco1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndGame : ContentPage
    {
        public int Record { get; set; }
        public int RecordTemp { get; set; } = 0;
        public EndGame(int punteggio)
        {
            InitializeComponent();
            RecordTemp = Convert.ToInt32(lbl_record.Text);
            lbl_punteggio.Text = punteggio.ToString();
            lbl_record.Text = Record.ToString();            
            if (RecordTemp < punteggio)
            {
                lbl_record.Text = punteggio.ToString();
            }
        }

        private void btn_rigioca_Clicked(object sender, EventArgs e)
        {
            lbl_punteggio.Text = "0";
            Record = RecordTemp;
            Navigation.PopAsync();
            Navigation.PopAsync();
        }

        private void btn_esci_Clicked(object sender, EventArgs e)
        {
            lbl_punteggio.Text = "0";
            Record = RecordTemp;
            Navigation.PopAsync();
            Navigation.PopAsync();
            Navigation.PopAsync();
        }
    }
}