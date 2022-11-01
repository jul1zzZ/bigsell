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
using Magazin.Modules;

namespace Magazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Zapis.xaml
    /// </summary>
    public partial class Zapis : Page
    {
        public List<zapis> Service { get; set; }
        public Zapis()
        {
            InitializeComponent();

            DataTour.ItemsSource = null;
            //загрузка обновленных данных
            Service = libraryEEntities1.GetContext().zapis.ToList();
            DataContext = Service;
            DataTour.ItemsSource = libraryEEntities1.GetContext().zapis.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ADMPage2());
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EditZapiz(null));
        }

        private void DELETE_Click(object sender, RoutedEventArgs e)
        {

            var selectedGoods = DataTour.SelectedItems.Cast<zapis>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedGoods.Count()} записей???",
            "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {

                    zapis x = selectedGoods[0];


                    libraryEEntities1.GetContext().zapis.Remove(x);

                    libraryEEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<zapis> tours = libraryEEntities1.GetContext().zapis.OrderBy(p => p.time_start).ToList();
                    DataTour.ItemsSource = null;
                    DataTour.ItemsSource = tours;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EditZapiz((zapis)(sender as Button).DataContext));
        }

        private void DataTour_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void DataTour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
