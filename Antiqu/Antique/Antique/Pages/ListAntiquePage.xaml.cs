using Antique.Modules;
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

namespace Antique.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListAntiquePage.xaml
    /// </summary>
    public partial class ListAntiquePage : Page
    {
        public List<Antiqe> Antiqes { get; set; }
        public ListAntiquePage()
        {
            InitializeComponent();
            DataAntique.ItemsSource = null;
            Antiqes = AntiquesShopEntities.GetContext().Antiqes.ToList();
            DataContext = this;
            DataAntique.ItemsSource = Antiqes;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.InfoAntiquePage(null));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedAntique = DataAntique.SelectedItems.Cast<Antiqe>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedAntique.Count()} записей?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Antiqe x = selectedAntique[0];
                    AntiquesShopEntities.GetContext().Antiqes.Remove(x);
                    AntiquesShopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Antiqe> antiques = AntiquesShopEntities.GetContext().Antiqes.OrderBy(p => p.Author).ToList();
                    DataAntique.ItemsSource = null;
                    DataAntique.ItemsSource = antiques;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.InfoAntiquePage((Antiqe)(sender as Button).DataContext));
        }
    }
}
