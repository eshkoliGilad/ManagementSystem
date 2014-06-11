using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Management_System
{


    /// <summary>
    /// /
    /// ///
    /// /
    /// /
    /// /
    /// /
    /// CHECK IF THERE IS ONLINE AND OFFLINE IN EVERY(!) FUNCTION BEFORE THERE ARE NEW FUNCTIONS HERE !
    /// /
    /// /
    /// /
    /// /
    /// /
    /// /
    /// /
    /// /
    /// </summary>
    public class SqlDB
    {
        
        List<string> items;
        List<Malfunctions.Malfunction> itemsMals;
        List<meetings.Meeting> items1;
        SqlConnection conLocal;
        MySqlConnection con;
        public static bool isOnline = false;
        public SqlDB()
        {
            con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
        }

        public void deleteAllMals()
        {
            
            con.Open();
            string sqlIns = "DELETE FROM malfunctions WHERE state=@state";

            try
            {
                MySqlCommand cmdIns = new MySqlCommand(sqlIns, con);
                cmdIns.Parameters.AddWithValue("@state", "close");
                int t = cmdIns.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }



        public void deleteMalfunction(int num)
        {
            
            int temp = num; 
            con.Open();
            string sqlIns = "DELETE FROM malfunctions WHERE id=@id";

            try
            {
                MySqlCommand cmdIns = new MySqlCommand(sqlIns, con);
                cmdIns.Parameters.AddWithValue("@id", temp);
                int t = cmdIns.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }


        public void closeMals(int num)
        {
            
            int temp = num;
            con.Open();
            string sqlIns = "UPDATE malfunctions SET state=@new_state WHERE id=@id";

            try
            {
                MySqlCommand cmdIns = new MySqlCommand(sqlIns, con);
                cmdIns.Parameters.AddWithValue("@new_state", "close");
                cmdIns.Parameters.AddWithValue("@id", temp);
                int t = cmdIns.ExecuteNonQuery();

            }

            finally
            {
                con.Close();
            }
        }

        public List<Malfunctions.Malfunction> updateListOfClosedMals()
        {
            itemsMals = new List<Malfunctions.Malfunction>();
            string type, building_mal, date;

            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM malfunctions WHERE state ='close' ", con); //for reading
            MySqlDataReader reader = cmd.ExecuteReader(); //for writing
            while (reader.Read()) //for writing
            {
                building_mal = reader[1].ToString().Trim();
                type = reader[2].ToString().Trim();
                date = reader[5].ToString().Trim();
                Malfunctions.Malfunction malfunctoin = new Malfunctions.Malfunction();
                malfunctoin.building = building_mal;
                string id = reader[4].ToString().Trim();
                malfunctoin.id = Convert.ToInt32(id);
                malfunctoin.type = type;
                malfunctoin.description = reader[3].ToString().Trim();
                malfunctoin.date = date;
                itemsMals.Add(malfunctoin);
            }
            con.Close();
            return itemsMals;
        }



        public List<Malfunctions.Malfunction> updateListOfOpenMals()
        {
            itemsMals = new List<Malfunctions.Malfunction>();
            string type, building_mal, date;
            //con = new MySqlConnection();
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM malfunctions WHERE state ='opend' ", con); //for reading
            MySqlDataReader reader = cmd.ExecuteReader(); //for writing
            while (reader.Read()) //for writing
            {
                building_mal = reader[1].ToString().Trim();
                type = reader[2].ToString().Trim();
                date = reader[5].ToString().Trim();
                Malfunctions.Malfunction malfunctoin = new Malfunctions.Malfunction();
                malfunctoin.building = building_mal;
                string id = reader[4].ToString().Trim();
                malfunctoin.id = Convert.ToInt32(id);
                malfunctoin.type = type;
                malfunctoin.date = date;
                malfunctoin.description = reader[3].ToString().Trim();
                itemsMals.Add(malfunctoin);
            }
            con.Close();
            return itemsMals;
        }


        public void copyDataBasesOfMalfunctions()
        {
            string s = "", s1 = "", s2 = "", s3="",s4="",s5="";
            con.Open();
            conLocal.Open();
            string deleteSQL = "DELETE FROM malfunctions";
            SqlCommand cmd2 = new SqlCommand(deleteSQL, conLocal);
            cmd2.ExecuteNonQuery();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM malfunctions", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s = reader[0].ToString().Trim();
                s1 = reader[1].ToString().Trim();
                s2 = reader[2].ToString().Trim();

                //   con.Close();
                string sqlIns = "INSERT INTO malfunctions (state,building,type,description,id,date) VALUES (@state, @building, @type,@desc,@id,@date)";

                try
                {
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conLocal);
                    cmdIns.Parameters.AddWithValue("@state", s);
                    cmdIns.Parameters.AddWithValue("@building", s1);
                    cmdIns.Parameters.AddWithValue("@type", s2);
                    cmdIns.Parameters.AddWithValue("@desc", s3);
                    cmdIns.Parameters.AddWithValue("@id", s4);
                    cmdIns.Parameters.AddWithValue("@date", s5);
                    cmdIns.ExecuteNonQuery();
                }

                finally
                {

                }
            }
            con.Close();
            conLocal.Close();
        }


        public void copyDataBasesOfMeeting()
        {
            string s = "", s1 = "", s2 = "";
            con.Open();
            conLocal.Open();
            string deleteSQL = "DELETE FROM meetings";
            SqlCommand cmd2 = new SqlCommand(deleteSQL, conLocal);
            cmd2.ExecuteNonQuery();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM meetings", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s = reader[0].ToString().Trim();
                s1 = reader[1].ToString().Trim();
                s2 = reader[2].ToString().Trim();
              
                //   con.Close();
                string sqlIns = "INSERT INTO meetings (date,explanation, building) VALUES (@date, @note, @building)";

                try
                {
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conLocal);
                    cmdIns.Parameters.AddWithValue("@date", s);
                    cmdIns.Parameters.AddWithValue("@note", s1);
                    cmdIns.Parameters.AddWithValue("@building", s2);
                    cmdIns.ExecuteNonQuery();
                }

                finally
                {

                }
            }
            con.Close();
            conLocal.Close();
        }


        public void copyDataBasesOfTenants()
        {
            string s = "", s1 = "", s2 = "", s3 = "", s4 = "", s5 = "", s6 = "", s7 = "", s8 = "", s9 = "", s10 = "", s11 = "", s12 = "", s13 = "", s14 = "", s15 = "", s16 = "", s17 = "", s18 = "", s19 = "";
            con.Open();
            conLocal.Open();
            string deleteSQL = "DELETE FROM tenants";
            SqlCommand cmd2 = new SqlCommand(deleteSQL, conLocal);
            cmd2.ExecuteNonQuery();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tenants", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s = reader[0].ToString().Trim();
                s1 = reader[1].ToString().Trim();
                s2 = reader[2].ToString().Trim();
                s3 = reader[3].ToString().Trim();
                s4 = reader[4].ToString().Trim();
                s5 = reader[5].ToString().Trim();
                s6 = reader[6].ToString().Trim();
                s7 = reader[7].ToString().Trim();
                s8 = reader[8].ToString().Trim();
                s9 = reader[9].ToString().Trim();
                s10 = reader[10].ToString().Trim();
                s11 = reader[11].ToString().Trim();
                s12 = reader[12].ToString().Trim();
                s13 = reader[13].ToString().Trim();
                s14 = reader[14].ToString().Trim();
                s15 = reader[15].ToString().Trim();
                s16 = reader[16].ToString().Trim();
                s17 = reader[17].ToString().Trim();
                s18 = reader[18].ToString().Trim();
                s19 = reader[19].ToString().Trim();
                //   con.Close();
                string sqlIns = "INSERT INTO tenants (name,building, floor_number, phoner_number, cellphone_number, email_address, appartment_state, appartent_number, january, february, march,april,may,june,july,august,september,october,november,december) VALUES (@name, @building, @floor, @phone, @cellphone, @email, @state, @appar_number, @jan, @feb,@mar,@apr,@may,@jun,@jul,@aug,@sep,@oct,@nov,@dec)";

                try
                {
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conLocal);
                    cmdIns.Parameters.AddWithValue("@name", s);
                    cmdIns.Parameters.AddWithValue("@building", s1);
                    cmdIns.Parameters.AddWithValue("@floor", s2);
                    cmdIns.Parameters.AddWithValue("@phone", s3);
                    cmdIns.Parameters.AddWithValue("@cellphone", s4);
                    cmdIns.Parameters.AddWithValue("@email", s5);
                    cmdIns.Parameters.AddWithValue("@state", s6);
                    cmdIns.Parameters.AddWithValue("@appar_number", s7);
                    cmdIns.Parameters.AddWithValue("@jan", s8);
                    cmdIns.Parameters.AddWithValue("@feb", s9);
                    cmdIns.Parameters.AddWithValue("@mar", s10);
                    cmdIns.Parameters.AddWithValue("@apr", s11);
                    cmdIns.Parameters.AddWithValue("@may", s12);
                    cmdIns.Parameters.AddWithValue("@jun", s13);
                    cmdIns.Parameters.AddWithValue("@jul", s14);
                    cmdIns.Parameters.AddWithValue("@aug", s15);
                    cmdIns.Parameters.AddWithValue("@sep", s16);
                    cmdIns.Parameters.AddWithValue("@oct", s17);
                    cmdIns.Parameters.AddWithValue("@nov", s18);
                    cmdIns.Parameters.AddWithValue("@dec", s19);
                    cmdIns.ExecuteNonQuery();
                }

                finally
                {

                }
            }
            con.Close();
            conLocal.Close();
        }






        public void copyDataBasesOfBuildings()
        {
            string s="", s1="", s2="", s3="", s4="", s5="", s6="", s7="", s8="", s9="", s10="", s11="", s12="", s13="";
            con.Open();
            conLocal.Open();
            string deleteSQL = "DELETE FROM buildings";
            SqlCommand cmd2 = new SqlCommand(deleteSQL, conLocal);
            cmd2.ExecuteNonQuery();
            
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM buildings ", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    s = reader[0].ToString().Trim();
                    s1 = reader[1].ToString().Trim();
                    s2 = reader[2].ToString().Trim();
                    s3 = reader[3].ToString().Trim();
                    s4 = reader[4].ToString().Trim();
                    s5 = reader[5].ToString().Trim();
                    s6 = reader[6].ToString().Trim();
                    s7 = reader[7].ToString().Trim();
                    s8 = reader[8].ToString().Trim();
                    s9 = reader[9].ToString().Trim();
                    s10 = reader[10].ToString().Trim();
                    s11 = reader[11].ToString().Trim();
                    s12 = reader[12].ToString().Trim();
                    s13 = reader[13].ToString().Trim();

                    //   con.Close();
                    string sqlIns = "INSERT INTO buildings (Address,Account,floors,tenants,for_whom,gardner,gardner_phone,elevator_num,heating_type,service_type,IsElevator,IsGarden,IsHeating,IsBasement) VALUES (@Address,@Account,@floors,@tenants,@for_whom,@gardner,@gardner_phone,@elevator_num,@heating_type,@service_type,@IsElevator,@IsGarden,@IsHeating,@IsBasement)";

                    try
                    {
                        SqlCommand cmdIns = new SqlCommand(sqlIns, conLocal);
                        cmdIns.Parameters.AddWithValue("@Address", s);
                        cmdIns.Parameters.AddWithValue("@Account", s1);
                        cmdIns.Parameters.AddWithValue("@floors", s2);
                        cmdIns.Parameters.AddWithValue("@tenants", s3);
                        cmdIns.Parameters.AddWithValue("@for_whom", s4);
                        cmdIns.Parameters.AddWithValue("@gardner", s5);
                        cmdIns.Parameters.AddWithValue("@gardner_phone", s6);
                        cmdIns.Parameters.AddWithValue("@elevator_num", s7);
                        cmdIns.Parameters.AddWithValue("@heating_type", s8);
                        cmdIns.Parameters.AddWithValue("@service_type", s9);
                        cmdIns.Parameters.AddWithValue("@IsElevator", s10);
                        cmdIns.Parameters.AddWithValue("@IsGarden", s11);
                        cmdIns.Parameters.AddWithValue("@IsHeating", s12);
                        cmdIns.Parameters.AddWithValue("@IsBasement", s13);
                        cmdIns.ExecuteNonQuery();
                    }

                    finally
                    {
                        
                    }
                }
                con.Close();
                conLocal.Close();
        }

        public void addMeeting(string[] listOfParameters)
        {
            //try
            //{
               // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
              //  con.Open();
             //   isOnline = true;
            //}
           // catch
          //  {
             //   isOnline = false;
             //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
             //   try
             //   {
             //       conLocal.Open();
              //  }
              //  catch
             //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
             //   }
            //}
           
            
            string sqlIns = "INSERT INTO meetings (building,explanation,date) VALUES (@building,@explanation,@date)";
            if (isOnline)
            {
                try
                {
                    con.Open();
                    MySqlCommand cmdIns = new MySqlCommand(sqlIns, con);
                    cmdIns.Parameters.AddWithValue("@building", listOfParameters[0]);
                    cmdIns.Parameters.AddWithValue("@explanation", listOfParameters[1]);
                    cmdIns.Parameters.AddWithValue("@date", listOfParameters[2]);
                    cmdIns.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                try
                {
                    conLocal.Open();
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conLocal);
                    cmdIns.Parameters.AddWithValue("@building", listOfParameters[0]);
                    cmdIns.Parameters.AddWithValue("@explanation", listOfParameters[1]);
                    cmdIns.Parameters.AddWithValue("@date", listOfParameters[2]);
                    cmdIns.ExecuteNonQuery();
                }
                finally
                {
                    conLocal.Close();
                }
            }
        }

        public List<meetings.Meeting> showMeetingList(string address)
        {
            string param = address.Trim();
            items1 = new List<meetings.Meeting>();
            string notes, building, date;

            if (isOnline)
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM meetings WHERE building='" + param + "'", con); //for reading
                MySqlDataReader reader = cmd.ExecuteReader(); //for writing
                while (reader.Read()) //for writing
                {
                    building = reader[2].ToString().Trim();
                    notes = reader[1].ToString().Trim();
                    date = reader[0].ToString().Trim();
                    meetings.Meeting meeting = new meetings.Meeting();
                    meeting.building = building;
                    meeting.notes = notes;
                    meeting.date = date;
                    items1.Add(meeting);
                }
                con.Close();
            }
            else
            {
                conLocal.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM meetings WHERE building='" + param + "'", conLocal); //for reading
                SqlDataReader reader = cmd.ExecuteReader(); //for writing
                while (reader.Read()) //for writing
                {
                    building = reader[2].ToString().Trim();
                    notes = reader[1].ToString().Trim();
                    date = reader[0].ToString().Trim();
                    meetings.Meeting meeting = new meetings.Meeting();
                    meeting.building = building;
                    meeting.notes = notes;
                    meeting.date = date;
                    items1.Add(meeting);
                }
                conLocal.Close();
            }
                return items1;
        }
        
        public bool check_username(string user, string password)
        {
            bool isValid = false;
            try
            {
             con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
              con.Open();
               isOnline = true;
            }
             catch
              {
              isOnline = false;
               conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
               try
               {
                   conLocal.Open();
              }
              catch
               {
                    //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
               }
            }

            if (isOnline)
            {
                
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users ", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string real_user = reader[0].ToString().Trim();
                    string real_password = reader[1].ToString().Trim();

                    if (real_user.Equals(user) && real_password.Equals(password))
                    {
                        isValid = true;
                        break;
                    }
                }
                con.Close();
                copyDataBasesOfBuildings(); //WORKING ?!?
                copyDataBasesOfTenants();
                copyDataBasesOfMeeting();
                copyDataBasesOfMalfunctions();
                return isValid;
            }

            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM users ", conLocal);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string real_user = reader[0].ToString().Trim();
                    string real_password = reader[1].ToString().Trim();

                    if (real_user.Equals(user) && real_password.Equals(password))
                    {
                        isValid = true;
                        break;
                    }
                }
                conLocal.Close();
                return isValid;
            }
        }
        public void add_new_building(string[] listOfParameters)
        {
            //try
            //{
            // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //  con.Open();
            //   isOnline = true;
            //}
            // catch
            //  {
            //   isOnline = false;
            //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
            //   try
            //   {
            //       conLocal.Open();
            //  }
            //  catch
            //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
            //   }
            //}
            string sqlIns = "INSERT INTO buildings (Address,Account,floors,tenants,for_whom,gardner,gardner_phone,elevator_num,heating_type,service_type,IsElevator,IsGarden,IsHeating,IsBasement) VALUES (@Address,@Account,@floors,@tenants,@for_whom,@gardner,@gardner_phone,@elevator_num,@heating_type,@service_type,@IsElevator,@IsGarden,@IsHeating,@IsBasement)";
            if (isOnline)
            {
            try
            {
                con.Open();
                MySqlCommand cmdIns = new MySqlCommand(sqlIns, con);
                
                cmdIns.Parameters.AddWithValue("@Address", listOfParameters[0]);
                cmdIns.Parameters.AddWithValue("@Account", listOfParameters[1]);
                cmdIns.Parameters.AddWithValue("@floors", listOfParameters[2]);
                cmdIns.Parameters.AddWithValue("@tenants", listOfParameters[3]);
                cmdIns.Parameters.AddWithValue("@for_whom", listOfParameters[4]);
                cmdIns.Parameters.AddWithValue("@gardner", listOfParameters[5]);
                cmdIns.Parameters.AddWithValue("@gardner_phone", listOfParameters[6]);
                cmdIns.Parameters.AddWithValue("@elevator_num", listOfParameters[7]);
                cmdIns.Parameters.AddWithValue("@heating_type", listOfParameters[8]);
                cmdIns.Parameters.AddWithValue("@service_type", listOfParameters[9]);
                cmdIns.Parameters.AddWithValue("@IsElevator", listOfParameters[10]);
                cmdIns.Parameters.AddWithValue("@IsGarden", listOfParameters[11]);
                cmdIns.Parameters.AddWithValue("@IsHeating", listOfParameters[12]);
                cmdIns.Parameters.AddWithValue("@IsBasement", listOfParameters[13]);
                cmdIns.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
            else
            {
                try
                {
                    conLocal.Open();
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conLocal);

                    cmdIns.Parameters.AddWithValue("@Address", listOfParameters[0]);
                    cmdIns.Parameters.AddWithValue("@Account", listOfParameters[1]);
                    cmdIns.Parameters.AddWithValue("@floors", listOfParameters[2]);
                    cmdIns.Parameters.AddWithValue("@tenants", listOfParameters[3]);
                    cmdIns.Parameters.AddWithValue("@for_whom", listOfParameters[4]);
                    cmdIns.Parameters.AddWithValue("@gardner", listOfParameters[5]);
                    cmdIns.Parameters.AddWithValue("@gardner_phone", listOfParameters[6]);
                    cmdIns.Parameters.AddWithValue("@elevator_num", listOfParameters[7]);
                    cmdIns.Parameters.AddWithValue("@heating_type", listOfParameters[8]);
                    cmdIns.Parameters.AddWithValue("@service_type", listOfParameters[9]);
                    cmdIns.Parameters.AddWithValue("@IsElevator", listOfParameters[10]);
                    cmdIns.Parameters.AddWithValue("@IsGarden", listOfParameters[11]);
                    cmdIns.Parameters.AddWithValue("@IsHeating", listOfParameters[12]);
                    cmdIns.Parameters.AddWithValue("@IsBasement", listOfParameters[13]);
                    cmdIns.ExecuteNonQuery();
                }
                finally
                {
                    conLocal.Close();
                }
            }
        }



        
        public List<string> UpdateBuildingsList()
        {
            items = new List<string>();
            //try
            //{
            // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //  con.Open();
            //   isOnline = true;
            //}
            // catch
            //  {
            //   isOnline = false;
            //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
            //   try
            //   {
            //       conLocal.Open();
            //  }
            //  catch
            //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
            //   }
            //}
            
            
            //con.Open();
            if (isOnline)
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM buildings ", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string address = reader[0].ToString().Trim();
                    items.Add(address);
                }
                con.Close();
                return items;
            }
            else
            {
                conLocal.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM buildings ", conLocal);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string address = reader[0].ToString().Trim();
                    items.Add(address);
                }
                conLocal.Close();
                return items;
            }
        }


        

        public List<string> getAllBuildingInfo(string name)
        {
            items = new List<string>();
            //try
            //{
            // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //  con.Open();
            //   isOnline = true;
            //}
            // catch
            //  {
            //   isOnline = false;
            //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
            //   try
            //   {
            //       conLocal.Open();
            //  }
            //  catch
            //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
            //   }
            //}
            if (isOnline)
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM buildings  WHERE Address='" + name + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string address = reader[0].ToString().Trim();
                    string account = reader[1].ToString().Trim();
                    string floors = reader[2].ToString().Trim();
                    string Tenants = reader[3].ToString().Trim();
                    string for_whom = reader[4].ToString().Trim();
                    string gardner = reader[5].ToString().Trim();
                    string gardner_phone = reader[6].ToString().Trim();
                    string elevator_num = reader[7].ToString().Trim();
                    string heating_type = reader[8].ToString().Trim();
                    string service_type = reader[9].ToString().Trim();
                    string IsElevator = reader[10].ToString().Trim();
                    string IsGarden = reader[11].ToString().Trim();
                    string IsHeating = reader[12].ToString().Trim();
                    string IsBasement = reader[13].ToString().Trim();
                    items.Add(address);
                    items.Add(account);
                    items.Add(floors);
                    items.Add(Tenants);
                    items.Add(for_whom);
                    items.Add(gardner);
                    items.Add(gardner_phone);
                    items.Add(elevator_num);
                    items.Add(heating_type);
                    items.Add(service_type);
                    items.Add(IsElevator);
                    items.Add(IsGarden);
                    items.Add(IsHeating);
                    items.Add(IsBasement);
                }
                con.Close();
                return items;
            }

            else
            {
                conLocal.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM buildings  WHERE Address='" + name + "'", conLocal);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string address = reader[0].ToString().Trim();
                    string account = reader[1].ToString().Trim();
                    string floors = reader[2].ToString().Trim();
                    string Tenants = reader[3].ToString().Trim();
                    string for_whom = reader[4].ToString().Trim();
                    string gardner = reader[5].ToString().Trim();
                    string gardner_phone = reader[6].ToString().Trim();
                    string elevator_num = reader[7].ToString().Trim();
                    string heating_type = reader[8].ToString().Trim();
                    string service_type = reader[9].ToString().Trim();
                    string IsElevator = reader[10].ToString().Trim();
                    string IsGarden = reader[11].ToString().Trim();
                    string IsHeating = reader[12].ToString().Trim();
                    string IsBasement = reader[13].ToString().Trim();
                    items.Add(address);
                    items.Add(account);
                    items.Add(floors);
                    items.Add(Tenants);
                    items.Add(for_whom);
                    items.Add(gardner);
                    items.Add(gardner_phone);
                    items.Add(elevator_num);
                    items.Add(heating_type);
                    items.Add(service_type);
                    items.Add(IsElevator);
                    items.Add(IsGarden);
                    items.Add(IsHeating);
                    items.Add(IsBasement);
                }
                conLocal.Close();
                return items;
            }
        }


        
        public void deleteBuilding(string name)
        {
            //try
            //{
            // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //  con.Open();
            //   isOnline = true;
            //}
            // catch
            //  {
            //   isOnline = false;
            //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
            //   try
            //   {
            //       conLocal.Open();
            //  }
            //  catch
            //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
            //   }
            //}
            if (isOnline)
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(
                   "DELETE FROM buildings WHERE Address='" + name + "'",
                     con);

                MySqlCommand cmd1 = new MySqlCommand(
                       "DELETE FROM tenants WHERE building='" + name + "'",
                         con); //DELETE ALL TENANTS FROM THAT BUILDING

                MySqlCommand cmd2 = new MySqlCommand(
                       "DELETE FROM malfunctions WHERE building='" + name + "'",
                         con); //DELETE ALL MALFUNCTIONS FROM THAT BUILDING

                //NEEDS TO DELETE ITS EXCEL FORM !!!
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                conLocal.Open();
                SqlCommand cmd = new SqlCommand(
                   "DELETE FROM buildings WHERE Address='" + name + "'",
                     conLocal);

                SqlCommand cmd1 = new SqlCommand(
                       "DELETE FROM tenants WHERE building='" + name + "'",
                         conLocal); //DELETE ALL TENANTS FROM THAT BUILDING

                SqlCommand cmd2 = new SqlCommand(
                       "DELETE FROM malfunctions WHERE building='" + name + "'",
                         conLocal); //DELETE ALL MALFUNCTIONS FROM THAT BUILDING

                //NEEDS TO DELETE ITS EXCEL FORM !!!
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                conLocal.Close();
            }
        }



        public void updateBuilding(List<string> list, string id)
        {
            //try
            //{
            // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //  con.Open();
            //   isOnline = true;
            //}
            // catch
            //  {
            //   isOnline = false;
            //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
            //   try
            //   {
            //       conLocal.Open();
            //  }
            //  catch
            //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
            //   }
            //}
            if (isOnline)
            {
                string sqlIns = "UPDATE buildings SET Address=@address,Account=@account,floors=@floors, tenants=@tenants,for_whom=@for_whom,gardner=@gardner,gardner_phone=@gardner_phone,elevator_num=@elevator_num,heating_type=@heating_type,service_type=@service_type,IsElevator=@IsElevator,IsGarden=@IsGarden,IsHeating=@IsHeating,IsBasement=@IsBasement WHERE Address=@id";
                string sqlUpT = "UPDATE tenants SET building='" + list[0] + "' WHERE building='" + id + "'"; //UPDATE BUILDING NAME IN TENANTS, WHEN UPDATING CURRENT BUILDING
                try
                {
                    con.Open();
                    MySqlCommand cmdIns = new MySqlCommand(sqlIns, con);
                    MySqlCommand cmdUpt = new MySqlCommand(sqlUpT, con);
                    cmdIns.Parameters.AddWithValue("@id", id);
                    cmdIns.Parameters.AddWithValue("@address", list[0]);
                    cmdIns.Parameters.AddWithValue("@account", list[1]);
                    cmdIns.Parameters.AddWithValue("@floors", list[2]);
                    cmdIns.Parameters.AddWithValue("@tenants", list[3]);
                    cmdIns.Parameters.AddWithValue("@for_whom", list[4]);
                    cmdIns.Parameters.AddWithValue("@gardner", list[5]);
                    cmdIns.Parameters.AddWithValue("@gardner_phone", list[6]);
                    cmdIns.Parameters.AddWithValue("@elevator_num", list[7]);
                    cmdIns.Parameters.AddWithValue("@heating_type", list[8]);
                    cmdIns.Parameters.AddWithValue("@service_type", list[9]);
                    cmdIns.Parameters.AddWithValue("@IsElevator", list[10]);
                    cmdIns.Parameters.AddWithValue("@IsGarden", list[11]);
                    cmdIns.Parameters.AddWithValue("@IsHeating", list[12]);
                    cmdIns.Parameters.AddWithValue("@IsBasement", list[13]);
                    cmdIns.ExecuteNonQuery();
                    cmdUpt.ExecuteNonQuery();

                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                string sqlIns = "UPDATE buildings SET Address=@address,Account=@account,floors=@floors, tenants=@tenants,for_whom=@for_whom,gardner=@gardner,gardner_phone=@gardner_phone,elevator_num=@elevator_num,heating_type=@heating_type,service_type=@service_type,IsElevator=@IsElevator,IsGarden=@IsGarden,IsHeating=@IsHeating,IsBasement=@IsBasement WHERE Address=@id";
                string sqlUpT = "UPDATE tenants SET building='" + list[0] + "' WHERE building='" + id + "'"; //UPDATE BUILDING NAME IN TENANTS, WHEN UPDATING CURRENT BUILDING
                try
                {
                    conLocal.Open();
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conLocal);
                    SqlCommand cmdUpt = new SqlCommand(sqlUpT, conLocal);
                    cmdIns.Parameters.AddWithValue("@id", id);
                    cmdIns.Parameters.AddWithValue("@address", list[0]);
                    cmdIns.Parameters.AddWithValue("@account", list[1]);
                    cmdIns.Parameters.AddWithValue("@floors", list[2]);
                    cmdIns.Parameters.AddWithValue("@tenants", list[3]);
                    cmdIns.Parameters.AddWithValue("@for_whom", list[4]);
                    cmdIns.Parameters.AddWithValue("@gardner", list[5]);
                    cmdIns.Parameters.AddWithValue("@gardner_phone", list[6]);
                    cmdIns.Parameters.AddWithValue("@elevator_num", list[7]);
                    cmdIns.Parameters.AddWithValue("@heating_type", list[8]);
                    cmdIns.Parameters.AddWithValue("@service_type", list[9]);
                    cmdIns.Parameters.AddWithValue("@IsElevator", list[10]);
                    cmdIns.Parameters.AddWithValue("@IsGarden", list[11]);
                    cmdIns.Parameters.AddWithValue("@IsHeating", list[12]);
                    cmdIns.Parameters.AddWithValue("@IsBasement", list[13]);
                    cmdIns.ExecuteNonQuery();
                    cmdUpt.ExecuteNonQuery();

                }
                finally
                {
                    conLocal.Close();
                }
            }
        }


        public List<Tenants.Tenant> updateTenantsList()
        {
            List <Tenants.Tenant> list = new List<Tenants.Tenant>();
            string name, building_name, appartment_number, phone, state;
            //try
            //{
            // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //  con.Open();
            //   isOnline = true;
            //}
            // catch
            //  {
            //   isOnline = false;
            //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
            //   try
            //   {
            //       conLocal.Open();
            //  }
            //  catch
            //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
            //   }
            //}
            if (isOnline)
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tenants ", con); //for reading
                MySqlDataReader reader = cmd.ExecuteReader(); //for writing
                while (reader.Read()) //for writing
                {
                    name = reader[0].ToString().Trim();
                    building_name = reader[1].ToString().Trim();
                    appartment_number = reader[7].ToString().Trim();
                    phone = reader[3].ToString().Trim();
                    state = reader[6].ToString().Trim();
                    Tenants.Tenant tenant = new Tenants.Tenant();
                    tenant.apartmentNumber = Convert.ToInt32(appartment_number);
                    tenant.Name = name;
                    tenant.building = building_name;
                    tenant.phone = phone;
                    tenant.state = state;
                    list.Add(tenant);
                }
                con.Close();
                return list;
            }
            else
            {
                conLocal.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tenants ", conLocal); //for reading
                SqlDataReader reader = cmd.ExecuteReader(); //for writing
                while (reader.Read()) //for writing
                {
                    name = reader[0].ToString().Trim();
                    building_name = reader[1].ToString().Trim();
                    appartment_number = reader[7].ToString().Trim();
                    phone = reader[3].ToString().Trim();
                    state = reader[6].ToString().Trim();
                    Tenants.Tenant tenant = new Tenants.Tenant();
                    tenant.apartmentNumber = Convert.ToInt32(appartment_number);
                    tenant.Name = name;
                    tenant.building = building_name;
                    tenant.phone = phone;
                    tenant.state = state;
                    list.Add(tenant);
                }
                conLocal.Close();
                return list;
            }
        }




        public List<Tenants.Tenant> showTenantsListOnReport(string address)
        {
            List<Tenants.Tenant> list = new List<Tenants.Tenant>();
            string name, appartment_number, january, feb, mar, apr, may, june, july, aug, sep, oct, nov, dec;
            address = address.Trim();
            //try
            //{
            // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //  con.Open();
            //   isOnline = true;
            //}
            // catch
            //  {
            //   isOnline = false;
            //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
            //   try
            //   {
            //       conLocal.Open();
            //  }
            //  catch
            //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
            //   }
            //}
            if (isOnline)
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tenants WHERE building='" + address + "'", con); //for reading
                MySqlDataReader reader = cmd.ExecuteReader(); //for writing
                while (reader.Read()) //for writing
                {
                    name = reader[0].ToString().Trim();
                    appartment_number = reader[7].ToString().Trim();
                    january = reader[8].ToString().Trim();
                    feb = reader[9].ToString().Trim();
                    mar = reader[10].ToString().Trim();
                    apr = reader[11].ToString().Trim();
                    may = reader[12].ToString().Trim();
                    june = reader[13].ToString().Trim();
                    july = reader[14].ToString().Trim();
                    aug = reader[15].ToString().Trim();
                    sep = reader[16].ToString().Trim();
                    oct = reader[17].ToString().Trim();
                    nov = reader[18].ToString().Trim();
                    dec = reader[19].ToString().Trim();
                    Tenants.Tenant tenant = new Tenants.Tenant();
                    tenant.apartmentNumber = Convert.ToInt32(appartment_number);
                    tenant.Name = name;
                    tenant.January = january;
                    tenant.February = feb;
                    tenant.March = mar;
                    tenant.April = apr;
                    tenant.May = may;
                    tenant.June = june;
                    tenant.July = july;
                    tenant.August = aug;
                    tenant.September = sep;
                    tenant.October = oct;
                    tenant.November = nov;
                    tenant.December = dec;
                    list.Add(tenant);
                }
                con.Close();
                return list;
            }
            else
            {
                conLocal.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tenants WHERE building='" + address + "'", conLocal); //for reading
                SqlDataReader reader = cmd.ExecuteReader(); //for writing
                while (reader.Read()) //for writing
                {
                    name = reader[0].ToString().Trim();
                    appartment_number = reader[7].ToString().Trim();
                    january = reader[8].ToString().Trim();
                    feb = reader[9].ToString().Trim();
                    mar = reader[10].ToString().Trim();
                    apr = reader[11].ToString().Trim();
                    may = reader[12].ToString().Trim();
                    june = reader[13].ToString().Trim();
                    july = reader[14].ToString().Trim();
                    aug = reader[15].ToString().Trim();
                    sep = reader[16].ToString().Trim();
                    oct = reader[17].ToString().Trim();
                    nov = reader[18].ToString().Trim();
                    dec = reader[19].ToString().Trim();
                    Tenants.Tenant tenant = new Tenants.Tenant();
                    tenant.apartmentNumber = Convert.ToInt32(appartment_number);
                    tenant.Name = name;
                    tenant.January = january;
                    tenant.February = feb;
                    tenant.March = mar;
                    tenant.April = apr;
                    tenant.May = may;
                    tenant.June = june;
                    tenant.July = july;
                    tenant.August = aug;
                    tenant.September = sep;
                    tenant.October = oct;
                    tenant.November = nov;
                    tenant.December = dec;
                    list.Add(tenant);
                }
                conLocal.Close();
                return list;
            }
        }


        public void deleteTenant(string name)
        {
            //try
            //{
            // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //  con.Open();
            //   isOnline = true;
            //}
            // catch
            //  {
            //   isOnline = false;
            //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
            //   try
            //   {
            //       conLocal.Open();
            //  }
            //  catch
            //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
            //   }
            //}
            if (isOnline)
            {
                con.Open();
                MySqlCommand Command = new MySqlCommand("DELETE FROM tenants WHERE name='" + name + "'", con);
                Command.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                conLocal.Open();
                SqlCommand Command = new SqlCommand("DELETE FROM tenants WHERE name='" + name + "'", conLocal);
                Command.ExecuteNonQuery();
                conLocal.Close();
            }
        }



        public string[] showTenant(string name)
        {
            string[] tempList = new string[8];
            string address = name;
            //try
            //{
            // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //  con.Open();
            //   isOnline = true;
            //}
            // catch
            //  {
            //   isOnline = false;
            //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
            //   try
            //   {
            //       conLocal.Open();
            //  }
            //  catch
            //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
            //   }
            //}
            if (isOnline)
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tenants WHERE name='" + name + "'", con); //for reading
                MySqlDataReader reader = cmd.ExecuteReader(); //for writing
                while (reader.Read()) //for writing
                {
                    tempList[0] = reader[0].ToString().Trim();
                    tempList[1] = reader[7].ToString().Trim();
                    tempList[2] = reader[2].ToString().Trim();
                    tempList[3] = reader[6].ToString().Trim();
                    tempList[4] = reader[3].ToString().Trim();
                    tempList[5] = reader[4].ToString().Trim();
                    tempList[6] = reader[1].ToString().Trim();
                    tempList[7] = reader[5].ToString().Trim();
                }
                con.Close();
                return tempList;
            }
            else
            {
                conLocal.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tenants WHERE name='" + name + "'", conLocal); //for reading
                SqlDataReader reader = cmd.ExecuteReader(); //for writing
                while (reader.Read()) //for writing
                {
                    tempList[0] = reader[0].ToString().Trim();
                    tempList[1] = reader[7].ToString().Trim();
                    tempList[2] = reader[2].ToString().Trim();
                    tempList[3] = reader[6].ToString().Trim();
                    tempList[4] = reader[3].ToString().Trim();
                    tempList[5] = reader[4].ToString().Trim();
                    tempList[6] = reader[1].ToString().Trim();
                    tempList[7] = reader[5].ToString().Trim();
                }
                conLocal.Close();
                return tempList;
            }
        }





        public void updateTenantOfReports(string[] list, int year) //???????????????????????????????????????????????
        {
            //try
            //{
            // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //  con.Open();
            //   isOnline = true;
            //}
            // catch
            //  {
            //   isOnline = false;
            //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
            //   try
            //   {
            //       conLocal.Open();
            //  }
            //  catch
            //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
            //   }
            //}
            string sqlIns = "UPDATE tenants SET january" + year + "=@jan,february" + year + "=@feb,march" + year + "=@mar, april" + year + "=@apr,may" + year + "=@may,june" + year + "=@jun,july" + year + "=@jul,august" + year + "=@aug, september" + year + "=@sep, october" + year + "=@oct, november" + year + "=@nov, december" + year + "=@dec WHERE name=@name";

            if (isOnline)
            {
                try
                {
                    con.Open();
                    MySqlCommand cmdIns = new MySqlCommand(sqlIns, con);
                    cmdIns.Parameters.AddWithValue("@jan", list[2]);
                    cmdIns.Parameters.AddWithValue("@feb", list[3]);
                    cmdIns.Parameters.AddWithValue("@mar", list[4]);
                    cmdIns.Parameters.AddWithValue("@apr", list[5]);
                    cmdIns.Parameters.AddWithValue("@may", list[6]);
                    cmdIns.Parameters.AddWithValue("@jun", list[7]);
                    cmdIns.Parameters.AddWithValue("@jul", list[8]);
                    cmdIns.Parameters.AddWithValue("@aug", list[9]);
                    cmdIns.Parameters.AddWithValue("@sep", list[10]);
                    cmdIns.Parameters.AddWithValue("@oct", list[11]);
                    cmdIns.Parameters.AddWithValue("@nov", list[12]);
                    cmdIns.Parameters.AddWithValue("@dec", list[13]);
                    cmdIns.Parameters.AddWithValue("@name", list[1]);

                    int t = cmdIns.ExecuteNonQuery();

                }

                finally
                {
                    con.Close();

                }
            }
            else
            {
                try
                {
                    conLocal.Open();
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conLocal);
                    cmdIns.Parameters.AddWithValue("@jan", list[2]);
                    cmdIns.Parameters.AddWithValue("@feb", list[3]);
                    cmdIns.Parameters.AddWithValue("@mar", list[4]);
                    cmdIns.Parameters.AddWithValue("@apr", list[5]);
                    cmdIns.Parameters.AddWithValue("@may", list[6]);
                    cmdIns.Parameters.AddWithValue("@jun", list[7]);
                    cmdIns.Parameters.AddWithValue("@jul", list[8]);
                    cmdIns.Parameters.AddWithValue("@aug", list[9]);
                    cmdIns.Parameters.AddWithValue("@sep", list[10]);
                    cmdIns.Parameters.AddWithValue("@oct", list[11]);
                    cmdIns.Parameters.AddWithValue("@nov", list[12]);
                    cmdIns.Parameters.AddWithValue("@dec", list[13]);
                    cmdIns.Parameters.AddWithValue("@name", list[1]);

                    int t = cmdIns.ExecuteNonQuery();

                }

                finally
                {
                    conLocal.Close();

                }
            }
        }




        /// <summary>
        /// ///////
        /// </summary>
        /// <param name="list"></param>
        /// <param name="address"></param>









        public void updateTenant(string [] list, string address)
        {
            
            string sqlIns = "UPDATE tenants SET name=@name,building=@building,floor_number=@floor, phoner_number=@phone,cellphone_number=@cellphone,email_address=@email,appartment_state=@state,appartent_number=@app_number WHERE name=@id";
            //try
            //{
            // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //  con.Open();
            //   isOnline = true;
            //}
            // catch
            //  {
            //   isOnline = false;
            //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
            //   try
            //   {
            //       conLocal.Open();
            //  }
            //  catch
            //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
            //   }
            //}
            if (isOnline)
            {
                try
                {
                    con.Open();
                    MySqlCommand cmdIns = new MySqlCommand(sqlIns, con);
                    cmdIns.Parameters.AddWithValue("@name", list[0]);
                    cmdIns.Parameters.AddWithValue("@building", list[1]);
                    cmdIns.Parameters.AddWithValue("@floor", list[2]);
                    cmdIns.Parameters.AddWithValue("@phone", list[3]);
                    cmdIns.Parameters.AddWithValue("@cellphone", list[4]);
                    cmdIns.Parameters.AddWithValue("@email", list[7]);
                    cmdIns.Parameters.AddWithValue("@state", list[5]);
                    cmdIns.Parameters.AddWithValue("@app_number", list[6]);
                    cmdIns.Parameters.AddWithValue("@id", address);
                    int t = cmdIns.ExecuteNonQuery();

                }

                finally
                {
                    con.Close();
                    Switcher.Switch(new Tenants());

                }
            }
            else
            {
                try
                {
                    conLocal.Open();
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conLocal);
                    cmdIns.Parameters.AddWithValue("@name", list[0]);
                    cmdIns.Parameters.AddWithValue("@building", list[1]);
                    cmdIns.Parameters.AddWithValue("@floor", list[2]);
                    cmdIns.Parameters.AddWithValue("@phone", list[3]);
                    cmdIns.Parameters.AddWithValue("@cellphone", list[4]);
                    cmdIns.Parameters.AddWithValue("@email", list[7]);
                    cmdIns.Parameters.AddWithValue("@state", list[5]);
                    cmdIns.Parameters.AddWithValue("@app_number", list[6]);
                    cmdIns.Parameters.AddWithValue("@id", address);
                    int t = cmdIns.ExecuteNonQuery();

                }

                finally
                {
                    conLocal.Close();
                    Switcher.Switch(new Tenants());

                }
            }

        }

        public void saveTenant(string [] list)
        {
            //try
            //{
            // con = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //  con.Open();
            //   isOnline = true;
            //}
            // catch
            //  {
            //   isOnline = false;
            //   conLocal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString);
            //   try
            //   {
            //       conLocal.Open();
            //  }
            //  catch
            //   {
            //        //SHOW MESSAGE IN OTHER CLASS OR SOMETHING LIKE THAT     
            //   }
            //}
            string sqlIns = "INSERT INTO tenants (name,building, floor_number, phoner_number, cellphone_number, email_address, appartment_state, appartent_number) VALUES (@name, @building, @floor, @phone, @cellphone, @email, @state, @appar_number)";
            if (isOnline)
            {
                try
                {
                    con.Open();
                    MySqlCommand cmdIns = new MySqlCommand(sqlIns, con);
                    cmdIns.Parameters.AddWithValue("@name", list[0]);
                    cmdIns.Parameters.AddWithValue("@building", list[1]);
                    cmdIns.Parameters.AddWithValue("@floor", list[2]);
                    cmdIns.Parameters.AddWithValue("@phone", list[3]);
                    cmdIns.Parameters.AddWithValue("@cellphone", list[4]);
                    cmdIns.Parameters.AddWithValue("@email", list[7]);
                    cmdIns.Parameters.AddWithValue("@state", list[5]);
                    cmdIns.Parameters.AddWithValue("@appar_number", list[6]);

                    cmdIns.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                    Switcher.Switch(new Tenants());
                }
            }
            else
            {
                try
                {
                    conLocal.Open();
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conLocal);
                    cmdIns.Parameters.AddWithValue("@name", list[0]);
                    cmdIns.Parameters.AddWithValue("@building", list[1]);
                    cmdIns.Parameters.AddWithValue("@floor", list[2]);
                    cmdIns.Parameters.AddWithValue("@phone", list[3]);
                    cmdIns.Parameters.AddWithValue("@cellphone", list[4]);
                    cmdIns.Parameters.AddWithValue("@email", list[7]);
                    cmdIns.Parameters.AddWithValue("@state", list[5]);
                    cmdIns.Parameters.AddWithValue("@appar_number", list[6]);

                    cmdIns.ExecuteNonQuery();
                }
                finally
                {
                    conLocal.Close();
                    Switcher.Switch(new Tenants());
                }
            }
        }


    }
}
