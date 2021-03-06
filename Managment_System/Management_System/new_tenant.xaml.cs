﻿using System;
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
    /// Interaction logic for new_tenant.xaml
    /// </summary>
    ///
 
    //Represent new Tenant Window
    public partial class new_tenant : Window
    {
        SqlDB db;
        string address = "";
        bool flag;

        //New Tenant Constructor
        public new_tenant() 
        {
            db = new SqlDB();
            InitializeComponent();
            flag = false;
        }

        //Edit existing Tenant costructor
        public new_tenant(string name) 
        {
            
            InitializeComponent();
            address = name;
            db = new SqlDB();
            string[] info = new string[8];
            flag = true;
            info = db.showTenant(name);

            name_of_tenant_box.Text = info[0];
            appartment_number_box.Text = info[1];
            floor_number_tenants.Text = info[2];
            state_combox.SelectedValue = info[3];
            phone_number_box.Text = info[4];
            cellphone_number_box.Text = info[5];
            building_combox.SelectedValue = info[6];
            email_box.Text = info[7] ; 
        }

        private void save_tenant_Click(object sender, RoutedEventArgs e)
        {
            if (name_of_tenant_box.Text.ToString().Equals("") && !building_combox.Text.ToString().Equals(""))
                MessageBox.Show("הכנס שם של דייר");
            
            else if (name_of_tenant_box.Text.ToString().Equals("") && building_combox.Text.ToString().Equals(""))
                MessageBox.Show("הכנס שם של דייר ובחר בניין");
            
            else if (!name_of_tenant_box.Text.ToString().Equals("") && building_combox.Text.ToString().Equals(""))
                MessageBox.Show("בחר בניין");
            
            else
            {
                string name = name_of_tenant_box.Text.ToString();
                string building = building_combox.Text.ToString();
                string floor = floor_number_tenants.Text.ToString();
                string phone = phone_number_box.Text.ToString();
                string cellphone = cellphone_number_box.Text.ToString();
                string state = state_combox.Text.ToString();
                string appartment_number = appartment_number_box.Text.ToString();
                string mail = email_box.Text.ToString();

                if (flag == false) //if it a new tenant
                {
                    string [] list = new string [8];
                    list[0] = name;
                    list[1] = building;
                    list[2] = floor;
                    list[3] = phone;
                    list[4] = cellphone;
                    list[5] = state;
                    list[6] = appartment_number;
                    list[7] = mail;

                    db.saveTenant(list);
                    MessageBox.Show(".דייר חדש נשמר בהצלחה"); 
                    this.Close();
                }
                else //Editing existing tenant
                {
                    string[] list = new string[8];
                    list[0] = name;
                    list[1] = building;
                    list[2] = floor;
                    list[3] = phone;
                    list[4] = cellphone;
                    list[5] = state;
                    list[6] = appartment_number;
                    list[7] = mail;
                    db.updateTenant(list, address);
                    MessageBox.Show(".דייר עודכן בהצלחה"); 
                    this.Close();
                }
            }
        }


        //Selection Changed in combobox
        private void building_combox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Do nothing
        }

        //Combobox buildings loading options
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            List<string> data = new List<string>();
            data=db.UpdateBuildingsList();
            comboBox.ItemsSource = data;   
        }

        //Changing state combobox
        private void state_combox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Do nothing
        }

        //Loading appartment's state options in combobox
        private void ComboBox_Loaded_2(object sender, RoutedEventArgs e) 
        {
            var comboBox = sender as ComboBox;
            List<string> data = new List<string>();
            data = db.UpdateTypesList();
            comboBox.ItemsSource = data;
        }
    }
}
