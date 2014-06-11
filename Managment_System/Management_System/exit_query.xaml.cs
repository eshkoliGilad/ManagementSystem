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

namespace Management_System
{
    /// <summary>
    /// Interaction logic for exit_query.xaml
    /// </summary>
    public partial class exit_query : Window
    {
        public exit_query()
        {
            InitializeComponent();
        }

        private void OK_button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
            Application.Current.Shutdown();
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
