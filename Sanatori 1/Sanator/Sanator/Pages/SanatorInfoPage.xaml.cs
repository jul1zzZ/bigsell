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
using Microsoft.Win32;
using Sanator.Module;
using Sanator.Pages;

namespace Sanator.Pages
{
    
    public partial class SanatorInfoPage : Page
    {
        public healing Healing { get; set; }
        public string _photoDirectory = $@"{Directory.GetCurrentDirectory()}\Images\";

        private string _photoPath;
        private string _photoName;
        public SanatorInfoPage( healing healing)
        {
            InitializeComponent();
            Healing = healing ?? new healing();
            HealCb.ItemsSource = sanEntities.GetContext().views.ToList();
            StaffCb.ItemsSource = sanEntities.GetContext().staffs.ToList();
            DataContext = Healing;
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
                Healing.id_view = (HealCb.SelectedItem as view).id_view;
                Healing.id_staff = (StaffCb.SelectedItem as staff).id_staff;
                if (_photoPath != null)
                {
                    Healing.photo = _photoName;
                    File.Copy(_photoPath, _photoDirectory + _photoName);
                }
                if (Healing.id_healing == 0)
                {
                    sanEntities.GetContext().healings.Add(Healing);
                }
                sanEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }
    }
}
