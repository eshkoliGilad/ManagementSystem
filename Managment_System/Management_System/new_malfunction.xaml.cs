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
using MySql.Data.MySqlClient;
namespace Management_System
{
    /// <summary>
    /// Interaction logic for new_malfunction.xaml
    /// </summary>
    /// 
    //Represent New Malfunction window
    public partial class new_malfunction : Window
    {
        SqlDB db;

        //New malfunction constructor
        public new_malfunction()
        {
            InitializeComponent();
            db = new SqlDB();
        }


        //Initial options loading - buildings
        private void ComboBox_Building_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data = db.combobox_building_load();
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
        }

        //Initial types options loading
        private void ComboBox_Type_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            List<string> data = new List<string>();
            data = db.UpdateMalsTypesList();
            comboBox.ItemsSource = data;
        }

        //Save button logic
        private void save_malfunctions_button_Click(object sender, RoutedEventArgs e)
        {
            string[] list = new string[4];
            var comboBox = sender as ComboBox;
            list[0] = DateTime.Now.ToString("dd-MM-yyyy");
            list[2] = combobox_type_mal.SelectedValue.ToString();
            list[1] = combobox_building_mal.SelectedValue.ToString();
            list[3] = description_mal_box.Text.ToString();
            try
            {
                db.save_Malfunction(list);
            }
            catch (Exception ex) { throw new Exception("Error saving Malfunction", ex); }
            finally
            {
                MessageBox.Show(".תקלה חדשה נשמרה בהצלחה"); //Save stats in DB and refresh list !!!!
                Switcher.Switch(new Malfunctions());
                this.Close();
            }
        }
    }
}
