using Storehouse.Modules;
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

namespace Storehouse
{
  public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = StoreHouseEntities.GetContext().Users.FirstOrDefault(u => u.Login == LoginTb.Text && u.Password == PassTb.Text);
                if (user != null)
                {
                    if (user.RoleID == 1)
                    {
                        MainUserWindow mainUser = new MainUserWindow();
                        mainUser.Show();
                        this.Close();
                    }
                    else if (user.RoleID == 2)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Неправильные данные, пожалуйста, попробуйте еще раз");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
