using CafeDemo.Model;
using CafeDemo.View.Windows;
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

            ShiftsLv.ItemsSource = App.context.Shift.ToList();
        }

        private void AddNewShiftBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewShiftWindow addNewShiftWindow = new AddNewShiftWindow();
            addNewShiftWindow.ShowDialog();
        }

        private void ShiftsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Shift selectedShift = ShiftsLv.SelectedItem as Shift;

            ShiftGrid.DataContext = selectedShift;

            ShiftEmployeesLv.ItemsSource = App.context.EmployeeShift.Where(employeeShift => employeeShift.ShiftId == selectedShift.Id).ToList();
        }
    }
}
