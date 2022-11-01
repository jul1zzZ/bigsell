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
using TaxiSt.Modules;

namespace TaxiSt
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = TaxiEntities.GetContext().Users.FirstOrDefault(p => p.login == LoginTb.Text && p.password == PassTb.Text);
                if (user != null)
                {
                    if (user.user_id == 3014)
                    {
                        AdminPage adminPage = new AdminPage();
                        adminPage.Show();
                        this.Close();
                    }
                    else
                    {
                        MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Некорректные данные, попробуйте еще раз");
                }
            }  
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }
    }
}
