using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Timers;
using Xamarin.Forms;

namespace ProgettoGioco
{
    public class StartGameOneViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Stopwatch Tempo { get; set; } = new Stopwatch();
        private string stopWatchSeconds;
        private string facile;
        private string normale;
        private string difficile;
        private string impossibile;
        public string temp;
        public string Temps { get { return temp; } set { temp = value; OnPropertyChanged("temp"); } }
        public string Facile { get { return facile; } set { facile = value; OnPropertyChanged("Facile"); } }
        public string Normale { get { return normale; } set { normale = value; OnPropertyChanged("Normale"); } }
        public string Difficile { get { return difficile; } set { difficile = value; OnPropertyChanged("Difficile"); } }
        public string Impossibile { get { return impossibile; } set { impossibile = value; OnPropertyChanged("Impossibile"); } }
        public string temp;
        public string Temps { get { return temp; } set { temp = value; OnPropertyChanged("Temps"); } }
        

        public string StopWatchSecond
        {
            get { return stopWatchSeconds; }
            set { stopWatchSeconds = value; OnPropertyChanged("StopWatchSecond"); }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }

        public StartGameOneViewModel()
        {
            Tempo.Start();
            Temps = Tempo.Elapsed.Seconds.ToString();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Temps = Tempo.Elapsed.Seconds.ToString();
                return true;
            });
            Tempo.Start();
            Facile = Tempo.Elapsed.Seconds.ToString();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Facile = Tempo.Elapsed.Seconds.ToString();
                return true;
            });

            Tempo.Start();
            Normale = Tempo.Elapsed.Milliseconds.ToString();
            Device.StartTimer(TimeSpan.FromMilliseconds(750), () =>
            {
                Normale = Tempo.Elapsed.Milliseconds.ToString();
                return true;
            });

            Tempo.Start();
            Difficile = Tempo.Elapsed.Milliseconds.ToString();
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                Difficile = Tempo.Elapsed.Milliseconds.ToString();
                return true;
            });

            Tempo.Start();
            Impossibile = Tempo.Elapsed.Milliseconds.ToString();
            Device.StartTimer(TimeSpan.FromMilliseconds(250), () =>
            {
                Impossibile = Tempo.Elapsed.Milliseconds.ToString();
                return true;
            });

            StopWatchSecond = Tempo.Elapsed.Seconds.ToString();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                StopWatchSecond = Tempo.Elapsed.Seconds.ToString();
                return true;
            }
            );
        }
    }
}
