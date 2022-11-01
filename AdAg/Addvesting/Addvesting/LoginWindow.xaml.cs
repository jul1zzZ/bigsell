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
using Addvesting.Modules;

namespace Addvesting
{
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
                Auth auth = AdvAgEntities.GetContext().Auths.FirstOrDefault(u => u.Login == LoginTb.Text && u.Password == PassTb.Text);
                if (auth != null)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверные данные, пожалуйста, попробуйте еще раз!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
