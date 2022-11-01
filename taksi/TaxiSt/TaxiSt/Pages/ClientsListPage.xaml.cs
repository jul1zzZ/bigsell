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
using TaxiSt.Modules;

namespace TaxiSt.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsListPage.xaml
    /// </summary>
    public partial class ClientsListPage : Page
    {
        public List<Client> Clients { get; set; }
        public ClientsListPage()
        {
            InitializeComponent();
            dataClient.ItemsSource = null;
            Clients = TaxiEntities.GetContext().Clients.ToList();
            DataContext = this;
            dataClient.ItemsSource = Clients;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.TaxiClientInfoPage());
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = dataClient.SelectedItems.Cast<Client>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedClient.Count()} записей?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Client x = selectedClient[0];
                   TaxiEntities.GetContext().Clients.Remove(x);
                    TaxiEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Client> clients = TaxiEntities.GetContext().Clients.OrderBy(p => p.Name).ToList();
                    dataClient.ItemsSource = null;
                    dataClient.ItemsSource = clients;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
