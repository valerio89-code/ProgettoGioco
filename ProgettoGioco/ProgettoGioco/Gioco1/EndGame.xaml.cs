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
        public int difficoltà;
        public EndGame(int punteggio,int difficoltàSeleionata)
        {
            InitializeComponent();
            if (difficoltàSeleionata == 0)
            {
                if (punteggio >= 15)
                {
                    img_win.IsVisible = true;
                }
                else if(punteggio < 15)
                    img_lose.IsVisible = true;
            }
            else if(difficoltàSeleionata == 1)
            {
                if(punteggio >= 10)
                {
                    img_win.IsVisible = true;
                }
                else if (punteggio < 10)
                    img_lose.IsVisible = true;
            }
            else if (difficoltàSeleionata == 2)
            {
                if (punteggio >= 7)
                {
                    img_win.IsVisible = true;
                }
                else if (punteggio < 7)
                    img_lose.IsVisible = true;
            }
            else if (difficoltàSeleionata == 3)
            {
                if (punteggio >= 4)
                {
                    img_win.IsVisible = true;
                }
                else if (punteggio < 4)
                    img_lose.IsVisible = true;
            }
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