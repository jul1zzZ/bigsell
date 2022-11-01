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
    /// Логика взаимодействия для VodilaListPage.xaml
    /// </summary>
    public partial class VodilaListPage : Page
    {
        public List<Vodila> Vodilas { get; set; }
        public VodilaListPage()
        {
            InitializeComponent();
            DataVodila.ItemsSource = null;
            Vodilas = TaxiEntities.GetContext().Vodilas.ToList();
            DataContext = this;
            DataVodila.ItemsSource = Vodilas;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.VodilaInfoPage());
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedVodila = DataVodila.SelectedItems.Cast<Vodila>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedVodila.Count()} записей?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Vodila x = selectedVodila[0];
                    TaxiEntities.GetContext().Vodilas.Remove(x);
                    TaxiEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Vodila> vodilas = TaxiEntities.GetContext().Vodilas.OrderBy(p => p.Name).ToList();
                    DataVodila.ItemsSource = null;
                    DataVodila.ItemsSource = vodilas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
