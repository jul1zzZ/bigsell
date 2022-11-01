using GosU.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace GosU.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesInfoPage.xaml
    /// </summary>
    public partial class ServicesInfoPage : Page
    {
        public Service Service { get; set; }
        public ServicesInfoPage()
        {
            InitializeComponent();
            Service = new Service();
            DataContext = Service;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                if (Service.ServiceID == 0)
                {
                    SocialSupportEntities.GetContext().Services.Add(Service);
                }
                SocialSupportEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }
    }
}
