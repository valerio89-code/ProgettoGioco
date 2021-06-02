using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace ProgettoGioco
{
    public class StartGameOneViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Stopwatch Tempo { get; set; } = new Stopwatch();
        private string stopWatchSeconds;
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
