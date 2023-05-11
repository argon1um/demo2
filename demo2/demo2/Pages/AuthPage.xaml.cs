using demo2.Models;
using demo2.Utility;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
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

namespace demo2.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        List<User> users = App.Context.Users.ToList();
        public AuthPage()
        {
            InitializeComponent();
        }

        private void signin_Click(object sender, RoutedEventArgs e)
        {
            string password = passwordpb.Password.ToString();
            string login = logintextbox.Text;
            bool check = false;
            string authuser = "";
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                foreach(User user in users)
                {
                    if (password == user.Userpassword && login == user.Userlogin)
                    {
                        authuser = user.Username+user.Usersurname;
                        check = true;
                    }
                }
                if (check)
                {
                    MessageBox.Show($"Добро пожаловать, {authuser}", "Уведомление");
                    PageManager.frame.Navigate(new OutPutPage());
                    App.Current.MainWindow.Title = authuser;
                }
            }

        }
    }
}
