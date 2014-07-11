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
using System.Windows.Markup;

namespace Management_System
{

    public partial class Buildings : UserControl
    {
        SqlDB db;
        List<string> items, data;
        List<Building> items1;
        Building building;

        public Buildings() //Constructor of Buildings
        {
            
            InitializeComponent();//Initialize UC

            BitmapImage pic = new BitmapImage();
            pic.BeginInit();
            pic.UriSource = new Uri(@"/Management_System;component/Resources/home.png", UriKind.Relative);
            pic.EndInit();
            building_img.Source = pic;

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
            UpdateList(); //Refreshing Buildings list
        }

        private void buildingslvDataBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            data = new List<string>();
            ListView list = sender as ListView;
            if (list.SelectedItem != null)
            {
                building_Address.Text = list.SelectedItem.ToString();
                string temp = building_Address.Text.ToString().Trim();
                data = db.getAllBuildingInfo(temp);
                account_Number_field.Text = data[1];
                number_of_floors_field.Text = data[2];
                attendence_box.Text = data[3];
                check_for_box.Text = data[4];
                garden_name_box.Text = data[5];
                gardner_phone_box.Text = data[6];
                elevator_num_box.Text = data[7];
                heating_type_box.Text = data[8];
                service_type_box.Text = data[9];
                if (data[10].Equals("Yes"))
                    evelvator_check.IsChecked = true;
                else
                    evelvator_check.IsChecked = false;
                if (data[11].Equals("Yes"))
                   garden_check.IsChecked = true;
                else
                    garden_check.IsChecked = false;
                if (data[12].Equals("Yes"))
                    heating_check.IsChecked = true;
                else
                    heating_check.IsChecked = false;
                if (data[13].Equals("Yes"))
                    miklat_check.IsChecked = true;
                else
                    miklat_check.IsChecked = false;
            }
        }

        private void cmd_NewBuilding_Click(object sender, RoutedEventArgs e)
        {
            var building1 = new new_building(); //Open new building form
            building1.Show();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            items1 = null;
            items = null;
            building = null;
            Switcher.Switch(this,new MainMenu()); //Returns to main menu
        }

        public void UpdateList()
        {

            items1 = new List<Building>();
            items = db.UpdateBuildingsList();
            for (int i=0; i < items.Count; i++)
            {
                building = new Building();
                building.Address = items[i];
                items1.Add(building);
            }
            buildingslvDataBinding.ItemsSource = items1;
            buildingslvDataBinding.Items.Refresh();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(buildingslvDataBinding.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Address", ListSortDirection.Ascending)); //Sort by name of tenant
        }


        private void cmd_EditBuilding_Click(object sender, RoutedEventArgs e) //
        {

            if (buildingslvDataBinding.SelectedItem != null)
            {
              
                string temp = buildingslvDataBinding.SelectedItem.ToString();
                db.deleteBuilding(temp);
                UpdateList();
                building_Address.Text = "";
                account_Number_field.Text = "";
                number_of_floors_field.Text = "";
                attendence_box.Text  ="";
                check_for_box.Text = "";
                garden_name_box.Text= "";
                gardner_phone_box.Text="";
                elevator_num_box.Text ="";
                heating_type_box.Text = "";
                service_type_box.Text = "";
                evelvator_check.IsChecked = false;
                garden_check.IsChecked = false;
                heating_check.IsChecked = false;
                miklat_check.IsChecked = false;


            }
            else
            {
                MessageBox.Show("לא נבחר בניין");
            }
           
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            Window exit = new exit_query();
            exit.Show();       
        }



        protected class Building //Represent a Building
        {

            public string Address { get; set; }
            public override string ToString()
            {
                return this.Address;
            }

        }

        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (buildingslvDataBinding.SelectedItem != null)
            {
                
                string address= buildingslvDataBinding.SelectedItem.ToString();
                var building1 = new new_building(address); //Open new building form
                building1.Show();
            }
            else
            {
                MessageBox.Show("לא נבחר בניין");
            }
            
            //OPEN NEW_BUILDING WITH SAME DATA BY ADDRESS AND 'UPDATE' (!!!!!) SQL TABLE
        }

        private void meetings_Click(object sender, RoutedEventArgs e)
        {
            if (buildingslvDataBinding.SelectedItem == null)
                MessageBox.Show("בחר בניין");
            else
            {
                var meetings = new meetings(buildingslvDataBinding.SelectedItem.ToString()); //Open Tenants Meetings window
                meetings.Show();

            }
        }

        private void print_building_Click(object sender, RoutedEventArgs e)
        {
         if (buildingslvDataBinding.SelectedItem == null)
        {
            MessageBox.Show("לא נבחר בניין");
        }
        else
     {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() != true) 
                return;
            FlowDocument doc = new FlowDocument();
            doc.ColumnWidth = pd.PrintableAreaWidth;

            Paragraph p = new Paragraph();

            p = new Paragraph(new Run(buildingslvDataBinding.SelectedItem.ToString()));
            p.TextDecorations = TextDecorations.Underline;
            p.TextAlignment = TextAlignment.Center;
            p.FontSize = 36;
            p.Padding = new Thickness(48);
            doc.Blocks.Add(p);

            p = new Paragraph(new Run(account_Number_field.Text + " " + account_Number.Text + "\n"));
            styleParagraph(p, doc);

            p.Inlines.Add(new Run(number_of_floors_field.Text + " " + floors_text.Text + "\n"));
            styleParagraph(p, doc);

            p.Inlines.Add(new Run(attendence_box.Text + " " + attendence_text.Text + "\n"));
            styleParagraph(p, doc);
            if (check_for_box.Text != "")
            p.Inlines.Add(new Run("לפקודת:" + " " + check_for_box.Text + "\n"));
            else
                p.Inlines.Add(new Run("לפקודת: אין" + "\n"));
            styleParagraph(p, doc);

            p.Inlines.Add(new Run("שם גנן:" + " " + garden_name_box.Text + "\n"));
            styleParagraph(p, doc);

            p.Inlines.Add(new Run("מספר טלפון:" + " " + gardner_phone_box.Text + "\n"));
            styleParagraph(p, doc);

            if (evelvator_check.IsChecked == true)
                p.Inlines.Add(new Run("מעליות: " + elevator_num_box.Text + "\n"));
            else
                p.Inlines.Add(new Run("מעליות: אין" + "\n"));

            styleParagraph(p, doc);


            if (garden_check.IsChecked == true)
                p.Inlines.Add(new Run("גינה: יש" + "\n"));
            
            else
                p.Inlines.Add(new Run("גינה: אין" + "\n"));


            styleParagraph(p, doc);

            if (heating_check.IsChecked == true)
            {
                p.Inlines.Add(new Run("הסקה: יש" + "\n"));
            }
            else
            {
                p.Inlines.Add(new Run("הסקה: אין" + "\n"));
            }

            styleParagraph(p, doc);

            if (miklat_check.IsChecked==true)
                p.Inlines.Add(new Run("מקלט: יש" + "\n"));
            else
                p.Inlines.Add(new Run("מקלט: אין"+"\n"));
           
            styleParagraph(p, doc);

            p.Inlines.Add(new Run("סוג חימום: " + heating_type_box.Text + "\n"));
            styleParagraph(p, doc);

            p.Inlines.Add(new Run("סוג שירות: " + service_type_box.Text + "\n"));
            styleParagraph(p, doc);

             IDocumentPaginatorSource dps = doc;
             pd.PrintDocument(dps.DocumentPaginator, "flowdoc");

            //FixedDocument document = new FixedDocument();
            //document.DocumentPaginator.PageSize = new Size(pd.PrintableAreaWidth, pd.PrintableAreaHeight);
            //FixedPage page1 = new FixedPage();
           // page1.Width = document.DocumentPaginator.PageSize.Width;
           // page1.Height = document.DocumentPaginator.PageSize.Height;

            // add some text to the page
//            TextBlock page1Text = new TextBlock();

  //          page1Text.Width = page1.Width;
    //        page1Text.Text = buildingslvDataBinding.SelectedItem.ToString(); 
      //      page1Text.FontSize = 40; // 30pt text
        //    page1Text.VerticalAlignment = VerticalAlignment.Center; 
            //page1Text.Margin = new Thickness(96); // 1 inch margin
 //           page1Text.Width = document.DocumentPaginator.PageSize.Width;
 //           page1Text.TextAlignment = TextAlignment.Center;
 //           page1Text.TextDecorations = TextDecorations.Underline;
  //          page1Text.Padding = new Thickness(96);
   //          TextBlock page2Text = new TextBlock();
  ///           page2Text.Text = "BLABLABLA";
   //          page2Text.Padding = new Thickness(200);
    //        page1.Children.Add(page1Text);
             
     //       PageContent page1Content = new PageContent();
     //       ((IAddChild)page1Content).AddChild(page1);
     //       document.Pages.Add(page1Content);
     //       pd.PrintDocument(document.DocumentPaginator, "My first document");
        }
}


        private void styleParagraph(Paragraph p, FlowDocument fd)
        {
            p.FontSize = 24;
           // p.Margin = new Thickness(96);
           // p.FontStyle = FontStyles.Italic;
            Thickness margin = p.Margin;
            margin.Right = 48;
            p.Margin = margin;
            p.Inlines.Add("\n");
            p.TextAlignment = TextAlignment.Right;
            p.Foreground = Brushes.Black;
            fd.Blocks.Add(p);
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.PrintVisual(this.print_building, "Print Button");
            
        }

    }


   

    
}
