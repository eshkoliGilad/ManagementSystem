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
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Data.SqlClient;
using System.Configuration;
using WPF.Themes;

namespace Management_System
{
    /// <summary>
    /// Interaction logic for PageSwitcher.xaml
    public partial class PageSwitcher : Window
    {
        public PageSwitcher()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //Start application at center of screen
            Switcher.pageSwitcher = this;
            Switcher.Switch(new Login());
        }

        //Navigate from UserControl to another
        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
            if (nextPage is Buildings_report) //If report, enlrage screen
            {
                this.Width = 1200;
                CenterWindowOnScreen();
            }
            else
            {
                this.Width = 800;
                this.Height = 600;
                CenterWindowOnScreen();
            }
        }

        //Navigate and change state if something is not normal
        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            if (nextPage is Buildings_report)
            {
                this.Width = 1200;
                CenterWindowOnScreen();
            }
            else
            {
                this.Width = 800;
                this.Height = 600;
                CenterWindowOnScreen();
            }
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
        }

        //Center to screen
        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}