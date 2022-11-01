using Addvesting.Modules;
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


namespace Addvesting.Pages
{
    public partial class AddvListPage : Page
    {
        public List<Service> Services { get; set; }
        public AddvListPage()
        {
            InitializeComponent();
            dataService.ItemsSource = null;
            Services = AdvAgEntities.GetContext().Services.ToList();
            DataContext = this;
            dataService.ItemsSource = Services;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AdvInfoPage((Service)(sender as Button).DataContext));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AdvInfoPage(null));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedService = dataService.SelectedItems.Cast<Service>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedService.Count()} записей?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Service x = selectedService[0];
                    AdvAgEntities.GetContext().Services.Remove(x);
                    AdvAgEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Service> services = AdvAgEntities.GetContext().Services.OrderBy(p => p.Name).ToList();
                    dataService.ItemsSource = null;
                    dataService.ItemsSource = services;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
