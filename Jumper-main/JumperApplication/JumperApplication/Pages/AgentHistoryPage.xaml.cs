using JumperApplication.Entities;
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

namespace JumperApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для AgentHistoryPage.xaml
    /// </summary>
    public partial class AgentHistoryPage : Page
    {
        List<Order> Orders { get; set; }
        public AgentHistoryPage(Agent agent)
        {
            InitializeComponent();
            OrdersDg.ItemsSource = JumperEntities.GetContext().Orders.Where(o => o.AgentId == agent.AgentId).OrderBy(o => o.OrderDate).ToList();
        }
    }
}
