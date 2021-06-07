using System;
using System.Collections.Generic;
using System.Text;

namespace ProgettoGioco.Gioco3
{
    class Livello
    {
        public string NumeroLivello { get; private set; }
        public int CondizioneVittoria { get; private set; }
        public string Descrizione { get; private set; }

        public Livello(int numeroLivello, int condizioneVittoria)
        {
            NumeroLivello = $"Livello {numeroLivello}";
            CondizioneVittoria = condizioneVittoria;
            Descrizione = $"Obbiettivo: premi il bottone {condizioneVittoria} volte nel minor tempo possibile!";
        }
    }
}
