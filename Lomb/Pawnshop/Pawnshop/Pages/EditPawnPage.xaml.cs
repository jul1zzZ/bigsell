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
using Microsoft.Win32;
using Pawnshop.Modules;

namespace Pawnshop.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditPawnPage.xaml
    /// </summary>
    public partial class EditPawnPage : Page
    {
        public Change Change { get; set; }
        public string _photoDirectory = $@"{Directory.GetCurrentDirectory()}\Images\";

        private string _photoPath;
        private string _photoName;
        public EditPawnPage(Change change)
        {
            InitializeComponent();
            Change = change ?? new Change();
            catCb.ItemsSource = PawnShopEntities.GetContext().ChangeCategories.ToList();
            ClientCb.ItemsSource = PawnShopEntities.GetContext().Clients.ToList();
            DataContext = Change;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Change.ChangeCategoryID = (catCb.SelectedItem as ChangeCategory).ChangeCategoryID;
                Change.ClientID = (ClientCb.SelectedItem as Client).ClientID;
                if (_photoPath != null)
                {
                    Change.Photo = _photoName;
                    File.Copy(_photoPath, _photoDirectory + _photoName);
                }
                if (Change.ChangeID == 0)
                {
                    PawnShopEntities.GetContext().Changes.Add(Change);
                }
                PawnShopEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
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
    }
}
