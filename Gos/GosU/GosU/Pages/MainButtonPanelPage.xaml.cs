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

namespace GosU.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainButtonPanelPage.xaml
    /// </summary>
    public partial class MainButtonPanelPage : Page
    {
        public MainButtonPanelPage()
        {
            InitializeComponent();
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ClientCatalogPage());
        }

        private void ServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ServiceListPage());
        }

        private void SocialBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ClientListPage());
        }
    }
}
