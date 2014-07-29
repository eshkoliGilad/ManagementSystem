
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Data;
using System.Collections;
using System.Printing;
using System.Windows.Controls.Primitives;

namespace Management_System
{
    /// <summary>
    /// Interaction logic for Buildings_report.xaml
    /// </summary>
    /// 
    //This Class represent Report of Building
    public partial class Buildings_report : UserControl
    {
        List<Tenants.Tenant> list = new List<Tenants.Tenant>();
        SqlDB db;
        string address_for_refresh = "";
        //Constructor of Report
        public Buildings_report(string address)
        {
            db = new SqlDB();
            InitializeComponent();
            
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            //Indicated whether system is local or online
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

            //Setting values and show list of tenants based on building
            address_for_refresh = address;
            address_Reports_show.Text = address;
            list = db.showTenantsListOnReport(address);
            dgUsers.ItemsSource = list;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgUsers.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("apartmentNumber", ListSortDirection.Ascending)); //Sort by name of tenant
        }

        //Back button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this, new Reports());
        }

        //Save report with updated values to Database
        private void save_button_Click(object sender, RoutedEventArgs e)
        {

            var rows = GetDataGridRows(dgUsers);
            int count = 13;
            string[] s = new string[14];
            foreach (DataGridRow r in rows)
            {
                Tenants.Tenant t = (Tenants.Tenant)r.Item;
                foreach (DataGridColumn column in dgUsers.Columns)
                {
                    if (column.GetCellContent(r) is TextBlock)
                    {
                        TextBlock cellContent = column.GetCellContent(r) as TextBlock;
                        s[count] = cellContent.Text.ToString();
                        if (count == 0)
                        {
                            count = 14;
                            db.updateTenantOfReports(s, 14); //Update for every teanats whole year based on apartment number and name
                        }
                        count--;
                    }
                }
            }
            MessageBox.Show("דוח נשמר בהצלחה");
        }

        //Returns List of rows from the table
        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //When choosing differenet user in table, do nothing
        }

        private void print_report_Click(object sender, RoutedEventArgs e)
        {

            //Create PrintDialog object
            PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            //Get layout of UserControl
            Transform originalScale = this.LayoutTransform;             
            System.Printing.PrintCapabilities capabilities = printDlg.PrintQueue.GetPrintCapabilities(printDlg.PrintTicket);
            //get scale of the print wrt to screen of WPF visual
            double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / dgUsers.ActualWidth, capabilities.PageImageableArea.ExtentHeight /dgUsers.ActualHeight);
            //Transform the Visual to scale
            dgUsers.LayoutTransform = new ScaleTransform(scale, scale);
            //get the size of the printer page
            Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);
            //update the layout of the visual to the printer page size.
            dgUsers.Measure(sz);
            dgUsers.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));
            //now print the visual to printer to fit on the one page.
            printDlg.PrintVisual(dgUsers, "דוח");
            //Returns layout frame to original size
            dgUsers.LayoutTransform = originalScale;
        }

        private void refresh_button_Click(object sender, RoutedEventArgs e)
        {
            list = db.showTenantsListOnReport(address_for_refresh);
            dgUsers.ItemsSource = list;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgUsers.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("apartmentNumber", ListSortDirection.Ascending)); //Sort by name of tenant
            MessageBox.Show("רענון הסתיים בהצלחה");
        }
    }
}

