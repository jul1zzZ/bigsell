using Magazin.Modules;
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

namespace Magazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для ADMPage2.xaml
    /// </summary>
    public partial class ADMPage2 : Page
    {

        private void UpdateData()
        {
            var currentUslugi = libraryEEntities1.GetContext().book.OrderBy(p => p.book_name).ToList();
            
            currentUslugi = currentUslugi.Where(p => p.book_name.ToLower().Contains(TBNAZ.Text.ToLower())).ToList();

            if (CmbCost.SelectedIndex >= 0)
            {
                if (CmbCost.SelectedIndex == 0)
                {
                    currentUslugi = currentUslugi.OrderBy(p => p.year).ToList();
                }
                if (CmbCost.SelectedIndex == 1)
                {
                    currentUslugi = currentUslugi.OrderByDescending(p => p.year).ToList();
                }
            }
            ListUslugi.ItemsSource = currentUslugi;
        }

        public ADMPage2()
        {
            InitializeComponent();
            libraryEEntities1 context = new libraryEEntities1();
            ListUslugi.ItemsSource = context.book.ToList();
        }

        private void CmbCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void CmbSale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void ListUslugi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EditPage((sender as Button).DataContext as book));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selecteduslug = ListUslugi.SelectedItems.Cast<book>().ToList();

            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selecteduslug.Count()} записей???",
            "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    book x = selecteduslug[0];

                    libraryEEntities1.GetContext().book.Remove(x);

                    libraryEEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<book> tours = libraryEEntities1.GetContext().book.OrderBy(p => p.book_name).ToList();
                    ListUslugi.ItemsSource = null;
                    ListUslugi.ItemsSource = tours;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void TBNAZ_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                libraryEEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListUslugi.ItemsSource = libraryEEntities1.GetContext().book.OrderBy(p => p.book_name).ToList();
            }
        }

        private void ZAP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Zapis());
        }

        private void Dobav_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EditPage(null));
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Osnova());
        }
    }
}
