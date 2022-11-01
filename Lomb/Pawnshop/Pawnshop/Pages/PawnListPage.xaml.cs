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
using Pawnshop.Modules;
using Pawnshop.Pages;

namespace Pawnshop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PawnListPage.xaml
    /// </summary>
    public partial class PawnListPage : Page
    {
        public List<Change> Changes { get; set; }
        public PawnListPage()
        {
            InitializeComponent();
            DataPawn.ItemsSource = null;
            Changes = PawnShopEntities.GetContext().Changes.ToList();
            DataContext = this;
            DataPawn.ItemsSource = Changes;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EditPawnPage(null));

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedPawn = DataPawn.SelectedItems.Cast<Change>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedPawn.Count()} записей?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Change x = selectedPawn[0];
                    PawnShopEntities.GetContext().Changes.Remove(x);
                    PawnShopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Change> changes = PawnShopEntities.GetContext().Changes.OrderBy(p => p.Descr).ToList();
                    DataPawn.ItemsSource = null;
                    DataPawn.ItemsSource = changes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EditPawnPage((Change)(sender as Button).DataContext));
        }
    }
}
