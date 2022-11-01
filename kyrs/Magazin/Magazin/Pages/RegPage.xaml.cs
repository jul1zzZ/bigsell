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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        private user User { get; set; }
        public RegPage()
        {
            InitializeComponent();
            User = new user();
            DataContext = User;
        }

        private void REG_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (User.id_user == 0)   
                {
                    libraryEEntities1.GetContext().user.Add(User);
                }
                libraryEEntities1.GetContext().SaveChanges();
                NavigationService.Navigate(new Pages.ADMPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ADMPage());
        }
    }
}
