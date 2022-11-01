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
            var currentUslugi = MagazEntities.GetContext().Yslyga.OrderBy(p => p.Naimenovanie).ToList();
            if (CmbSale.SelectedIndex >= 0)
            {
                int a = 0;
                int b = 0;
                switch (CmbSale.SelectedIndex)
                {
                    case 1:
                        a = 0;
                        b = 5;
                        break;
                    case 2:
                        a = 5;
                        b = 15;
                        break;
                    case 3:
                        a = 15;
                        b = 30;
                        break;
                    case 4:
                        a = 30;
                        b = 70;
                        break;
                    case 5:
                        a = 70;
                        b = 100;
                        break;
                }
                currentUslugi = currentUslugi.Where(p => p.Skidka >= a && p.Skidka < b).ToList();
            }
            currentUslugi = currentUslugi.Where(p => p.Naimenovanie.ToLower().Contains(TBNAZ.Text.ToLower())).ToList();

            if (CmbCost.SelectedIndex >= 0)
            {
                if (CmbCost.SelectedIndex == 0)
                {
                    currentUslugi = currentUslugi.OrderBy(p => p.Stoimost).ToList();
                }
                if (CmbCost.SelectedIndex == 1)
                {
                    currentUslugi = currentUslugi.OrderByDescending(p => p.Stoimost).ToList();
                }
            }
            ListUslugi.ItemsSource = currentUslugi;
        }

        public ADMPage2()
        {
            InitializeComponent();
            MagazEntities context = new MagazEntities();
            ListUslugi.ItemsSource = context.Yslyga.ToList();
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
            NavigationService.Navigate(new Pages.EditPage((sender as Button).DataContext as Yslyga));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selecteduslug = ListUslugi.SelectedItems.Cast<Yslyga>().ToList();

            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selecteduslug.Count()} записей???",
            "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Yslyga x = selecteduslug[0];

                    MagazEntities.GetContext().Yslyga.Remove(x);

                    MagazEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Yslyga> tours = MagazEntities.GetContext().Yslyga.OrderBy(p => p.Naimenovanie).ToList();
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
                MagazEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListUslugi.ItemsSource = MagazEntities.GetContext().Yslyga.OrderBy(p => p.Naimenovanie).ToList();
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
