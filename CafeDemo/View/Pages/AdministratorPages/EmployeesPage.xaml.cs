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
        List<Employee> employees = App.context.Employee.ToList();
        List<Role> roles = App.context.Role.ToList();
        public EmployeesPage()
        {
            InitializeComponent();

            EmployeesLv.ItemsSource = employees;
            EmployeesLv.SelectedIndex = 0;

            // Программно добавляем пункт для выбора пользователей всех должностей.
            roles.Insert(0, new Role { Name = "Все должности" });

            // Заполнение выпадающего списка для поиска.
            FilterByRoleCmb.ItemsSource = roles;
            FilterByRoleCmb.DisplayMemberPath = "Name";
            FilterByRoleCmb.SelectedValuePath = "Id";
            FilterByRoleCmb.SelectedIndex = 0;
        }

        private void AddNewEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmployeeWindow addNewEmployeeWindow = new AddNewEmployeeWindow();
            addNewEmployeeWindow.ShowDialog();
        }

        private void SaveEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            // Подхватываем изменения в роль из выпадающего списка.
            (EmployeesLv.SelectedItem as Employee).RoleId = Convert.ToInt32(RoleCmb.SelectedValue);

            App.context.SaveChanges();

            EmployeesLv.ItemsSource = employees = App.context.Employee.ToList();

            MessageBoxHelper.Information("Данные пользователя изменены!");
        }

        private void EmployeesLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeeGrid.DataContext = EmployeesLv.SelectedItem as Employee;

            RoleCmb.ItemsSource = App.context.Role.ToList();
            RoleCmb.DisplayMemberPath = "Name";
            RoleCmb.SelectedValuePath = "Id";
            // Влияет на поиск. Выдаёт исключение типа NullReferenceException.
            // Если при поиске выбранный пользователь пропадает из списка, то нужно установить индекс на -1 (убрать выбор) из выпадающего списка.
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
                EmployeesLv.ItemsSource = employees = employees.Where(employee => employee.Name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();
            }
            else
            {
                EmployeesLv.ItemsSource = employees = App.context.Employee.ToList();
            }
        }
        #endregion

        #region Фильтрация
        private void FilterByRoleCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterByRoleCmb.SelectedIndex != 0)
            {
                EmployeesLv.ItemsSource = employees.Where(employee => employee.RoleId == FilterByRoleCmb.SelectedIndex).ToList();
            }
            else
            {
                EmployeesLv.ItemsSource = employees;
            }
        }
        #endregion
    }
}
