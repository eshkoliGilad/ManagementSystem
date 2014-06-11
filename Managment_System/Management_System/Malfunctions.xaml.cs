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
using Excel=Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
namespace Management_System
{
    /// <summary>
    /// Interaction logic for Malfunctions.xaml
    /// </summary>
    public partial class Malfunctions : UserControl
    {
        List<Malfunction> items;
        MySqlConnection con;
        SqlDB db;
        public Malfunctions()
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
            UpdateListOfOpenMals();
            UpdateListOfClosedMals();
        }

        public void UpdateListOfOpenMals()
        {
            db = new SqlDB();
            items = db.updateListOfOpenMals();
            openMalslvDataBinding.ItemsSource = items;
            openMalslvDataBinding.Items.Refresh();
        }


        public void UpdateListOfClosedMals()
        {
            db = new SqlDB();
            items = db.updateListOfClosedMals();
            closedMalslvDataBinding.ItemsSource = items;
            closedMalslvDataBinding.Items.Refresh();
        }

        public class Malfunction
        {
            public string date { get; set; }
            public string type { get; set; }
            public string building { get; set; }
            public string state { get; set; }
            public string description { get; set; }
            public int id { get; set; }
        }
        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this,new MainMenu());
        }

        private void openMalslvDataBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void closedMalslvDataBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void new_mal_button_Click(object sender, RoutedEventArgs e)
        {
            new_malfunction mal = new new_malfunction();
            mal.Show();
        }

        private void close_mals_button_Click(object sender, RoutedEventArgs e)
        {
            if (openMalslvDataBinding.SelectedItem != null)
            {

                //OleDbConnection excel = new OleDbConnection();
                //excel.ConnectionString =
                 //   "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\USERS\\PUBLIC\\PRINT.XLSX;Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"";
                //string des = "";
                //pass query to Insert values into Excel
               // string bu = ((Malfunction)(openMalslvDataBinding.SelectedItem)).building.ToString().Trim();
               // string ty = ((Malfunction)(openMalslvDataBinding.SelectedItem)).type.ToString().Trim();
               // if (((Malfunction)(openMalslvDataBinding.SelectedItem)).description != "")
                //{
                  //  des = ((Malfunction)(openMalslvDataBinding.SelectedItem)).description.ToString().Trim();
              //  }
                 
               // OleDbCommand cmd = new OleDbCommand();

               // cmd.CommandText = "insert into [Sheet1$] values('" + bu + "','" + ty + "','" + des + "')";
               // cmd.Connection = excel;

                // EXECUTE QUERY
//                excel.Open();
  //              cmd.ExecuteNonQuery();
    //            excel.Close();

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
                    MessageBox.Show(".תקלה נסגרה בהצלחה"); //Save stats in DB and refresh list !!!!
                }
            }
            else
            {
                MessageBox.Show("לא נבחרה תקלה");
            }
        }

        private void delete_mals_button_Click(object sender, RoutedEventArgs e)
        {
            
            if (closedMalslvDataBinding.SelectedItem != null)
            {
                int temp = ((Malfunction)(closedMalslvDataBinding.SelectedItem)).id;
                db.deleteMalfunction(temp);
                UpdateListOfClosedMals();
                MessageBox.Show(".תקלה סגורה נמחקה בהצלחה"); //Save stats in DB and refresh list !!!!
            }
        }

        private void print_sum_button_Click(object sender, RoutedEventArgs e)
        {

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbook wb = excelApp.Workbooks.Open(@"C:\\USERS\\PUBLIC\\PRINT.XLSX",
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
            bool userDidntCancel = excelApp.Dialogs[Excel.XlBuiltInDialog.xlDialogPrintPreview].Show(
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            wb.Close(false, Type.Missing, Type.Missing);
            excelApp.Quit();
        }

        private void refresh_button_Click(object sender, RoutedEventArgs e)
        {
            
            db.updateListOfClosedMals();
            db.updateListOfOpenMals();
        }

        private void delete_all_button_Click(object sender, RoutedEventArgs e)
        {
            
            db.deleteAllMals();
            UpdateListOfClosedMals();
            MessageBox.Show(".כל התקלות הסגורות נמחקו בהצלחה"); //Save stats in DB and refresh list !!!!

            
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            Window exit = new exit_query();
            exit.Show();
        }


    }
}
