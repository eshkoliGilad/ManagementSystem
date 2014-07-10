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
    public partial class MainMenu : UserControl,ISwitchable
    {
        public MainMenu()
        {
            InitializeComponent();

            BitmapImage pic = new BitmapImage();
            pic.BeginInit();
            pic.UriSource = new Uri(@"/Management_System;component/Resources/buildings.png", UriKind.Relative);
            pic.EndInit();
            logo_menu.Source = pic;
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
                
                BitmapImage logo= new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(@"/Management_System;component/Resources/offline.png", UriKind.Relative);
                logo.EndInit();
                stateOfDB.Source = logo;
            }

        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            Window exit = new exit_query();
            exit.Show();
        }

        private void buildings_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this,new Buildings());
        }

        private void attendence_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this,new Tenants());
        }

        private void reports_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this,new Reports());
        }

        private void malfunctions_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this,new Malfunctions());
        }


        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this, new Login());
        }
      

       
    }
}
