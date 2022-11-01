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


namespace stay.Pages
{
    /// <summary>
    /// Логика взаимодействия для GoodAddStay.xaml
    /// </summary>
    public partial class GoodAddStay : Page
    {
        public static specialization Specialization { get; set; }
        // путь к файлу
        public string _photoDirectory = $@"{Directory.GetCurrentDirectory()}\Images\";

        private string _photoPath;
        private string _photoName;

        public GoodAddStay(specialization specialization)
        {
            InitializeComponent();
            Specialization = specialization ?? new specialization();
            CmbNaprav.ItemsSource = stayEntities.GetContext().directions.ToList();
            CmbStaff.ItemsSource = stayEntities.GetContext().staffs.ToList();
            CmbMode.ItemsSource = stayEntities.GetContext().modes.ToList();
            DataContext = Specialization;
        }

        private void LoagImage_Click(object sender, RoutedEventArgs e)  /*загрузить*/
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


        private void BtnSave_Click(object sender, RoutedEventArgs e) /*сохранить*/
        {
            try
            {
                Specialization.id_directions = (CmbNaprav.SelectedItem as direction).id_directions;
                Specialization.id_staff = (CmbStaff.SelectedItem as staff).id_staff;
                Specialization.id_mode = (CmbMode.SelectedItem as mode).id_mode;
                if (_photoPath != null)
                {
                    Specialization.image = _photoName;
                    File.Copy(_photoPath, _photoDirectory + _photoName);
                }
                if (Specialization.id_specialization  == 0)
                {
                    stayEntities.GetContext().specializations.Add(Specialization);
                }
                stayEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e) /*назад*/
        {
            NavigationService.Navigate(new Pages.AddStayPage1());
        }
    }
}
