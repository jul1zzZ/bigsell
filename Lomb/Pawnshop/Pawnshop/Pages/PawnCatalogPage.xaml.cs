using Pawnshop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Pawnshop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PawnCatalogPage.xaml
    /// </summary>
    public partial class PawnCatalogPage : Page
    {
        int pageNum = 1;
        public PawnCatalogPage()
        {
            InitializeComponent();
            PawnLb.ItemsSource = PawnShopEntities.GetContext().Changes.ToList();
            List<ChangeCategory> changeCategories = PawnShopEntities.GetContext().ChangeCategories.ToList();
            changeCategories.Insert(0, new ChangeCategory
            {
                Name = "Все"
            });
            FiltCb.ItemsSource = changeCategories;
            FiltCb.DisplayMemberPath = "Name";
            FiltCb.SelectedIndex = 0;
            SortCb.SelectedIndex = 0;
        }

        private void Update()
        {
            List<Change> changes = PawnShopEntities.GetContext().Changes.OrderBy(p => p.Descr).ToList();
            if (FiltCb.SelectedIndex > 0)
            {
                changes = changes.Where(p => p.ChangeCategoryID == (FiltCb.SelectedItem as ChangeCategory).ChangeCategoryID).ToList();
            }
            changes = changes.Where(p => p.Descr.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            if (SortCb.SelectedIndex >= 0)
            {
                if (SortCb.SelectedIndex == 0)
                {
                    changes = changes.OrderBy(p => p.MoneyHand).ToList();
                }
                if (SortCb.SelectedIndex == 1)
                {
                    changes = changes.OrderByDescending(p => p.MoneyHand).ToList();
                }
            }

            try
            {
                bool canParse = int.TryParse(PageCount.Text, out int currentPage);
                List<Change> pageChanges = new List<Change>();
                currentPage = currentPage <= 0 || currentPage > changes.Count || !canParse ? 1 : currentPage;
                int itemsPerPage = 5;
                int offset = ((currentPage - 1) * itemsPerPage + 1) - 1;
                for (int i = offset; i < itemsPerPage + offset; i++)
                {
                    if (i < changes.Count)
                    {
                        pageChanges.Add(changes[i]);
                    }
                }
                PawnLb.ItemsSource = pageChanges;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FiltCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void PageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void prevPage_Click(object sender, RoutedEventArgs e)
        {
            List<Change> changes = PawnShopEntities.GetContext().Changes.OrderBy(p => p.Descr).ToList();
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
            PageCount.Text = (pageNum + 1).ToString();
            Update();
        }

        private void nextPage_Click(object sender, RoutedEventArgs e)
        {
            List<Change> changes = PawnShopEntities.GetContext().Changes.OrderBy(p => p.Descr).ToList();
            if (pageNum < changes.Count / 5)
            {
                pageNum += 2;
                firstPage.Content = pageNum;
                secondPage.Content = pageNum + 1;
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PawnShopEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                PawnLb.ItemsSource = PawnShopEntities.GetContext().Changes.OrderBy(p => p.Descr).ToList();
            }
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
