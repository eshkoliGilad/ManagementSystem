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
    public partial class new_malfunction : Window
    {
        MySqlConnection con;        
        public new_malfunction()
        {
            InitializeComponent();
        }


        private void ComboBox_Building_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            con = new MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM buildings ", con); //for reading
            MySqlDataReader reader = cmd.ExecuteReader(); //for writing
            var comboBox = sender as ComboBox;
            while (reader.Read()) //for writing
            {
                data.Add(reader[0].ToString().Trim());
            }

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

        }


        private void ComboBox_Type_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            List<string> data = new List<string>();
            data.Add("פיצוץ צינור מים");
            data.Add("תקלת חשמל");
            data.Add("גיזום עצים");
            data.Add("נזילת גג");
            comboBox.ItemsSource = data;

        }
        

        private void save_malfunctions_button_Click(object sender, RoutedEventArgs e)
        {

            con = new MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();
            int rows=0;
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM malfunctions ", con); //for reading
            MySqlDataReader reader = cmd.ExecuteReader(); //for writing
            var comboBox = sender as ComboBox;
            while (reader.Read()) //for writing
            {
                if (rows < Convert.ToInt32(reader[4].ToString()))
                    rows = Convert.ToInt32(reader[4].ToString());
            }
            rows++;
            string state, type, building, desc,date;
            date = DateTime.Now.ToString("dd-MM-yyyy");
            state = "opend";
            type = combobox_type_mal.SelectedValue.ToString();
            building = combobox_building_mal.SelectedValue.ToString();
            desc = description_mal_box.Text.ToString();
            con.Close();
            con.Open();
            string sqlIns = "INSERT INTO malfunctions (date, state,building, type, description, id) VALUES (@date, @state, @building, @type, @desc, @id)";
            try
            {
                MySqlCommand cmdIns = new MySqlCommand(sqlIns, con);
                cmdIns.Parameters.AddWithValue("@date", date);
                cmdIns.Parameters.AddWithValue("@state", state);
                cmdIns.Parameters.AddWithValue("@building", building);
                cmdIns.Parameters.AddWithValue("@type", type);
                cmdIns.Parameters.AddWithValue("@desc", desc);
                cmdIns.Parameters.AddWithValue("@id", rows);
                cmdIns.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
                MessageBox.Show(".תקלה חדשה נשמרה בהצלחה"); //Save stats in DB and refresh list !!!!
                Switcher.Switch(new Malfunctions());
                this.Close();
            }
        }
    }
}
