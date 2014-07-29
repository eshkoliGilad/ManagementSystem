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
using System.ComponentModel;

namespace Management_System
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    /// 
    //This class represent Building's Reports
    public partial class Reports : UserControl
    {
        List<Report> items;
        List<string> temp;
        SqlDB db;
        exit_query exit;

        //Represent a Report
        private class Report
        {
            public string Address { get; set; }
            public override string ToString()
            {
                return this.Address;
            }
    }

        //Reports Constructor
        public Reports()
        {
            InitializeComponent();
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(@"/Management_System;component/Resources/report.png", UriKind.Relative);
            img.EndInit();
            report_img.Source = img;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            
            if (SqlDB.isOnline)
            {
                logo.UriSource = new Uri(@"/Management_System;component/Resources/online.png", UriKind.Relative);
                logo.EndInit();
                stateOfDB.Source = logo;
            }
            else
            {
                
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
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ReportsList.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Address", ListSortDirection.Ascending)); //Sort by name of tenant
        }

        //Back button
        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this,new MainMenu());
        }

        //Cancel button
        private void quit_button_Click(object sender, RoutedEventArgs e)
        {
            exit = new exit_query();
            exit.Show();
        }

        //Open report of choosen building
        private void open_button_Click(object sender, RoutedEventArgs e)
        {
            if (ReportsList.SelectedItem != null)
                Switcher.Switch(this, new Buildings_report(ReportsList.SelectedItem.ToString()));
            else
                MessageBox.Show("לא נבחר בניין");
        }
    }
}
