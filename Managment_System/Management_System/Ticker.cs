using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.ComponentModel;

namespace Management_System
{
    //Represnet Timer ticking class
    public class Ticker : INotifyPropertyChanged
    {
        Timer timer;
        public Ticker()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1 second updates
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        //Get the date of now
        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Now"));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
