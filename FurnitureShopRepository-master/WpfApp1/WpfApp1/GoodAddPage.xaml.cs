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
using System.IO;
using Microsoft.Win32;
using WpfApp1.Entity;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для GoodAddPage.xaml
    /// </summary>
    public partial class GoodAddPage : Page
    {
        private Product _currentGood { get; set; }
        private string _filePath = null;
        private string _photoName = null;
        private static string _currentDirectory = Directory.GetCurrentDirectory() + @"\Images\";

        public GoodAddPage(Product selectedGoods)
        {
            InitializeComponent();
            _currentGood = selectedGoods ?? new Product();
            DataContext = _currentGood;
            _photoName = _currentGood.Photo; 
        }

        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentGood.ProductName)) s.AppendLine("Поле названия пустое");
            if (_currentGood.SellPrice < 0) s.AppendLine("Цена не может быть отрицательной");
            if (_currentGood.SellAmount < 0) s.AppendLine("Количество не может быть отрицательным");
            if (string.IsNullOrWhiteSpace(_photoName)) s.AppendLine("Фото не выбрано");
            return s;
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFields();
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }
            if (_currentGood.ProductID == 0)
            {
                string image = ChangePhotoName();
                string dest = _currentDirectory + image;
                File.Copy(_filePath, dest);
                _currentGood.Photo = image;
                FurnitureShopEntities.GetContext().Products.Add(_currentGood);
            }
            try
            {
                if (_filePath != null)
                {
                    string image = ChangePhotoName();
                    string dest = _currentDirectory + image;
                    File.Copy(_filePath, dest);
                    _currentGood.Photo = image;
                }
                FurnitureShopEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись изменена");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        string ChangePhotoName()
        {
            string x = _currentDirectory + _photoName;
            string photoname = _photoName;
            int i = 0;
            if (File.Exists(x))
            {
                while (File.Exists(x))
                {
                    i++;
                    x = _currentDirectory + i.ToString() + photoname;
                }
                photoname = i.ToString() + photoname;
            }
            return photoname;
        }

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
         try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
                if (op.ShowDialog() == true)
                {
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    if (fileInfo.Length > (2048 *2048 * 4))
                    {
                        throw new Exception("Размер файла должен быть меньше 4 Мб");
                    }
                    ImagePhoto.Source = new BitmapImage(new Uri(op.FileName));
                    _photoName = op.SafeFileName;
                    _filePath = op.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _filePath = null;
            }
        }
    }
}
