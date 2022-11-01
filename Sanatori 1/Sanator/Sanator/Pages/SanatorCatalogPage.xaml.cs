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
    /// Логика взаимодействия для SanatorCatalogPage.xaml
    /// </summary>
    public partial class SanatorCatalogPage : Page
    {
        int pageNum = 1;
        public SanatorCatalogPage()
        {
            InitializeComponent();
            SanatorLb.ItemsSource = sanEntities.GetContext().healings.ToList();
            List<view> views = sanEntities.GetContext().views.ToList();
            views.Insert(0, new view
            {
                view_healing = "Все"
            });
            FiltCb.ItemsSource = views;
            FiltCb.DisplayMemberPath = "view_healing";
            FiltCb.SelectedIndex = 0;
            SortCb.SelectedIndex = 0;
        }


        private void Update()
        {
            List<healing> healings = sanEntities.GetContext().healings.OrderBy(p => p.healing_name).ToList();
            if (FiltCb.SelectedIndex > 0)
            {
                healings = healings.Where(p => p.id_view == (FiltCb.SelectedItem as view).id_view).ToList();
            }
            healings = healings.Where(p => p.healing_name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            if (SortCb.SelectedIndex >= 0)
            {
                if (SortCb.SelectedIndex == 0)
                {
                    healings = healings.OrderBy(p => p.price).ToList();
                }
                if (SortCb.SelectedIndex == 1)
                {
                    healings = healings.OrderByDescending(p => p.price).ToList();
                }
            }

            try
            {
                bool canParse = int.TryParse(PageCount.Text, out int currentPage);
                List<healing> pageHealing = new List<healing>();
                currentPage = currentPage <= 0 || currentPage > healings.Count || !canParse ? 1 : currentPage;
                int itemsPerPage = 4;
                int offset = ((currentPage - 1) * itemsPerPage + 1) - 1;
                for (int i = offset; i < itemsPerPage + offset; i++)
                {
                    if (i < healings.Count)
                    {
                        pageHealing.Add(healings[i]);
                    }
                }
                SanatorLb.ItemsSource = pageHealing;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                sanEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                SanatorLb.ItemsSource = sanEntities.GetContext().healings.OrderBy(p => p.healing_name).ToList();
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void FiltCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void PageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void prevPage_Click(object sender, RoutedEventArgs e)
        {
            List<healing> healings = sanEntities.GetContext().healings.OrderBy(p => p.healing_name).ToList();
            if (pageNum > 2)
            {
                pageNum -= 2;
                firstPage.Content = pageNum;
                secondPage.Content = pageNum + 1;
            }
        }

        private void firstPage_Click(object sender, RoutedEventArgs e)
        {
            PageCount.Text = pageNum.ToString();
            Update();
        }

        private void secondPage_Click(object sender, RoutedEventArgs e)
        {
            PageCount.Text = (pageNum + 1 ).ToString();
            Update();
        }

        private void nextPage_Click(object sender, RoutedEventArgs e)
        {
            List<healing> healings = sanEntities.GetContext().healings.OrderBy(p => p.healing_name).ToList();
            if (pageNum < healings.Count / 2)
            {
                pageNum += 2;
                firstPage.Content = pageNum;
                secondPage.Content = pageNum + 1;
            }
        }

        private void TOurBtn_Click(object sender, RoutedEventArgs e)
        {
            healing healing = (healing)(sender as Button).DataContext;
            NavigationService.Navigate(new Pages.TourSanatorPage(healing));
        }
    }
}
