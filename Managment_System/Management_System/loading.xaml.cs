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
using System.Windows.Threading;
namespace Management_System
{
    /// <summary>
    /// Interaction logic for loading.xaml
    /// </summary>
    //This class represent Loading window during connection time
    public partial class loading : Window
    {
        BitmapImage logo;
        public loading()
        {
            InitializeComponent();
            logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(@"/Management_System;component/Resources/world.png", UriKind.Relative);
            logo.EndInit();
            world.Source = logo;
            Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle, null);
        }
      
    }
}
