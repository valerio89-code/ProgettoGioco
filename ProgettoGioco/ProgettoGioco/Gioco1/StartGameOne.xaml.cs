﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;

namespace ProgettoGioco.Gioco1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartGameOne : ContentPage
    {
        public int punteggio = 0;
        public int uscita = 0;
        public Random rnd = new Random();
        public Timer timer;
        public StartGameOne()
        {
            InitializeComponent();
        BindingContext = new StartGameOneViewModel();
        } 

        private void btn_CliccaImmagine_Clicked(object sender, EventArgs e)
        {
            punteggio++;
            lbl_punteggioGame.Text = $"Punteggio: {punteggio}";
            btn_CliccaImmagine.IsVisible = false;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            punteggio--;
            if(punteggio < 0)
            {
                punteggio = 0;
            }
            lbl_punteggioGame.Text = $"Punteggio: {punteggio}";
        }

        private void lbl_tempoStart_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
            if (lbl_tempoStart.Text == "20" && uscita == 0)
            {
                Navigation.PushAsync(new EndGame(punteggio));
                uscita = 1;
            }
        }
        private void lbl_Timer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            btn_CliccaImmagine.IsVisible = true;
            btn_CliccaImmagine.TranslationY = rnd.Next(-190, 190);
            btn_CliccaImmagine.TranslationX = rnd.Next(-190, 190);
        }
    }
}