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
using System.Data.SqlClient;
using System.Configuration;

namespace Management_System
{
    /// <summary>
    /// Interaction logic for new_building.xaml
    /// </summary>
    public partial class new_building : Window
    {
        string name = "";
        bool flag = false;
        SqlDB db;
        string[] list;
        List<string> info, updatedInfo;

        //New building constructor for creating new building
        public new_building()
        {
            InitializeComponent();
            list = new string[14];
            db = new SqlDB();
        }

        //New building constructor for editing exists buildings
        public new_building(string address)
        {
            InitializeComponent();
            db = new SqlDB();
            list = new string[14];
            name = address;
            flag = true;
            info = new List<string>();
            info=db.getAllBuildingInfo(address);

            address_box.Text = info.ElementAt(0);
            account_box.Text = info.ElementAt(1);
            floors_box.Text = info.ElementAt(2);
            tenants_box.Text = info.ElementAt(3);
            order_box.Text = info.ElementAt(4);
            gardner_box.Text = info.ElementAt(5);
            phone_box.Text = info.ElementAt(6);
            num_elevator_box.Text = info.ElementAt(7);
            heating_type_box.Text = info.ElementAt(8);
            service_type_box.Text = info.ElementAt(9);
            if (info.ElementAt(10).Equals("Yes"))
                elevator_checkbox.IsChecked = true;
            else
                elevator_checkbox.IsChecked = false;
            if (info.ElementAt(11).Equals("Yes"))
                garden_checkbox.IsChecked = true;
            else
                garden_checkbox.IsChecked = false;
            if (info.ElementAt(12).Equals("Yes"))
                heating_checkbox.IsChecked = true;
            else
                heating_checkbox.IsChecked = false;
            if(info.ElementAt(13).Equals("Yes"))
                basement_checkbox.IsChecked= true;
            else
                basement_checkbox.IsChecked= false;
        }

        //Save buildingss information in DB
        private void new_save_Click(object sender, RoutedEventArgs e)
        {
            list[0] = address_box.Text.ToString().Trim();
            list[1] = account_box.Text.ToString().Trim();
            list[2] = floors_box.Text.ToString().Trim();
            list[3] = tenants_box.Text.ToString().Trim();
            list[4] = order_box.Text.ToString().Trim();
            list[5] = gardner_box.Text.ToString().Trim();
            list[6] = phone_box.Text.ToString().Trim();
            list[7] = num_elevator_box.Text.ToString().Trim();
            list[8] = heating_type_box.Text.ToString().Trim();
            list[9] = service_type_box.Text.ToString().Trim();
            if (elevator_checkbox.IsChecked.Value)
                list[10] = "Yes";
            else
                list[10] = "No";
            if (garden_checkbox.IsChecked.Value)
                list[11] = "Yes";
            else
                list[11] = "No";

            if (heating_checkbox.IsChecked.Value)
                list[12] = "Yes";
            else
                list[12] = "No";
            if (basement_checkbox.IsChecked.Value)
                list[13] = "Yes";
            else
                list[13] = "No";

            if (flag == false)
                db.add_new_building(list);
            else
            {
                updatedInfo = new List<string>(list);
                db.updateBuilding(updatedInfo, name);
            }
              
            Switcher.Switch(new Buildings());
            this.Close();    
        }

        //Close Window
        private void new_abort_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
