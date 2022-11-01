using Microsoft.Win32;
using Storehouse.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    public partial class ProductInfoPage : Page
    {
        public Product Product { get; set; }

        public string _photoDirectory = $@"{Directory.GetCurrentDirectory()}\Images\";

        private string _photoPath;
        private string _photoName;
        public ProductInfoPage(Product product)
        {
            InitializeComponent();
            Product = product ?? new Product();
            ProvCb.ItemsSource = StoreHouseEntities.GetContext().Proviiders.ToList();
            TypeCb.ItemsSource = StoreHouseEntities.GetContext().ProductTypes.ToList();
            DataContext = Product;
        }

        private void LoadPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

            if (fileInfo.Length > 8 * 1024 * 1024 * 6)
            {
                MessageBox.Show("Размер фото не должен превышать 6 мб");
                return;
            }

            _photoName = Guid.NewGuid().ToString();
            _photoPath = fileInfo.FullName;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product.ProductTypeID = (TypeCb.SelectedItem as ProductType).ProductTypeID;
                Product.ProviiderID = (ProvCb.SelectedItem as Proviider).ProviiderID;
                if (_photoPath != null)
                {
                    Product.Photo = _photoName;
                    File.Copy(_photoPath, _photoDirectory + _photoName);
                }
                if (Product.ProductID == 0)
                {
                    StoreHouseEntities.GetContext().Products.Add(Product);
                }
                StoreHouseEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }
    }
}
