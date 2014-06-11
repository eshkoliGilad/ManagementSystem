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

 //           this.Background = Brushes.Yellow;
            db = new SqlDB();
        }


        private void login_button(object sender, RoutedEventArgs e) //Check if username and password is valid
        {
            string user = textBok_user.Text.ToString().Trim();
            string password = textBox_password.Password;
            bool isValid = db.check_username(user, password);
            if (isValid == false)
                MessageBox.Show("שם משתמש או סיסמא לא נכונים. נסה שוב");
            else
                Switcher.Switch(this, new MainMenu());
        }
    }
}
