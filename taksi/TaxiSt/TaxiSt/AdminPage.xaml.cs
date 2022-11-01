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

namespace TaxiSt
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();
            SecondFrame.Navigate(new Pages.RidersCatalogPage());
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            SecondFrame.Navigate(new Pages.ClientsListPage());
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            SecondFrame.Navigate(new Pages.OrdersListPage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SecondFrame.CanGoBack)
            {
                SecondFrame.GoBack();
            }
        }

        private void SecondFrame_ContentRendered(object sender, EventArgs e)
        {
            if (SecondFrame.CanGoBack)
            {
                BackBtn.Visibility = Visibility.Visible;
                ClientBtn.Visibility = Visibility.Collapsed;
                OrderBtn.Visibility = Visibility.Collapsed;
                RaiderBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                BackBtn.Visibility = Visibility.Collapsed;
                ClientBtn.Visibility = Visibility.Visible;
                OrderBtn.Visibility = Visibility.Visible;
                RaiderBtn.Visibility = Visibility.Visible;
            }
        }

        private void RaiderBtn_Click(object sender, RoutedEventArgs e)
        {
            SecondFrame.Navigate(new Pages.VodilaListPage());
        }
    }
}
