using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Management_System
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : UserControl
    {
        List<Report> items;
        List<string> temp;
        SqlDB db;
        private class Report{
            public string Address { get; set; }

            public override string ToString()
            {
                return this.Address;
            }
    }

        public Reports()
        {
            InitializeComponent();
            if (SqlDB.isOnline)
            {
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(@"/Management_System;component/Resources/online.png", UriKind.Relative);
                logo.EndInit();
                stateOfDB.Source = logo;
            }
            else
            {
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(@"/Management_System;component/Resources/offline.png", UriKind.Relative);
                logo.EndInit();
                stateOfDB.Source = logo;
            }
            db = new SqlDB();
            items = new List<Report>();
            string address;
            temp = db.UpdateBuildingsList();
            string [] temp1 =temp.ToArray();


            for (int i = 0; i < temp1.Length; i++)
            {
                address = temp[i];
                Report report = new Report();
                report.Address = address;
                items.Add(report);
            }
                
            ReportsList.ItemsSource = items;
            ReportsList.Items.Refresh();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this,new MainMenu());
        }

        private void quit_button_Click(object sender, RoutedEventArgs e)
        {
            Window exit = new exit_query();
            exit.Show();
        }

        private void open_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this, new Buildings_report(ReportsList.SelectedItem.ToString()));
        }
    }
}
