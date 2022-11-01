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
    /// Логика взаимодействия для CatalogAntiquePage.xaml
    /// </summary>
    public partial class CatalogAntiquePage : Page
    {
        int pageNum = 1;
        public CatalogAntiquePage()
        {
            InitializeComponent();
            AntiqueLb.ItemsSource = AntiquesShopEntities.GetContext().Antiqes.ToList();

            List<Antiqe> antiqes = AntiquesShopEntities.GetContext().Antiqes.ToList();
            antiqes.Insert(0, new Antiqe
            {
                ProdCount = "Все"
            });
            FiltCb.ItemsSource = antiqes;
            FiltCb.DisplayMemberPath = "ProdCount";
            FiltCb.SelectedIndex = 0;
            SortCb.SelectedIndex = 0;
        }

        private void FiltCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Update()
        {
            List<Antiqe> antiqes = AntiquesShopEntities.GetContext().Antiqes.OrderBy(p => p.Author).ToList();
            if (FiltCb.SelectedIndex > 0)
            {
                antiqes = antiqes.Where(p => p.ProdCount == (FiltCb.SelectedItem as Antiqe).ProdCount).ToList();
            }
            antiqes = antiqes.Where(p => p.Author.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            if (SortCb.SelectedIndex >= 0)
            {
                if (SortCb.SelectedIndex == 0)
                {
                    antiqes = antiqes.OrderBy(p => p.Price).ToList();
                }
                if (SortCb.SelectedIndex == 1)
                {
                    antiqes = antiqes.OrderByDescending(p => p.Price).ToList();
                }
            }

            try
            {
                bool canParse = int.TryParse(PageCount.Text, out int currentPage);
                List<Antiqe> pageAntiqe = new List<Antiqe>();
                currentPage = currentPage <= 0 || currentPage > antiqes.Count || !canParse ? 1 : currentPage;
                int itemsPerPage = 5;
                int offset = ((currentPage - 1) * itemsPerPage + 1) - 1;
                for (int i = offset; i < itemsPerPage + offset; i++)
                {
                    if (i < antiqes.Count)
                    {
                        pageAntiqe.Add(antiqes[i]);
                    }
                }
                AntiqueLb.ItemsSource = pageAntiqe;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            List<Antiqe> antiqes = AntiquesShopEntities.GetContext().Antiqes.OrderBy(p => p.Author).ToList();
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
            List<Antiqe> antiqes = AntiquesShopEntities.GetContext().Antiqes.OrderBy(p => p.Author).ToList();
            if (pageNum < antiqes.Count / 5)
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
                AntiquesShopEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                AntiqueLb.ItemsSource = AntiquesShopEntities.GetContext().Antiqes.OrderBy(p => p.Author).ToList();
            }
        }
    }
}
