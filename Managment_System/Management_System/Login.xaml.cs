using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
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
using System.Data.SqlClient;
using System.Data.Sql;
using MySql.Data.MySqlClient;
using MySql.Web;
namespace Management_System
{
    public partial class Login : UserControl
    {
        SqlDB db;

        public Login()
        {
            InitializeComponent();
            BitmapImage pic = new BitmapImage();
            pic.BeginInit();
            pic.UriSource = new Uri(@"/Management_System;component/Resources/companyLogo.png", UriKind.Relative);
            pic.EndInit();
            company_logo.Source = pic;

            BitmapImage pic1 = new BitmapImage();
            pic1.BeginInit();
            pic1.UriSource = new Uri(@"/Management_System;component/Resources/as.png", UriKind.Relative);
            pic1.EndInit();
            as_one.Source = pic1;

            BitmapImage pic2 = new BitmapImage();
            pic2.BeginInit();
            pic2.UriSource = new Uri(@"/Management_System;component/Resources/as2.png", UriKind.Relative);
            pic2.EndInit();
            as_two.Source = pic2;

            //           this.Background = Brushes.Yellow;
            db = new SqlDB();
        }


        private void login_button(object sender, RoutedEventArgs e) //Check if username and password is valid
        {
            var a = new loading();
            a.Show();
            Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle, null);
            //connection();
            string user = textBok_user.Text.ToString().Trim();
            string password = textBox_password.Password;
            bool isValid = db.check_username(user, password);
            a.Close();
            if (isValid == false)
                MessageBox.Show("שם משתמש או סיסמא לא נכונים. נסה שוב");
            else
            {
                if (SqlDB.isOnline)
                    MessageBox.Show("המערכת מחוברת לרשת בהצלחה");
                else
                    MessageBox.Show("המערכת אינה מחוברת לאינטרנט, שים לב כי ניתן להשתמש בתוכנה אך לא ניתן לשמור שינויים");

                Switcher.Switch(this, new MainMenu());
            }
        }

     //   private void connection()
      //  {
       //     try_to_connect.Visibility = Visibility.Visible;
        //    Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle, null);
       // }
        
        }
}
