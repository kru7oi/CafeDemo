using CafeDemo.AppData;
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

namespace CafeDemo.View.Windows
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            if (Properties.Settings.Default.LoginValue != string.Empty)
            {
                LoginTb.Text = Properties.Settings.Default.LoginValue;
                PaswwordPb.Password = Properties.Settings.Default.PasswordValue;
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationHelper.CheckData(LoginTb.Text, PaswwordPb.Password, RememberMeCb.IsChecked);
        }
    }
}
