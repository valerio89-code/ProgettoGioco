using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

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
            var changed = PropertyChanged; if (changed != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }



        }

    }
}
