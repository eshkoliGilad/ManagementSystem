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
using System.ComponentModel;


namespace Management_System
{
    /// <summary>
    /// Interaction logic for Tenants.xaml
    /// </summary>
    public partial class Tenants : UserControl
    {
        List<Tenant> items;
        SqlDB db;
        public Tenants()
        {
            InitializeComponent();
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(@"/Management_System;component/Resources/family.png", UriKind.Relative);
            img.EndInit();
            tenants_img.Source = img;

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
            db = new SqlDB();
            UpdateList();
        }

        public void UpdateList()
        {
            items = db.updateTenantsList();
            tenantslvDataBinding.ItemsSource = items;
            tenantslvDataBinding.Items.Refresh();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(tenantslvDataBinding.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("building", ListSortDirection.Ascending)); //Sort by name of tenant
            view.SortDescriptions.Add(new SortDescription("apartmentNumber", ListSortDirection.Ascending)); //Sort by name of tenant
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("building");
            view.GroupDescriptions.Add(groupDescription);

        }


        public class Tenant
        {
            public string Name { get; set; }
            public string building { get; set; }
            public int apartmentNumber { get; set; }
            public string state { get; set; }
            public string phone { get; set; }
            public string January { get; set; }
            public string February { get; set; }
            public string March { get; set; }
            public string April { get; set; }
            public string May { get; set; }
            public string June { get; set; }
            public string July { get; set; }
            public string August { get; set; }
            public string September { get; set; }
            public string October { get; set; }
            public string November { get; set; }
            public string December { get; set; }
            public override string ToString()
            {
                return this.Name;
            }
        }

        private void edit_tenant_Click(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void add_tenant_Click(object sender, RoutedEventArgs e)
        {
            new_tenant tenant = new new_tenant();
            tenant.Show();
        }

        private void delete_tenant_Click(object sender, RoutedEventArgs e)
        {
            if (tenantslvDataBinding.SelectedItem != null)
            {
                string name = tenantslvDataBinding.SelectedItem.ToString();
                db.deleteTenant(name);
                UpdateList();
                MessageBox.Show("דייר נמחק בהצלחה");
            }
            else
            {
                MessageBox.Show("לא נבחר דייר");
            }
        }

        private void back_button_tenants_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(this,new MainMenu());
        }

        private void open_tenant_Click(object sender, RoutedEventArgs e)
        {
            //Add option for save only changes,and not whole tenant all over again with same name ...
            new_tenant tenant;
            if (tenantslvDataBinding.SelectedItem != null)
            {
                tenant = new new_tenant(tenantslvDataBinding.SelectedItem.ToString());
                tenant.Show();
            }
            else
                MessageBox.Show("בחר דייר");
             
            
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            Window exit = new exit_query();
            exit.Show();
        }


    }
}
