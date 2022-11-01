using JumperApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class AgentCatalogPage : Page
    {
        int pageNum = 1;
        public AgentCatalogPage()
        {
            InitializeComponent();
            AgentLb.ItemsSource = JumperEntities.GetContext().Agents.ToList();


            List<AgentType> agentTypes = JumperEntities.GetContext().AgentTypes.ToList();
            agentTypes.Insert(0, new AgentType
            {
                Name = "Все"
            });
            AgentFilterCb.ItemsSource = agentTypes;
            AgentFilterCb.DisplayMemberPath = "Name";
            AgentFilterCb.SelectedIndex = 0;

            AgentSortCb.SelectedIndex = 0;
        }

        private void Update()
        {
            List<Agent> agents = JumperEntities.GetContext().Agents
                .OrderBy(p => p.Name)
                .ToList();

            if (SearchTb.Text.Trim() != "")
            {
                agents = agents
                    .Where(p => p.Name.Trim().ToLower().Contains(SearchTb.Text.Trim().ToLower()) ||
                     p.Email.Trim().ToLower().Contains(SearchTb.Text.Trim().ToLower()) ||
                     p.Phone.Trim().ToLower().Contains(SearchTb.Text.Trim().ToLower())
                    ).ToList();
            }

            if (AgentFilterCb.SelectedIndex > 0)
            {
                agents = agents.Where(p => p.AgentTypeId == (AgentFilterCb.SelectedItem as AgentType).AgentTypeId).ToList();
            }

            if (AgentSortCb.SelectedIndex > 0)
            {
                switch (AgentSortCb.SelectedIndex)
                {
                    case 1:
                        agents = agents.OrderBy(p => p.OrderAmount).ToList();
                        break;
                    case 2:
                        agents = agents.OrderByDescending(p => p.OrderAmount).ToList();
                        break;
                }
            }

            try
            {
                bool canParse = int.TryParse(PageCount.Text, out int currentPage);
                List<Agent> pageAgents = new List<Agent>();

                currentPage = currentPage <= 0 || currentPage > agents.Count || !canParse ? 1: currentPage;

                int itemsPerPage = 6;
                int offset = ((currentPage - 1) * itemsPerPage + 1) - 1;
                for (int i = offset; i < itemsPerPage + offset; i++)
                {
                    if (i < agents.Count)
                    {
                        pageAgents.Add(agents[i]);
                    }
                }
                AgentLb.ItemsSource = pageAgents;
                AgentLb.ItemsSource = pageAgents;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void AgentFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void AgentSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void PageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void firstBtn_Click(object sender, RoutedEventArgs e)
        {
            PageCount.Text = pageNum.ToString();
            Update();
        }

        private void secondBtn_Click(object sender, RoutedEventArgs e)
        {
            PageCount.Text = (pageNum+1).ToString();
            Update();
        }

        private void fourthBtn_Click(object sender, RoutedEventArgs e)
        {
            PageCount.Text = (pageNum+2).ToString();
            Update();
        }

        private void fivethBtn_Click(object sender, RoutedEventArgs e)
        {
            PageCount.Text = (pageNum+3).ToString();
            Update();
        }

        private void nextPages_Click(object sender, RoutedEventArgs e)
        {
            List<Agent> agents = JumperEntities.GetContext().Agents
               .OrderBy(p => p.Name)
               .ToList();
            if (pageNum < agents.Count/6)
            {
                pageNum += 4;
                firstBtn.Content = pageNum;
                secondBtn.Content = pageNum+1;
                fourthBtn.Content = pageNum+2;
                fivethBtn.Content = pageNum+3;
            }
        }

        private void prevPages_Click(object sender, RoutedEventArgs e)
        {
            List<Agent> agents = JumperEntities.GetContext().Agents
               .OrderBy(p => p.Name)
               .ToList();
            if (pageNum > 4)
            {
                pageNum -= 4;
                firstBtn.Content = pageNum;
                secondBtn.Content = pageNum + 1;
                fourthBtn.Content = pageNum + 2;
                fivethBtn.Content = pageNum + 3;
            }
        }

        private void AgentBtn_Click(object sender, RoutedEventArgs e)
        {
            Agent agent = (Agent)(sender as Button).DataContext;
            NavigationService.Navigate(new AgentInfoPage(agent));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AgentLb.ItemsSource = JumperEntities.GetContext().Agents.ToList();


            List<AgentType> agentTypes = JumperEntities.GetContext().AgentTypes.ToList();
            agentTypes.Insert(0, new AgentType
            {
                Name = "Все"
            });
            AgentFilterCb.ItemsSource = agentTypes;
            AgentFilterCb.DisplayMemberPath = "Name";
            AgentFilterCb.SelectedIndex = 0;

            AgentSortCb.SelectedIndex = 0;
        }

        private void AgentOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            Agent agent = (Agent)(sender as Button).DataContext;
            NavigationService.Navigate(new AgentHistoryPage(agent));
        }
    }
}