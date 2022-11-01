using JumperApplication.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace JumperApplication
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public AuthWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = JumperEntities.GetContext().Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);

            CaptchaWindow captchaWindow = new CaptchaWindow();
            if (captchaWindow.ShowDialog() == true)
            {
                if (captchaWindow._isCorrect == false)
                {
                    MessageBox.Show("Каптча введена неверно");
                    return;
                }
                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль, пожалуйста попробуйте ещё раз");
                    return;
                }

                AuthStorage.IsAuth = true;
                AuthStorage.Role = user.Role;

                if (captchaWindow._isCorrect == true)
                {
                    this.Close();
                }
            }

           
        }
    }
}
