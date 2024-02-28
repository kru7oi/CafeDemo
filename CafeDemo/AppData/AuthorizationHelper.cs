using CafeDemo.Model;
using CafeDemo.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CafeDemo.AppData
{
    internal class AuthorizationHelper
    {
        public static void CheckData(string login, string password, bool? state)
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

                    #region Запоминание данных пользователя
                    if (state == true)
                    {
                        Properties.Settings.Default.LoginValue = login;
                        Properties.Settings.Default.PasswordValue = password;
                    }
                    else
                    {
                        Properties.Settings.Default.LoginValue = string.Empty;
                        Properties.Settings.Default.PasswordValue = string.Empty;
                    }

                    Properties.Settings.Default.Save();
                    #endregion

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
