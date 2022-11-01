using Librar.Modules;
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

namespace Librar.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientListPage.xaml
    /// </summary>
    public partial class ClientListPage : Page
    {
        public List<Reader> Readers { get; set; }
        public ClientListPage()
        {
            InitializeComponent();
            DataClient.ItemsSource = null;
            Readers = LibrEntities.GetContext().Readers.ToList();
            DataContext = this;
            DataClient.ItemsSource = Readers;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ClientInfoPage((Reader)(sender as Button).DataContext));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ClientInfoPage(null));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedReader = DataClient.SelectedItems.Cast<Reader>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedReader.Count()} записей?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Reader x = selectedReader[0];
                    LibrEntities.GetContext().Readers.Remove(x);
                    LibrEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Reader> readers = LibrEntities.GetContext().Readers.OrderBy(p => p.Name).ToList();
                    DataClient.ItemsSource = null;
                    DataClient.ItemsSource = readers;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
