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
using Magazin.Modules;

namespace Magazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditZapiz.xaml
    /// </summary>
    public partial class EditZapiz : Page
    {
        private zapis _currentGood = new zapis();
        public zapis Zapis { get; set; }
        public EditZapiz(zapis zapis)
        {
            
            InitializeComponent();
            DataContext = _currentGood;

            userFCb.ItemsSource = libraryEEntities1.GetContext().user.ToList();
            bookCb.ItemsSource = libraryEEntities1.GetContext().book.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentGood.id_book = (bookCb.SelectedItem as book).id_book;
                _currentGood.id_user = (userFCb.SelectedItem as user).id_user;
                if (_currentGood.id_zapis == 0)
                {
                    libraryEEntities1.GetContext().zapis.Add(_currentGood);
                }
                libraryEEntities1.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Zapis());
        }

        private void TxtID4_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
