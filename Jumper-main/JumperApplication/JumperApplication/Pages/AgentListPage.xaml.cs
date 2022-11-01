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
    /// Логика взаимодействия для AgentListPage.xaml
    /// </summary>
    public partial class AgentListPage : Page
    {
        public List<Agent> Agents { get; set; }
        public AgentListPage()
        {
            InitializeComponent();
            Agents = JumperEntities.GetContext().Agents.ToList();
            DataContext = this;
            
        }

        private void AddAgent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AgentInfoPage(null));
        }

        private void AgentInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AgentInfoPage((Agent) (sender as Button).DataContext));
        }

        private void AgentHistoryBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
