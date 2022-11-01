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
using TaxiSt.Modules;

namespace TaxiSt.Pages
{
    /// <summary>
    /// Логика взаимодействия для TaxiClientInfoPage.xaml
    /// </summary>
    public partial class TaxiClientInfoPage : Page
    {
        public Client Client { get; set; }  
        public TaxiClientInfoPage()
        {
            InitializeComponent();
            Client = new Client();
            DataContext = Client;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                if (Client.Client_id == 0)
                {
                    TaxiEntities.GetContext().Clients.Add(Client);
                }
                TaxiEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }
    }
}
