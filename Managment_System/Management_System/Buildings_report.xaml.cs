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

namespace Management_System
{
    /// <summary>
    /// Interaction logic for Buildings_report.xaml
    /// </summary>
    public partial class Buildings_report : UserControl
    {
        List<Tenants.Tenant> list = new List<Tenants.Tenant>();
        SqlDB db;
        public Buildings_report(string address)
        {
            db = new SqlDB();
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

            address_Reports_show.Text = address;
            list = db.showTenantsListOnReport(address);
            dgUsers.ItemsSource = list;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgUsers.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("apartmentNumber", ListSortDirection.Ascending)); //Sort by name of tenant
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this, new Reports());
        }


        private void show_Tenants(string address)
        {
            
        }

        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            var rows = GetDataGridRows(dgUsers);
            int count = 13;
            string[] s = new string[14];
            foreach (DataGridRow r in rows)
            {
               // DataRowView rv = (DataRowView)r.Item;

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
                            db.updateTenantOfReports(s,14);
                         //   MessageBox.Show("WOWOWOWO !!!!");
                            //UPDATE DATABASE !!!!
                        }
                        count--;

                        //MessageBox.Show(cellContent.Text);
                    }
                }
            }
            MessageBox.Show("דוח נשמר בהצלחה");
        }


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

        }



    }
}
