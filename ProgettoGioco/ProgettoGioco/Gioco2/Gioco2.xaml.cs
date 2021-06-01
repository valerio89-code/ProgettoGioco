﻿using System;
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
        public static Timer timer;
        public int IndiceSequenza { get; set; } = 0;
        public int[] Sequenza { get; set; }
        public int CifreSequenza { get; set; }
        public GiocoSequenza(int livello)
        {
            InitializeComponent();

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

                default: CifreSequenza = 9;
                    break;
            }
            Sequenza = new int[CifreSequenza];
            for (int i = 0; i < CifreSequenza; i++)
            {
                Random rnd = new Random();
                Sequenza[i] = rnd.Next(0, 9);
            }

        }

        private void btn_uno_Clicked(object sender, EventArgs e)
        {
            if (VerificaInput(1, Sequenza[IndiceSequenza]))
            {
                btn_uno.BackgroundColor = Color.Green;
                timer = new Timer(1000);
                timer.Enabled = true;
                btn_uno.BackgroundColor = Color.Default;
            }
        }

        private void btn_due_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_tre_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_quattro_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_cinque_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_sei_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_sette_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_otto_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_nove_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_zero_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_exit_Clicked(object sender, EventArgs e)
        {

        }
        private bool VerificaInput(int numInserito, int numSequenza)
        {
            return numInserito == numSequenza;
        }
    }
}