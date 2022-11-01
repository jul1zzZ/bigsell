using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using Magazin.Modules;

namespace Magazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {

        private Yslyga _currentGood = new Yslyga();

        private string _filePath = null;

        private string _photoName = null;

        private static string _currentDirectory = Directory.GetCurrentDirectory() + @"\image\";

        public EditPage(Yslyga selectedGood)
        {
            InitializeComponent();
            if (selectedGood != null)
            {
                _currentGood = selectedGood;
                TextBoxId.Visibility = Visibility.Hidden;
                TextBlocID.Visibility = Visibility.Hidden;

                int x = selectedGood.Yslyga_ID;

                List<Yslyga> tours = new List<Yslyga>();

                _filePath = _currentDirectory + _currentGood.Photo;
            }
            DataContext = _currentGood;
            _photoName = _currentGood.Photo;
        }

        public EditPage()
        {
            InitializeComponent();
        }

        private void LoagImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

                if (op.ShowDialog() == true)
                {
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    if (fileInfo.Length > (1024 * 1024 * 2))
                    {
                        throw new Exception("Размер файла должен быть меньше 2Мб");
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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFileds();

            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }
            try
            {
                if (_currentGood.Yslyga_ID == 0)
                {

                    string photo = ChangePhotoName();

                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentGood.Photo = photo;
                    MagazEntities.GetContext().Yslyga.Add(_currentGood);
                }

                if (_filePath != null)
                {
                    string photo = ChangePhotoName();
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentGood.Photo = photo;
                }
                MagazEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись изменена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private StringBuilder CheckFileds()
        {
            StringBuilder s = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentGood.Naimenovanie))
                s.AppendLine("Поле название пустое");
            if (_currentGood.Stoimost < 0)
                s.AppendLine("цена не может быть отрицательной");
            if (_currentGood.Prodolgit < 1)
                s.AppendLine("Нет продолжительности");
            if (string.IsNullOrWhiteSpace(_photoName))
                s.AppendLine("фото не выбрано");
            return s;
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ADMPage2());
        }
    }
}
