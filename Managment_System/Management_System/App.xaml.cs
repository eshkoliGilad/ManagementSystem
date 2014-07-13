using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace Management_System
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Gets the application process and checks if it it already opened
            string RunningProcess = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(RunningProcess);
            if (processes.Length > 1)
            {
                MessageBox.Show("המערכת ניהול כבר מופעלת, אין באפשרותך לפתוח אותה שוב");
                Application.Current.Shutdown();
            }
            base.OnStartup(e);
            EventManager.RegisterClassHandler(typeof(DatePicker),
                DatePicker.LoadedEvent,
                new RoutedEventHandler(DatePicker_Loaded));
        }




        public static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        //DatePicker text overloading for every DatePicker in the Application
        void DatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            var dp = sender as DatePicker;
            if (dp == null) return;

            var tb = GetChildOfType<DatePickerTextBox>(dp);
            if (tb == null) return;

            var wm = tb.Template.FindName("PART_Watermark", tb) as ContentControl;
            if (wm == null) return;

            wm.Content = "בחר תאריך";
        }

    }
}
