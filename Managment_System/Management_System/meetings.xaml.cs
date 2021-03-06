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
using System.Windows.Controls.Primitives;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.ComponentModel;

namespace Management_System
{
    /// <summary>
    /// Interaction logic for meetings.xaml
    /// </summary>
    /// 


    //This class represent Tenants Meetings
    public partial class meetings : Window
    {
        string building;
        SqlDB db;
        List<Meeting> items1;
        public string dateString;

        //Meeting Consructor
        public meetings(string s)
        {
            InitializeComponent();
            building = s;
            db = new SqlDB();
            meetings_Address.Text = s;
            dateString = DateTime.Today.ToShortDateString();
            showMeetingsList(s);
        }

        public class Meeting //Represent a Meeting
        {
            public string building { get; set; }
            public string notes { get; set; }
            public string date { get; set; }
        }

        public void showMeetingsList(string address)
        {
            items1 = db.showMeetingList(address);
            TenatsMeetings.ItemsSource = items1;
            TenatsMeetings.Items.Refresh();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(TenatsMeetings.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("date", ListSortDirection.Ascending)); //Sort by date
        }

        //Cancel button
        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Save meetings button
        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            string[] list = new string[3];
            list[0] = building.ToString().Trim();
            list[1] = notes_meetings_box.Text.ToString().Trim();
            list[2] = dateString.ToString().Trim();
            db.addMeeting(list);
            showMeetingsList(list[0]);
            notes_meetings_box.Text = "";
            dateString = DateTime.Today.ToString();
            datepicker_meetings.SelectedDate = DateTime.Parse(dateString);
            MessageBox.Show("אסיפה נשמרה בהצלחה");
        }

        //Double click item in ListView
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = TenatsMeetings.SelectedItem as meetings.Meeting;
            if (item != null)
            {
                this.notes_meetings_box.Text = item.notes.ToString();
                datepicker_meetings.SelectedDate = DateTime.Parse(item.date.ToString());
            }
            else
                MessageBox.Show("לא נבחרה אסיפה");
        }

        //Changing date
        private void DatePicker_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime? date = picker.SelectedDate;
            if (date == null)
                dateString = DateTime.Today.ToString();
            else
                dateString = date.Value.ToShortDateString();
        }

        //Delete meeting
        private void delete_metting_Click(object sender, RoutedEventArgs e)
        {
            var item = TenatsMeetings.SelectedItem as meetings.Meeting;
            if (item != null)
            {
                if (MessageBox.Show("? האם אתה בטוח שברצונך למחוק", "אזהרה", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    //do nothing
                }
                else
                {
                    string a = item.notes.ToString().Trim();
                    string b = item.date.ToString().Trim();
                    db.deleteMeeting(a, b);
                    showMeetingsList(building);
                    notes_meetings_box.Text = "";
                     dateString = DateTime.Today.ToString();
                    datepicker_meetings.SelectedDate = DateTime.Parse(dateString);
                    MessageBox.Show("אסיפה נמחקה בהצלחה");
                }
                
            }
            else
                MessageBox.Show("לא נבחרה אסיפה");
        }
    }
}
