using CafeDemo.AppData;
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
    /// Interaction logic for EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();

            EmployeesLv.ItemsSource = App.context.Employee.ToList();
            EmployeesLv.SelectedIndex = 0;
        }

        private void AddNewEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmployeeWindow addNewEmployeeWindow = new AddNewEmployeeWindow();
            addNewEmployeeWindow.ShowDialog();
        }

        private void SaveEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            // Подхватываем изменения в роль из комбобокса
            (EmployeesLv.SelectedItem as Employee).RoleId = Convert.ToInt32(RoleCmb.SelectedValue);

            App.context.SaveChanges();

            EmployeesLv.ItemsSource = App.context.Employee.ToList();

            MessageBoxHelper.Information("Данные пользователя изменены!");
        }

        private void EmployeesLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeeGrid.DataContext = EmployeesLv.SelectedItem as Employee;

            RoleCmb.ItemsSource = App.context.Role.ToList();
            RoleCmb.DisplayMemberPath = "Name";
            RoleCmb.SelectedValuePath = "Id";
            // Влияет на поиск. Выдаёт исключение типа NullReferenceException.
            // Если при поиске выбранный пользователь пропадает из поиска, то нужно убрать индекс выбранного элемента из комбобокса.
            RoleCmb.SelectedIndex = EmployeesLv.SelectedItem as Employee != null ? (EmployeesLv.SelectedItem as Employee).RoleId - 1 : -1;
        }

        #region Поиск
        private void SearchTb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTb.Text == string.Empty)
            {
                SearchTbl.Text = string.Empty;
            }
        }

        private void SearchTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTb.Text == string.Empty)
            {
                SearchTbl.Text = "Поиск по имени";
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTb.Text != string.Empty)
            {
                EmployeesLv.ItemsSource = App.context.Employee.Where(employee => employee.Name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();
            }
            else
            {
                EmployeesLv.ItemsSource = App.context.Employee.ToList();
            }
        }
        #endregion
    }
}
