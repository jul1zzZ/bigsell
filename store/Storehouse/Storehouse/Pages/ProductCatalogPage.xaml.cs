using Storehouse.Modules;
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

namespace Storehouse.Pages
{
    public partial class ProductCatalogPage : Page
    {
        int pageNum = 1;
        public ProductCatalogPage()
        {
            InitializeComponent();
            ProductLb.ItemsSource = StoreHouseEntities.GetContext().Products.ToList();

            List<ProductType> productTypes = StoreHouseEntities.GetContext().ProductTypes.ToList();
            productTypes.Insert(0, new ProductType
            {
                Name = "Все"
            });
            FiltCb.ItemsSource =  productTypes;
            FiltCb.DisplayMemberPath = "Name";
            FiltCb.SelectedIndex = 0;
            SortCb.SelectedIndex = 0;
        }

        private void Update()
        {
            List<Product> products = StoreHouseEntities.GetContext().Products.OrderBy(p => p.Name).ToList();
            if (FiltCb.SelectedIndex > 0)
            {
                products = products.Where(p => p.ProductTypeID == (FiltCb.SelectedItem as ProductType).ProductTypeID).ToList();
            }
            products = products.Where(p => p.Name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            if (SortCb.SelectedIndex >= 0)
            {
                if (SortCb.SelectedIndex == 0)
                {
                    products = products.OrderBy(p => p.AmountOnWH).ToList();
                }
                if (SortCb.SelectedIndex == 1)
                {
                    products = products.OrderByDescending(p => p.AmountOnWH).ToList();
                }
            }

            try
            {
                bool canParse = int.TryParse(PageCount.Text, out int currentPage);
                List<Product> pageProduct = new List<Product>();
                currentPage = currentPage <= 0 || currentPage > products.Count || !canParse ? 1 : currentPage;
                int itemsPerPage = 10;
                int offset = ((currentPage - 1) * itemsPerPage + 1) - 1;
                for (int i = offset; i < itemsPerPage + offset; i++)
                {
                    if (i < products.Count)
                    {
                        pageProduct.Add(products[i]);
                    }
                }
                ProductLb.ItemsSource = pageProduct;
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
                StoreHouseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ProductLb.ItemsSource = StoreHouseEntities.GetContext().Products.OrderBy(p => p.Name).ToList();
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
            List<Product> products = StoreHouseEntities.GetContext().Products.OrderBy(p => p.Name).ToList();
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
            List<Product> products = StoreHouseEntities.GetContext().Products.OrderBy(p => p.Name).ToList();
            if (pageNum < products.Count / 10)
            {
                pageNum += 2;
                firstPage.Content = pageNum;
                secondPage.Content = pageNum + 1;
            }
        }
    }
}
