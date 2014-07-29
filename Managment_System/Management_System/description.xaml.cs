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
    /// Interaction logic for description.xaml
    /// </summary>
    public partial class description : Window
    {
        
        //This class represent malfunction description
        public description(Malfunctions.Malfunction a)
        {
            InitializeComponent();
            description_mal_box.Text = a.description;
        }

        //Close button
        public void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
}