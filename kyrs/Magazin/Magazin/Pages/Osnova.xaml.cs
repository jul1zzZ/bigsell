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
    /// Логика взаимодействия для Osnova.xaml
    /// </summary>
    public partial class Osnova : Page
    {
        public Osnova()
        {
            InitializeComponent();
            libraryEEntities1 context = new libraryEEntities1();
            ListUslugi.ItemsSource = context.book.ToList();
        }

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

        private void ADM_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ADMPage());
        }
    }
}
