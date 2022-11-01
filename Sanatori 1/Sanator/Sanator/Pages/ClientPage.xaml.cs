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
using Sanator.Module;
using Sanator.Pages;

namespace Sanator.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public List<client> clients { get; set; }
        public ClientPage()
        {
            InitializeComponent();
            DateClient.ItemsSource = null;
            clients = sanEntities.GetContext().clients.ToList();
            DataContext = this;
            DateClient.ItemsSource = clients;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddPage((client)(sender as Button).DataContext));

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddPage(null));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = DateClient.SelectedItems.Cast<client>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedClient.Count()} записей??", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    client x = selectedClient[0];
                    sanEntities.GetContext().clients.Remove(x);
                    sanEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<client> clients = sanEntities.GetContext().clients.OrderBy(p => p.lastname).ToList();
                    DateClient.ItemsSource = null;
                    DateClient.ItemsSource = clients;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
