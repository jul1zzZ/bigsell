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
using WpfApp1.Entity;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для TableFurniture.xaml
    /// </summary>
    public partial class TableFurniture : Page
    {
        public TableFurniture()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GoodAddPage((Product)(sender as Button).DataContext));
        }

        private void DataFurniture_LoadingRow_1(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DataFurniture.ItemsSource = null;
                FurnitureShopEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<Product> products = FurnitureShopEntities.GetContext().Products.OrderBy(p => p.ProductName).ToList();
                DataFurniture.ItemsSource = products;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GoodAddPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedGoods = DataFurniture.SelectedItems.Cast<Product>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить { selectedGoods.Count()} записей?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Product x = selectedGoods[0];
                    FurnitureShopEntities.GetContext().Products.Remove(x);
                    FurnitureShopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Product> products = FurnitureShopEntities.GetContext().Products.OrderBy(p => p.ProductName).ToList();
                    DataFurniture.ItemsSource = null;
                    DataFurniture.ItemsSource = products;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
