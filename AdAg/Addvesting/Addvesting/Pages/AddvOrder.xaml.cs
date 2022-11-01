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
    public partial class AddvOrder : Page
    {
        public List<Perfomance> Perfomances { get; set; }
        public AddvOrder()
        {
            InitializeComponent();
            DataOrder.ItemsSource = null;
            Perfomances = AdvAgEntities.GetContext().Perfomances.ToList();
            DataContext = this;
            DataOrder.ItemsSource = Perfomances;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddvOrderInfo());
        }
    }
}
