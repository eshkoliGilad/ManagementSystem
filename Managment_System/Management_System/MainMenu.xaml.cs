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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    /// 
    //This class represent the Main Menu of the app
    public partial class MainMenu : UserControl, ISwitchable
    {
        public MainMenu()
        {
            InitializeComponent();

            BitmapImage pic = new BitmapImage();
            pic.BeginInit();
            pic.UriSource = new Uri(@"/Management_System;component/Resources/buildings.png", UriKind.Relative);
            pic.EndInit();
            logo_menu.Source = pic;
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
        }

        //Exit button logic
        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            Window exit = new exit_query();
            exit.Show();
        }

        //Buildings button
        private void buildings_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this, new Buildings());
        }
        //Tenants button
        private void attendence_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this, new Tenants());
        }
        //Reports button
        private void reports_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this, new Reports());
        }
        //Malfunction button
        private void malfunctions_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this, new Malfunctions());
        }

        //Back button
        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this, new Login());
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
