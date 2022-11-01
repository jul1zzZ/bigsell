using Addvesting.Modules;
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

namespace Addvesting.Pages
{
    public partial class AddvOrderInfo : Page
    {
        public Perfomance Perfomance { get; set; }
        public AddvOrderInfo()
        {
            InitializeComponent();
            Perfomance = new Perfomance();
            ClientCb.ItemsSource = AdvAgEntities.GetContext().Clients.ToList();
            EmployeeCb.ItemsSource = AdvAgEntities.GetContext().Employees.ToList();
            ServiceCb.ItemsSource = AdvAgEntities.GetContext().Services.ToList();
            DataContext = Perfomance;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Perfomance.ClientID = (ClientCb.SelectedItem as Client).ClientID;
                Perfomance.EmployeeID = (EmployeeCb.SelectedItem as Employee).EmoloyeeID;
                Perfomance.ServiceID = (ServiceCb.SelectedItem as Service).ServiceID;
                if (Perfomance.PerfomanceID == 0)
                {
                    AdvAgEntities.GetContext().Perfomances.Add(Perfomance);
                }
                AdvAgEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }
    }
}
