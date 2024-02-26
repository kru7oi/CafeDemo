using CafeDemo.AppData;
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
using System.Windows.Shapes;

namespace CafeDemo.View.Windows
{
    /// <summary>
    /// Interaction logic for AddNewEmployeeWindow.xaml
    /// </summary>
    public partial class AddNewEmployeeWindow : Window
    {
        public AddNewEmployeeWindow()
        {
            InitializeComponent();
            
            GenerateId();
            FillRoles();
        }

        private void AddNewEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee();
        }

        private void GenerateId()
        {
            int id = App.context.Employee.Max(employee => employee.Id);
            id++;
            IdTb.Text = id.ToString();
        }
        private void FillRoles()
        {
            RoleCmb.ItemsSource = App.context.Role.ToList();
            RoleCmb.DisplayMemberPath = "Name";
            RoleCmb.SelectedValuePath = "Id";
        }
        private void AddEmployee()
        {
            if (string.IsNullOrEmpty(NameTb.Text) ||
                DateOfBirthDp.SelectedDate.Value == null ||
                RoleCmb.SelectedValue == null ||
                string.IsNullOrEmpty(LoginTb.Text) ||
                string.IsNullOrEmpty(PasswordPb.Text))
            {
                MessageBoxHelper.Warning("Заполните все поля!");
            }
            else
            {
                try
                {
                    Employee newEmployee = new Employee()
                    {
                        Name = NameTb.Text,
                        DateOfBirth = DateOfBirthDp.SelectedDate.Value,
                        IsFired = false,
                        RoleId = Convert.ToInt32(RoleCmb.SelectedValue),
                        Login = LoginTb.Text,
                        Password = PasswordPb.Text
                    };

                    App.context.Employee.Add(newEmployee);
                    App.context.SaveChanges();

                    MessageBoxHelper.Information("Пользователь успешно добавлен!");
                }
                catch (Exception exception)
                {
                    MessageBoxHelper.Error(exception);
                }
            }
        }
    }
}
