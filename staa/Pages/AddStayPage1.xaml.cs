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

namespace stay.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddStayPage1.xaml
    /// </summary>
    public partial class AddStayPage1 : Page
    {
        public AddStayPage1()
        {
            InitializeComponent();
            List<specialization> specializations = stayEntities.GetContext().specializations.OrderBy(p =>p.name_specialization).ToList();
            DataStay.ItemsSource = specializations;
        }

        private void DataStay_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //событие отображения данного Page
            // обновляем данные каждый раз когда активируется этот Page
            if (Visibility == Visibility.Visible)
            {
                DataStay.ItemsSource = null;
                //загрузка обновленных данных
                stayEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<specialization> specializations = stayEntities.GetContext().specializations.OrderBy(p => p.name_specialization).ToList();
                DataStay.ItemsSource = specializations;
            }
        }

        

        private void BtnNaz_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.CatalogStay());
        }

        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GoodAddStay((sender as Button).DataContext as specialization));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedspecialization = DataStay.SelectedItems.Cast<specialization>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedspecialization.Count()} записей?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    specialization x = selectedspecialization[0];
                    stayEntities.GetContext().specializations.Remove(x);
                    stayEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<specialization> specializations = stayEntities.GetContext().specializations.OrderBy(p => p.name_specialization).ToList();
                    DataStay.ItemsSource = null;
                    DataStay.ItemsSource = specializations;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void BtnDob_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.GoodAddStay(null));
        }
    }
}
