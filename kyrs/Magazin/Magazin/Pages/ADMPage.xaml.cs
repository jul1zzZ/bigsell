using Magazin.Modules;
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

namespace Magazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для ADMPage.xaml
    /// </summary>
    public partial class ADMPage : Page
    {
        public ADMPage()
        {
            InitializeComponent();
        }

        private void NEXT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<user> users = libraryEEntities1.GetContext().user.ToList();

                user u = users.FirstOrDefault(p => p.pass == PB.Text);


                if (u == null)
                {
                    MessageBox.Show("*Не тот пароль*");
                    return;
                }
                else { NavigationService.Navigate(new Pages.ADMPage2()); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Osnova());
        }

        private void REG_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.RegPage());
        }
    }
}
