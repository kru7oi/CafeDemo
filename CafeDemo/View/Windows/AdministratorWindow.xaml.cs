using CafeDemo.View.Pages.AdministratorPages;
using System.Windows;
using System.Windows.Navigation;

namespace CafeDemo.View.Windows
{
    /// <summary>
    /// Interaction logic for AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();
        }
        private void OpenEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.NavigationService.Navigate(new EmployeesPage());
        }
        private void OpenOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void OpenShiftsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.NavigationService.Navigate(new ShiftsPage());
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.GoBack();
        }

        private void MainFrm_Navigated(object sender, NavigationEventArgs e)
        {
            if (MainFrm.CanGoBack)
            {
                GoBackBtn.Visibility = Visibility.Visible;
            }
            else
            {
                GoBackBtn.Visibility = Visibility.Collapsed;
            }
        }
    }
}
