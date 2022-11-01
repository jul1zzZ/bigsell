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
    /// Логика взаимодействия для RidersCatalogPage.xaml
    /// </summary>
    public partial class RidersCatalogPage : Page
    {
        int pageNum = 1;
        public RidersCatalogPage()
        {
            InitializeComponent();
            RiderLb.ItemsSource = TaxiEntities.GetContext().Vodilas.ToList();
            List<Vodila> vodilas = TaxiEntities.GetContext().Vodilas.ToList();
            vodilas.Insert(0, new Vodila
            {
                Reiting = 0
            });
            FiltCb.ItemsSource = vodilas;
            FiltCb.DisplayMemberPath = "Reiting";
            FiltCb.SelectedIndex = 0;
            SortCb.SelectedIndex = 0;
        }

        private void Update()
        {
            List<Vodila> vodilas = TaxiEntities.GetContext().Vodilas.OrderBy(p => p.Name).ToList();
            if (FiltCb.SelectedIndex > 0)
            {
                vodilas = vodilas.Where(p => p.Voditel_id == (FiltCb.SelectedItem as Vodila).Voditel_id).ToList();
            }
            vodilas = vodilas.Where(p => p.Name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            if (SortCb.SelectedIndex >= 0)
            {
                if (SortCb.SelectedIndex == 0)
                {
                    vodilas = vodilas.OrderBy(p => p.Count).ToList();
                }
                if (SortCb.SelectedIndex == 1)
                {
                    vodilas = vodilas.OrderByDescending(p => p.Count).ToList();
                }
            }

            try
            {
                bool canParse = int.TryParse(PageCount.Text, out int currentPage);
                List<Vodila> pageVodila = new List<Vodila>();
                currentPage = currentPage <= 0 || currentPage > vodilas.Count || !canParse ? 1 : currentPage;
                int itemsPerPage = 5;
                int offset = ((currentPage - 1) * itemsPerPage + 1) - 1;
                for (int i = offset; i < itemsPerPage + offset; i++)
                {
                    if (i < vodilas.Count)
                    {
                        pageVodila.Add(vodilas[i]);
                    }
                }
                RiderLb.ItemsSource = pageVodila;
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
                TaxiEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                RiderLb.ItemsSource = TaxiEntities.GetContext().Vodilas.OrderBy(p => p.Name).ToList();
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
            List<Vodila> vodilas = TaxiEntities.GetContext().Vodilas.OrderBy(p => p.Name).ToList();
            if (pageNum > 4)
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
            List<Vodila> vodilas = TaxiEntities.GetContext().Vodilas.OrderBy(p => p.Name).ToList();
            if (pageNum < vodilas.Count / 5)
            {
                pageNum += 2;
                firstPage.Content = pageNum;
                secondPage.Content = pageNum + 1;
            }
        }
    }
}
