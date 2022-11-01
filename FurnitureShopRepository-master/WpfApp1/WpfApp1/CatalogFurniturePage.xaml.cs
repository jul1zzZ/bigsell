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
    /// Логика взаимодействия для CatalogFurniturePage.xaml
    /// </summary>
    public partial class CatalogFurniturePage : Page
    {
        public CatalogFurniturePage()
        {
            InitializeComponent();
            ListoxBoxFur.ItemsSource = FurnitureShopEntities.GetContext().Products.OrderBy(p => p.ProductName).ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TableFurniture());
        }
    }
}
