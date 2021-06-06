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
        private string stopWatchMilliseconds;

        public string StopWatchMillisecond
        {
            get { return stopWatchMilliseconds; }
            set { stopWatchMilliseconds = value; OnPropertyChanged("StopWatchMillisecond"); }
        }

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
            StopWatchMillisecond = Tempo.Elapsed.Milliseconds.ToString();
            Device.StartTimer(TimeSpan.FromMilliseconds(400), () =>
            {
                StopWatchMillisecond = Tempo.Elapsed.Milliseconds.ToString();
                return true;
            }
            );
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
