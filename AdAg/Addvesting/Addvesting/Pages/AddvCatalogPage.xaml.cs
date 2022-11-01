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
using Addvesting.Modules;
using Addvesting.Pages;

namespace Addvesting.Pages
{
    public partial class AddvCatalogPage : Page
    {
        int pageNum = 1;
        public AddvCatalogPage()
        {
            InitializeComponent();
            AddvLb.ItemsSource = AdvAgEntities.GetContext().Services.ToList();
            List<Service> services = AdvAgEntities.GetContext().Services.ToList();
            services.Insert(0, new Service
            {
                Name = "Все"
            });
            FiltCb.ItemsSource = services;
            FiltCb.DisplayMemberPath = "Name";
            FiltCb.SelectedIndex = 0;
            SortCb.SelectedIndex = 0;
            
        }

        private void Update()
        {
            List<Service> services = AdvAgEntities.GetContext().Services.OrderBy(p => p.Name).ToList();
            if (FiltCb.SelectedIndex > 0)
            {
                services = services.Where(p => p.ServiceID == (FiltCb.SelectedItem as Service).ServiceID).ToList();
            }
            services = services.Where(p => p.Name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            if (SortCb.SelectedIndex >= 0)
            {
                if (SortCb.SelectedIndex == 0)
                {
                    services = services.OrderBy(p => p.Price).ToList();
                }
                if (SortCb.SelectedIndex == 1)
                {
                    services = services.OrderByDescending(p => p.Price).ToList();
                    
                }
            }

            try
            {
                bool canParse = int.TryParse(PageCount.Text, out int currentPage);
                List<Service> pageService = new List<Service>();
                currentPage = currentPage <= 0 || currentPage > services.Count || !canParse ? 1 : currentPage;
                int itemsPerPage = 3;
                int offset = ((currentPage - 1) * itemsPerPage + 1) - 1;
                for (int i = offset; i < itemsPerPage + offset; i++)
                {
                    if (i < services.Count)
                    {
                        pageService.Add(services[i]);
                    }
                }
                AddvLb.ItemsSource = pageService;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            List<Service> services = AdvAgEntities.GetContext().Services.OrderBy(p => p.Name).ToList();
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
            List<Service> services = AdvAgEntities.GetContext().Services.OrderBy(p => p.Name).ToList();
            if (pageNum < services.Count / 3)
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
                AdvAgEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                AddvLb.ItemsSource = AdvAgEntities.GetContext().Services.OrderBy(p => p.Name).ToList();
            }
        }
    }
}
