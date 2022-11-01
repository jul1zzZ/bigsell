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
    /// Логика взаимодействия для EditPage2.xaml
    /// </summary>
    public partial class EditPage2 : Page
    {

        private Zapis_klienta _currentGood = new Zapis_klienta();

        public EditPage2()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Zapis());
        }
    }
}
