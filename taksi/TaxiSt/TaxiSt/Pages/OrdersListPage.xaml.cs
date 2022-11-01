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
    /// Логика взаимодействия для OrdersListPage.xaml
    /// </summary>
    public partial class OrdersListPage : Page
    {
        public List<Taxi> Taxis { get; set; }
        public OrdersListPage()
        {
            InitializeComponent();
            dataOrder.ItemsSource = null;
            Taxis = TaxiEntities.GetContext().Taxis.ToList();
            DataContext = this;
            dataOrder.ItemsSource = Taxis;
        }
    }
}
