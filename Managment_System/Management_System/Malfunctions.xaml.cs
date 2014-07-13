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
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace Management_System
{
    /// <summary>
    /// Interaction logic for Malfunctions.xaml
    /// </summary>
    //This class represent Malfunctions class
    public partial class Malfunctions : UserControl
    {
        List<Malfunction> items;
        List<Malfunction> items1;
        List<Malfunction_Closed> items2;
        SqlDB db;

        public Malfunctions()
        {
            InitializeComponent();
            items2 = new List<Malfunction_Closed>();
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(@"/Management_System;component/Resources/malfunction.png", UriKind.Relative);
            img.EndInit();
            mals_img.Source = img;
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

            UpdateListOfOpenMals();
            UpdateListOfClosedMals();
        }

        //Show list of open malfunctions
        public void UpdateListOfOpenMals()
        {
            db = new SqlDB();
            items = db.updateListOfOpenMals();
            openMalslvDataBinding.ItemsSource = items;
            openMalslvDataBinding.Items.Refresh();
        }

        //Show list of closed malfunctions
        public void UpdateListOfClosedMals()
        {
            items2 = null;
            items2 = new List<Malfunction_Closed>();
            db = new SqlDB();
            items1 = db.updateListOfClosedMals();
            closedMalslvDataBinding.ItemsSource = items1;
            closedMalslvDataBinding.Items.Refresh();
            items1.ForEach(Copy); //For printing closed malfunctions
        }

        public void Copy(Malfunction mal)
        {
            Malfunction_Closed closed = new Malfunction_Closed();
            closed.building = mal.building;
            closed.date = mal.date;
            closed.type = mal.type;
            closed.description = mal.description;
            items2.Add(closed);
        }

        //Represent Closed malfunction
        public class Malfunction_Closed
        {
            public string date { get; set; }
            public string type { get; set; }
            public string building { get; set; }
            public string description { get; set; }
        }
        //Represent General Malfunction
        public class Malfunction
        {
            public string date { get; set; }
            public string type { get; set; }
            public string building { get; set; }
            public string state { get; set; }
            public string description { get; set; }
            public int id { get; set; }
        }

        //Back button
        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this, new MainMenu());
        }

        //Selection changed in Open Malfunctions list
        private void openMalslvDataBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Do nothing
        }

        //Selection changed in Closed Malfunctions list
        private void closedMalslvDataBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Do nothing
        }

        //Open new Malfunction window
        private void new_mal_button_Click(object sender, RoutedEventArgs e)
        {
            new_malfunction mal = new new_malfunction();
            mal.Show();
        }

        //Close open Malfunction button
        private void close_mals_button_Click(object sender, RoutedEventArgs e)
        {
            if (openMalslvDataBinding.SelectedItem != null)
            {
                db = new SqlDB();
                int temp = ((Malfunction)(openMalslvDataBinding.SelectedItem)).id;
                try
                {
                    db.closeMals(temp);
                    UpdateListOfClosedMals();
                    UpdateListOfOpenMals();
                }
                finally
                {
                    MessageBox.Show(".תקלה נסגרה בהצלחה");
                }
            }
            else
                MessageBox.Show("לא נבחרה תקלה");
        }

        //Delete close Malfunction button
        private void delete_mals_button_Click(object sender, RoutedEventArgs e)
        {
            if (closedMalslvDataBinding.SelectedItem != null)
            {
                int temp = ((Malfunction)(closedMalslvDataBinding.SelectedItem)).id;
                db.deleteMalfunction(temp);
                UpdateListOfClosedMals();
                MessageBox.Show(".תקלה סגורה נמחקה בהצלחה");
            }
        }

        //Open description for open Malfunction
        private void malsOpen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var item = ((FrameworkElement)e.OriginalSource).DataContext as Track;

            var variable = openMalslvDataBinding.SelectedItem;
            if (variable != null)
            {
                var desc = new description((Malfunction)variable);
                desc.Show();
            }
            else
                MessageBox.Show("לא נבחרה תקלה פתוחה");

        }

        //Open description for closed Malfunction
        private void malsClosed_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var variable = closedMalslvDataBinding.SelectedItem;
            if (variable != null)
            {
                var desc = new description((Malfunction)variable);
                desc.Show();
            }
            else
                MessageBox.Show("לא נבחרה תקלה סגורה");
        }

        //Print button logic
        private void print_sum_button_Click(object sender, RoutedEventArgs e)
        {

            datagrid.ItemsSource = items2; //DataBinding for DataGrid
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();//Create PrintDialog button
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth - 30, Printdlg.PrintableAreaHeight);
                // sizing of the element.
                datagrid.Measure(pageSize);
                datagrid.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                datagrid.Visibility = Visibility.Visible; //Make hidden datagrid visibile for printing 
                Printdlg.PrintVisual(datagrid, "תקלות");
                datagrid.Visibility = Visibility.Collapsed; //Make Datagrid hidden again
            }
        }

        //Delete All malfunction button logic
        private void delete_all_button_Click(object sender, RoutedEventArgs e)
        {
            db.deleteAllMals();
            UpdateListOfClosedMals();
            MessageBox.Show(".כל התקלות הסגורות נמחקו בהצלחה");
        }

        //Exit button
        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            Window exit = new exit_query();
            exit.Show();
        }


    }
}
