using GosU.Modules;
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
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public List<Service> Services { get; set; }
        public ServiceListPage()
        {
            InitializeComponent();
            DataService.ItemsSource = null;
            Services = SocialSupportEntities.GetContext().Services.ToList();
            DataContext = this;
            DataService.ItemsSource = Services;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ServicesInfoPage());
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedService = DataService.SelectedItems.Cast<Service>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedService.Count()} записей?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Service x = selectedService[0];
                    SocialSupportEntities.GetContext().Services.Remove(x);
                    SocialSupportEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Service> services = SocialSupportEntities.GetContext().Services.OrderBy(p => p.Name).ToList();
                    DataService.ItemsSource = null;
                    DataService.ItemsSource = services;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
