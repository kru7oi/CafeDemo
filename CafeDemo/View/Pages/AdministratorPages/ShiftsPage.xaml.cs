using CafeDemo.Model;
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

namespace CafeDemo.View.Pages.AdministratorPages
{
    /// <summary>
    /// Interaction logic for ShiftsPage.xaml
    /// </summary>
    public partial class ShiftsPage : Page
    {
        public ShiftsPage()
        {
            InitializeComponent();

            ShiftsLv.ItemsSource = App.context.EmployeeShift.ToList();
        }

        private void AddNewShiftBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShiftsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeeShift selectedShift = ShiftsLv.SelectedItem as EmployeeShift;
            ShiftGrid.DataContext = selectedShift;

            ShiftEmployeesLb.ItemsSource = App.context.EmployeeShift.Where(employeeShift => employeeShift.ShiftId == selectedShift.ShiftId).ToList();
        }
    }
}
