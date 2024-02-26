using CafeDemo.Model;
using CafeDemo.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CafeDemo.AppData
{
    internal class AuthorizationHelper
    {
        public static void CheckData(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
            {
                MessageBoxHelper.Warning("Введите логин!");
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBoxHelper.Warning("Введите пароль!");
            }
            else if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                Employee newEmployee = App.context.Employee.FirstOrDefault(employee => employee.Login == login && employee.Password == password);

                if (newEmployee != null)
                {
                    switch (newEmployee.RoleId)
                    {
                        case 1:
                            AdministratorWindow administratorWindow = new AdministratorWindow();
                            administratorWindow.Show();
                            break;
                        case 2:
                            WaiterWindow waiterWindow = new WaiterWindow();
                            waiterWindow.Show();
                            break;
                        case 3:
                            CookWindow cookWindow = new CookWindow();
                            cookWindow.Show();
                            break;
                    }

                    Application.Current.Windows[0].Close();
                }
                else
                {
                    MessageBoxHelper.Error("Неправильно введён логин или пароль!");
                }
            }
            else
            {
                MessageBoxHelper.Warning("Введите логин и пароль!");
            }
        }
    }
}
