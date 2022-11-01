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
    public partial class ProductListPage : Page
    {
        public List<Product> Products { get; set; }
        public ProductListPage()
        {
            InitializeComponent();
            DataProduct.ItemsSource = null;
            Products = StoreHouseEntities.GetContext().Products.ToList();
            DataContext = this;
            DataProduct.ItemsSource = Products;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ProductInfoPage((Product)(sender as Button).DataContext));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ProductInfoPage(null));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = DataProduct.SelectedItems.Cast<Product>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedProduct.Count()} записей?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Product x = selectedProduct[0];
                    StoreHouseEntities.GetContext().Products.Remove(x);
                    StoreHouseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Product> products = StoreHouseEntities.GetContext().Products.OrderBy(p => p.Name).ToList();
                    DataProduct.ItemsSource = null;
                    DataProduct.ItemsSource = products;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
