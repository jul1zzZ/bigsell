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
        public Zapis_klienta Zapis { get; set; }
        public EditZapiz(Zapis_klienta zapis)
        {
            
            InitializeComponent();
            Zapis = zapis ?? new Zapis_klienta();
            DataContext = Zapis;
            FamilCmb.ItemsSource = MagazEntities.GetContext().Klient.ToList();
            KlientCmb.ItemsSource = MagazEntities.GetContext().Klient.ToList();
            UslugiCmb.ItemsSource = MagazEntities.GetContext().Yslyga.ToList();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Zapis.Zapis_klienta_ID == 0)
                {
                    MagazEntities.GetContext().Zapis_klienta.Add(Zapis);
                }
                MagazEntities.GetContext().SaveChanges();
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
