using Sanator.Module;
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

namespace Sanator.Pages
{
    /// <summary>
    /// Логика взаимодействия для SanatorListPage.xaml
    /// </summary>
    public partial class SanatorListPage : Page
    {
        public List<healing> Healings { get; set; }
        public SanatorListPage()
        {
            InitializeComponent();
            DataHeal.ItemsSource = null;
            Healings = sanEntities.GetContext().healings.ToList();
            DataContext = this;
            DataHeal.ItemsSource = Healings;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.SanatorInfoPage((healing)(sender as Button).DataContext));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.SanatorInfoPage(null));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedHeal = DataHeal.SelectedItems.Cast<healing>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedHeal.Count()} записей??", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    healing x = selectedHeal[0];
                    sanEntities.GetContext().healings.Remove(x);
                    sanEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<healing> healings = sanEntities.GetContext().healings.OrderBy(p => p.healing_name).ToList();
                    DataHeal.ItemsSource = null;
                    DataHeal.ItemsSource = healings;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
